namespace DesktopShortcutMgr.Forms
{
    partial class ExportShortcutForm
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
            this.gbxGroups = new System.Windows.Forms.GroupBox();
            this.cbRemoveInvalidItems = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cblGroups = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.gbxGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxGroups
            // 
            this.gbxGroups.Controls.Add(this.cbRemoveInvalidItems);
            this.gbxGroups.Controls.Add(this.label1);
            this.gbxGroups.Controls.Add(this.cblGroups);
            this.gbxGroups.Location = new System.Drawing.Point(12, 12);
            this.gbxGroups.Name = "gbxGroups";
            this.gbxGroups.Size = new System.Drawing.Size(429, 157);
            this.gbxGroups.TabIndex = 0;
            this.gbxGroups.TabStop = false;
            this.gbxGroups.Text = "Shortcut Export Options";
            // 
            // cbRemoveInvalidItems
            // 
            this.cbRemoveInvalidItems.AutoSize = true;
            this.cbRemoveInvalidItems.Checked = true;
            this.cbRemoveInvalidItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemoveInvalidItems.Location = new System.Drawing.Point(102, 119);
            this.cbRemoveInvalidItems.Name = "cbRemoveInvalidItems";
            this.cbRemoveInvalidItems.Size = new System.Drawing.Size(148, 17);
            this.cbRemoveInvalidItems.TabIndex = 2;
            this.cbRemoveInvalidItems.Text = "Remove Invalid Shortcuts";
            this.cbRemoveInvalidItems.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Groups To Export";
            // 
            // cblGroups
            // 
            this.cblGroups.CheckOnClick = true;
            this.cblGroups.FormattingEnabled = true;
            this.cblGroups.Location = new System.Drawing.Point(102, 19);
            this.cblGroups.Name = "cblGroups";
            this.cblGroups.Size = new System.Drawing.Size(301, 94);
            this.cblGroups.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(366, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(285, 185);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmExportShortcut
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(453, 220);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxGroups);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmExportShortcut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Shortcuts";
            this.Load += new System.EventHandler(this.frmExportShortcut_Load);
            this.gbxGroups.ResumeLayout(false);
            this.gbxGroups.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxGroups;
        private System.Windows.Forms.CheckedListBox cblGroups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbRemoveInvalidItems;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
    }
}