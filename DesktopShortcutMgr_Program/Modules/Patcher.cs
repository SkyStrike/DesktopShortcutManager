using DesktopShortcutMgr.Entity;
using DesktopShortcutMgr.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DesktopShortcutMgr.Modules
{
    /// <summary>
    /// <para>Created By    : YUKUANG</para>
    /// <para>Created Date  : 24 Oct 2009</para>
    /// --------------------------------------------------------------------------------------
    /// Changes In a Glance |
    /// ---------------------
    /// 
    /// --------------------------------------------------------------------------------------
    /// Version 1.2  | Released: 2011.08.05 |
    /// -------------------------------------
    ///     - Enhancement & Fixes
    ///         - Fixed the extracting of icon to create unique name instead of overriding existing icon. 
    ///           this will also cause duplicates...
    /// 
    /// --------------------------------------------------------------------------------------
    /// Version 1.1  | Released: 2011.08.03 |
    /// -------------------------------------
    ///     - Patcher Enhancement
    ///         - Adds interface to allow users to execute the commands from interface.
    ///         - Some of the patch are finally working...It was broken ever since the apps are 
    ///           splited to Program and Parameters
    /// 
    /// --------------------------------------------------------------------------------------
    /// Version 1.0  | Released: 2009.10.30 |
    /// -------------------------------------
    ///     - Patcher Enhancement
    ///         - Allows clean up of icons using the P:ClearUnusedIcons
    /// 
    /// 
    /// </summary>
    public class Patcher
    {
        private TextBox tbConsole = null;
        public PatcherForm parentForm;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Patcher() { }
		

        delegate void AppendStringCallBack(string s);
        private void WriteLine(string txt)
        {
            if (tbConsole != null)
            {
                if (tbConsole.InvokeRequired || tbConsole.InvokeRequired)
                {
                    AppendStringCallBack cb = new AppendStringCallBack(parentForm.AppendConsoleLine);
                    parentForm.Invoke(cb, new object[] { txt + Environment.NewLine });
                }
                else
                {
                    //Set the labels in the form
                    tbConsole.Text = txt + Environment.NewLine;
                }
            }
            Console.WriteLine(txt);
        }

        private void Write(string txt)
        {
            if (tbConsole != null)
            {
                if (tbConsole.InvokeRequired || tbConsole.InvokeRequired)
                {
                    AppendStringCallBack cb = new AppendStringCallBack(parentForm.AppendConsoleLine);
                    parentForm.Invoke(cb, new object[] { txt });
                }
                else
                {
                    //Set the labels in the form
                    tbConsole.Text = txt;
                }
            }
            Console.Write(txt);
        }

		public void ApplyPatch(Commands cmd)
		{
			switch (cmd)
			{
				case Commands.RebuildIcons:
					WriteLine("Rebuilding Icons");
					RebuildIcons();
					WriteLine("Icons Rebuilt");
					break;

				case Commands.ClearUnusedIcons:
					WriteLine("Clearing Unused Icons");
					DeletedUnusedIcons();
					WriteLine("Unused Icons Cleared");
					break;

				case Commands.FixApplicationPaths:
					Write("Patching Application Paths");
					FixApplicationPaths();
					Write("\tDone\n");
					break;

				case Commands.AssignShortcutIds:
					WriteLine("Patching Application Id");
					AssignShortcutIds();
					WriteLine("\tDone\n");
					break;

				case Commands.RemoveCustomIcons:
					Write("Removing Custom Icons");
					DeleteUnmappedIcons();
					Write("\tDone\n");
					break;

				case Commands.RemoveAllShortcuts:
					Write("Removing All Shortcuts");
					RemoveAllShortcuts();
					Write("\tDone\n");
					break;

				case Commands.RemoveInvalidEntries:
					WriteLine("Removing Invalid Entries. This may take some time.");
					RemoveInvalidEntries();
					WriteLine("\tDone\n");
					break;

				default:
					MessageBox.Show("Unknown Patch Command: " + cmd);
					break;
			}
		}

		/// <summary>
		/// <para>Created By    : YUKUANG</para>
		/// <para>Created Date  : 24 Oct 2009</para>
		/// <para>Modified By   : -</para>
		/// <para>Modified Date : -</para>
		/// <para>---------------------------------------------------------------</para>
		/// <para></para>
		/// <para>Changes</para>
		/// <para>---------------------------------------------------------------</para>
		/// <para></para>
		/// <para>Description</para>
		/// <para>---------------------------------------------------------------</para>
		/// The main functions deciphering the commands passed in
		/// </summary>
		/// <param name="cmd"></param>
		public void ApplyPatch(string cmd)
        {
            if (!Patcher.IsCommand(cmd)) return;

            Commands cmdType = Commands.ClearUnusedIcons;
			object o = System.Enum.Parse(typeof(Commands), cmd, true);

			if (o == null)
				return;

			cmdType = (Commands)o;
			ApplyPatch(cmdType);
        }

        public void ApplyPatch(string cmd, ref TextBox tbConsole)
        {
            this.tbConsole = tbConsole;
            ApplyPatch(cmd);
        }

        public enum Commands
        {
            RebuildIcons,
            ClearUnusedIcons,
            FixApplicationPaths,
            AssignShortcutIds,
            RemoveCustomIcons,
            RemoveAllShortcuts,
			RemoveInvalidEntries
        }

        public static bool IsCommand(string cmd)
        {
            try
            {
                System.Enum.Parse(typeof(Commands), cmd, true);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public static string[] GetCommands()
        {
            return System.Enum.GetNames(typeof(Commands));
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 15 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// For rebuilding of icons for older release of the Shortcut Manager. 
        /// It will extract icons and patch up the shortcut files
        /// </summary>
        private void RebuildIcons()
        {
            WriteLine("Getting Group Name Config");

			DeleteUnmappedIcons();

			List<string> groupNames = ShortcutUtil.GetShortcutGroupNames();
			foreach (string groupName in groupNames)
			{
				List<ShortcutItem> shortcuts = ShortcutUtil.GetShortcuts(groupName);
				foreach (ShortcutItem item in shortcuts)
				{
					string applicationPath = item.Application;
					if (applicationPath.EndsWith(".exe") && System.IO.File.Exists(applicationPath))
					{
						//Try to extract the icon file
						try
						{
							Write(string.Format("Extracting Icon: {0}", applicationPath));
							IconExtractor extractor = new IconExtractor(applicationPath);

							//Gets the first icon in the Executable
							System.Drawing.Icon ico = extractor.GetIcon(0);

							//create unique name
							string uniqueFilename = System.IO.Path.GetFileNameWithoutExtension(applicationPath);
							string iconPath = System.IO.Path.Combine(AppConfig.IconFolder, uniqueFilename + ".ico");
							string uniqueIconPath = MakeUniqueFilename(iconPath);

							bool isNonUnique = !uniqueIconPath.Equals(iconPath);

							//Save the Icon using a FileStream
							using (System.IO.FileStream fs = new System.IO.FileStream(uniqueIconPath, System.IO.FileMode.OpenOrCreate))
							{
								ico.Save(fs);
								fs.Close();
								fs.Dispose();
							}
							WriteLine("\tExtracted\n");




							if (isNonUnique)
							{
								//non-unique file path detected. check if it's same bytes
								WriteLine("Non unique icon found. Checking hashcode.");

								byte[] b1 = System.IO.File.ReadAllBytes(uniqueIconPath);
								byte[] b2 = System.IO.File.ReadAllBytes(iconPath);

								int s1 = System.Convert.ToBase64String(b1).GetHashCode();
								int s2 = System.Convert.ToBase64String(b2).GetHashCode();

								WriteLine(string.Format("  {0} vs {1}", s1, s2));
								if (s1 == s2) {
									WriteLine("Deleting duplicate.");
									System.IO.File.Delete(uniqueIconPath);
									uniqueIconPath = iconPath;
								}
							}

							//Patch the datarow
							item.IconPath = System.IO.Path.GetFileName(uniqueIconPath);
						}
						catch (Exception)
						{
							//display error
							MessageBox.Show(
								"Unable to extract icon for [" + groupName + "/" + item.Text + "]",
								"Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
				ShortcutUtil.UpdateGroupShortcut(groupName, shortcuts.ToArray());
			}
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 30 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Clean unused icons
        /// </summary>
        private void DeletedUnusedIcons()
        {
			List<string> usedIcons = new List<string>();
			usedIcons.Add("unknown.ico");

			List<IconMapItem> mappedIcons = IconMapperUtil.GetMappedIcons();

			foreach (IconMapItem item in mappedIcons)
			{
				usedIcons.Add(item.Icon);
			}
			

			List<string> groupNames = ShortcutUtil.GetShortcutGroupNames();
			foreach (string groupName in groupNames)
			{
				List<ShortcutItem> shortcuts = ShortcutUtil.GetShortcuts(groupName);
				foreach (ShortcutItem item in shortcuts)
				{
					if (!string.IsNullOrEmpty(item.IconPath))
					{
						if (!usedIcons.Contains(item.IconPath))
							usedIcons.Add(item.IconPath);
					}
				}
			}

			string[] iconsInFolder = System.IO.Directory.GetFiles(AppConfig.IconFolder, "*.ico");
			for (int i = iconsInFolder.Length-1; i > 0; i--)
			{
				string iconPath = iconsInFolder[i];
				string iconName = System.IO.Path.GetFileName(iconPath);
				if (!usedIcons.Contains(iconName))
				{
					WriteLine("Deleting: " + iconName);
					System.IO.File.Delete(iconPath);
				}
			}
        }

        private void DeleteUnmappedIcons()
        {
			List<string> usedIcons = new List<string>();
			usedIcons.Add("unknown.ico");

			List<IconMapItem> mappedIcons = IconMapperUtil.GetMappedIcons();

			foreach (IconMapItem item in mappedIcons)
			{
				usedIcons.Add(item.Icon);
			}

			WriteLine("Removing Unmapped Icons");

			string[] iconsInFolder = System.IO.Directory.GetFiles(AppConfig.IconFolder, "*.ico");
			for (int i = iconsInFolder.Length-1; i > 0; i--)
			{
				string iconPath = iconsInFolder[i];
				string iconName = System.IO.Path.GetFileName(iconPath);
				if (!usedIcons.Contains(iconName))
				{
					WriteLine("Deleting: " + iconName);
					System.IO.File.Delete(iconPath);
				}
			}
		}



        private void FixApplicationPaths()
        {
			List<string> groupNames = ShortcutUtil.GetShortcutGroupNames();
			foreach (string groupName in groupNames)
			{
				List<ShortcutItem> shortcuts = ShortcutUtil.GetShortcuts(groupName);
				foreach (ShortcutItem item in shortcuts)
				{
					string applicationPath = item.Application;
					if (applicationPath.StartsWith("\""))
					{
						item.Application = GetApplicationPart(applicationPath);
					}
				}
				ShortcutUtil.UpdateGroupShortcut(groupName, shortcuts.ToArray());
			}
        }

        /// <summary>
		/// Reassign Shortcut Id. In the event where Ids are corrupted.
		/// </summary>
		private void AssignShortcutIds()
        {
			List<string> groupNames = ShortcutUtil.GetShortcutGroupNames();
			foreach (string groupName in groupNames)
			{
				List<ShortcutItem> shortcuts = ShortcutUtil.GetShortcuts(groupName);
				foreach (ShortcutItem item in shortcuts)
				{
					string newId = Guid.NewGuid().ToString();
					WriteLine(string.Format("{0}: {1}", groupName, item.Text));
					WriteLine(string.Format("   {0} => {1}", item.Id, newId));
					item.Id = newId;
				}
				ShortcutUtil.UpdateGroupShortcut(groupName, shortcuts.ToArray());
			}
        }

        private void RemoveAllShortcuts()
        {
			List<string> groupNames = ShortcutUtil.GetShortcutGroupNames();
			foreach (string groupName in groupNames)
			{
				ShortcutUtil.DeleteGroup(groupName);
			}
			ShortcutUtil.UpdateGroup(new ShortcutGroup());
			DeleteUnmappedIcons();
        }

		private void RemoveInvalidEntries()
		{

			List<string> groupNames = ShortcutUtil.GetShortcutGroupNames();
			foreach (string groupName in groupNames)
			{
				List<ShortcutItem> shortcuts = ShortcutUtil.GetShortcuts(groupName);
				foreach (ShortcutItem item in shortcuts)
				{
					string application = item.Application;
					string txt = item.Text;
					if (!System.IO.Directory.Exists(application) && !System.IO.File.Exists(application))
					{
						//invalid
						WriteLine(string.Format("removing: {0}", txt));
						WriteLine(string.Format("   {0}", application));
					}
				}
				ShortcutUtil.UpdateGroupShortcut(groupName, shortcuts.ToArray());
			}
		}

		public static string GetApplicationPart(string strApplicationPath)
		{
			string strResult = strApplicationPath;
			if (strResult[0] == '\"')
			{
				try
				{
					strResult = strResult.Substring(1, strResult.LastIndexOf("\"") - 1);
				}
				catch (Exception)
				{
					throw new Exception("Please ensure that the filepath is a valid path: " + strApplicationPath);
				}
			}
			return strResult;
		}

		public static string MakeUniqueFilename(string newIconFilePath)
		{
			if (!System.IO.File.Exists(newIconFilePath))
			{
				//does not exists, create new
				return newIconFilePath;
			}
			else
			{
				string folder = System.IO.Path.GetDirectoryName(newIconFilePath);
				string filename = System.IO.Path.GetFileNameWithoutExtension(newIconFilePath);
				string ext = System.IO.Path.GetExtension(newIconFilePath);

				string final = string.Concat(System.IO.Path.Combine(folder, filename), ext);
				while (System.IO.File.Exists(final))
				{
					filename = System.IO.Path.GetFileNameWithoutExtension(newIconFilePath) + "__" + DateTime.Now.Millisecond;
					final = string.Concat(System.IO.Path.Combine(folder, filename), ext);
				}
				return final;
			}
		}
	}
}