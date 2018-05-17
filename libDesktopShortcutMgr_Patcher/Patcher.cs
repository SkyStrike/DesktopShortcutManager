using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DSMUpdater
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
        public string strConfigfolder { get; set; }
        public string strShortcutFolder { get; set; }
        public string strIconFolder { get; set; }

        public string strShortcutGroupConfigFile { get; set; }
        public string strDefaultIconMapConfigFile { get; set; }

        private TextBox tbConsole = null;
        public PatcherInterface parentForm;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Patcher() { }

        /// <summary>
        /// Constructor with Patcher Configuration. 
        /// 
        /// It will call the Load Config
        /// </summary>
        /// <param name="strPatchConfig"></param>
        public Patcher(string strPatchConfig)
        {
            LoadConfig(strPatchConfig);
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
        /// Loads config into memory
        /// </summary>
        /// <param name="strPatchConfig"></param>
        public void LoadConfig(string strPatchConfig)
        {
            if (!System.IO.File.Exists(strPatchConfig))
            {
                WriteLine("Invalid Patch Config File: " + strPatchConfig);
                return;
            }

            DataSet dsConfig = new DataSet();
            dsConfig.ReadXml(strPatchConfig);


            this.strShortcutFolder = dsConfig.Tables[0].Rows[0]["folder_shortcut"].ToString();
            this.strIconFolder = dsConfig.Tables[0].Rows[0]["folder_icon"].ToString();
            this.strConfigfolder = dsConfig.Tables[0].Rows[0]["folder_config"].ToString();

            DataTable dtImports = dsConfig.Tables["import"];

            foreach (DataRow drImport in dtImports.Rows)
            {
                string strType = drImport["type"].ToString();
                string strFile = drImport["file"].ToString();
                switch (strType.ToLower())
                {
                    case "icon_map":
                        this.strDefaultIconMapConfigFile = strFile;
                        break;

                    case "shortcut_groups":
                        this.strShortcutGroupConfigFile = strFile;
                        break;

                    default:
                        break;
                }
            }
        }


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
            try
            {
                object o = System.Enum.Parse(typeof(Commands), cmd, true);
                cmdType = (Commands)o;

                switch (cmdType)
                {
                    case Commands.RebuildIcons:
                        WriteLine("Rebuilding Icons");
                        RebuildIcons();
                        WriteLine("Icons Rebuilt");
                        break;

                    case Commands.ClearUnusedIcons:
                        WriteLine("Clearing Unused Icons");
                        ClearUnusedIcons();
                        WriteLine("Unused Icons Cleared");
                        break;

                    case Commands.FixApplicationPaths:
                        Write("Patching Application Paths");
                        FixApplicationPaths();
                        Write("\tDone\n");
                        break;

                    case Commands.AssignShortcutIds:
                        Write("Patching Application Id");
                        AssignShortcutIds();
                        Write("\tDone\n");
                        break;

                    case Commands.RemoveCustomIcons:
                        Write("Removing Custom Icons");
                        RemoveCustomIcons();
                        Write("\tDone\n");
                        break;

                    case Commands.RemoveAllShortcuts:
                        Write("Removing All Shortcuts");
                        RemoveAllShortcuts();
                        Write("\tDone\n");
                        break;

                    default:
                        MessageBox.Show("Unknown Patch Command: " + cmd);
                        break;
                }
            }
            catch (Exception) { throw; }
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
            RemoveAllShortcuts
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
            string strShortcutGroupConfigFile = strConfigfolder + this.strShortcutGroupConfigFile;

            if (!System.IO.File.Exists(strShortcutGroupConfigFile))
            {
                WriteLine("Invalid Shortcut Group Settings File: " + strShortcutGroupConfigFile);
                return;
            }


            WriteLine("Getting Group Name Config");

            //Check if the file exists
            DataSet ds = null;

            //Read the shortcut file
            ds = new DataSet();
            ds.ReadXml(strShortcutGroupConfigFile);

            if (ds.Tables.Count == 0)
            {
                WriteLine("No Shortcuts to remove!");
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Get the group name
                    string strGroupName = dr["name"].ToString();

                    //get the full path
                    string strShortcutFile = strShortcutFolder + @strGroupName + ".xml";

                    WriteLine("Loading Group: " + strGroupName);

                    //locate file. If it exists, load the items
                    if (System.IO.File.Exists(strShortcutFile))
                    {

                        //Read all items of the group
                        DataSet dsItems = new DataSet();
                        dsItems.ReadXml(strShortcutFile);


                        //Loop all records
                        foreach (DataRow subDr in dsItems.Tables[0].Rows)
                        {

                            //Get the application name
                            string strApplicationName = subDr["text"].ToString();


                            //Get the application path
                            string strApplication = GetApplicationPart(subDr["application"].ToString());


                            //only patch FILES that exists
                            if (System.IO.File.Exists(strApplication))
                            {

                                //Only Patch EXEs
                                if (System.IO.Path.GetExtension(strApplication).ToLower() == ".exe")
                                {
                                    //Try to extract the icon file
                                    try
                                    {
                                        Write(string.Format("Extracting Icon: {0}", strApplication));
                                        Libraries.IconExtractor extractor = new Libraries.IconExtractor(strApplication);

                                        //Gets the first icon in the Executable
                                        System.Drawing.Icon ico = extractor.GetIcon(0);

                                        //create unique name
                                        string uniqueFilename = System.IO.Path.GetFileNameWithoutExtension(strApplication);
                                        string strIconPath = strIconFolder + uniqueFilename + ".ico";
                                        strIconPath = CreateUniqueFilename(strIconPath);

                                        //Save the Icon using a FileStream
                                        using (System.IO.FileStream fs = new System.IO.FileStream(strIconPath, System.IO.FileMode.OpenOrCreate))
                                        {
                                            ico.Save(fs);
                                            fs.Close();
                                            fs.Dispose();
                                        }
                                        WriteLine("\tExtracted\n");

                                        //Patch the datarow
                                        subDr["icon"] = System.IO.Path.GetFileName(strIconPath);
                                    }
                                    catch (Exception)
                                    {
                                        //display error
                                        MessageBox.Show(
                                            "Unable to extract icon for [" + strGroupName + "/" + strApplicationName + "]",
                                            "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }

                        //Update the shortcut file
                        dsItems.WriteXml(strShortcutFile);
                    }
                }
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
        private void ClearUnusedIcons()
        {
            string strDefaultIconMapConfigFile = strConfigfolder + this.strDefaultIconMapConfigFile;
            string strShortcutGroupConfigFile = strConfigfolder + this.strShortcutGroupConfigFile;

            if (!System.IO.File.Exists(strDefaultIconMapConfigFile))
            {
                WriteLine("Invalid Default Icon Map Settings File: " + strDefaultIconMapConfigFile);
                return;
            }

            //Check if the file exists
            DataSet ds = null;

            WriteLine("Getting Default Icon Files");
            //Read the shortcut file
            ds = new DataSet();
            ds.ReadXml(strDefaultIconMapConfigFile);

            List<string> lstIcons = new List<string>();
            foreach (DataRow drIcon in ds.Tables[0].Rows)
            {
                if (drIcon["icon"] != null)
                    if (!string.IsNullOrEmpty(drIcon["icon"].ToString()))
                        lstIcons.Add(drIcon["icon"].ToString());

            }


            if (System.IO.File.Exists(strShortcutGroupConfigFile))
            {
                WriteLine("Getting Icons used in groups");

                //Read the shortcut file
                ds = new DataSet();
                ds.ReadXml(strShortcutGroupConfigFile);

                if (ds.Tables.Count == 0)
                {
                    WriteLine("No Shortcut groups found!");

                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //Get the group name
                            string strGroupName = dr["name"].ToString();

                            //get the full path
                            string strShortcutFile = strShortcutFolder + @strGroupName + ".xml";

                            //locate file. If it exists, load the items
                            if (System.IO.File.Exists(strShortcutFile))
                            {

                                //Read all items of the group
                                DataSet dsItems = new DataSet();
                                dsItems.ReadXml(strShortcutFile);


                                //Loop all records
                                foreach (DataRow subDr in dsItems.Tables[0].Rows)
                                {
                                    if (subDr["icon"] != null)
                                        if (!string.IsNullOrEmpty(subDr["icon"].ToString()))
                                            if (!lstIcons.Contains(subDr["icon"].ToString()))
                                                lstIcons.Add(subDr["icon"].ToString());
                                }
                            }
                        }
                    }
                }
            }

            lstIcons.Add("unknown.ico");


            string[] lstAllIcons = System.IO.Directory.GetFiles(this.strIconFolder);
            List<string> lstToRemove = new List<string>();

            WriteLine("Generating List to remove");
            foreach (string strIcon in lstAllIcons)
            {
                System.IO.FileInfo inf = new System.IO.FileInfo(strIcon);
                string strFilename = inf.Name;
                if (inf.Extension == ".ico")
                {
                    if (!lstIcons.Contains(strFilename))
                    {
                        lstToRemove.Add(strFilename);
                    }
                }
            }

            WriteLine("Removing Unused Icons");
            foreach (string strIconToRemove in lstToRemove)
            {
                try
                {
                    WriteLine("Removing.." + strIconToRemove);
                    System.IO.File.Delete(strIconFolder + strIconToRemove);
                    
                }
                catch (Exception ex)
                {
                    WriteLine("Unable to delete file: " + strIconToRemove + ".\nError: " + ex.ToString());
                }
            }
        }

        private void RemoveCustomIcons()
        {
            string strDefaultIconMapConfigFile = strConfigfolder + this.strDefaultIconMapConfigFile;
            if (!System.IO.File.Exists(strDefaultIconMapConfigFile))
            {
                WriteLine("Invalid Default Icon Map Settings File: " + strDefaultIconMapConfigFile);
                return;
            }

            //Check if the file exists
            DataSet ds = null;

            //Read the shortcut file
            ds = new DataSet();
            ds.ReadXml(strDefaultIconMapConfigFile);

            WriteLine("Getting default icon list");

            List<string> lstIcons = new List<string>();
            foreach (DataRow drIcon in ds.Tables[0].Rows)
            {
                if (drIcon["icon"] != null)
                    if (!string.IsNullOrEmpty(drIcon["icon"].ToString()))
                        lstIcons.Add(drIcon["icon"].ToString());

            }

            lstIcons.Add("unknown.ico");

            WriteLine("Getting all icon files in folder");
            string[] lstAllIcons = System.IO.Directory.GetFiles(this.strIconFolder);
            List<string> lstToRemove = new List<string>();

            WriteLine("Generating List to remove");
            foreach (string strIcon in lstAllIcons)
            {
                System.IO.FileInfo inf = new System.IO.FileInfo(strIcon);
                string strFilename = inf.Name;
                if (inf.Extension == ".ico")
                {
                    if (!lstIcons.Contains(strFilename))
                    {
                        lstToRemove.Add(strFilename);
                    }
                }
            }

            WriteLine("Removing Custom Icons");
            foreach (string strIconToRemove in lstToRemove)
            {
                try
                {
                    WriteLine("Removing.." + strIconToRemove);
                    System.IO.File.Delete(strIconFolder + strIconToRemove);
                }
                catch (Exception ex)
                {
                    Write("Unable to delete file: " + strIconToRemove + ".\nError: " + ex.ToString());
                }
            }
        }

        private void FixApplicationPaths()
        {
            string strShortcutGroupConfigFile = strConfigfolder + this.strShortcutGroupConfigFile;

            if (!System.IO.File.Exists(strShortcutGroupConfigFile))
            {
                WriteLine("Invalid Shortcut Group Settings File: " + strShortcutGroupConfigFile);
                return;
            }

            WriteLine("Getting Group Names");

            //Check if the file exists
            DataSet ds = null;

            //Read the shortcut file
            ds = new DataSet();
            ds.ReadXml(strShortcutGroupConfigFile);

            if (ds.Tables.Count == 0)
            {
                WriteLine("No Shortcuts patch path!");
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Get the group name
                    string strGroupName = dr["name"].ToString();

                    //get the full path
                    string strShortcutFile = strShortcutFolder + @strGroupName + ".xml";

                    

                    //locate file. If it exists, load the items
                    if (System.IO.File.Exists(strShortcutFile))
                    {
                        WriteLine("Patching Group: " + strGroupName);

                        //Read all items of the group
                        DataSet dsItems = new DataSet();
                        dsItems.ReadXml(strShortcutFile);

                        //Loop all records
                        foreach (DataRow subDr in dsItems.Tables[0].Rows)
                        {

                            //Get the application name
                            string strApplicationName = subDr["text"].ToString();


                            //Get the application path
                            string strApplication = subDr["application"].ToString();


                            if (strApplication[0] != '\"')
                            {
                                strApplication = "\"" + strApplication + "\"";
                                subDr["application"] = strApplication;
                            }
                        }

                        //Update the shortcut file
                        WriteLine("Saving Group: " + strGroupName);
                        dsItems.WriteXml(strShortcutFile);
                    }
                }
            }
        }

        private void AssignShortcutIds()
        {
            string strShortcutGroupConfigFile = strConfigfolder + this.strShortcutGroupConfigFile;

            if (!System.IO.File.Exists(strShortcutGroupConfigFile))
            {
                WriteLine("Invalid Shortcut Group Settings File: " + strShortcutGroupConfigFile);
                return;
            }

            WriteLine("Getting Group Names");

            //Check if the file exists
            DataSet ds = null;

            //Read the shortcut file
            ds = new DataSet();
            ds.ReadXml(strShortcutGroupConfigFile);

            if (ds.Tables.Count == 0)
            {
                WriteLine("No Shortcuts to assign Ids!");
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Get the group name
                    string strGroupName = dr["name"].ToString();

                    //get the full path
                    string strShortcutFile = strShortcutFolder + @strGroupName + ".xml";

                    //locate file. If it exists, load the items
                    if (System.IO.File.Exists(strShortcutFile))
                    {
                        WriteLine("Patching Group: " + strGroupName);

                        //Read all items of the group
                        DataSet dsItems = new DataSet();
                        dsItems.ReadXml(strShortcutFile);

                        if (dsItems.Tables[0].Columns.Contains("id"))
                        {
                            dsItems.Tables[0].Columns.Remove("id");
                        }

                        if (!dsItems.Tables[0].Columns.Contains("id"))
                        {
                            dsItems.Tables[0].Columns.Add("id");
                            //Loop all records
                            foreach (DataRow subDr in dsItems.Tables[0].Rows)
                            {
                                subDr["id"] = Guid.NewGuid().ToString();
                            }
                        }

                        //Update the shortcut file
                        WriteLine("Saving Group: " + strGroupName);
                        dsItems.WriteXml(strShortcutFile);
                    }
                }
            }
        }

        private void RemoveAllShortcuts()
        {
            string strDefaultIconMapConfigFile = strConfigfolder + this.strDefaultIconMapConfigFile;
            string strShortcutGroupConfigFile = strConfigfolder + this.strShortcutGroupConfigFile;

            if (!System.IO.File.Exists(strShortcutGroupConfigFile))
            {
                WriteLine("No Shortcut File Found!");
                return;
            }

            WriteLine("Get Group Name Settings");

            //Check if the file exists
            DataSet ds = null;

            //Read the shortcut file
            ds = new DataSet();
            ds.ReadXml(strShortcutGroupConfigFile);

            if (ds.Tables.Count == 0)
            {
                WriteLine("No Shortcuts to remove!");
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Get the group name
                    string strGroupName = dr["name"].ToString();

                    //get the full path
                    string strShortcutFile = strShortcutFolder + @strGroupName + ".xml";

                    //locate file. If it exists, load the items
                    if (System.IO.File.Exists(strShortcutFile))
                    {
                        WriteLine("Removing " + strGroupName);

                        try
                        {
                            System.IO.File.Delete(strShortcutFile);
                        }
                        catch (Exception) { }
                    }
                }
            }

            WriteLine("Updating Group Name Config");
            ds = new DataSet("shortcuts");
            ds.WriteXml(strShortcutGroupConfigFile);

            RemoveCustomIcons();
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
	}
}