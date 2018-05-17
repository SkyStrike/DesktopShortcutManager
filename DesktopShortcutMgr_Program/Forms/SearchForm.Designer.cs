namespace DesktopShortcutMgr
{
    partial class SearchForm
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
            this.gbxSearchCriteria = new System.Windows.Forms.GroupBox();
            this.ddlShortcutFile = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbShortcutName = new System.Windows.Forms.TextBox();
            this.lblShortcutName = new System.Windows.Forms.Label();
            this.lvSearchResult = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ctxMnuListViewItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMnuListViewItem_Execute = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuListViewItem_OpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxSearchCriteria.SuspendLayout();
            this.ctxMnuListViewItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSearchCriteria
            // 
            this.gbxSearchCriteria.Controls.Add(this.ddlShortcutFile);
            this.gbxSearchCriteria.Controls.Add(this.btnSearch);
            this.gbxSearchCriteria.Controls.Add(this.tbShortcutName);
            this.gbxSearchCriteria.Controls.Add(this.lblShortcutName);
            this.gbxSearchCriteria.Location = new System.Drawing.Point(12, 12);
            this.gbxSearchCriteria.Name = "gbxSearchCriteria";
            this.gbxSearchCriteria.Size = new System.Drawing.Size(568, 55);
            this.gbxSearchCriteria.TabIndex = 0;
            this.gbxSearchCriteria.TabStop = false;
            this.gbxSearchCriteria.Text = "Search Criteria";
            // 
            // ddlShortcutFile
            // 
            this.ddlShortcutFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlShortcutFile.FormattingEnabled = true;
            this.ddlShortcutFile.Location = new System.Drawing.Point(260, 22);
            this.ddlShortcutFile.Name = "ddlShortcutFile";
            this.ddlShortcutFile.Size = new System.Drawing.Size(221, 21);
            this.ddlShortcutFile.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(487, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 22);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbShortcutName
            // 
            this.tbShortcutName.Location = new System.Drawing.Point(103, 23);
            this.tbShortcutName.Name = "tbShortcutName";
            this.tbShortcutName.Size = new System.Drawing.Size(151, 20);
            this.tbShortcutName.TabIndex = 1;
            // 
            // lblShortcutName
            // 
            this.lblShortcutName.AutoSize = true;
            this.lblShortcutName.Location = new System.Drawing.Point(6, 26);
            this.lblShortcutName.Name = "lblShortcutName";
            this.lblShortcutName.Size = new System.Drawing.Size(78, 13);
            this.lblShortcutName.TabIndex = 0;
            this.lblShortcutName.Text = "Shortcut Name";
            // 
            // lvSearchResult
            // 
            this.lvSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSearchResult.BackColor = System.Drawing.SystemColors.Control;
            this.lvSearchResult.LargeImageList = this.imageList1;
            this.lvSearchResult.Location = new System.Drawing.Point(12, 73);
            this.lvSearchResult.Name = "lvSearchResult";
            this.lvSearchResult.ShowItemToolTips = true;
            this.lvSearchResult.Size = new System.Drawing.Size(840, 474);
            this.lvSearchResult.SmallImageList = this.imageList1;
            this.lvSearchResult.TabIndex = 1;
            this.lvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult.View = System.Windows.Forms.View.Tile;
            this.lvSearchResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSearchResult_MouseDoubleClick);
            this.lvSearchResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvSearchResult_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ctxMnuListViewItem
            // 
            this.ctxMnuListViewItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMnuListViewItem_Execute,
            this.ctxMnuListViewItem_OpenDirectory});
            this.ctxMnuListViewItem.Name = "ctxMnuListViewItem";
            this.ctxMnuListViewItem.Size = new System.Drawing.Size(155, 48);
            // 
            // ctxMnuListViewItem_Execute
            // 
            this.ctxMnuListViewItem_Execute.Name = "ctxMnuListViewItem_Execute";
            this.ctxMnuListViewItem_Execute.Size = new System.Drawing.Size(154, 22);
            this.ctxMnuListViewItem_Execute.Text = "Execute";
            this.ctxMnuListViewItem_Execute.Click += new System.EventHandler(this.ctxMnuListViewItem_Execute_Click);
            // 
            // ctxMnuListViewItem_OpenDirectory
            // 
            this.ctxMnuListViewItem_OpenDirectory.Name = "ctxMnuListViewItem_OpenDirectory";
            this.ctxMnuListViewItem_OpenDirectory.Size = new System.Drawing.Size(154, 22);
            this.ctxMnuListViewItem_OpenDirectory.Text = "Open Directory";
            this.ctxMnuListViewItem_OpenDirectory.Click += new System.EventHandler(this.ctxMnuListViewItem_OpenDirectory_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(777, 564);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(864, 599);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvSearchResult);
            this.Controls.Add(this.gbxSearchCriteria);
            this.Name = "frmSearch";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.gbxSearchCriteria.ResumeLayout(false);
            this.gbxSearchCriteria.PerformLayout();
            this.ctxMnuListViewItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSearchCriteria;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbShortcutName;
        private System.Windows.Forms.Label lblShortcutName;
        private System.Windows.Forms.ListView lvSearchResult;
        private System.Windows.Forms.ComboBox ddlShortcutFile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip ctxMnuListViewItem;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_Execute;
        private System.Windows.Forms.ToolStripMenuItem ctxMnuListViewItem_OpenDirectory;
        private System.Windows.Forms.Button btnClose;
    }
}