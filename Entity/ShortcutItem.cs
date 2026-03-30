using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using DesktopShortcutMgr.Modules;
using IWshRuntimeLibrary;

namespace DesktopShortcutMgr.Entity
{
	/// <summary>
	/// Represents an individual shortcut item, including its display text, target application path, icon, and execution arguments.
	/// </summary>
	[XmlRoot("Shortcuts")]
	public class ShortcutItem
    {
		/// <summary>
		/// Gets or sets the path to the icon file for this shortcut.
		/// </summary>
		[XmlElement("icon")]
		public string IconPath { get; set; }

		/// <summary>
		/// Gets or sets the display text for the shortcut.
		/// </summary>
		[XmlElement("text")]
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets the full path to the target application or directory.
		/// </summary>
		[XmlElement("application")]
		public string Application { get; set; }
        
		/// <summary>
		/// Gets or sets a unique identifier for the shortcut item.
		/// </summary>
		[XmlElement("id")]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the application should be run with administrative privileges.
		/// </summary>
		[XmlElement("runasAdmin")]
		public bool RunAsAdmin { get; set; }

		/// <summary>
		/// Gets or sets the command-line arguments to pass to the target application.
		/// </summary>
		[XmlElement("args")]
		public string Arguments { get; set; }

		/// <summary>
		/// Gets or sets the name of the group this shortcut belongs to (not persisted to individual shortcut XML).
		/// </summary>
		public string GroupName { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ShortcutItem"/> class.
		/// </summary>
		public ShortcutItem() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ShortcutItem"/> class with basic properties.
		/// </summary>
        public ShortcutItem(string strIconPath, string strText, string strApplication, string strId)
        {
            this.IconPath = strIconPath;
            this.Text = strText;
            this.Application = strApplication;
            this.Id = strId;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ShortcutItem"/> class with group information.
		/// </summary>
        public ShortcutItem(string strIconPath, string strText, string strApplication, string strId, string strGroupName)
        {
            this.IconPath = strIconPath;
            this.Text = strText;
            this.Application = strApplication;
            this.Id = strId;
            this.GroupName = strGroupName;
        }

		/// <summary>
		/// Determines if the shortcut's target is a valid file or directory.
		/// </summary>
		/// <returns>True if valid.</returns>
        public bool IsValid()
        {
            return ((IsFile() || IsDirectory()));
        }

		/// <summary>
		/// Creates a physical Windows shortcut (.lnk file) on the filesystem.
		/// </summary>
		/// <param name="SaveToDirectory">The directory where the shortcut file will be created.</param>
		/// <param name="CustomName">A custom name for the shortcut file. If null or empty, <see cref="Text"/> is used.</param>
		/// <param name="DoNotCreateIfInvalidApp">If true, the shortcut will not be created if the target path is invalid.</param>
        public void CreateDesktopShortcut(string SaveToDirectory, string CustomName, bool DoNotCreateIfInvalidApp)
        {
            if (DoNotCreateIfInvalidApp)
            {
                if (!IsFile() && !IsDirectory())
                {
                    return;
                }
            }

            if (!System.IO.Directory.Exists(SaveToDirectory))
                System.IO.Directory.CreateDirectory(SaveToDirectory);

            string filename = "";
            if (string.IsNullOrEmpty(CustomName))
                filename = Text;
            else
                filename = CustomName;

            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                if (filename.Contains(c.ToString()))
                {
                    filename = filename.Replace(c.ToString(), " ");
                }
            }

            string shortcutName = filename + ".lnk";
            while (System.IO.File.Exists(System.IO.Path.Combine(SaveToDirectory, shortcutName)))
            {
                shortcutName = filename + "__" + DateTime.Now.Millisecond.ToString() + ".lnk";
            }

            string strFinalPath = System.IO.Path.Combine(SaveToDirectory, shortcutName);

            WshShellClass shell = new WshShellClass();
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(strFinalPath);


			if (!string.IsNullOrEmpty(this.IconPath))
			{
				//Find in the computer first. if it exists, use it
				string fullIconPath = (System.IO.File.Exists(this.IconPath) ? this.IconPath : AppConfig.GetIconMapFile(this.IconPath));
				if (System.IO.File.Exists(fullIconPath))
				{
					link.IconLocation = fullIconPath + ",0";
				}
			}
			
			link.TargetPath = this.Application;
			link.Arguments = this.Arguments;

			try
			{
				link.Save();
			}
			finally
			{
				link = null;
				shell = null;
			}
        }

		/// <summary>
		/// Creates a physical Windows shortcut (.lnk file) with default naming.
		/// </summary>
        public void CreateDesktopShortcut(string SaveToDirectory, bool DoNotCreateIfInvalidApp)
        {
            CreateDesktopShortcut(SaveToDirectory, string.Empty, DoNotCreateIfInvalidApp);
        }

		/// <summary>
		/// Checks if the target path points to an existing file.
		/// </summary>
		/// <returns>True if it's a file.</returns>
        public bool IsFile()
        {
            return System.IO.File.Exists(CommonUtil.GetApplicationPart(this.Application));
        }

		/// <summary>
		/// Checks if the target path points to an existing directory.
		/// </summary>
		/// <returns>True if it's a directory.</returns>
        public bool IsDirectory()
        {
            return System.IO.Directory.Exists(CommonUtil.GetApplicationPart(this.Application));
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current shortcut item based on text, application path, and arguments.
		/// </summary>
		public override bool Equals(object obj)
		{
			var item = obj as ShortcutItem;
			return item != null &&
				   Text == item.Text &&
				   Application == item.Application &&
				   Arguments == item.Arguments;
		}

		/// <summary>
		/// Serves as a hash function for the shortcut item.
		/// </summary>
		public override int GetHashCode()
		{
			var hashCode = -2710998;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Application);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Arguments);
			return hashCode;
		}
	}
}
