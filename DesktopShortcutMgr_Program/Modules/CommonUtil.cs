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
	public class CommonUtil
	{
		//Gets Icon from Icon Folder
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
		/// Gets the real application path of the program.
		/// this will remove all parameters 
		/// e.g. 
		/// 
		/// From "C:\program files\my program.exe" -MyParam
		/// To "C:\program files\my program.exe"
		/// 
		/// </summary>
		/// <returns></returns>
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
		/// Gets the parameter part of the program.
		/// this will remove all parameters 
		/// e.g. 
		/// 
		/// From "C:\program files\my program.exe" -MyParam
		/// To -MyParam
		/// 
		/// </summary>
		/// <returns></returns>
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

		//Opens the program parent directory
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

		public static void OpenProgramParent(ShortcutItem item) {

			string strCurrentShortcutName = item.Text;
			string strCurrentShortcutPath = item.Application;

			OpenProgramParent(strCurrentShortcutPath);
		}

		public static bool IsExecutable(string application) {
			return 
				application.ToLower().EndsWith(".exe") || 
				application.ToLower().EndsWith(".cmd") || 
				application.ToLower().EndsWith(".bat");
		}
	}
}
