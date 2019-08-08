namespace DesktopShortcutMgr.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lvShortcuts = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.ctxMnuListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pVisiblePart = new System.Windows.Forms.Panel();
            this.ctxMnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMnuMain_SelectGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_AddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_DeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMnuMain_Sort = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_Sort_Asc = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_Sort_Desc = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_Sort_Custom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMnuMain_Search = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMnuMain_AlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_ExportShortcutToDesktop = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_MoreExportOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_DisplayAllShortcutKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_SwitchScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuMain_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMnuMain_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMiniPanel = new System.Windows.Forms.Panel();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.vlblMain = new DesktopShortcutMgr.UserControls.VerticalLabel();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ctxMnuListViewItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMnuListViewItem_Execute = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuListViewItem_OpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMnuListViewItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuListViewItem_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMnuListViewItem_MoveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuListViewItem_CopyTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMnuListViewItem_ExportToShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuListViewItem_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShortcutGroup = new System.Windows.Forms.MenuStrip();
            this.mnuShortcut_Hidden = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShortcut_Hidden_options = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShortcut_Hidden_Search = new System.Windows.Forms.ToolStripMenuItem();
            this.switchScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDockUnDock = new System.Windows.Forms.Button();
            this.pVisiblePart.SuspendLayout();
            this.ctxMnuMain.SuspendLayout();
            this.ctxMnuListViewItem.SuspendLayout();
            this.mnuShortcutGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvShortcuts
            // 
            this.lvShortcuts.AllowDrop = true;
            this.lvShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvShortcuts.BackColor = System.Drawing.SystemColors.Control;
            this.lvShortcuts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvShortcuts.LabelEdit = true;
            this.lvShortcuts.LargeImageList = this.imageList1;
            this.lvShortcuts.Location = new System.Drawing.Point(25, 18);
            this.lvShortcuts.Margin = new System.Windows.Forms.Padding(0);
            this.lvShortcuts.Name = "lvShortcuts";
            this.lvShortcuts.ShowItemToolTips = true;
            this.lvShortcuts.Size = new System.Drawing.Size(241, 598);
            this.lvShortcuts.SmallImageList = this.imageListSmall;
            this.lvShortcuts.TabIndex = 0;
            this.lvShortcuts.TileSize = new System.Drawing.Size(184, 34);
            this.lvShortcuts.UseCompatibleStateImageBehavior = false;
            this.lvShortcuts.View = System.Windows.Forms.View.Tile;
            this.lvShortcuts.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvShortcuts_AfterLabelEdit);
            this.lvShortcuts.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvShortcuts_BeforeLabelEdit);
            this.lvShortcuts.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvShortcuts_DragDrop);
            this.lvShortcuts.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvShortcuts_DragEnter);
            this.lvShortcuts.DoubleClick += new System.EventHandler(this.lvShortcuts_DoubleClick);
            this.lvShortcuts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvShortcuts_KeyUp);
            this.lvShortcuts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvShortcuts_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListSmall.ImageSize = new System.Drawing.Size(23, 23);
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ctxMnuListView
            // 
            this.ctxMnuListView.Name = "ctxMnuItems";
            this.ctxMnuListView.Size = new System.Drawing.Size(61, 4);
            // 
            // pVisiblePart
            // 
            this.pVisiblePart.BackColor = System.Drawing.SystemColors.Desktop;
            this.pVisiblePart.ContextMenuStrip = this.ctxMnuMain;
            this.pVisiblePart.Controls.Add(this.pnlMiniPanel);
            this.pVisiblePart.Controls.Add(this.btnMainMenu);
            this.pVisiblePart.Controls.Add(this.btnDockUnDock);
            this.pVisiblePart.Controls.Add(this.vlblMain);
            this.pVisiblePart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pVisiblePart.Location = new System.Drawing.Point(0, 0);
            this.pVisiblePart.Name = "pVisiblePart";
            this.pVisiblePart.Size = new System.Drawing.Size(25, 617);
            this.pVisiblePart.TabIndex = 1;
            this.pVisiblePart.DoubleClick += new System.EventHandler(this.btnDockUnDock_Click);
            // 
            // ctxMnuMain
            // 
            this.ctxMnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMnuMain_SelectGroup,
            this.ctxMnuMain_AddGroup,
            this.ctxMnuMain_DeleteGroup,
            this.toolStripSeparator6,
            this.ctxMnuMain_Sort,
            this.toolStripSeparator1,
            this.ctxMnuMain_Search,
            this.toolStripSeparator3,
            this.ctxMnuMain_AlwaysOnTop,
            this.ctxMnuMain_Export,
            this.ctxMnuMain_DisplayAllShortcutKeys,
            this.ctxMnuMain_SwitchScreen,
            this.ctxMnuMain_Options,
            this.toolStripSeparator2,
            this.ctxMnuMain_Exit});
            this.ctxMnuMain.Name = "ctxMnuMain";
            this.ctxMnuMain.Size = new System.Drawing.Size(210, 270);
            // 
            // ctxMnuMain_SelectGroup
            // 
            this.ctxMnuMain_SelectGroup.Name = "ctxMnuMain_SelectGroup";
            this.ctxMnuMain_SelectGroup.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_SelectGroup.Text = "Select Group";
            // 
            // ctxMnuMain_AddGroup
            // 
            this.ctxMnuMain_AddGroup.Name = "ctxMnuMain_AddGroup";
            this.ctxMnuMain_AddGroup.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_AddGroup.Text = "Add Group";
            this.ctxMnuMain_AddGroup.Click += new System.EventHandler(this.ctxMnuMain_AddGroup_Click);
            // 
            // ctxMnuMain_DeleteGroup
            // 
            this.ctxMnuMain_DeleteGroup.Name = "ctxMnuMain_DeleteGroup";
            this.ctxMnuMain_DeleteGroup.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_DeleteGroup.Text = "Delete Group";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(206, 6);
            // 
            // ctxMnuMain_Sort
            // 
            this.ctxMnuMain_Sort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMnuMain_Sort_Asc,
            this.ctxMnuMain_Sort_Desc,
            this.ctxMnuMain_Sort_Custom});
            this.ctxMnuMain_Sort.Name = "ctxMnuMain_Sort";
            this.ctxMnuMain_Sort.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_Sort.Text = "Sort";
            // 
            // ctxMnuMain_Sort_Asc
            // 
            this.ctxMnuMain_Sort_Asc.Name = "ctxMnuMain_Sort_Asc";
            this.ctxMnuMain_Sort_Asc.Size = new System.Drawing.Size(136, 22);
            this.ctxMnuMain_Sort_Asc.Text = "Ascending";
            this.ctxMnuMain_Sort_Asc.Click += new System.EventHandler(this.ctxMnuMain_Sort_Asc_Click);
            // 
            // ctxMnuMain_Sort_Desc
            // 
            this.ctxMnuMain_Sort_Desc.Name = "ctxMnuMain_Sort_Desc";
            this.ctxMnuMain_Sort_Desc.Size = new System.Drawing.Size(136, 22);
            this.ctxMnuMain_Sort_Desc.Text = "Descending";
            this.ctxMnuMain_Sort_Desc.Click += new System.EventHandler(this.ctxMnuMain_Sort_Desc_Click);
            // 
            // ctxMnuMain_Sort_Custom
            // 
            this.ctxMnuMain_Sort_Custom.Name = "ctxMnuMain_Sort_Custom";
            this.ctxMnuMain_Sort_Custom.Size = new System.Drawing.Size(136, 22);
            this.ctxMnuMain_Sort_Custom.Text = "Custom";
            this.ctxMnuMain_Sort_Custom.Click += new System.EventHandler(this.ctxMnuMain_Sort_Custom_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // ctxMnuMain_Search
            // 
            this.ctxMnuMain_Search.Name = "ctxMnuMain_Search";
            this.ctxMnuMain_Search.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_Search.Text = "Search";
            this.ctxMnuMain_Search.Click += new System.EventHandler(this.ctxMnuMain_Search_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            // 
            // ctxMnuMain_AlwaysOnTop
            // 
            this.ctxMnuMain_AlwaysOnTop.CheckOnClick = true;
            this.ctxMnuMain_AlwaysOnTop.Name = "ctxMnuMain_AlwaysOnTop";
            this.ctxMnuMain_AlwaysOnTop.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_AlwaysOnTop.Text = "Always on top";
            this.ctxMnuMain_AlwaysOnTop.Click += new System.EventHandler(this.ctxMnuMain_AlwaysOnTop_Click);
            // 
            // ctxMnuMain_Export
            // 
            this.ctxMnuMain_Export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMnuMain_ExportShortcutToDesktop,
            this.ctxMnuMain_MoreExportOptions});
            this.ctxMnuMain_Export.Name = "ctxMnuMain_Export";
            this.ctxMnuMain_Export.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_Export.Text = "Export";
            // 
            // ctxMnuMain_ExportShortcutToDesktop
            // 
            this.ctxMnuMain_ExportShortcutToDesktop.Name = "ctxMnuMain_ExportShortcutToDesktop";
            this.ctxMnuMain_ExportShortcutToDesktop.Size = new System.Drawing.Size(239, 22);
            this.ctxMnuMain_ExportShortcutToDesktop.Text = "Export Current Group Shortcuts";
            this.ctxMnuMain_ExportShortcutToDesktop.Click += new System.EventHandler(this.ctxMnuMain_ExportShortcutToDesktop_Click);
            // 
            // ctxMnuMain_MoreExportOptions
            // 
            this.ctxMnuMain_MoreExportOptions.Name = "ctxMnuMain_MoreExportOptions";
            this.ctxMnuMain_MoreExportOptions.Size = new System.Drawing.Size(239, 22);
            this.ctxMnuMain_MoreExportOptions.Text = "More Export Options";
            this.ctxMnuMain_MoreExportOptions.Click += new System.EventHandler(this.ctxMnuMain_MoreExportOptions_Click);
            // 
            // ctxMnuMain_DisplayAllShortcutKeys
            // 
            this.ctxMnuMain_DisplayAllShortcutKeys.Name = "ctxMnuMain_DisplayAllShortcutKeys";
            this.ctxMnuMain_DisplayAllShortcutKeys.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_DisplayAllShortcutKeys.Text = "Display All Shortcut Keys";
            this.ctxMnuMain_DisplayAllShortcutKeys.Click += new System.EventHandler(this.ctxMnuMain_DisplayAllShortcutKeys_Click);
            // 
            // ctxMnuMain_SwitchScreen
            // 
            this.ctxMnuMain_SwitchScreen.Name = "ctxMnuMain_SwitchScreen";
            this.ctxMnuMain_SwitchScreen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.ctxMnuMain_SwitchScreen.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_SwitchScreen.Text = "Switch Screen";
            this.ctxMnuMain_SwitchScreen.Click += new System.EventHandler(this.ctxMnuMain_SwitchScreen_Click);
            // 
            // ctxMnuMain_Options
            // 
            this.ctxMnuMain_Options.Name = "ctxMnuMain_Options";
            this.ctxMnuMain_Options.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ctxMnuMain_Options.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_Options.Text = "Options";
            this.ctxMnuMain_Options.Click += new System.EventHandler(this.ctxMnuMain_Options_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            // 
            // ctxMnuMain_Exit
            // 
            this.ctxMnuMain_Exit.Name = "ctxMnuMain_Exit";
            this.ctxMnuMain_Exit.Size = new System.Drawing.Size(209, 22);
            this.ctxMnuMain_Exit.Text = "Exit";
            this.ctxMnuMain_Exit.Click += new System.EventHandler(this.ctxMnuMain_Exit_Click);
            // 
            // pnlMiniPanel
            // 
            this.pnlMiniPanel.AutoSize = true;
            this.pnlMiniPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiniPanel.Location = new System.Drawing.Point(0, 44);
            this.pnlMiniPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiniPanel.Name = "pnlMiniPanel";
            this.pnlMiniPanel.Size = new System.Drawing.Size(25, 0);
            this.pnlMiniPanel.TabIndex = 3;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMainMenu.FlatAppearance.BorderSize = 0;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnMainMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMainMenu.Image")));
            this.btnMainMenu.Location = new System.Drawing.Point(0, 21);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(25, 23);
            this.btnMainMenu.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnMainMenu, "Menu");
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // vlblMain
            // 
            this.vlblMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.vlblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.vlblMain.ForeColor = System.Drawing.Color.White;
            this.vlblMain.Location = new System.Drawing.Point(0, 92);
            this.vlblMain.Name = "vlblMain";
            this.vlblMain.Size = new System.Drawing.Size(25, 525);
            this.vlblMain.TabIndex = 2;
            this.vlblMain.Text = null;
            this.vlblMain.DoubleClick += new System.EventHandler(this.btnDockUnDock_Click);
            // 
            // lblGroupName
            // 
            this.lblGroupName.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblGroupName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.ForeColor = System.Drawing.Color.White;
            this.lblGroupName.Location = new System.Drawing.Point(25, 0);
            this.lblGroupName.Margin = new System.Windows.Forms.Padding(0);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(241, 18);
            this.lblGroupName.TabIndex = 2;
            this.lblGroupName.Text = "Shortcut Manager";
            this.toolTip1.SetToolTip(this.lblGroupName, "Double click to edit group name");
            this.lblGroupName.DoubleClick += new System.EventHandler(this.lblGroupName_DoubleClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ctxMnuMain;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Shortcut Manager";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // tbGroupName
            // 
            this.tbGroupName.BackColor = System.Drawing.SystemColors.Desktop;
            this.tbGroupName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbGroupName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.tbGroupName.ForeColor = System.Drawing.Color.White;
            this.tbGroupName.Location = new System.Drawing.Point(25, 18);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(241, 19);
            this.tbGroupName.TabIndex = 3;
            this.tbGroupName.LostFocus += new System.EventHandler(this.tbGroupName_LostFocus);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 50;
            // 
            // ctxMnuListViewItem
            // 
            this.ctxMnuListViewItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMnuListViewItem_Execute,
            this.ctxMnuListViewItem_OpenDirectory,
            this.toolStripSeparator4,
            this.ctxMnuListViewItem_Delete,
            this.ctxMnuListViewItem_Rename,
            this.toolStripSeparator5,
            this.ctxMnuListViewItem_MoveTo,
            this.ctxMnuListViewItem_CopyTo,
            this.toolStripSeparator7,
            this.ctxMnuListViewItem_ExportToShortcut,
            this.ctxMnuListViewItem_Properties});
            this.ctxMnuListViewItem.Name = "ctxMnuListViewItem";
            this.ctxMnuListViewItem.Size = new System.Drawing.Size(172, 198);
            // 
            // ctxMnuListViewItem_Execute
            // 
            this.ctxMnuListViewItem_Execute.Name = "ctxMnuListViewItem_Execute";
            this.ctxMnuListViewItem_Execute.Size = new System.Drawing.Size(171, 22);
            this.ctxMnuListViewItem_Execute.Text = "Execute";
            this.ctxMnuListViewItem_Execute.Click += new System.EventHandler(this.ctxMnuListViewItem_Execute_Click);
            // 
            // ctxMnuListViewItem_OpenDirectory
            // 
            this.ctxMnuListViewItem_OpenDirectory.Name = "ctxMnuListViewItem_OpenDirectory";
            this.ctxMnuListViewItem_OpenDirectory.Size = new System.Drawing.Size(171, 22);
            this.ctxMnuListViewItem_OpenDirectory.Text = "Open Directory";
            this.ctxMnuListViewItem_OpenDirectory.Click += new System.EventHandler(this.ctxMnuListViewItem_OpenDirectory_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(168, 6);
            // 
            // ctxMnuListViewItem_Delete
            // 
            this.ctxMnuListViewItem_Delete.Name = "ctxMnuListViewItem_Delete";
            this.ctxMnuListViewItem_Delete.Size = new System.Drawing.Size(171, 22);
            this.ctxMnuListViewItem_Delete.Text = "Delete";
            this.ctxMnuListViewItem_Delete.Click += new System.EventHandler(this.ctxMnuListViewItem_Delete_Click);
            // 
            // ctxMnuListViewItem_Rename
            // 
            this.ctxMnuListViewItem_Rename.Name = "ctxMnuListViewItem_Rename";
            this.ctxMnuListViewItem_Rename.Size = new System.Drawing.Size(171, 22);
            this.ctxMnuListViewItem_Rename.Text = "Rename";
            this.ctxMnuListViewItem_Rename.Click += new System.EventHandler(this.ctxMnuListViewItem_Rename_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(168, 6);
            // 
            // ctxMnuListViewItem_MoveTo
            // 
            this.ctxMnuListViewItem_MoveTo.Name = "ctxMnuListViewItem_MoveTo";
            this.ctxMnuListViewItem_MoveTo.Size = new System.Drawing.Size(171, 22);
            this.ctxMnuListViewItem_MoveTo.Text = "Move To";
            this.ctxMnuListViewItem_MoveTo.DropDownOpening += new System.EventHandler(this.ctxMnuListViewItem_MoveTo_DropDownOpening);
            // 
            // ctxMnuListViewItem_CopyTo
            // 
            this.ctxMnuListViewItem_CopyTo.Name = "ctxMnuListViewItem_CopyTo";
            this.ctxMnuListViewItem_CopyTo.Size = new System.Drawing.Size(171, 22);
            this.ctxMnuListViewItem_CopyTo.Text = "Copy To";
            this.ctxMnuListViewItem_CopyTo.DropDownOpening += new System.EventHandler(this.ctxMnuListViewItem_CopyTo_DropDownOpening);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(168, 6);
            // 
            // ctxMnuListViewItem_ExportToShortcut
            // 
            this.ctxMnuListViewItem_ExportToShortcut.Name = "ctxMnuListViewItem_ExportToShortcut";
            this.ctxMnuListViewItem_ExportToShortcut.Size = new System.Drawing.Size(171, 22);
            this.ctxMnuListViewItem_ExportToShortcut.Text = "Export To Shortcut";
            this.ctxMnuListViewItem_ExportToShortcut.Click += new System.EventHandler(this.ctxMnuListViewItem_ExportToShortcut_Click);
            // 
            // ctxMnuListViewItem_Properties
            // 
            this.ctxMnuListViewItem_Properties.Name = "ctxMnuListViewItem_Properties";
            this.ctxMnuListViewItem_Properties.Size = new System.Drawing.Size(171, 22);
            this.ctxMnuListViewItem_Properties.Text = "Properties";
            this.ctxMnuListViewItem_Properties.Click += new System.EventHandler(this.ctxMnuListViewItem_Properties_Click);
            // 
            // mnuShortcutGroup
            // 
            this.mnuShortcutGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShortcut_Hidden});
            this.mnuShortcutGroup.Location = new System.Drawing.Point(0, 0);
            this.mnuShortcutGroup.Name = "mnuShortcutGroup";
            this.mnuShortcutGroup.Size = new System.Drawing.Size(266, 22);
            this.mnuShortcutGroup.TabIndex = 4;
            this.mnuShortcutGroup.Text = "menuStrip1";
            this.mnuShortcutGroup.Visible = false;
            // 
            // mnuShortcut_Hidden
            // 
            this.mnuShortcut_Hidden.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShortcut_Hidden_options,
            this.mnuShortcut_Hidden_Search,
            this.switchScreenToolStripMenuItem});
            this.mnuShortcut_Hidden.Name = "mnuShortcut_Hidden";
            this.mnuShortcut_Hidden.Size = new System.Drawing.Size(108, 18);
            this.mnuShortcut_Hidden.Text = "HiddenShortcuts";
            // 
            // mnuShortcut_Hidden_options
            // 
            this.mnuShortcut_Hidden_options.Name = "mnuShortcut_Hidden_options";
            this.mnuShortcut_Hidden_options.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuShortcut_Hidden_options.Size = new System.Drawing.Size(209, 22);
            this.mnuShortcut_Hidden_options.Text = "Options";
            this.mnuShortcut_Hidden_options.Click += new System.EventHandler(this.mnuShortcut_Hidden_options_Click);
            // 
            // mnuShortcut_Hidden_Search
            // 
            this.mnuShortcut_Hidden_Search.Name = "mnuShortcut_Hidden_Search";
            this.mnuShortcut_Hidden_Search.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuShortcut_Hidden_Search.Size = new System.Drawing.Size(209, 22);
            this.mnuShortcut_Hidden_Search.Text = "Search";
            this.mnuShortcut_Hidden_Search.Click += new System.EventHandler(this.mnuShortcut_Hidden_Search_Click);
            // 
            // switchScreenToolStripMenuItem
            // 
            this.switchScreenToolStripMenuItem.Name = "switchScreenToolStripMenuItem";
            this.switchScreenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.switchScreenToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.switchScreenToolStripMenuItem.Text = "Switch Screen";
            this.switchScreenToolStripMenuItem.Click += new System.EventHandler(this.ctxMnuMain_SwitchScreen_Click);
            // 
            // btnDockUnDock
            // 
            this.btnDockUnDock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDockUnDock.FlatAppearance.BorderSize = 0;
            this.btnDockUnDock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDockUnDock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDockUnDock.ForeColor = System.Drawing.Color.White;
            this.btnDockUnDock.Location = new System.Drawing.Point(0, 0);
            this.btnDockUnDock.Margin = new System.Windows.Forms.Padding(0);
            this.btnDockUnDock.Name = "btnDockUnDock";
            this.btnDockUnDock.Size = new System.Drawing.Size(25, 21);
            this.btnDockUnDock.TabIndex = 0;
            this.btnDockUnDock.Text = "<<";
            this.btnDockUnDock.UseVisualStyleBackColor = true;
            this.btnDockUnDock.Click += new System.EventHandler(this.btnDockUnDock_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(266, 617);
            this.Controls.Add(this.tbGroupName);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.pVisiblePart);
            this.Controls.Add(this.lvShortcuts);
            this.Controls.Add(this.mnuShortcutGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.mnuShortcutGroup;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pVisiblePart.ResumeLayout(false);
            this.pVisiblePart.PerformLayout();
            this.ctxMnuMain.ResumeLayout(false);
            this.ctxMnuListViewItem.ResumeLayout(false);
            this.mnuShortcutGroup.ResumeLayout(false);
            this.mnuShortcutGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private UserControls.VerticalLabel vlblMain;
        private System.Windows.Forms.ListView lvShortcuts;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pVisiblePart;
        private System.Windows.Forms.ContextMenuStrip ctxMnuMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_Exit;
        private System.Windows.Forms.ContextMenuStrip ctxMnuListView;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_AddGroup;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_DeleteGroup;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_Options;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_AlwaysOnTop;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_Sort;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_Sort_Asc;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_Sort_Desc;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_Search;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip ctxMnuListViewItem;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_OpenDirectory;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_Execute;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_Rename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_Delete;
        private System.Windows.Forms.MenuStrip mnuShortcutGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_Properties;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_Sort_Custom;
        private System.Windows.Forms.ToolStripMenuItem mnuShortcut_Hidden;
        private System.Windows.Forms.ToolStripMenuItem mnuShortcut_Hidden_options;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_DisplayAllShortcutKeys;
        private System.Windows.Forms.Panel pnlMiniPanel;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_SelectGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuShortcut_Hidden_Search;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_MoveTo;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_CopyTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_Export;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_ExportShortcutToDesktop;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_ExportToShortcut;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_MoreExportOptions;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuMain_SwitchScreen;
        private System.Windows.Forms.ToolStripMenuItem switchScreenToolStripMenuItem;
        private System.Windows.Forms.Button btnDockUnDock;
    }
}

