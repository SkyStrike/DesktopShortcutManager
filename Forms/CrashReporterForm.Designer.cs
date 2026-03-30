namespace DesktopShortcutMgr.Forms
{
	partial class CrashReporterForm
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
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.tbException = new System.Windows.Forms.TextBox();
			this.lblError = new System.Windows.Forms.Label();
			this.cbWrapText = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(559, 227);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(478, 227);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// tbException
			// 
			this.tbException.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbException.Location = new System.Drawing.Point(15, 25);
			this.tbException.Multiline = true;
			this.tbException.Name = "tbException";
			this.tbException.ReadOnly = true;
			this.tbException.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbException.Size = new System.Drawing.Size(619, 196);
			this.tbException.TabIndex = 2;
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			this.lblError.Location = new System.Drawing.Point(12, 9);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(329, 13);
			this.lblError.TabIndex = 3;
			this.lblError.Text = "The application crashed. Please refer to the textbox below for details";
			// 
			// cbWrapText
			// 
			this.cbWrapText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbWrapText.AutoSize = true;
			this.cbWrapText.Checked = true;
			this.cbWrapText.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbWrapText.Location = new System.Drawing.Point(15, 227);
			this.cbWrapText.Name = "cbWrapText";
			this.cbWrapText.Size = new System.Drawing.Size(76, 17);
			this.cbWrapText.TabIndex = 4;
			this.cbWrapText.Text = "Wrap Text";
			this.cbWrapText.UseVisualStyleBackColor = true;
			this.cbWrapText.CheckedChanged += new System.EventHandler(this.cbWrapText_CheckedChanged);
			// 
			// frmCrashReporter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(646, 262);
			this.Controls.Add(this.cbWrapText);
			this.Controls.Add(this.lblError);
			this.Controls.Add(this.tbException);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClose);
			this.Name = "frmCrashReporter";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Crash Reporter";
			this.Load += new System.EventHandler(this.frmCrashReporter_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox tbException;
		private System.Windows.Forms.Label lblError;
		private System.Windows.Forms.CheckBox cbWrapText;
	}
}