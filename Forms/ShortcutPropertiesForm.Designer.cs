namespace DesktopShortcutMgr.Forms
{
    partial class ShortcutPropertiesForm
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
			this.lblShortcutName = new System.Windows.Forms.Label();
			this.tbShortcutName = new System.Windows.Forms.TextBox();
			this.tbShortcutPath = new System.Windows.Forms.TextBox();
			this.ctxMnu_Path = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctxMnu_Path_OpenParentDir = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMnu_Path_Browse = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMnu_Path_Browse_File = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMnu_Path_Browse_Folder = new System.Windows.Forms.ToolStripMenuItem();
			this.lblShortcutPath = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pbIcon = new System.Windows.Forms.PictureBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.cbRunAsAdmin = new System.Windows.Forms.CheckBox();
			this.tbArguments = new System.Windows.Forms.TextBox();
			this.lblArgs = new System.Windows.Forms.Label();
			this.ctxMnu_Path.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// lblShortcutName
			// 
			this.lblShortcutName.AutoSize = true;
			this.lblShortcutName.Location = new System.Drawing.Point(66, 12);
			this.lblShortcutName.Name = "lblShortcutName";
			this.lblShortcutName.Size = new System.Drawing.Size(78, 13);
			this.lblShortcutName.TabIndex = 0;
			this.lblShortcutName.Text = "Shortcut Name";
			// 
			// tbShortcutName
			// 
			this.tbShortcutName.Location = new System.Drawing.Point(150, 9);
			this.tbShortcutName.Name = "tbShortcutName";
			this.tbShortcutName.Size = new System.Drawing.Size(348, 20);
			this.tbShortcutName.TabIndex = 1;
			// 
			// tbShortcutPath
			// 
			this.tbShortcutPath.ContextMenuStrip = this.ctxMnu_Path;
			this.tbShortcutPath.Location = new System.Drawing.Point(150, 40);
			this.tbShortcutPath.Name = "tbShortcutPath";
			this.tbShortcutPath.Size = new System.Drawing.Size(317, 20);
			this.tbShortcutPath.TabIndex = 2;
			// 
			// ctxMnu_Path
			// 
			this.ctxMnu_Path.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMnu_Path_OpenParentDir,
            this.ctxMnu_Path_Browse});
			this.ctxMnu_Path.Name = "ctxMnu_Path";
			this.ctxMnu_Path.Size = new System.Drawing.Size(192, 48);
			// 
			// ctxMnu_Path_OpenParentDir
			// 
			this.ctxMnu_Path_OpenParentDir.Name = "ctxMnu_Path_OpenParentDir";
			this.ctxMnu_Path_OpenParentDir.Size = new System.Drawing.Size(191, 22);
			this.ctxMnu_Path_OpenParentDir.Text = "Open Parent Directory";
			this.ctxMnu_Path_OpenParentDir.Click += new System.EventHandler(this.ctxMnu_Path_OpenParentDir_Click);
			// 
			// ctxMnu_Path_Browse
			// 
			this.ctxMnu_Path_Browse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMnu_Path_Browse_File,
            this.ctxMnu_Path_Browse_Folder});
			this.ctxMnu_Path_Browse.Name = "ctxMnu_Path_Browse";
			this.ctxMnu_Path_Browse.Size = new System.Drawing.Size(191, 22);
			this.ctxMnu_Path_Browse.Text = "Browse";
			// 
			// ctxMnu_Path_Browse_File
			// 
			this.ctxMnu_Path_Browse_File.Name = "ctxMnu_Path_Browse_File";
			this.ctxMnu_Path_Browse_File.Size = new System.Drawing.Size(107, 22);
			this.ctxMnu_Path_Browse_File.Text = "File";
			this.ctxMnu_Path_Browse_File.Click += new System.EventHandler(this.ctxMnu_Path_Browse_File_Click);
			// 
			// ctxMnu_Path_Browse_Folder
			// 
			this.ctxMnu_Path_Browse_Folder.Name = "ctxMnu_Path_Browse_Folder";
			this.ctxMnu_Path_Browse_Folder.Size = new System.Drawing.Size(107, 22);
			this.ctxMnu_Path_Browse_Folder.Text = "Folder";
			this.ctxMnu_Path_Browse_Folder.Click += new System.EventHandler(this.ctxMnu_Path_Browse_Folder_Click);
			// 
			// lblShortcutPath
			// 
			this.lblShortcutPath.AutoSize = true;
			this.lblShortcutPath.Location = new System.Drawing.Point(66, 43);
			this.lblShortcutPath.Name = "lblShortcutPath";
			this.lblShortcutPath.Size = new System.Drawing.Size(72, 13);
			this.lblShortcutPath.TabIndex = 3;
			this.lblShortcutPath.Text = "Shortcut Path";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(345, 163);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(426, 163);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// pbIcon
			// 
			this.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbIcon.Location = new System.Drawing.Point(12, 12);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new System.Drawing.Size(48, 48);
			this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbIcon.TabIndex = 6;
			this.pbIcon.TabStop = false;
			this.pbIcon.Click += new System.EventHandler(this.pbIcon_Click);
			// 
			// btnBrowse
			// 
			this.btnBrowse.ContextMenuStrip = this.ctxMnu_Path;
			this.btnBrowse.Location = new System.Drawing.Point(473, 38);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(28, 23);
			this.btnBrowse.TabIndex = 7;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBrowse_MouseUp);
			// 
			// cbRunAsAdmin
			// 
			this.cbRunAsAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbRunAsAdmin.AutoSize = true;
			this.cbRunAsAdmin.Location = new System.Drawing.Point(12, 169);
			this.cbRunAsAdmin.Name = "cbRunAsAdmin";
			this.cbRunAsAdmin.Size = new System.Drawing.Size(123, 17);
			this.cbRunAsAdmin.TabIndex = 8;
			this.cbRunAsAdmin.Text = "Run as Administrator";
			this.cbRunAsAdmin.UseVisualStyleBackColor = true;
			// 
			// tbArguments
			// 
			this.tbArguments.Location = new System.Drawing.Point(150, 67);
			this.tbArguments.Multiline = true;
			this.tbArguments.Name = "tbArguments";
			this.tbArguments.Size = new System.Drawing.Size(317, 90);
			this.tbArguments.TabIndex = 9;
			// 
			// lblArgs
			// 
			this.lblArgs.AutoSize = true;
			this.lblArgs.Location = new System.Drawing.Point(66, 70);
			this.lblArgs.Name = "lblArgs";
			this.lblArgs.Size = new System.Drawing.Size(57, 13);
			this.lblArgs.TabIndex = 10;
			this.lblArgs.Text = "Arguments";
			// 
			// ShortcutPropertiesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(513, 198);
			this.Controls.Add(this.lblArgs);
			this.Controls.Add(this.tbArguments);
			this.Controls.Add(this.cbRunAsAdmin);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.pbIcon);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblShortcutPath);
			this.Controls.Add(this.tbShortcutPath);
			this.Controls.Add(this.tbShortcutName);
			this.Controls.Add(this.lblShortcutName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ShortcutPropertiesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shortcut Properties";
			this.Load += new System.EventHandler(this.frmShortcutProperties_Load);
			this.ctxMnu_Path.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShortcutName;
        private System.Windows.Forms.TextBox tbShortcutName;
        private System.Windows.Forms.TextBox tbShortcutPath;
        private System.Windows.Forms.Label lblShortcutPath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.ContextMenuStrip ctxMnu_Path;
        private System.Windows.Forms.ToolStripMenuItem ctxMnu_Path_OpenParentDir;
        private System.Windows.Forms.ToolStripMenuItem ctxMnu_Path_Browse;
        private System.Windows.Forms.ToolStripMenuItem ctxMnu_Path_Browse_File;
        private System.Windows.Forms.ToolStripMenuItem ctxMnu_Path_Browse_Folder;
        private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.CheckBox cbRunAsAdmin;
		private System.Windows.Forms.TextBox tbArguments;
		private System.Windows.Forms.Label lblArgs;
	}
}