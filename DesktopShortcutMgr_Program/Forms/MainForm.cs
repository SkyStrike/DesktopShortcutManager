using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using DesktopShortcutMgr.Modules;
using DesktopShortcutMgr.Entity;

namespace DesktopShortcutMgr.Forms
{
	/// <summary>
	/// <![CDATA[
	/// --------------------------------------------------------------------------------------
	/// Visit My Website |
	/// ------------------
	/// Custom Apps Code Repository
	/// - https://docs.google.com/leaf?id=0BzXiotnC8aoGN2EwMmQyZjktZDk0MS00ZTMyLWJkZWUtMWY5ZWY5ODU1ZjUw&hl=en_GB
	/// 
	/// Deskop Shortcut Manager Repository
	/// - Main Folder   : https://docs.google.com/leaf?id=0BzXiotnC8aoGYzY3ODJiYjktYzM3My00ZmU5LTkxNzItZjY0OWY5NzE4Nzli&hl=en_GB
	/// - Source Files  : https://docs.google.com/leaf?id=0BzXiotnC8aoGMjYwYzEyMzItNDY0OC00MTk4LWJjZDMtYzJjZjIxMjFlMjlk&hl=en_GB
	/// - Binaries Only : https://docs.google.com/leaf?id=0BzXiotnC8aoGMDdkY2Q2MjktOWNlZi00MDczLWFiODMtMmZjMmM4YzkwZjdl&hl=en_GB
	/// 
	/// My WordPress Blog
	/// - http://ykgoh.wordpress.com
	/// 
	/// --------------------------------------------------------------------------------------
	/// Changes In a Glance |
	/// ---------------------
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.7.0  | Released: 2018.05.16 |
	/// ---------------------------------------
	///		- Changed target framework to .NET 4.0.
	///		- Default "Add Group" dialog to focus on "Submit" button.
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.10  | Released: 2011.09.01 |
	/// ---------------------------------------
	///     - Fix
	///         - Fixed a bug where launching from the Startup folder may cause the patching program to 
	///           fail (as in, config file not found or along those line)
	/// 
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.9  | Released: 2011.08.10 |
	/// ---------------------------------------
	///     - Fix
	///         - Fixed the Execution of shortcuts via Shortcut keys
	///         - Reversioned the programs...
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.8  | Released: 2011.08.10 |
	/// ---------------------------------------
	///     - Enhancement & Fixes
	///         - Changed the Export All Shortcut to a Display all Shortcut Keys...
	///         - Another Attempt Optimisation....not going too well. Memory seems to be gathering at AddItem
	///         - Added Visit my Google Docs and Visit my Blog links in Options form.
	///         - Provides links to the configuration files and folder in Options.
	///         
	///         - Fixed the extracting of icon to create unique name instead of overriding existing icon. 
	///           this will also cause duplicates...
	///         - The Icon now removes itself from System Tray when Program Closes.
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.7  | Released: 2011.08.03 |
	/// ---------------------------------------
	///     - Enhancement
	///         -   Added function to allow exporting of shortcuts back to desktop shortcut
	///         
	///     - Bug Fix
	///         -   Icons are not named corrected when extracted....can't believe I did not notice it..
	/// 
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.6  | Released: 2011.07.28 |
	/// ---------------------------------------
	///     - Bug Fix
	///         -   Fixed Patching library.
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.5  | Released: 2011.01.07 |
	/// ---------------------------------------
	///     - Enhancement
	///         -   Made SelectGroup run on a New Thread. 
	///             !!! Testing to see if it helps to reduce lagging when selecting group !!!
	///         
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.4  | Released: 2010.12.09 |
	/// ---------------------------------------
	///     - Enhancement
	///         -   Added function to allow Moving/Copying Shortcuts to other groups
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.3  | Released: 2010.09.02 |
	/// ---------------------------------------
	///     - Bug Fix
	///         -   Fix broken menus for shortcut group selection
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.2  | Released: 2010.09.01 |
	/// ---------------------------------------
	///     - Bug Fix
	///         -   The shortcut F1-12 was not working after the last version. Fixed
	///         
	///     - Enhancement
	///         -   Added an option to allow show/hide of the mini panel (defaulted to Show)
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.6.1  | Released: 2010.08.30 |
	/// ---------------------------------------
	///     - Maintainence (Requires Patching)
	///         -   Added a ID to all shortcuts. This will also help when renaming shortuts. 
	///             Previously there is a bug whereby you rename to the same name for the same 
	///             shortcut and the program disallows
	///         -   To Patch the program, execute
	///                 P:AssignShortcutIds
	///         
	///         -   Patch Program added more functions to remove all custom icons 
	///             (easier for me to distribute without my custom icons)
	///                 P:RemoveCustomIcons
	///                 P:RemoveAllShortcuts
	///                 
	///             -   RemoveCustomIcons will remove all icons that are not in the default icon mapping configuration
	///             -   RemoveAllShortcuts removes all shortcut groups and reset icons to default
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.5.5  | Released: 2010.08.30 |
	/// ---------------------------------------
	///     - Feature Enhancement
	///         -   Added a search shortcut feature.
	///         -   Moved a couple of functions to the CustomLibraries.UserFunctions and IconMap.
	///             -   UserFunctions
	///                 -   ExecuteProgram
	///                 -   OpenProgramParent
	///                 
	///             -   IconMap
	///                 -   GetDefaultIcon
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.5.4  | Released: 2010.08.06 |
	/// ---------------------------------------
	///     - Minor Enhancement
	///         -   Shortcut's working directory is where the exe is located. This will fix 
	///             some issues whereby the executable requires some of the dll/config files 
	///             located in the same folder
	///             
	/// --------------------------------------------------------------------------------------
	/// Version 1.5.3  | Released: 2010.05.25 |
	/// ---------------------------------------
	///     - Feature Enhancement
	///         - Allows Mouse Click (Single Click) to show the shortcut
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.5.2  | Released: 2010.04.21 |
	/// ---------------------------------------
	///     - Feature Enhancement
	///         - Allows exporting of program shortcuts to a text file
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.5.1  | Released: 2009.11.10 |
	/// ---------------------------------------
	///     - Program Maintainence
	///         - Splitted the custom controls into a new dll project libararies
	///             - CustomLibraries
	///                 Contains all shared libraries used. Currently it consist of
	///                     - IconExtractor
	///                     - UserFunctions -> all generic functions that can be cross shared
	///                 
	///             - CustomControls
	///                 Contains all shared controls. This includes
	///                     - KnownColorPicker
	///                     - VerticalLabel
	///         
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.4.4  | Released: 2009.11.09 |
	/// ---------------------------------------
	///     - Feature Enhancement
	///         - Allow launching of selected multiple programs (shows prompting)
	///         - Allows supressing of the prompt when launching multiple programs. 
	///           This can be found in the Options > Behaviour
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.4.3  | Released: 2009.11.06 |
	/// ---------------------------------------
	///     - Feature Enhancement
	///         - Allows Color of the Shortcut Bar and it's text to be changed. 
	///           Colors can be set in the Options form
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.4.2  | Released: 2009.11.05 |
	/// ---------------------------------------
	///     - Bug Fix
	///         - After selecting a background image from the Options form (when the default is no image), 
	///           on Cancel, the Background Image remains.
	///         - The "Options" Form title was overriden by the About tab's text.
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.4.1  | Released: 2009.10.30 |
	/// ---------------------------------------
	///     - Feature Enhancement
	///         - Allows arguments in the application path. 
	///           (undiscovered bugs may arise due to this)
	///             use "P:FixApplicationPaths" to fix the application paths
	///         
	///     - Bug Fix
	///         - Drag & Drop Executable's icon path is not saved
	///         
	///     - Program Maintainence
	///         - Updated Patching subroutine
	///             - Just pass in a config file Patcher "PatcherConfig.xml" and the 
	///               patch library will handle the rest
	///             
	///         - Implemented a Class AppConfig.cs to hold all global variables like
	///             - strAppPath
	///             - strConfigFolder
	///             - strIconFolder
	///             - etc...
	///         
	///         - Moved configuration files like Shortcuts.xml & DefaultIconMapping.xml to 
	///           a new folder: Config
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.3.3  | Released: 2009.10.27 |
	/// ---------------------------------------
	///     - Feature Enhancement
	///         - Allows Icon to be changed from the properties dialog
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.3.2  | Released: 2009.10.26 |
	/// ---------------------------------------
	///     - Bug Fix
	///         - Previous Feature enhancement (ListView ContextMenu item) causes the 
	///           F1-F9 to stop functioning.
	///           
	///     - Feature Enhancement
	///         - Added "Properties" to the listview context menu item. Hopefully in the 
	///           future can allow changes to the shortcut item.
	///           
	///         - Allows Custom Sorting of Group
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.3.1  | Released: 2009.10.24 |
	/// ---------------------------------------
	///     - Bug Fix
	///          - Unable to create Group since not sure when....
	///          
	///     - Feature Enhancements
	///          - Ablility to have context menu on the list view items 
	///                - Execute
	///                - Open Parent Directory
	///                - Rename
	///                - Delete
	///                
	///          - The Patch Module is now a seperated component library. 
	///            Btw, now patching command line requires a "P:" infront (case sensitive)
	///            e.g. "P:RebuildIcons"
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.2.3  | Released: 2009.10.23 |
	/// ---------------------------------------
	///     - Bug Fix
	///          - Folders/Documents are not able to be added unless they are shortcuts coming from exe
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.2.2  | Released: 2009.10.21 |
	/// ---------------------------------------
	///     - Bug Fix
	///          - Icons of Exe programs are not extracted
	///       
	/// --------------------------------------------------------------------------------------
	/// Version 1.2.1  | Released: 2009.10.15 |
	/// ---------------------------------------
	///     - Allows Icons to be extracted when new Exe applications shortcuts are added. Credits to 
	///       Tsuda Kageyu, http://www.codeproject.com/KB/cs/IconExtractor.aspx
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.0.7  | Released: 2009.09.24 |
	/// ---------------------------------------
	///     - Added New Options
	///         - Changable Background Image
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.0.6  | Released: 2009.08.31 |
	/// ---------------------------------------
	///     - Bug Fix
	///         - Program crashes when the moust double click on the side of 
	///           the item and the item is not selected
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.0.5  | Released: 2009.07.23 |
	/// ---------------------------------------
	///     - Bug Fix
	///         - 1 of the "Load" method used a default 
	///           location (e.g. System32 folder or Documents & Settings folder) 
	///           to load the file causing the program to crash.
	/// 
	/// --------------------------------------------------------------------------------------          
	/// Version 1.0.4  | Released: 2009.07.22 |
	/// ---------------------------------------
	///     - Bug Fix
	///         - The "Run on Startup" works now.
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.0.3  | Released: 2009.07.21 |
	/// ---------------------------------------
	///     - Added New Options
	///         - Expand & Contract Style (Appear or Hover)
	///         - Auto Startup (Administrators only)
	///     - Added Shortcuts (F1 - F12) for Group Selection
	///     - Pressing Enter when an icon is selected will execute the program
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.0.2  | Released: 2009.07.18 |
	/// ---------------------------------------
	///     - Bug Fix
	///         - No longer allows creation of group name with empty name
	///     - New Options to allow sorting of Group (Move up, Down, To Top, To Bottom)
	///     - New Options in the left menu to allow sorting icons by Ascending or Descending
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.0.1  | Released: 2009.07.17 |
	/// ---------------------------------------
	///     - Added a option control for the Default Icon Mappings
	/// 
	/// --------------------------------------------------------------------------------------
	/// Version 1.0.0  | Released: 2009.07.09 |
	/// ---------------------------------------
	///     - Allows multiple delete of shortcuts
	///     - Shows Tooltips on Icon to display target path/exe
	///     - Added a context menu to the Notifiy Icon
	///     - Allow users to change opacity of the bar.
	///     - Always on top option at the main context menu
	///     - Docking Panel'strFilename codes came from babarjehangir, December 15th, 2008, http://www.dottostring.com/tag/windows-form/
	///     
	/// ]]>
	/// </summary>
	public partial class MainForm : Form
    {
        private string currentGroupName = string.Empty;
        private const string programName = "Shortcut Manager";


