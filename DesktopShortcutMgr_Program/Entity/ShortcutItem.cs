using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using DesktopShortcutMgr.Modules;
using IWshRuntimeLibrary;

namespace DesktopShortcutMgr.Entity
{
	[XmlRoot("Shortcuts")]
	public class ShortcutItem
    {
		[XmlElement("icon")]
		public string IconPath { get; set; }

		[XmlElement("text")]
		public string Text { get; set; }

		[XmlElement("application")]
		public string Application { get; set; }
        
		[XmlElement("id")]
		public string Id { get; set; }

		[XmlElement("runasAdmin")]
		public bool RunAsAdmin { get; set; }

		[XmlElement("args")]
		public string Arguments { get; set; }

		public string GroupName { get; set; }

		public ShortcutItem() { }

        public ShortcutItem(string strIconPath, string strText, string strApplication, string strId)
        {
            this.IconPath = strIconPath;
            this.Text = strText;
            this.Application = strApplication;
            this.Id = strId;
        }

        public ShortcutItem(string strIconPath, string strText, string strApplication, string strId, string strGroupName)
        {
            this.IconPath = strIconPath;
            this.Text = strText;
            this.Application = strApplication;
            this.Id = strId;
            this.GroupName = strGroupName;
        }

        public bool IsValid()
        {
            return ((IsFile() || IsDirectory()));
        }

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

            if (IsFile())
            {
                link.TargetPath = CommonUtil.GetApplicationPart(this.Application);
                string args = CommonUtil.GetArgumentPart(this.Application);
                if (!string.IsNullOrEmpty(args))
                {
                    link.Arguments = args;
                }
            }
            else
            {
                link.TargetPath = @"%windir%\explorer.exe";
                link.Arguments = "/e," + CommonUtil.GetApplicationPart(this.Application);
            }

            link.Save();
            link = null;
            shell = null;

        }

        public void CreateDesktopShortcut(string SaveToDirectory, bool DoNotCreateIfInvalidApp)
        {
            CreateDesktopShortcut(SaveToDirectory, string.Empty, DoNotCreateIfInvalidApp);
        }

        public bool IsFile()
        {
            return System.IO.File.Exists(CommonUtil.GetApplicationPart(this.Application));
        }

        public bool IsDirectory()
        {
            return System.IO.Directory.Exists(CommonUtil.GetApplicationPart(this.Application));
        }

		public override bool Equals(object obj)
		{
			var item = obj as ShortcutItem;
			return item != null &&
				   Text == item.Text &&
				   Application == item.Application &&
				   Arguments == item.Arguments;
		}

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
