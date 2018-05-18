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
	class ShortcutUtil
	{
		public const string ElementRootNodeName = "NewDataSet";
		public const string ElementNodeName = "Shortcuts";
		public const string ElementShortcutId = "Id";

		public const string ElementGroup = "Groups";
		public const string ElementGroupName = "Name";

		//Gets all shortcut groups
		public static DataSet GetShortcutGroups()
		{
			DataSet ds = new DataSet(ElementNodeName);
			ds.ReadXml(AppConfig.BaseShortcutFile);

			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count < 1)
				{
					DataTable dt = new DataTable(ElementGroup);
					dt.Columns.Add("name");
					ds.Tables.Add(dt);
				}
			}
			else
			{
				DataTable dt = new DataTable(ElementGroup);
				dt.Columns.Add(ElementGroupName);
				ds.Tables.Add(dt);
			}

			return ds;
		}

		//Gets the list of shortcut group name
		public static List<string> GetShortcutGroupNames()
		{
			
			List<string> l = new List<string>();
			if (GetShortcutGroups().Tables.Count == 0) return l;

			foreach (DataRow dr in GetShortcutGroups().Tables[0].Rows)
			{
				l.Add(dr[ElementGroupName].ToString());
			}
			return l;
		}

		//Gets all shortcut items from the file
		public static List<ShortcutItem> GetShortcuts(string groupName)
		{
			string strSettingsFile = AppConfig.GetShortcutFile(groupName);

			List<ShortcutItem> lstShortcuts = new List<ShortcutItem>();
			if (System.IO.File.Exists(strSettingsFile))
			{
				using (FileStream fileStream = new FileStream(strSettingsFile, FileMode.Open))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Shortcuts));
					Shortcuts result = (Shortcuts)serializer.Deserialize(fileStream);

					if (result != null && result.Items != null)
					{
						foreach (ShortcutItem item in result.Items)
						{
							lstShortcuts.Add(item);
						}
					}
					else
					{
						System.IO.File.Delete(strSettingsFile);
					}
				}
			}

			return lstShortcuts;
		}

		public static void UpdateGroupShortcut(string groupName, params ShortcutItem[] shortcuts)
		{
			UpdateMenuFile(AppConfig.GetShortcutFile(groupName), shortcuts);
		}
		public static void UpdateGroupShortcut(string groupName, Shortcuts shortcuts)
		{
			UpdateMenuFile(AppConfig.GetShortcutFile(groupName), shortcuts);
		}

		public static void UpdateMenuFile(string fileName, params ShortcutItem[] shortcuts)
		{
			Shortcuts s = new Shortcuts() {
				Items = shortcuts.ToList<ShortcutItem>()
			};
			UpdateMenuFile(fileName, s);
		}

		public static void UpdateMenuFile(string fileName, Shortcuts shortcuts)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Shortcuts));
			var emptyNamepsaces = new XmlSerializerNamespaces(new[] {
				XmlQualifiedName.Empty
			});

			XmlWriterSettings settings = new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = ("\t"),
				OmitXmlDeclaration = true
			};

			using (XmlWriter writer = XmlWriter.Create(fileName, settings))
			{
				writer.WriteWhitespace("");
				serializer.Serialize(writer, shortcuts, emptyNamepsaces);
				writer.Close();
			}
		}

		//Sort the group items
		public static void SortShortcuts(string groupName, string sortOrder)
		{
			//If the group name is empty, ignore
			if (string.IsNullOrEmpty(groupName)) { return; }

			//get the full path
			string strShortcutFile = AppConfig.GetShortcutFile(groupName);

			DataSet ds = new DataSet();
			ds.ReadXml(strShortcutFile);

			ds.Tables[0].DefaultView.Sort = "[text] " + sortOrder;


			DataSet ds2 = new DataSet();
			ds2.Tables.Add(ds.Tables[0].DefaultView.ToTable());
			ds2.WriteXml(strShortcutFile);

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

			if (strTargetPath[0] != '\"')
			{
				strTargetPath = "\"" + strTargetPath + "\"";
			}

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
			DataSet ds = GetShortcutGroups();
			if (ds.Tables.Count == 0) return false;

			string filter = string.Format("{0} = '{1}'", ElementGroupName, groupName);
			DataRow[] existing = ds.Tables[0].Select(filter);

			return (existing.Length > 0);
		}

		public static void CreateGroup(String groupName)
		{
			DataSet ds = GetShortcutGroups();

			//Add to xml
			DataRow dr = ds.Tables[0].NewRow();
			dr["name"] = groupName;
			ds.Tables[0].Rows.Add(dr);

			ds.WriteXml(AppConfig.BaseShortcutFile);
		}

		public static bool DeleteGroup(string groupName)
		{

			string groupFile = AppConfig.GetShortcutFile(groupName);
			if (System.IO.File.Exists(groupFile)) {
				System.IO.File.Delete(groupFile);
			}

			//Load XML shortcut files into DataSet
			DataSet ds = GetShortcutGroups();
			if (ds.Tables.Count == 0) return false;

			//If the group name is empty, ignore
			if (string.IsNullOrEmpty(groupName)) { return false; }

			string filter = string.Format("{0} = '{1}'", ElementGroupName, groupName);
			DataRow[] rows = ds.Tables[0].Select(filter);
			foreach (var item in rows)
			{
				item.Delete();
			}

			ds.WriteXml(AppConfig.BaseShortcutFile);

			return true;
		}

		public static bool RenameGroup(string oldGroupName, string newGroupName)
		{

			DataSet ds = GetShortcutGroups();
			string filter = string.Format("{0} = '{1}'", ElementGroupName, oldGroupName);
			DataRow[] groupRow = ds.Tables[0].Select(filter);
			if (groupRow.Length > 0)
			{

				//rename
				groupRow[0][ElementGroupName] = newGroupName;

				//Check if the file exist. If exists, rename it using the MOVE
				if (System.IO.File.Exists(AppConfig.GetShortcutFile(oldGroupName)))
				{
					System.IO.File.Move(
						AppConfig.GetShortcutFile(oldGroupName),
						AppConfig.GetShortcutFile(newGroupName)
					);
				}

				ds.WriteXml(AppConfig.BaseShortcutFile);
			}

			return true;
		}

		public static bool UpdateGroup(ShortcutGroup group)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ShortcutGroup));
			var emptyNamepsaces = new XmlSerializerNamespaces(new[] {
				XmlQualifiedName.Empty
			});

			XmlWriterSettings settings = new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = ("\t"),
				OmitXmlDeclaration = true
			};

			using (XmlWriter writer = XmlWriter.Create(AppConfig.BaseShortcutFile, settings))
			{
				writer.WriteWhitespace("");
				serializer.Serialize(writer, group, emptyNamepsaces);
				writer.Close();
			}

			return true;
		}

		#endregion

		#region Shortcut CRUD Function

		public static List<ShortcutItem> CreateShortcut(string settingsFile, params string[] files)
		{
			List<ShortcutItem> items = new List<ShortcutItem>();

			//if file does not exists, create file.
			if (!System.IO.File.Exists(settingsFile))
			{
				DataSet newDt = new DataSet(ElementRootNodeName);
				newDt.WriteXml(settingsFile);
			}

			XmlDocument xDoc = new XmlDocument();
			xDoc.Load(settingsFile);
			var rootNode = xDoc.GetElementsByTagName(ElementRootNodeName)[0];
			var nav = rootNode.CreateNavigator();

			var emptyNamepsaces = new XmlSerializerNamespaces(new[] {
				XmlQualifiedName.Empty
			});

			using (var writer = nav.AppendChild())
			{
				writer.WriteWhitespace("");
				foreach (string file in files)
				{
					ShortcutItem i = ConvertFilePathToShortcut(file);
					var serializer = new XmlSerializer(i.GetType());
					serializer.Serialize(writer, i, emptyNamepsaces);
					items.Add(i);
				}
				writer.Close();
			}
			xDoc.Save(settingsFile);

			return items;
		}

		public static bool UpdateShortcut(string groupName, ShortcutItem editedItem)
		{
			//find xml file
			string strMenuFile = AppConfig.GetShortcutFile(groupName);

			List<ShortcutItem> lstShortcuts = new List<ShortcutItem>();
			Shortcuts result = null;
			XmlSerializer serializer = new XmlSerializer(typeof(Shortcuts));

			using (FileStream fileStream = new FileStream(strMenuFile, FileMode.Open))
			{
				result = (Shortcuts)serializer.Deserialize(fileStream);

				if (result != null && result.Items != null)
				{
					for (int i = 0; i < result.Items.Count; i++)
					{

						var fileItem = result.Items[i];
						if (fileItem.Id == editedItem.Id)
						{
							result.Items[i] = editedItem;
							break;
						}
					}
				}
			}

			UpdateMenuFile(strMenuFile, result);

			return true;
		}

		public static bool DeleteShortcut(string groupName, params ShortcutItem[] shortcutsToDelete)
		{

			if (shortcutsToDelete == null) return false;
			if (shortcutsToDelete.Length == 0) return false;

			//Gets the shortcut file from xml
			DataSet ds = new DataSet();
			string strShortcutFile = AppConfig.GetShortcutFile(groupName);
			ds.ReadXml(strShortcutFile);

			foreach (ShortcutItem item in shortcutsToDelete)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					if (dr[ElementShortcutId].ToString() == item.Id)
					{
						//delete when found
						ds.Tables[0].Rows.Remove(dr);
						break;
					}
				}
			}
			ds.WriteXml(strShortcutFile);
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
			Shortcuts s = new Shortcuts()
			{
				Items = shortcuts
			};

			UpdateMenuFile(strShortcutFile, s);
		}

		#endregion


	}
}