		//global variables
		private bool AttemptedPatch = false;
		private Thread GroupSelectorThread = null;


		#region Delegates

		delegate void ClearItemsCallBack();
        delegate void PanelAddControlCallBack(Control ctrl);
        delegate void lvShortcutsAddItemCallBack(ListViewItem l);
        delegate void SetStringCallBack(string s);
        delegate void SetToolStripMenuItemCheckedStateCallBack(ContextMenuStrip msParent, ToolStripMenuItem itm, bool bln);
        delegate void AddImageListIconCallBack(ImageList imgList, Icon icn);

        #endregion

        public MainForm()
        {
			//checks that the default files are there before the program continues.
			StartupCheck();

			InitializeComponent();
            this.vlblMain.Text = programName;
            notifyIcon1.Text = programName + " v" + Application.ProductVersion;

            //If there are commands to be executed
            ExecuteStartupCommand(Environment.GetCommandLineArgs());
            try
            {
                Properties.Settings.Default.Upgrade();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to upgrade Settings. Error: ", ex);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
			/*
             * Load some dynamic shortcuts
             * Alt + 1 = Execute Application 1
             * ...
             * ...
             * ...
             * Alt + 9 = Execute Application 9
             */
			PreloadShortcuts();

            //Load the shortcuts
            LoadShortcutGroups();


            //Load initial Settings
            LoadSettings();

            //Configure the bar
            ConfigureThis(GetUserSize());

            //Hide the items that should not be visible. HIDE not VISIBILITY=FALSE
            this.tbGroupName.Hide();
            this.btnMainMenu.Hide();

            DockIn();
            Test();
        }

        private void Test()
        {

		}

		#region Other Form Events

		//Renaming the group
		private void lblGroupName_DoubleClick(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (ToolStripItem itm in ctxMnuListView.Items)
            {
                if (itm.GetType() == typeof(ToolStripMenuItem))
                {
                    if (((ToolStripMenuItem)itm).Checked)
                    {
                        counter += 1;
                        break;
                    }
                }
            }

            //if no group is selected, exit function
            if (counter <= 0) { return; }


            //Show the textbox to make it looks like the label is editable
            lblGroupName.Hide();
            tbGroupName.Show();
            tbGroupName.Focus();
            tbGroupName.Text = lblGroupName.Text;
            tbGroupName.SelectAll();
        }

		//Textbox Group name Lost focus event. Rename group when lost focus. If new group name is empty, ignore
		private void tbGroupName_LostFocus(object sender, System.EventArgs e)
        {
            string oldGroupName = lblGroupName.Text;
            string newGroupName = tbGroupName.Text;

            lblGroupName.Show();
            tbGroupName.Hide();

            RenameGroup(oldGroupName, newGroupName);
        }

		//Show the bar
		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowShortcutBar();
            if (IsDockedIn()) { DockOut(); }
        }

