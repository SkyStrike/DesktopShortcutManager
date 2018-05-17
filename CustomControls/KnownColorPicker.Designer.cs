namespace CustomControls
{
    partial class KnownColorPicker
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tvColors = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvColors
            // 
            this.tvColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvColors.Indent = 15;
            this.tvColors.Location = new System.Drawing.Point(0, 0);
            this.tvColors.Name = "tvColors";
            this.tvColors.ShowLines = false;
            this.tvColors.ShowPlusMinus = false;
            this.tvColors.ShowRootLines = false;
            this.tvColors.Size = new System.Drawing.Size(329, 326);
            this.tvColors.TabIndex = 1;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvColors);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(329, 326);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView tvColors;
    }
}
