namespace DesktopShortcutMgr.Forms
{
    partial class TextReturnerForm
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
			this.tbReturnText = new System.Windows.Forms.TextBox();
			this.lblLabel = new System.Windows.Forms.Label();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbReturnText
			// 
			this.tbReturnText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbReturnText.Location = new System.Drawing.Point(85, 6);
			this.tbReturnText.Name = "tbReturnText";
			this.tbReturnText.Size = new System.Drawing.Size(149, 20);
			this.tbReturnText.TabIndex = 5;
			// 
			// lblLabel
			// 
			this.lblLabel.AutoSize = true;
			this.lblLabel.Location = new System.Drawing.Point(12, 9);
			this.lblLabel.Name = "lblLabel";
			this.lblLabel.Size = new System.Drawing.Size(33, 13);
			this.lblLabel.TabIndex = 4;
			this.lblLabel.Text = "Label";
			// 
			// btnSubmit
			// 
			this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSubmit.Location = new System.Drawing.Point(240, 4);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(49, 23);
			this.btnSubmit.TabIndex = 3;
			this.btnSubmit.Text = "Submit";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// frmTextReturner
			// 
			this.AcceptButton = this.btnSubmit;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 33);
			this.Controls.Add(this.tbReturnText);
			this.Controls.Add(this.lblLabel);
			this.Controls.Add(this.btnSubmit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmTextReturner";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Text Returner";
			this.Shown += new System.EventHandler(this.frmTextReturner_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox tbReturnText;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Button btnSubmit;
    }
}