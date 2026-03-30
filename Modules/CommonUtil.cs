using DesktopShortcutMgr.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopShortcutMgr.Modules
{
	/// <summary>
	/// Provides a collection of utility methods for common application tasks, such as file operations, program execution, and UI manipulation.
	/// </summary>
	public class CommonUtil
	{
		/// <summary>
		/// Attempts to load an icon from a specified file path.
		/// </summary>
		/// <param name="strIconFile">The path to the icon file.</param>
		/// <returns>The loaded <see cref="Icon"/> object, or null if loading fails.</returns>
		public static Icon GetIcon(string strIconFile)
		{
			try
			{
				return new Icon(strIconFile);
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// Sets the font for all controls in a collection to a generic Sans-Serif font, while preserving the original size and style.
		/// </summary>
		/// <param name="collections">The collection of controls to modify.</param>
		public static void SetApplicationFont(System.Windows.Forms.Control.ControlCollection collections) {
            foreach (Control c in collections)
            {
                Font f = new Font(FontFamily.GenericSansSerif, c.Font.Size, c.Font.Style);
                c.Font = f;
            }
        }

		/// <summary>
		/// Extracts the application path from a string that might contain both the path and arguments.
		/// It handles paths enclosed in quotes.
		/// </summary>
		/// <param name="strApplicationPath">The complete command-line-style application path string.</param>
		/// <returns>The isolated application path.</returns>
		/// <exception cref="Exception">Thrown if the provided path is invalid or improperly formatted.</exception>
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

		/// <summary>
		/// Extracts the arguments part from a string that might contain both the application path and arguments.
		/// Assumes that the application path is enclosed in quotes.
		/// </summary>
		/// <param name="strApplicationPath">The complete command-line-style application path string.</param>
		/// <returns>The extracted arguments string, or an empty string if no arguments are found.</returns>
		public static string GetArgumentPart(string strApplicationPath)
		{
			string strResult = strApplicationPath;

			if ((strResult.LastIndexOf("\"") + 1) == 0)
			{
				strResult = string.Empty;
			}
			else
			{
				strResult = strResult.Substring(strResult.LastIndexOf("\"") + 1);
			}

			return strResult;
		}

		/// <summary>
		/// Opens the parent directory of a specified program or file in Windows Explorer.
		/// </summary>
		/// <param name="strApplicationToExecute">The path to the file or folder.</param>
		public static void OpenProgramParent(string strApplicationToExecute)
		{
			string strToExecute = GetApplicationPart(strApplicationToExecute);

			//Exit if empty
			if (string.IsNullOrEmpty(strToExecute)) return;


			if (System.IO.File.Exists(strToExecute) || System.IO.Directory.Exists(strToExecute))

				//Try to execute file
				try
				{
					System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(strToExecute));
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			else
				MessageBox.Show("Application/Directory does not exists.\nPlease ensure that the folder/executable exist.");
		}

		/// <summary>
		/// Generates a unique filename for a file by appending a timestamp-based suffix if a file with the same name already exists.
		/// </summary>
		/// <param name="strFileSaveToLocation">The desired file path.</param>
		/// <returns>A unique file path.</returns>
		public static string CreateUniqueFilename(string strFileSaveToLocation)
		{
			if (!System.IO.File.Exists(strFileSaveToLocation))
			{
				return strFileSaveToLocation;
			}
			else
			{
				string folder = System.IO.Path.GetDirectoryName(strFileSaveToLocation);
				string filename = System.IO.Path.GetFileNameWithoutExtension(strFileSaveToLocation);
				string ext = System.IO.Path.GetExtension(strFileSaveToLocation);

				string final = string.Concat(System.IO.Path.Combine(folder, filename), ext);
				while (System.IO.File.Exists(final))
				{
					filename = System.IO.Path.GetFileNameWithoutExtension(strFileSaveToLocation) + "__" + DateTime.Now.Millisecond;
					final = string.Concat(System.IO.Path.Combine(folder, filename), ext);
				}
				return final;
			}
		}

		/// <summary>
		/// Executes a program or opens a directory based on the provided path string.
		/// This method attempts to handle parameters and sets the working directory to the program's location.
		/// </summary>
		/// <param name="shortcutItem">A string containing the path to the executable or directory.</param>
		public static void JustExecute(String shortcutItem) {

			if (string.IsNullOrEmpty(shortcutItem)) return;

			string strApplicationToExecute = shortcutItem;
			if (System.IO.File.Exists(GetApplicationPart(strApplicationToExecute)) || System.IO.Directory.Exists(GetApplicationPart(strApplicationToExecute)))

				//Try to execute file
				try
				{
					string strExecutable = GetApplicationPart(strApplicationToExecute);
					string strArgs = GetArgumentPart(strApplicationToExecute);

					System.Diagnostics.Process p = new System.Diagnostics.Process();
					p.StartInfo = new System.Diagnostics.ProcessStartInfo(strExecutable, strArgs);

					if (System.IO.File.Exists(strExecutable))
					{
						p.StartInfo.WorkingDirectory = System.IO.Directory.GetParent(strExecutable).FullName;
					}

					p.Start();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			else
				MessageBox.Show("Application/Directory does not exists.\nPlease ensure that the folder/executable exist.");

		}

		/// <summary>
		/// Executes a shortcut item, handling both executables and directories, and supporting elevated privileges.
		/// </summary>
		/// <param name="shortcutItem">The shortcut item to execute.</param>
		public static void ExecuteProgram(ShortcutItem shortcutItem)
		{
			//Exit if empty
			if (shortcutItem == null) return;

			string strApplicationToExecute = shortcutItem.Application;

			if (System.IO.File.Exists(GetApplicationPart(strApplicationToExecute)) || System.IO.Directory.Exists(GetApplicationPart(strApplicationToExecute)))

				//Try to execute file
				try
				{
					string strExecutable = GetApplicationPart(strApplicationToExecute);
					string strArgs = shortcutItem.Arguments; //GetArgumentPart(strApplicationToExecute);

					System.Diagnostics.Process p = new System.Diagnostics.Process();
					ProcessStartInfo StartInfo = new System.Diagnostics.ProcessStartInfo(strExecutable, strArgs);

					if (shortcutItem.RunAsAdmin)
					{
						StartInfo.UseShellExecute = true;
						StartInfo.Verb = "runas";

						if (System.IO.Directory.Exists(strExecutable))
						{
							//directory... use explorer
							string windows = Environment.GetEnvironmentVariable("windir");
							string explorer = Path.Combine(windows, "explorer.exe");

							StartInfo.Arguments = StartInfo.FileName;
							StartInfo.FileName = explorer;
						}
						else if (!IsExecutable(strExecutable))
						{
							MessageBox.Show("Unable to run program as Administrator.");
							return;
						}
					}

					if (System.IO.File.Exists(strExecutable))
					{
						StartInfo.WorkingDirectory = System.IO.Directory.GetParent(strExecutable).FullName;
					}

					p.StartInfo = StartInfo;
					p.Start();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			else
				MessageBox.Show("Application/Directory does not exists.\nPlease ensure that the folder/executable exist.");
		}

		/// <summary>
		/// Opens the parent directory of a shortcut item in Windows Explorer.
		/// </summary>
		/// <param name="item">The shortcut item whose parent folder should be opened.</param>
		public static void OpenProgramParent(ShortcutItem item) {

			string strCurrentShortcutName = item.Text;
			string strCurrentShortcutPath = item.Application;

			OpenProgramParent(strCurrentShortcutPath);
		}

		/// <summary>
		/// Determines whether a specified file is an executable (.exe, .cmd, or .bat).
		/// </summary>
		/// <param name="application">The path to the file.</param>
		/// <returns>True if the file is an executable; otherwise, false.</returns>
		public static bool IsExecutable(string application) {
			return 
				application.ToLower().EndsWith(".exe") || 
				application.ToLower().EndsWith(".cmd") || 
				application.ToLower().EndsWith(".bat");
		}
	}
}
