namespace DSMUpdater
{
    partial class PatcherInterface
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
            this.btnExecutePatch = new System.Windows.Forms.Button();
            this.lbPatchCommands = new System.Windows.Forms.ListBox();
            this.gbxConsole = new System.Windows.Forms.GroupBox();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxConsole.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecutePatch
            // 
            this.btnExecutePatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecutePatch.Location = new System.Drawing.Point(414, 480);
            this.btnExecutePatch.Name = "btnExecutePatch";
            this.btnExecutePatch.Size = new System.Drawing.Size(102, 23);
            this.btnExecutePatch.TabIndex = 3;
            this.btnExecutePatch.Text = "Execute Patch";
            this.btnExecutePatch.UseVisualStyleBackColor = true;
            this.btnExecutePatch.Click += new System.EventHandler(this.btnExecutePatch_Click);
            // 
            // lbPatchCommands
            // 
            this.lbPatchCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPatchCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPatchCommands.FormattingEnabled = true;
            this.lbPatchCommands.ItemHeight = 18;
            this.lbPatchCommands.Location = new System.Drawing.Point(0, 0);
            this.lbPatchCommands.Name = "lbPatchCommands";
            this.lbPatchCommands.Size = new System.Drawing.Size(585, 228);
            this.lbPatchCommands.TabIndex = 2;
            this.lbPatchCommands.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbPatchCommands_MouseDoubleClick);
            // 
            // gbxConsole
            // 
            this.gbxConsole.Controls.Add(this.tbConsole);
            this.gbxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxConsole.Location = new System.Drawing.Point(0, 0);
            this.gbxConsole.Name = "gbxConsole";
            this.gbxConsole.Size = new System.Drawing.Size(585, 230);
            this.gbxConsole.TabIndex = 4;
            this.gbxConsole.TabStop = false;
            this.gbxConsole.Text = "Console";
            // 
            // tbConsole
            // 
            this.tbConsole.BackColor = System.Drawing.Color.Black;
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsole.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsole.ForeColor = System.Drawing.Color.White;
            this.tbConsole.Location = new System.Drawing.Point(3, 16);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbConsole.Size = new System.Drawing.Size(579, 211);
            this.tbConsole.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbPatchCommands);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbxConsole);
            this.splitContainer1.Size = new System.Drawing.Size(585, 462);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(522, 480);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PatcherInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(609, 515);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnExecutePatch);
            this.MinimizeBox = false;
            this.Name = "PatcherInterface";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patcher Interface";
            this.Load += new System.EventHandler(this.PatcherInterface_Load);
            this.gbxConsole.ResumeLayout(false);
            this.gbxConsole.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExecutePatch;
        private System.Windows.Forms.ListBox lbPatchCommands;
        private System.Windows.Forms.GroupBox gbxConsole;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClose;
    }
}