		//Show the bar
		private void notifyIcon1_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(sender, null);
        }

		//Remove Icon when form closes
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notifyIcon1 != null)
            {
                notifyIcon1.Visible = false;
                notifyIcon1.Icon = null;
                notifyIcon1.Dispose();
            }
        }

		#endregion


		#region List View Events

		//Double click action for ListView
		private void lvShortcuts_DoubleClick(object sender, System.EventArgs e)
        {
            //if there is something selected, then try to execute
            if (lvShortcuts.SelectedItems != null)
            {
                if (lvShortcuts.SelectedItems.Count > 0)
                {
                    if (lvShortcuts.SelectedItems.Count > 1)
                    {
                        //Launching multiple program, prompt for confirmation

                        bool supressPrompt = Properties.Settings.Default.SupressPromptMultipleProgram;
                        bool proceed = false;
                        if (!supressPrompt)
                        {
                            proceed = MessageBox.Show(
                                "You are about to launch more than 1 program.\nThis may cause the computer to lag/hang.\nDo you wish to continue? \n\nTo turn off this prompt, check the option in \n\t[Options] \n\t\t> [Behaviour] \n\t\t\t> 'Supress Prompting when launching multiple selected programs'",
                                "Multiple Program Launch",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                        }
                        else
                        {
                            proceed = true;
                        }

                        if (proceed)
                        {
                            foreach (ListViewItem liSelectedItem in lvShortcuts.SelectedItems)
                            {
                                if (liSelectedItem != null)
									CommonUtil.ExecuteProgram((ShortcutItem)liSelectedItem.Tag);
                            }
                        }
                    }
                    else
                    {
                        //Launching single program
                        if (lvShortcuts.SelectedItems[0] != null)
                        {
							CommonUtil.ExecuteProgram(GetSelectedListViewItem());
                        }
                    }
                }
            }
        }

		//Check for the delete button press event.
		private void lvShortcuts_KeyUp(object sender, KeyEventArgs e)
        {
            //check for delete key
            if (e.KeyCode == Keys.Delete && itemEditing == null)
            {
                DeleteListViewItem();
            }

            //Execute the file if the label is not in edit mode and the enter is pressed, execute the file
            else if (e.KeyCode == Keys.Enter && itemEditing == null)
            {
                if (lvShortcuts.SelectedItems.Count > 0)
                {
                    lvShortcuts_DoubleClick(sender, e);
                }
            }
        }

		//Handles the context menu showing
		private void lvShortcuts_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem itm;
                itm = lvShortcuts.GetItemAt(e.X, e.Y);
                if (itm != null)
                {
                    this.ctxMnuListViewItem.Show(this.lvShortcuts, new Point(e.X, e.Y));
                }
                else
                {
                    this.ctxMnuListView.Show(this.lvShortcuts, new Point(e.X, e.Y));
                }
            }
        }

        #region Editing Icon Text

        //Contains the name of the currently editing icon
        ShortcutItem itemEditing = null;

		//Before editing label, get the original item text
		private void lvShortcuts_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            itemEditing = (ShortcutItem) lvShortcuts.SelectedItems[0].Tag;
        }

		//Save the new value after editing if it is unique
		private void lvShortcuts_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            //ensure that the new name is not empty.
            if (string.IsNullOrEmpty(e.Label))
            {
                itemEditing = null;
                e.CancelEdit = true;
                return;
            }

			itemEditing.Text = e.Label;
			ShortcutUtil.UpdateShortcut(currentGroupName, itemEditing);
            itemEditing = null;
        }

		#endregion

		#region Drag & Drop

		//Adding new items to group
		private void lvShortcuts_DragDrop(object sender, DragEventArgs e)
        {
            string strFolderName = currentGroupName;

            //Gets all files dropped
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string strShortcutFile = string.Empty;
            //DataSet ds = null;

			//if no folder is selected, auto create one.
			if (string.IsNullOrEmpty(strFolderName))
			{
				string strGroup = DateTime.Now.ToString("yyyyMMdd_hhmmss");
				
				//Create the group
				CreateGroup(strGroup);
				strShortcutFile = AppConfig.GetShortcutFile(strGroup);
				strFolderName = strGroup;
			}
			else {
				//Get the shortcut file
				strShortcutFile = AppConfig.GetShortcutFile(strFolderName);
			}

			List<ShortcutItem> newItems = ShortcutUtil.CreateShortcut(strShortcutFile, files);
			if (newItems.Count > 0) {
				foreach (var item in newItems)
				{
					AddItem(item);
				}
			}
		}

		//Show the "cursor effect"
		private void lvShortcuts_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                e.Effect = DragDropEffects.All;

        }

		#endregion

		#endregion



		#region ContextMenu - ListView

		//Delete Group
		private void listViewCtxMenuItem_Delete_Click(object sender, EventArgs e)
        {
            //Show confirmation message before proceeding to delete
            string strGroupName = ((ToolStripMenuItem)sender).Text;

            if (MessageBox.Show(
                "Are you sure you want to delete Group [" + strGroupName + "]?",
                "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteGroup(strGroupName);
            }
        }

		//Gets Shortcut from Group Name
		private void listViewCtxMenuItem_Selection_Click(object sender, EventArgs e)
        {
            string strGroupName = ((ToolStripMenuItem)sender).Text;
            SelectGroup(strGroupName);
        }

		#endregion



		#region ContextMenu - ListViewItem

		//Execute the program/folder/directory
		private void ctxMnuListViewItem_Execute_Click(object sender, EventArgs e)
        {
			CommonUtil.ExecuteProgram(GetSelectedListViewItem());
        }

		//Opens the program'strFilename parent directory
		private void ctxMnuListViewItem_OpenDirectory_Click(object sender, EventArgs e)
        {
			CommonUtil.OpenProgramParent(GetSelectedListViewItem());
		}

		//Renames an item
		private void ctxMnuListViewItem_Rename_Click(object sender, EventArgs e)
        {
            RenameItem();
        }

		//Deletes items
		private void ctxMnuListViewItem_Delete_Click(object sender, EventArgs e)
        {
            DeleteListViewItem();
        }

		//Shows the shortcut properties
		private void ctxMnuListViewItem_Properties_Click(object sender, EventArgs e)
        {
            ShowListViewItemProperties();
        }

		//Disable the current group in the list
		private void ctxMnuListViewItem_MoveTo_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in ctxMnuListViewItem_MoveTo.DropDownItems)
            {
                item.Enabled = (item.Text != currentGroupName);
            }
        }

		//Disable the current group in the list
		private void ctxMnuListViewItem_CopyTo_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in ctxMnuListViewItem_CopyTo.DropDownItems)
            {
                item.Enabled = (item.Text != currentGroupName);
            }
        }

		//Exports Item to Icon
		private void ctxMnuListViewItem_ExportToShortcut_Click(object sender, EventArgs e)
        {
			ShortcutItem selectedItem = GetSelectedListViewItem();

			string strCurrentShortcutName = selectedItem.Text;
			string strCurrentShortcutPath = selectedItem.Application;

            if (!selectedItem.IsValid())
            {
                if (MessageBox.Show("Shortcut is invalid, do you still want to export?", "Invalid Shortcut", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Shortcut File (*.lnk)|.lnk";
            sfd.FileName = strCurrentShortcutName;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
				selectedItem.CreateDesktopShortcut(System.IO.Path.GetDirectoryName(sfd.FileName), System.IO.Path.GetFileNameWithoutExtension(sfd.FileName), false);
            }
        }

		#endregion



		#region ContextMenu - Main

		//Add a new group
		private void ctxMnuMain_AddGroup_Click(object sender, EventArgs e)
        {
            //frmNewGroup frm = new frmNewGroup();
            TextReturnerForm frm = new TextReturnerForm("New Group Name", "Group Name", "Submit");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Create new group
                CreateGroup(frm.strReturnText);
            }
        }

        private void ctxMnuMain_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ctxMnuMain_Options_Click(object sender, EventArgs e)
        {
            OptionsForm frm = new OptionsForm();
            frm.opener = this;
            frm.ShowDialog();
            LoadShortcutGroups();

            frm.Dispose();
            frm = null;
        }

        private void ctxMnuMain_AlwaysOnTop_Click(object sender, EventArgs e)
        {
            this.TopMost = ctxMnuMain_AlwaysOnTop.Checked;
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            ctxMnuMain.Show((this.Location.X + btnMainMenu.Location.X + btnMainMenu.Width), btnMainMenu.Location.Y);
        }

        private void ctxMnuMain_Search_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm();
            search.ShowDialog();
            search = null;
        }

        private void ctxMnuMain_DisplayAllShortcutKeys_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            ShortcutLister libShortcutLister = new ShortcutLister();
            libShortcutLister.GetShortcuts(this, ref sb);

            TextDisplayForm frm = new TextDisplayForm("Shortcuts", sb.ToString());
            frm.ShowDialog();

            frm = null;
            sb = null;
            libShortcutLister = null;
        }


        private void ctxMnuMain_ExportShortcutToDesktop_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentGroupName))
            {
                ExportShortcutForm frm = new ExportShortcutForm();
                frm.ExportGroup(currentGroupName, false);
                frm = null;
            }
            else
            {
                MessageBox.Show("No Group Selected");
            }
        }

        private void ctxMnuMain_MoreExportOptions_Click(object sender, EventArgs e)
        {
            ExportShortcutForm frm = new ExportShortcutForm();
            frm.ShowDialog();
            frm = null;
        }

        #region Sorting Options

        private void ctxMnuMain_Sort_Asc_Click(object sender, EventArgs e)
        {
			ShortcutUtil.SortShortcuts(currentGroupName, "ASC");
        }

		private void ctxMnuMain_Sort_Desc_Click(object sender, EventArgs e)
        {
			ShortcutUtil.SortShortcuts(currentGroupName, "DESC");
        }

		//Opens the Custom Sorting Window
		private void ctxMnuMain_Sort_Custom_Click(object sender, EventArgs e)
        {
            CustomSortingForm frmCSort = new CustomSortingForm(lvShortcuts, imageList1);
            if (frmCSort.ShowDialog() == DialogResult.OK)
            {
                ListView lv = frmCSort.UpdatedListView();
				List<ShortcutItem> items = new List<ShortcutItem>();
				foreach (ListViewItem item in lv.Items)
				{
					items.Add((ShortcutItem) item.Tag);
				}

				string strShortcutFile = AppConfig.GetShortcutFile(currentGroupName);
				ShortcutUtil.UpdateMenuFile(strShortcutFile, new Shortcuts()
				{
					Items = items
				});

                SelectGroup(currentGroupName);
            }
            frmCSort = null;
        }

		#endregion

		#endregion

		#region Main Menu - Hidden

		//Launches the Options window
		private void mnuShortcut_Hidden_options_Click(object sender, EventArgs e)
        {
            ctxMnuMain_Options_Click(sender, e);
        }

        private void mnuShortcut_Hidden_Search_Click(object sender, EventArgs e)
        {
            ctxMnuMain_Search_Click(sender, e);
        }

		//Handles the Shortcut for Execution of Program
		private void ApplicationShortcut_Click(object sender, EventArgs e)
        {
            if (sender != null && sender is ToolStripMenuItem)
            {
                ToolStripMenuItem itm = (ToolStripMenuItem)sender;
                int selectedItemIdx = (int)itm.Tag;
                if (selectedItemIdx <= lvShortcuts.Items.Count)
                {
                    lvShortcuts.SelectedItems.Clear();
                    lvShortcuts.Items[selectedItemIdx - 1].Selected = true;
					CommonUtil.ExecuteProgram(GetSelectedListViewItem());
                }
            }
        }

		#endregion



		#region Dock In/Out
		/*
         * Credits for the Dock In/Dock Out should go to: babarjehangir, December 15th, 2008
         * 
         * http://www.dottostring.com/tag/windows-form/
         */

		//Gets The Screen Width Available for Work
		public int GetScreenWidth()
        {
            Rectangle recWorkingArea = new Rectangle();
            recWorkingArea = Screen.PrimaryScreen.WorkingArea;
            return recWorkingArea.Width;
        }

		//Gets The Screen Height Available for Work  
		public int GetScreenHeight()
        {
            Rectangle recWorkingArea = new Rectangle();
            recWorkingArea = Screen.PrimaryScreen.WorkingArea;
            return recWorkingArea.Height;
        }

		//Initialize the Docking Window Start Location
		private void ConfigureThis()
        {
            //Dynamically resizing the form to match the height available on the screen  
            this.Size = new Size(this.Width, GetScreenHeight());

            //Calculating the Horizontal Location of the Form (Docking Window)  
            //such that only the panel having the Docking Window'strFilename Navigation Control  
            //will be visible  

            int EndX = GetScreenWidth() - pVisiblePart.Width;
            this.Location = new System.Drawing.Point(EndX, 0);
            //Setting the Text of the Button which will act at the Navigation for Docking Window  
            this.btnDockUnDock.Text = "<<";
        }

		//Sets the height of the Shortcutbar
		public void ConfigureThis(int height)
        {
            //Dynamically resizing the form to match the height available on the screen  
            this.Size = new Size(this.Width, height);

            //Calculating the Horizontal Location of the Form (Docking Window)  
            //such that only the panel having the Docking Window'strFilename Navigation Control  
            //will be visible  

            int EndX = GetScreenWidth() - pVisiblePart.Width;
            this.Location = new System.Drawing.Point(EndX, 0);
            //Setting the Text of the Button which will act at the Navigation for Docking Window  
            this.btnDockUnDock.Text = "<<";
        }

        private void btnDockUnDock_Click(object sender, EventArgs e)
        {
            if (btnDockUnDock.Text.Trim().Equals("<<"))
                DockOut();
            else
                DockIn();
        }

        private bool IsDockedIn()
        {
            if (btnDockUnDock.Text.Trim().Equals("<<"))
                return true;
            else
                return false;
        }

		//Docking Window is brought to the front
		public void DockOut()
        {
            btnMainMenu.Show();
            pnlMiniPanel.Hide();

            switch ((OptionsForm.ExpandContractStyle)Properties.Settings.Default.ExpandContractStyle)
            {
                case OptionsForm.ExpandContractStyle.Hover:

                    //Starting Location of the Docking Window  
                    int StartX = this.Location.X;

                    //Calculating the final X Coordinate at which the docking window should  
                    //settle in order to be completely visible  
                    int EndX = GetScreenWidth() - this.Width;

                    //This loops does the trick for us, this will effectively simulate the  
                    //coming out effect to the docking window, eventually making the window  
                    //completely visible  
                    for (int i = StartX; i >= EndX; i--)
                    {
                        this.Location = new System.Drawing.Point(i, 0);
                    }
                    //Setting the final location (ensuring the final location)  
                    this.Location = new System.Drawing.Point(EndX, 0);

                    break;
                case OptionsForm.ExpandContractStyle.Appear:

                    this.Location = new System.Drawing.Point((GetScreenWidth() - this.Width), 0);

                    break;
                default:
                    break;
            }

            //Expand Full height
            this.Height = GetScreenHeight();



            this.btnDockUnDock.Text = ">>";
        }

		//Docking Window is Docked Back In  
		public void DockIn()
        {
            btnMainMenu.Hide();

            if (Properties.Settings.Default.ShowMiniPanel)
                pnlMiniPanel.Show();

            switch ((OptionsForm.ExpandContractStyle)Properties.Settings.Default.ExpandContractStyle)
            {
                case OptionsForm.ExpandContractStyle.Hover:

                    //Getting the Start Location for the loop  
                    int StartX = this.Location.X;

                    //Calculation the final x coordinate for the loop to finish  
                    int EndX = GetScreenWidth() - pVisiblePart.Width;

                    //This is loop will dock the window back in  
                    for (int i = StartX; i <= EndX; i++)
                    {
                        this.Location = new System.Drawing.Point(i, 0);
                    }
                    this.Location = new System.Drawing.Point(EndX, 0);

                    break;
                case OptionsForm.ExpandContractStyle.Appear:

                    this.Location = new System.Drawing.Point((GetScreenWidth() - pVisiblePart.Width), 0);


                    break;
                default:
                    break;
            }

            //Contract to user defined height
            this.Height = GetUserSize();



            this.btnDockUnDock.Text = "<<";
        }

		#endregion



		#region Form Functions

		//Get the user defined height for the bar
		private int GetUserSize()
        {
            int intReturn = ((int)((Properties.Settings.Default.IntialHeight / 100.0) * GetScreenHeight()));
            return intReturn;
        }

		//Gets the listview Width
		public int GetListViewWidth()
        {
            return lvShortcuts.Width;
        }

		//Gets the listview Height
		public int GetListViewHeight()
        {
            return lvShortcuts.Height;
        }

		//Gets the selected item'strFilename application path in the list view
		private ShortcutItem GetSelectedListViewItem()
        {
			return (ShortcutItem)lvShortcuts.SelectedItems[0].Tag;
        }

		//Gets the selected item'strFilename application path in the list view
		private string GetSelectedShortcutNameFromListView()
        {
            return GetSelectedListViewItem().Text;
        }

        private string GetSelectedShortcutIdFromListView()
        {
            return GetSelectedListViewItem().Id;
        }

		private void StartupCheck()
		{
			if (!System.IO.Directory.Exists(AppConfig.IconFolder))
			{
				System.IO.Directory.CreateDirectory(AppConfig.IconFolder);

				Icon ico = DesktopShortcutMgr.Properties.Resources.folder;
				string iconPath = System.IO.Path.Combine(AppConfig.IconFolder, "folder.ico");
				using (System.IO.FileStream fs = new System.IO.FileStream(iconPath, System.IO.FileMode.OpenOrCreate))
				{
					ico.Save(fs);
					fs.Close();
					fs.Dispose();
				}
			}
			if (!System.IO.Directory.Exists(AppConfig.ShortcutFolder))
			{
				System.IO.Directory.CreateDirectory(AppConfig.ShortcutFolder);
			}
			if (!System.IO.Directory.Exists(AppConfig.ConfigFolder))
			{
				System.IO.Directory.CreateDirectory(AppConfig.ConfigFolder);
			}


			if (!System.IO.File.Exists(AppConfig.BaseShortcutFile))
			{
				ShortcutUtil.UpdateGroup(new ShortcutGroup());

				Properties.Settings.Default.LastMenuLoaded = null;
				Properties.Settings.Default.Save();
				Properties.Settings.Default.Reload();
			}

			if (!System.IO.File.Exists(AppConfig.DefaultIconMappingFile))
			{
				IconMap iconMap = new IconMap() {
					Items = new List<IconMapItem>() {
						new IconMapItem() {
							Ext = "folder",
							Icon = "folder.ico"
						}
					}
				};
				IconMapperUtil.UpdateIconMapping(iconMap);
			}
		}

		//Loads dynamic shortcuts for generic use
		private void PreloadShortcuts()
        {
            ToolStripMenuItem itmMain = new ToolStripMenuItem("Execute Application");
            itmMain.Name = "ExeApp";
            itmMain.Text = "ExeApp";
            //itmMain.Visible = false;
            itmMain.Visible = true;

            for (int i = 1; i <= 9; i++)
            {
                ToolStripMenuItem itm = new ToolStripMenuItem("Execute App " + i);
                itm.Tag = i;
                Keys k = (Keys)(System.Enum.Parse(typeof(Keys), "D" + i.ToString()));
                itm.ShortcutKeys = Keys.Alt | k;
                itm.Click += new EventHandler(ApplicationShortcut_Click);
                itmMain.DropDown.Items.Add(itm);
            }
            mnuShortcutGroup.Items.Add(itmMain);
        }


		//[ThreadSafe] Set the title of the forms and other related labels
		private void SetTitle(string strTitle)
        {
            if (vlblMain.InvokeRequired || lblGroupName.InvokeRequired)
            {
                SetStringCallBack cb = new SetStringCallBack(SetTitle);
                this.Invoke(cb, new object[] { strTitle });
                cb = null;
            }
            else
            {
                //Set the labels in the form
                vlblMain.Text = programName + " - " + strTitle;
                lblGroupName.Text = strTitle;
            }
        }

		//Setting the opacity form
		public void SetOpacity(double dblOpacity) { this.Opacity = dblOpacity; }


		//Load settings from Settings File
		private void LoadSettings()
        {
            //Set the default view (Large Icons, Small Icons, List, Tile)
            //SetView(Properties.Settings.Default.DefaultView);

            //Set Opacity of the form
            SetOpacity(Properties.Settings.Default.Opacity);

			//Select last chosen group
			SelectGroup(Properties.Settings.Default.LastMenuLoaded);


			//Set the background image if not empty
			if (!string.IsNullOrEmpty(Properties.Settings.Default.BackgroundImagePath))
            {
                ChangeBackgroundImage(Properties.Settings.Default.BackgroundImagePath);
            }

            pnlMiniPanel.Visible = Properties.Settings.Default.ShowMiniPanel;

            ChangeShortcutBarColor(Color.FromName(Properties.Settings.Default.ShortcutBarColor));
            ChangeShortcutBarTextColor(Color.FromName(Properties.Settings.Default.ShortcutBarTextColor));
        }

		//Change the color of the bar
		public void ChangeShortcutBarColor(Color c)
        {
            lblGroupName.BackColor = c;
            tbGroupName.BackColor = c;
            vlblMain.BackColor = c;
            pVisiblePart.BackColor = c;
        }

		//change the color of the text in the bar
		public void ChangeShortcutBarTextColor(Color c)
        {
            vlblMain.ForeColor = c;
            lblGroupName.ForeColor = c;
            tbGroupName.ForeColor = c;
        }

		//Reset the form to original view without any group selected
		private void ClearToDefaultView()
        {
            vlblMain.Text = programName;
            lblGroupName.Text = programName;
            lvShortcuts.Items.Clear();
        }

		//Show the shortcut bar
		private void ShowShortcutBar()
        {
            SetForegroundWindow(Handle.ToInt32());
            //this.TopMost = true;
            //this.Focus();
            //this.TopMost = false;
        }

		//Change background image
		public void ChangeBackgroundImage(string strBackgroundImagePath)
        {
            if (System.IO.File.Exists(strBackgroundImagePath))
            {
                Image i = null;
                try
                {
                    i = System.Drawing.Image.FromFile(strBackgroundImagePath);
                    lvShortcuts.BackgroundImage = i;
                    i.Dispose();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Setting BackgroundImage");
                }
            }
            else
            {
                lvShortcuts.BackgroundImage = null;
            }
        }

		//Renames a listview item
		private void RenameItem()
        {
            if (lvShortcuts.SelectedItems != null)
            {
                lvShortcuts.SelectedItems[0].BeginEdit();
            }
        }

		//Deletes a listview item
		private void DeleteListViewItem()
        {
			List<ShortcutItem> itemsToDelete = new List<ShortcutItem>();
			if (lvShortcuts.SelectedItems.Count > 1)
			{
				if (MessageBox.Show("Are you sure you want to delete these shortcuts ?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					foreach (ListViewItem i in lvShortcuts.SelectedItems)
					{
						itemsToDelete.Add((ShortcutItem)i.Tag);
					}
				}
				else {
					return;
				}
			}
			else
			{
				ShortcutItem selectedItem = ((ShortcutItem)lvShortcuts.SelectedItems[0].Tag);
				string idToDelete = selectedItem.Id;
				string strItemToDelete = selectedItem.Text;

				//ask for confirmation
				if (MessageBox.Show("Are you sure you want to delete shortcut [" + strItemToDelete + "]?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					itemsToDelete.Add(selectedItem);
				}
				else
				{
					return;
				}
			}

			if (itemsToDelete.Count > 0)
			{
				if (ShortcutUtil.DeleteShortcut(currentGroupName, itemsToDelete.ToArray()))
				{
					SelectGroup(currentGroupName);
				}
			}
        }

		//Shows the shortcut properties
		private void ShowListViewItemProperties()
        {

			ShortcutItem selectedItem = GetSelectedListViewItem();

			string strCurrentShortcutName = selectedItem.Text;
			string strCurrentShortcutPath = selectedItem.Application;

			Console.WriteLine(selectedItem.IconPath);

			//New Properties form
			ShortcutPropertiesForm frmProp = new ShortcutPropertiesForm()
			{
				ShortcutItem = selectedItem
			};

			frmProp.FrmOpener = this;


            //If OK, make the changes
            if (frmProp.ShowDialog() == DialogResult.OK)
            {
				ShortcutItem editedItem = frmProp.ShortcutItem;
                string strSelectedIcon = editedItem.IconPath;
                if (!string.IsNullOrEmpty(strSelectedIcon))
                {
                    string strSelectedIconFolder = System.IO.Path.GetDirectoryName(strSelectedIcon) + "\\";

                    //If same path, copy the icons to the program'strFilename system directory
                    if (string.Compare(strSelectedIconFolder, AppConfig.IconFolder, true) != 0)
                    {
                        string strIconName = System.IO.Path.GetFileName(strSelectedIcon);
                        System.IO.File.Copy(strSelectedIcon, AppConfig.GetIconMapFile(strIconName), true);
                        strSelectedIcon = strIconName;
                    }
                    else
                    {
                        strSelectedIcon = System.IO.Path.GetFileName(strSelectedIcon);
                    }
                }

				if (!ShortcutUtil.UpdateShortcut(currentGroupName, editedItem)) {
					ShowListViewItemProperties();
				}

                //Select the group
                SelectGroup(currentGroupName);

                //Select the item
                SelectItem(editedItem.Id);
            }

            if (frmProp != null)
            {
                frmProp.Dispose();
                frmProp = null;
            }
        }

        #region ShortcutFile Dataset

        //Writes to the base shortcut file
        private void UpdateAllGroupNameDataset(ref DataSet ds)
        {
            ds.WriteXml(AppConfig.BaseShortcutFile);
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : Undated</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Checks if the base shortcut file exists
        /// </summary>
        /// <returns></returns>
        private bool AllGroupNameDatasetExists()
        {
            return (System.IO.File.Exists(AppConfig.BaseShortcutFile));
        }


		#endregion

		//Perform patching based on the startup parameters
		private void ExecuteStartupCommand(string[] strCmd)
        {
            try
            {
                foreach (string cmd in strCmd)
                {
                    if (cmd.Length > 2)
                    {
                        if (cmd.Substring(0, 2) == "P:")
                        {
                            Patcher patcher = new Patcher();
							patcher.ApplyPatch(cmd.Substring(2));
                            patcher = null;
                        }
                        else
                        {
                            ExecuteCommand(cmd);
                        }
                    }
                    else
                    {
                        ExecuteCommand(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                CrashReporterForm rpt = new CrashReporterForm(ex);
                rpt.ShowDialog();
                rpt.Dispose();
                rpt = null;
            }
        }

        /// <summary>
        /// 2009 Oct 30
        /// Executes command. does nothing at this point in time
        /// </summary>
        /// <param name="cmd"></param>
        private void ExecuteCommand(string cmd)
        {
            switch (cmd)
            {
                default:
                    break;
            }
        }



		//[ThreadSafe] Clear all shortcuts from menu
		private void ClearItems()
        {
            if (lvShortcuts.InvokeRequired || pnlMiniPanel.InvokeRequired)
            {
                ClearItemsCallBack cb = new ClearItemsCallBack(ClearItems);
                this.Invoke(cb);
                cb = null;
            }
            else
            {
                lvShortcuts.Items.Clear();
                pnlMiniPanel.Controls.Clear();
                imageList1.Images.Clear();
                imageListSmall.Images.Clear();

                //There is already some memory leak before this collection..
                GC.Collect();
            }
        }

		//[ThreadSafe] Adds shortcut into the listview
		private void AddItem(ShortcutItem item)
        {
            Icon icn = null;

            //Load icon from path. If empty, try use the icons in the mappings
            if (string.IsNullOrEmpty(item.IconPath))
            {
                string strApplicationPart = CommonUtil.GetApplicationPart(item.Application);

                if (System.IO.Directory.Exists(strApplicationPart))
                {
                    //folder
                    icn = IconMapperUtil.GetDefaultIcon("folder");
                }
                else
                {
                    //get the default icons
                    string strExt = System.IO.Path.GetExtension(strApplicationPart).ToLower();
                    icn = IconMapperUtil.GetDefaultIcon(strExt);
                }
            }
            else
            {
                //Find in the icon folder first. if it exists, use it
                if (System.IO.File.Exists(AppConfig.GetIconMapFile(item.IconPath)))
                {
                    icn = CommonUtil.GetIcon(AppConfig.GetIconMapFile(item.IconPath));
                }

                //Locate the physical file directly. If exists, use it
                else if (System.IO.File.Exists(item.IconPath))
                {
                    icn = CommonUtil.GetIcon(item.IconPath);
                }

                //Use default icon
                else
                {
                    string strExt = System.IO.Path.GetExtension(CommonUtil.GetApplicationPart(item.Application)).ToLower();
                    icn = IconMapperUtil.GetDefaultIcon(strExt);
                }
            }

            //Add item to list so that it is viewable in the list
            AddImageListIcon(imageList1, icn);
            AddImageListIcon(imageListSmall, icn);

            icn.Dispose();
            icn = null;

            //Gets the shortcut for this item
            string strItemShortcut = "";
            ToolStripMenuItem itmMain = (ToolStripMenuItem)mnuShortcutGroup.Items["ExeApp"];

            if (itmMain.DropDown != null)
            {
                ToolStripMenuItem itm = null;
                if (itmMain.DropDown.Items.Count > lvShortcuts.Items.Count)
                {
                    itm = (ToolStripMenuItem)itmMain.DropDown.Items[lvShortcuts.Items.Count];
                    strItemShortcut = Environment.NewLine + " Shortcut: " + FormatShortcutString(itm.ShortcutKeys.ToString());
                }
                else
                {
                    strItemShortcut = "";
                }
            }
            else
            {
                ToolStripMenuItem itm = (ToolStripMenuItem)itmMain.DropDown.Items[0];
                strItemShortcut = Environment.NewLine + " Shortcut: " + FormatShortcutString(itm.ShortcutKeys.ToString());
            }

            //Creates button in the mini panel
            Button btn = new Button();
            //btn.Tag = item.Id;
			btn.Tag = item;
            btn.Image = imageListSmall.Images[imageList1.Images.Count - 1];
            btn.Margin = new Padding(1);
            btn.Size = new System.Drawing.Size((pnlMiniPanel.Width - btn.Margin.Left - btn.Margin.Right), (pnlMiniPanel.Width - btn.Margin.Top - btn.Margin.Bottom));
            btn.FlatStyle = FlatStyle.Flat;
            btn.Location = new Point(btn.Margin.Left, (btn.Height + btn.Margin.Bottom) * lvShortcuts.Items.Count);  //intShortcutIndex
			btn.Click += new EventHandler(btnMiniPanelShortcut_Click);
            pnlMiniPanelAddItem(btn);


            //create listview item
            ListViewItem l = new ListViewItem();
            l.ImageIndex = imageList1.Images.Count - 1;
            l.Text = item.Text;
            l.Name = item.Id;
			//l.Tag = item.Id;
			l.Tag = item;
			l.ToolTipText = item.Application + strItemShortcut;


            //Add list view item
            lvShortcutsAddItem(l);

            item = null;
        }

		//[ThreadSafe] Add Items to the MiniPanel
		private void pnlMiniPanelAddItem(Control ctrl)
        {
            if (pnlMiniPanel.InvokeRequired)
            {
                PanelAddControlCallBack cb = new PanelAddControlCallBack(pnlMiniPanelAddItem);
                this.Invoke(cb, new object[] { ctrl });
                cb = null;
            }
            else
            {
                pnlMiniPanel.Controls.Add(ctrl);
            }
        }

		//[ThreadSafe] Add items to the ListView
		private void lvShortcutsAddItem(ListViewItem l)
        {
            if (pnlMiniPanel.InvokeRequired)
            {
                lvShortcutsAddItemCallBack cb = new lvShortcutsAddItemCallBack(lvShortcutsAddItem);
                this.Invoke(cb, new object[] { l });
                cb = null;
            }
            else
            {
                lvShortcuts.Items.Add(l);
            }
        }

		//[ThreadSafe] Set ContextToolstripMenuItem checkstate
		private void SetCtxToolStripMenuItemCheckedState(ContextMenuStrip msParent, ToolStripMenuItem itm, bool bln)
        {
            if (msParent.InvokeRequired)
            {
                SetToolStripMenuItemCheckedStateCallBack cb = new SetToolStripMenuItemCheckedStateCallBack(SetCtxToolStripMenuItemCheckedState);
                this.Invoke(cb, new object[] { msParent, itm, bln });
                cb = null;
            }
            else
            {
                itm.Checked = bln;
            }
        }


		//[ThreadSafe] Add Icon to ImageList
		private void AddImageListIcon(ImageList imgList, Icon icn)
        {
            if (this.InvokeRequired)
            {
                AddImageListIconCallBack cb = new AddImageListIconCallBack(AddImageListIcon);
                this.Invoke(cb, new object[] { imgList, icn });
                cb = null;
            }
            else
            {
                imgList.Images.Add(icn);
            }
        }

        private void btnMiniPanelShortcut_Click(object sender, EventArgs e)
        {
            if (sender != null && sender is Button)
            {
				ShortcutItem item = (ShortcutItem)((Button)sender).Tag;
				CommonUtil.ExecuteProgram(item);
            }
        }

		#endregion

		#region Group Functions (Create/Rename/Delete/Select)

		//Load the Group Names for shortcuts from XML file
		private void LoadShortcutGroups()
        {
            DataSet ds = ShortcutUtil.GetShortcutGroups();


			//If the File does not exists, create a empty XML file with a Empty Root Element "Groups"
			if (!AllGroupNameDatasetExists())
            {
                ds = new DataSet("shortcuts");
                DataTable dt = new DataTable("Groups");
                ds.Tables.Add(dt);
                UpdateAllGroupNameDataset(ref ds);
            }


            //Ensure there is a root element
            if (ds.Tables.Count > 0)
            {

                //Ensure there are records in the group
                if (ds.Tables[0].Rows.Count > 0)
                {

                    //Clear the context menu
                    ctxMnuListView.Items.Clear();
                    ctxMnuMain_SelectGroup.DropDownItems.Clear();
                    ctxMnuMain_DeleteGroup.DropDownItems.Clear();

                    ctxMnuListViewItem_MoveTo.DropDownItems.Clear();
                    ctxMnuListViewItem_CopyTo.DropDownItems.Clear();

                    int intShortcutKey_ListView = 1;


                    //Loop each group in the Shortcuts.xml
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ToolStripMenuItem itm, itm_shortcutGrp, itm_selectGrp, itm_CopyTo, itm_MoveTo;

                        /********************************************************************************************************************
                         * Adds items to the Listview Context Menu (Adds to listview context menu strip)
                         * Adds items to the List of Group for selection 
                         ********************************************************************************************************************/
                        itm = new ToolStripMenuItem();
                        itm_shortcutGrp = new ToolStripMenuItem();
                        itm_selectGrp = new ToolStripMenuItem();
                        itm_CopyTo = new ToolStripMenuItem();
                        itm_MoveTo = new ToolStripMenuItem();

                        if (intShortcutKey_ListView <= 12)
                        {
                            Keys k = (
                                (Keys)System.Enum.Parse(typeof(Keys),
                                ("F" + intShortcutKey_ListView.ToString()), true)
                            );

                            itm.ShortcutKeys = k;
                            itm_shortcutGrp.ShortcutKeys = k;
                            itm_selectGrp.ShortcutKeys = k;
                            intShortcutKey_ListView += 1;
                        }

                        //To appear in the context menu of the list view
                        itm.Text = dr["name"].ToString();
                        itm.Click += new EventHandler(listViewCtxMenuItem_Selection_Click);

                        //To Appear in the hidden menu for Selection of group via Hotkeys
                        itm_shortcutGrp.Text = dr["name"].ToString();
                        itm_shortcutGrp.Click += new EventHandler(listViewCtxMenuItem_Selection_Click);

                        //To appear in the Left Menu
                        itm_selectGrp.Text = dr["name"].ToString();
                        itm_selectGrp.Click += new EventHandler(listViewCtxMenuItem_Selection_Click);

                        itm_CopyTo.Text = dr["name"].ToString();
                        itm_CopyTo.Click += new EventHandler(itm_CopyTo_Click);

                        itm_MoveTo.Text = dr["name"].ToString();
                        itm_MoveTo.Click += new EventHandler(itm_MoveTo_Click);

                        ctxMnuListView.Items.Add(itm);
                        mnuShortcutGroup.Items.Add(itm_shortcutGrp);
                        ctxMnuMain_SelectGroup.DropDownItems.Add(itm_selectGrp);

                        ctxMnuListViewItem_MoveTo.DropDownItems.Add(itm_MoveTo);
                        ctxMnuListViewItem_CopyTo.DropDownItems.Add(itm_CopyTo);

                        /********************************************************************************************************************
                         * Add to List of Group for deleting
                         ********************************************************************************************************************/
                        itm = new ToolStripMenuItem();
                        itm.Text = dr["name"].ToString();
                        itm.Click += new EventHandler(listViewCtxMenuItem_Delete_Click);

                        ctxMnuMain_DeleteGroup.DropDownItems.Add(itm);
                    }
                }
            }

            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
        }

        private void itm_MoveTo_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                ToolStripMenuItem itm = (ToolStripMenuItem)sender;
                if (itm.Text != currentGroupName)
                {
                    CopyItems(itm.Text, true);
                }
            }
        }

        private void itm_CopyTo_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                ToolStripMenuItem itm = (ToolStripMenuItem)sender;
                if (itm.Text != currentGroupName)
                {
                    CopyItems(itm.Text, false);
                }
            }
        }

		//Actual Creation of the Group
		private void CreateGroup(string strGroupName)
        {
			if (ShortcutUtil.GroupNameExists(strGroupName))
			{
				MessageBox.Show(
						"Unable to create group. Group Already Exists.",
						"Unable to create group",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
				return;
			}
			ShortcutUtil.CreateGroup(strGroupName);

            //ReLoad the shortcut Groups
            LoadShortcutGroups();

            //Select the new group active
            SelectGroup(strGroupName);

        }

		//Rename Group
		private void RenameGroup(string oldGroupName, string newGroupName)
        {
            //Exit if empty new group name
            if (string.IsNullOrEmpty(newGroupName)) { return; }

			//no change in name
			if (oldGroupName == newGroupName) { return; }

			if (ShortcutUtil.GroupNameExists(newGroupName))
			{
				MessageBox.Show(
					"Unable to rename group. Group with existing name already exists.",
					"Unable to rename group",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			if (ShortcutUtil.RenameGroup(oldGroupName, newGroupName))
			{
				//Reload
				LoadShortcutGroups();

				//Select the new group name
				SelectGroup(newGroupName);
			}
        }

		//Delete Group
		private void DeleteGroup(string groupName)
        {
			if (ShortcutUtil.DeleteGroup(groupName)) {
				LoadShortcutGroups();

				//If the currently selected group is the one deleted, clear the list view
				if (groupName == lblGroupName.Text)
				{
					ClearToDefaultView();
				}
			}
		}

		//Load the shortcuts and set the menu checked
		private void SelectGroup(string strGroupName)
        {
			if (GroupSelectorThread != null && GroupSelectorThread.IsAlive) GroupSelectorThread.Abort();

			//Start a new thread to load the selection of group
			GroupSelectorThread = new Thread(new ParameterizedThreadStart(SelectGroupAsync));
			GroupSelectorThread.Start(strGroupName);
			GroupSelectorThread = null;
		}


		//ThreadSafe] Selects & Loads Selected Group
		private void SelectGroupAsync(object objStrGroupName)
        {
            try
            {
                string strGroupName = objStrGroupName.ToString();

                //If the group name is empty, ignore
                if (string.IsNullOrEmpty(strGroupName)) { return; }

                ClearItems();

				//locate file. If it exists, load the items
				List<ShortcutItem> files = ShortcutUtil.GetShortcuts(strGroupName);
				if (files != null && files.Count > 0)
				{
					int idx = 0;
					foreach (ShortcutItem item in files)
					{
						idx++;
						AddItem(item);
						SetTitle(string.Format("{0} Loading: {1} of {2}", strGroupName, idx, files.Count));
					}
					files = null;
				}

				SetTitle(strGroupName);
                currentGroupName = strGroupName;

                //Checked the selected group
                foreach (ToolStripMenuItem itm in ctxMnuListView.Items)
                {
                    SetCtxToolStripMenuItemCheckedState(ctxMnuListView, itm, false);
                }

                foreach (ToolStripMenuItem itm in ctxMnuListView.Items)
                {
                    if (itm.Text == strGroupName)
                    {
                        SetCtxToolStripMenuItemCheckedState(ctxMnuListView, itm, true);
                        //itm.Checked = true;
                        break;
                    }
                }

                //Save the last selected group name
                Properties.Settings.Default.LastMenuLoaded = strGroupName;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

			}
            catch (ThreadAbortException)
            {
                ClearItems();
            }
            catch (Exception ex)
            {
                if (ex.Message == "An entry with the same key already exists.")
                {
                    if (!AttemptedPatch)
                    {
						(new Patcher()).ApplyPatch(Patcher.Commands.AssignShortcutIds);
                        SelectGroupAsync(objStrGroupName);
                    }
                    else
                    {
                        Program.HandleError(ex);
                        AttemptedPatch = false;
                    }
                }
                else
                {
                    Program.HandleError(ex);
                }
            }

			
		}


		//Selects the item in the list view
		private void SelectItem(string selectedId)
        {
            foreach (ListViewItem item in lvShortcuts.Items)
            {
				ShortcutItem lvItem = (ShortcutItem) item.Tag;
				if (lvItem.Id == selectedId) {
					item.Selected = true;
					break;
				}
			}
        }

        // Format the shortcut to be easily understandable. e.g. change D1 to 1, Oemtilde to ~
        public string FormatShortcutString(string shortcut)
        {

            List<string> l = new List<string>();
            string[] strAry = shortcut.Split(',');

            foreach (string s in strAry)
                l.Add(s.Trim());


            string strResult = "";
            if (l.Contains("Control"))
            {
                l.Remove("Control");
                strResult = "Ctl + ";
            }

            if (l.Contains("Alt"))
            {
                l.Remove("Alt");
                strResult += "Alt + ";
            }

            if (l.Contains("Shift"))
            {
                l.Remove("Shift");
                strResult += "Shift + ";
            }

            foreach (string s in l)
            {
                switch (s.Trim())
                {
                    case "Oemtilde":
                        strResult += "~";
                        break;

                    case "D0":
                    case "D1":
                    case "D2":
                    case "D3":
                    case "D4":
                    case "D5":
                    case "D6":
                    case "D7":
                    case "D8":
                    case "D9":
                        strResult += s.Replace("D", "");
                        break;

                    default:
                        strResult += s;
                        break;
                }
            }

            return strResult;
        }

		//Method to copy/move items from one group to another based on the current selected item(s) in the active listview
		public void CopyItems(string newGroupName, bool deleteAfterCopy)
        {
			List<ShortcutItem> items = new List<ShortcutItem>();
			if (lvShortcuts.SelectedItems != null && lvShortcuts.SelectedItems.Count > 0)
			{
				foreach (ListViewItem item in lvShortcuts.SelectedItems)
				{
					items.Add((ShortcutItem)item.Tag);
				}

				ShortcutUtil.CopyShortcut(newGroupName, items.ToArray());
				if (deleteAfterCopy)
				{
					ShortcutUtil.DeleteShortcut(currentGroupName, items.ToArray());

					//Reload current group to reflect changes if any
					SelectGroup(currentGroupName);
				}
			}
        }

		#endregion


		#region DllImports

		//Bring the Window into Foreground
		[DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        #endregion


    }
}