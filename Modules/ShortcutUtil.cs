using DesktopShortcutMgr.Entity;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace DesktopShortcutMgr.Modules
{
    /// <summary>
    /// Provides utility methods for CRUD operations and other management tasks related to ShortcutGroups and ShortcutItems.
    /// </summary>
    class ShortcutUtil
    {
        public const string ElementRootNodeName = "NewDataSet";
        public const string ElementNodeName = "Shortcuts";
        public const string ElementShortcutId = "Id";

        public const string ElementGroup = "Groups";
        public const string ElementGroupName = "Name";


        #region Retrieve and Write to config file

        /// <summary>
        /// Retrieves all shortcut group items from the base configuration file.
        /// </summary>
        /// <returns>A list of <see cref="ShortcutGroupItem"/> objects.</returns>
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

        /// <summary>
        /// Retrieves all shortcut items belonging to a specific group from its XML configuration file.
        /// </summary>
        /// <param name="groupName">The name of the shortcut group.</param>
        /// <returns>A list of <see cref="ShortcutItem"/> objects.</returns>
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


        /// <summary>
        /// Updates the shortcuts within a group using an array of shortcut items.
        /// </summary>
        /// <param name="groupName">The name of the group to update.</param>
        /// <param name="shortcuts">The array of <see cref="ShortcutItem"/> objects.</param>
        public static void UpdateGroupShortcut(string groupName, params ShortcutItem[] shortcuts)
        {
            Shortcuts s = new Shortcuts()
            {
                Items = shortcuts.ToList<ShortcutItem>()
            };
            UpdateGroupShortcut(groupName, s);
        }

        /// <summary>
        /// Persists the provided shortcuts to the XML configuration file for the specified group.
        /// </summary>
        /// <param name="groupName">The name of the shortcut group.</param>
        /// <param name="shortcuts">The <see cref="Shortcuts"/> collection to save.</param>
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

        /// <summary>
        /// Updates the list of shortcut groups in the base configuration file.
        /// </summary>
        /// <param name="groupItems">The list of <see cref="ShortcutGroupItem"/> objects.</param>
        /// <returns>True if the update was successful.</returns>
        public static bool UpdateGroup(List<ShortcutGroupItem> groupItems)
        {
            ShortcutGroup group = new ShortcutGroup()
            {
                Items = groupItems
            };
            return UpdateGroup(group);
        }

        /// <summary>
        /// Persists the provided shortcut group configuration to the base XML file.
        /// </summary>
        /// <param name="group">The <see cref="ShortcutGroup"/> object to save.</param>
        /// <returns>True if the update was successful.</returns>
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

        /// <summary>
        /// Retrieves the names of all existing shortcut groups.
        /// </summary>
        /// <returns>A list of group names.</returns>
        public static List<string> GetShortcutGroupNames()
        {
            List<string> groupNames = GetGroupsItems()
                                    .Select(c => c.Name)
                                    .ToList();
            return groupNames;
        }

        /// <summary>
        /// Sorts the shortcuts within a specified group alphabetically.
        /// </summary>
        /// <param name="groupName">The name of the group to sort.</param>
        /// <param name="sortOrder">The sort order ("ASC" for ascending, any other value for descending).</param>
        public static void SortShortcuts(string groupName, string sortOrder)
        {
            //If the group name is empty, ignore
            if (string.IsNullOrEmpty(groupName)) { return; }

            List<ShortcutItem> items = GetShortcuts(groupName);
            if ("ASC" == sortOrder)
            {
                items.Sort((x, y) => x.Text.CompareTo(y.Text));
            }
            else
            {
                items.Sort((x, y) => y.Text.CompareTo(x.Text));
            }

            UpdateGroupShortcut(groupName, items.ToArray());
        }

        /// <summary>
        /// Converts a file path into a <see cref="ShortcutItem"/>, extracting icons for executables and shortcuts (.lnk files).
        /// </summary>
        /// <param name="file">The path to the file or directory.</param>
        /// <returns>A new <see cref="ShortcutItem"/> object.</returns>
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
                bool iconAlreadyExtracted = false;
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
                            //has icon
                            if (!string.IsNullOrEmpty(link.IconLocation))
                            {
                                hasIcon = true;

                                //get icon details
                                string[] aryIconPart = link.IconLocation.Split(',');

                                //if the application part is missing/empty, get it straight from the EXE
                                if (string.IsNullOrEmpty(aryIconPart[0]))
                                {
                                    aryIconPart[0] = link.TargetPath;
                                    iconPath = System.Environment.ExpandEnvironmentVariables(aryIconPart[0]);
                                    iconIndex = int.Parse(aryIconPart[1]);
                                }
                                else
                                {

                                    iconAlreadyExtracted = (System.IO.Path.GetExtension(aryIconPart[0]) == ".ico");

                                    //aryIconPart[0] = link.TargetPath;
                                    //iconPath = System.Environment.ExpandEnvironmentVariables(aryIconPart[0]);
                                    iconPath = aryIconPart[0];
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
                    if (iconAlreadyExtracted)
                    {
                        item.IconPath = iconPath;
                    }
                    else
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
            }
            else if (System.IO.Directory.Exists(file))
            {
                //directory
                DirectoryInfo inf = new DirectoryInfo(file);
                strFilename = inf.Name;
            }

            item.Text = strFilename;
            item.Application = strTargetPath;

            return item;
        }

        /// <summary>
        /// Converts the data within a <see cref="DataTable"/> into a list of <see cref="ShortcutItem"/> objects.
        /// </summary>
        /// <param name="dt">The DataTable containing shortcut information.</param>
        /// <returns>A list of <see cref="ShortcutItem"/> objects.</returns>
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

        /// <summary>
        /// Checks if a shortcut group with the specified name already exists.
        /// </summary>
        /// <param name="groupName">The name of the group to check.</param>
        /// <returns>True if the group exists.</returns>
        public static bool GroupNameExists(string groupName)
        {
            return GetShortcutGroupNames().Contains(groupName);
        }

        /// <summary>
        /// Creates a new shortcut group with the specified name.
        /// </summary>
        /// <param name="groupName">The name of the new group.</param>
        public static void CreateGroup(String groupName)
        {
            List<ShortcutGroupItem> allGroups = GetGroupsItems();
            allGroups.Add(new ShortcutGroupItem()
            {
                Name = groupName
            });
            UpdateGroup(allGroups);
        }

        /// <summary>
        /// Deletes a specified shortcut group and its associated configuration file.
        /// </summary>
        /// <param name="groupName">The name of the group to delete.</param>
        /// <returns>True if the deletion was successful.</returns>
        public static bool DeleteGroup(string groupName)
        {
            string groupFile = AppConfig.GetShortcutFile(groupName);
            if (System.IO.File.Exists(groupFile))
            {
                System.IO.File.Delete(groupFile);
            }

            List<ShortcutGroupItem> allGroups = GetGroupsItems();
            allGroups.RemoveAll(item => item.Name == groupName);
            UpdateGroup(allGroups);

            return true;
        }

        /// <summary>
        /// Renames an existing shortcut group and moves its configuration file to the new name.
        /// </summary>
        /// <param name="oldGroupName">The current name of the group.</param>
        /// <param name="newGroupName">The new name for the group.</param>
        /// <returns>True if the rename was successful.</returns>
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

        /// <summary>
        /// Creates new shortcut items for a list of files and adds them to a specified group.
        /// </summary>
        /// <param name="groupName">The name of the target group.</param>
        /// <param name="files">An array of file paths.</param>
        /// <returns>A list of the newly created <see cref="ShortcutItem"/> objects.</returns>
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

        /// <summary>
        /// Updates an existing shortcut item within a specified group.
        /// </summary>
        /// <param name="groupName">The name of the group containing the shortcut.</param>
        /// <param name="editedItem">The updated <see cref="ShortcutItem"/> object.</param>
        /// <returns>True if the update was successful.</returns>
        public static bool UpdateShortcut(string groupName, ShortcutItem editedItem)
        {
            List<ShortcutItem> items = GetShortcuts(groupName);
            for (int i = 0; i < items.Count; i++)
            {
                ShortcutItem item = items[i];
                if (item.Id == editedItem.Id)
                {
                    items[i] = editedItem;
                    break;
                }
            }
            UpdateGroupShortcut(groupName, items.ToArray());
            return true;
        }

        /// <summary>
        /// Deletes one or more shortcut items from a specified group.
        /// </summary>
        /// <param name="groupName">The name of the group.</param>
        /// <param name="shortcutsToDelete">An array of <see cref="ShortcutItem"/> objects to delete.</param>
        /// <returns>True if the deletion was successful.</returns>
        public static bool DeleteShortcut(string groupName, params ShortcutItem[] shortcutsToDelete)
        {

            if (shortcutsToDelete == null) return false;
            if (shortcutsToDelete.Length == 0) return false;

            List<ShortcutItem> items = GetShortcuts(groupName);
            foreach (ShortcutItem toDelete in shortcutsToDelete)
            {
                for (int i = items.Count - 1; i >= 0; i--) // Fixed loop condition from > to >=
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

        /// <summary>
        /// Copies one or more shortcut items into a specified group, avoiding duplicates.
        /// </summary>
        /// <param name="groupName">The name of the target group.</param>
        /// <param name="shortcutsToCopy">An array of <see cref="ShortcutItem"/> objects to copy.</param>
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
