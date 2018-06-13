using DesktopShortcutMgr.Entity;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DesktopShortcutMgr.Modules
{
	/// <summary>
	/// ShortcutUtil
	/// Mainly a class for any CRUD operations to the ShortcutGroups and ShortcutItems
	/// </summary>
	class ShortcutUtil
	{
		public const string ElementRootNodeName = "NewDataSet";
		public const string ElementNodeName = "Shortcuts";
		public const string ElementShortcutId = "Id";

		public const string ElementGroup = "Groups";
		public const string ElementGroupName = "Name";


		#region Retrieve and Write to config file

		//Gets Group
		public static List<ShortcutGroupItem> GetGroupsItems()
		{
			List<ShortcutGroupItem> groupItems = new List<ShortcutGroupItem>();
			string strSettingsFile = AppConfig.BaseShortcutFile;

			if (System.IO.File.Exists(strSettingsFile))
			{
				using (FileStream fileStream = new FileStream(strSettingsFile, FileMode.Open))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(ShortcutGroup));
					ShortcutGroup result = (ShortcutGroup)serializer.Deserialize(fileStream);

					if (result != null && result.Items != null)
					{
						groupItems.AddRange(result.Items);
					}
				}
			}

			return groupItems;
		}

		//Gets Group's shortcut items
		public static List<ShortcutItem> GetShortcuts(string groupName)
		{
			string cfgFile = AppConfig.GetShortcutFile(groupName);

			List<ShortcutItem> groupShortcuts = new List<ShortcutItem>();
			if (System.IO.File.Exists(cfgFile))
			{
				using (FileStream fileStream = new FileStream(cfgFile, FileMode.Open))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Shortcuts));
					Shortcuts result = (Shortcuts)serializer.Deserialize(fileStream);

					if (result != null && result.Items != null)
					{
						groupShortcuts.AddRange(result.Items);
					}
					else
					{
						System.IO.File.Delete(cfgFile);
					}
				}
			}

			return groupShortcuts;
		}


		public static void UpdateGroupShortcut(string groupName, params ShortcutItem[] shortcuts)
		{
			Shortcuts s = new Shortcuts()
			{
				Items = shortcuts.ToList<ShortcutItem>()
			};
			UpdateGroupShortcut(groupName, s);
		}

		public static void UpdateGroupShortcut(string groupName, Shortcuts shortcuts)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Shortcuts));
			using (XmlWriter writer = XmlWriter.Create(AppConfig.GetShortcutFile(groupName), AppConfig.GetXmlWritterSettings()))
			{
				writer.WriteWhitespace("");
				serializer.Serialize(writer, shortcuts, AppConfig.GetXmlSerializerNamespaces());
				writer.Close();
			}
		}

		public static bool UpdateGroup(List<ShortcutGroupItem> groupItems)
		{
			ShortcutGroup group = new ShortcutGroup()
			{
				Items = groupItems
			};
			return UpdateGroup(group);
		}

		public static bool UpdateGroup(ShortcutGroup group)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ShortcutGroup));
			using (XmlWriter writer = XmlWriter.Create(AppConfig.BaseShortcutFile, AppConfig.GetXmlWritterSettings()))
			{
				writer.WriteWhitespace("");
				serializer.Serialize(writer, group, AppConfig.GetXmlSerializerNamespaces());
				writer.Close();
			}

			return true;
		}

		#endregion

		//Gets the list of shortcut group name
		public static List<string> GetShortcutGroupNames()
		{
			List<string> groupNames = GetGroupsItems()
									.Select(c => c.Name)
									.ToList();
			return groupNames;
		}

		//Sort the group items
		public static void SortShortcuts(string groupName, string sortOrder)
		{
			//If the group name is empty, ignore
			if (string.IsNullOrEmpty(groupName)) { return; }

			List<ShortcutItem> items = GetShortcuts(groupName);
			if ("ASC" == sortOrder)
			{
				items.Sort((x, y) => x.Text.CompareTo(y.Text));
			}
			else {
				items.Sort((x, y) => y.Text.CompareTo(x.Text));
			}
			
			UpdateGroupShortcut(groupName, items.ToArray());
		}

		public static ShortcutItem ConvertFilePathToShortcut(string file)
		{

			//If the dropped item is a file

			string strFilename = string.Empty;
			string strTargetPath = file;
			ShortcutItem item = new ShortcutItem()
			{
				Id = Guid.NewGuid().ToString()
			};

			if (System.IO.File.Exists(file))
			{
				strFilename = System.IO.Path.GetFileNameWithoutExtension(file);
				string strIconPath = string.Empty;
				string strExtension = System.IO.Path.GetExtension(file);



				IconExtractor extractor = null;
				Icon ico = null;
				string iconPath = null;
				int iconIndex = 0;

				bool hasIcon = false;
				if (".lnk" == strExtension.ToLower())
				{
					//get extensions
					string linkPathName = @file;
					WshShell shell = new WshShell();
					IWshShortcut link = (IWshShortcut)shell.CreateShortcut(linkPathName);

					if (!System.IO.Directory.Exists(link.TargetPath))
					{
						//Ensure that this is not a folder
						if (System.IO.Path.GetExtension(link.TargetPath) == ".exe")
						{
							if (!string.IsNullOrEmpty(link.IconLocation))
							{
								hasIcon = true;
								string[] aryIconPart = link.IconLocation.Split(',');

								//if the application part is missing/empty, get it straight from the EXE
								if (string.IsNullOrEmpty(aryIconPart[0]))
								{
									aryIconPart[0] = link.TargetPath;
									iconPath = System.Environment.ExpandEnvironmentVariables(aryIconPart[0]);
									iconIndex = int.Parse(aryIconPart[1]);
								}
							}
						}

						strTargetPath = link.TargetPath;
					}
				}
				else if (".exe" == strExtension.ToLower())
				{
					//exe
					hasIcon = true;
					iconPath = file;
					iconIndex = 0;
					strTargetPath = file;
				}
				else
				{
					//file 
					hasIcon = false;
					iconPath = null;
					iconIndex = 0;
					strTargetPath = file;
				}


				if (hasIcon)
				{
					//extract icon
					try
					{
						//Extract the icon
						extractor = new IconExtractor(iconPath);
						ico = extractor.GetIcon(iconIndex);

						//strIconPath =  AppConfig.GetIcon(strFilename) + ".ico";
						strIconPath = CommonUtil.CreateUniqueFilename(AppConfig.GetIconMapFile(strFilename) + ".ico");

						System.IO.FileStream fs = new System.IO.FileStream(strIconPath, System.IO.FileMode.OpenOrCreate);
						ico.Save(fs);
						fs.Close();
						fs.Dispose();

						item.IconPath = System.IO.Path.GetFileName(strIconPath);
					}
					catch (Exception)
					{
						item.IconPath = "";
					}
					finally
					{
						if (extractor != null)
						{
							extractor.Dispose();
							extractor = null;
						}

						if (ico != null)
						{
							ico.Dispose();
							ico = null;
						}
					}
				}
			}
			else if (System.IO.Directory.Exists(file))
			{
				//directory
				DirectoryInfo inf = new DirectoryInfo(file);
				strFilename = inf.Name;
			}

			/*
			if (strTargetPath[0] != '\"')
			{
				strTargetPath = "\"" + strTargetPath + "\"";
			}
			*/

			item.Text = strFilename;
			item.Application = strTargetPath;

			return item;
		}

		//Gets all shortcut items from the DataTable
		public static List<ShortcutItem> ConvertToShortcut(DataTable dt)
		{

			List<ShortcutItem> lstShortcuts = new List<ShortcutItem>();

			string groupName = dt.TableName;
			using (MemoryStream ms = new MemoryStream())
			{
				//internal name used by program
				dt.TableName = ElementNodeName;
				DataSet ds = new DataSet(ElementRootNodeName);
				ds.Tables.Add(dt);
				ds.WriteXml(ms);
				ms.Seek(0, SeekOrigin.Begin);

				XmlSerializer serializer = new XmlSerializer(typeof(Shortcuts));
				Shortcuts result = (Shortcuts)serializer.Deserialize(ms);


				if (result != null && result.Items != null)
				{
					foreach (ShortcutItem item in result.Items)
					{
						item.GroupName = groupName;
						lstShortcuts.Add(item);
					}
				}
			}
			return lstShortcuts;
		}


		#region Group CRUD Functions

		public static bool GroupNameExists(string groupName)
		{
			return GetShortcutGroupNames().Contains(groupName);
		}

		public static void CreateGroup(String groupName)
		{
			List<ShortcutGroupItem> allGroups = GetGroupsItems();
			allGroups.Add(new ShortcutGroupItem()
			{
				Name = groupName
			});
			UpdateGroup(allGroups);
		}

		public static bool DeleteGroup(string groupName)
		{
			string groupFile = AppConfig.GetShortcutFile(groupName);
			if (System.IO.File.Exists(groupFile)) {
				System.IO.File.Delete(groupFile);
			}

			List<ShortcutGroupItem> allGroups = GetGroupsItems();
			allGroups.RemoveAll(item => item.Name == groupName);
			UpdateGroup(allGroups);

			return true;
		}

		public static bool RenameGroup(string oldGroupName, string newGroupName)
		{

			List<ShortcutGroupItem> allGroups = GetGroupsItems();
			ShortcutGroupItem selectedItem = allGroups.Find(item => item.Name == oldGroupName);
			if (selectedItem != null)
			{
				selectedItem.Name = newGroupName;
				if (System.IO.File.Exists(AppConfig.GetShortcutFile(oldGroupName)))
				{
					System.IO.File.Move(
						AppConfig.GetShortcutFile(oldGroupName),
						AppConfig.GetShortcutFile(newGroupName)
					);
				}
			}
			UpdateGroup(allGroups);

			return true;
		}

		

		#endregion

		#region Shortcut CRUD Function

		public static List<ShortcutItem> CreateShortcut(string groupName, params string[] files)
		{
			List<ShortcutItem> newItems = new List<ShortcutItem>();
			foreach (string file in files)
			{
				ShortcutItem i = ConvertFilePathToShortcut(file);
				newItems.Add(i);
			}

			List<ShortcutItem> existingItems = GetShortcuts(groupName);
			existingItems.AddRange(newItems);

			UpdateGroupShortcut(groupName, existingItems.ToArray());
			return newItems;
		}

		public static bool UpdateShortcut(string groupName, ShortcutItem editedItem)
		{
			List<ShortcutItem> items = GetShortcuts(groupName);
			for (int i = 0; i < items.Count; i++)
			{
				ShortcutItem item = items[i];
				if (item.Id == editedItem.Id) {
					items[i] = editedItem;
					break;
				}
			}
			UpdateGroupShortcut(groupName, items.ToArray());
			return true;
		}

		public static bool DeleteShortcut(string groupName, params ShortcutItem[] shortcutsToDelete)
		{

			if (shortcutsToDelete == null) return false;
			if (shortcutsToDelete.Length == 0) return false;

			List<ShortcutItem> items = GetShortcuts(groupName);
			foreach (ShortcutItem toDelete in shortcutsToDelete)
			{
				for (int i = items.Count - 1; i > 0; i--)
				{
					ShortcutItem item = items[i];
					if (item.Id == toDelete.Id)
					{
						items.RemoveAt(i);
						break;
					}
				}
			}
			UpdateGroupShortcut(groupName, items.ToArray());
			return true;
		}

		public static void CopyShortcut(string groupName, params ShortcutItem[] shortcutsToCopy)
		{

			List<ShortcutItem> shortcuts = GetShortcuts(groupName);
			string strShortcutFile = AppConfig.GetShortcutFile(groupName);

			foreach (var itemToCopy in shortcutsToCopy)
			{
				bool toAdd = true;
				foreach (var item in shortcuts)
				{
					if (item.Equals(itemToCopy))
					{
						toAdd = false;
						break;
					}
				}

				if (toAdd)
				{
					shortcuts.Add(itemToCopy);
				}
			}
			UpdateGroupShortcut(groupName, shortcuts.ToArray());
		}

		#endregion

	}
}
