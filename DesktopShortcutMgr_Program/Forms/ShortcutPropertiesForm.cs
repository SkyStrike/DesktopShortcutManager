using DesktopShortcutMgr.Entity;
using DesktopShortcutMgr.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopShortcutMgr.Forms
{
	//Display shortcut settings. Allows users to specify new shortcut name and application path
	public partial class ShortcutPropertiesForm : Form
    {

		//Get/Sets Parent Form
		public MainForm FrmOpener { get; set; }

		public ShortcutItem ShortcutItem { get; set; }

		public ShortcutPropertiesForm()
		{
			InitializeComponent();
		}

		//OK = Return OK
		private void btnOK_Click(object sender, EventArgs e)
        {
			ShortcutItem.Text = tbShortcutName.Text;
			ShortcutItem.Application = tbShortcutPath.Text;
			ShortcutItem.RunAsAdmin = cbRunAsAdmin.Checked;
			ShortcutItem.Arguments = tbArguments.Text;

			this.DialogResult = DialogResult.OK;
        }

		//Returns Cancel Result
		private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmShortcutProperties_Load(object sender, EventArgs e)
        {

            if (ShortcutItem != null)
            {
                if (!string.IsNullOrEmpty(ShortcutItem.IconPath) && System.IO.File.Exists(AppConfig.GetIconMapFile(ShortcutItem.IconPath)))
                {
                    LoadIcon(AppConfig.GetIconMapFile(ShortcutItem.IconPath));
                }
                else if (System.IO.File.Exists(ShortcutItem.IconPath))
                {
                    LoadIcon(ShortcutItem.IconPath);
                }


				tbShortcutName.Text = ShortcutItem.Text;
				string path = ShortcutItem.Application;
				if (path[0] != '\"')
				{
					tbShortcutPath.Text = "\"" + path + "\"";
				}
				else
				{
					tbShortcutPath.Text = path;
				}
				cbRunAsAdmin.Checked = ShortcutItem.RunAsAdmin;
				if (!string.IsNullOrEmpty(ShortcutItem.Arguments)) {
					tbArguments.Lines = ShortcutItem.Arguments.Split(
						new string[] { "\n", "\r\n", "\n\r" },
						StringSplitOptions.None
					);
				}
				
			}
        }

		//Opens the FileBrowser Dialog for icon selection
		private void pbIcon_Click(object sender, EventArgs e)
        {
			OpenFileDialog ofd = new OpenFileDialog()
			{
				InitialDirectory = AppConfig.IconFolder,
				Filter = "All icons (*.ico)|*.ico"
			};

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadIcon(ofd.FileName);
            }
        }

		//Loads selected file icon into picture box
		private void LoadIcon(string strIconPath)
        {
            try
            {
                Icon i = new Icon(strIconPath);
                pbIcon.Image = i.ToBitmap();
				ShortcutItem.IconPath = strIconPath;
			}
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred while loading Icon. " + ex.ToString());
            }
        }

        private void ctxMnu_Path_Browse_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(ofd.FileName))
                {
                    if (ofd.FileName[0] != '\"')
                    {
                        ofd.FileName = "\"" + ofd.FileName + "\"";
                    }
                    tbShortcutPath.Text = ofd.FileName;
                }
            }
        }

        private void ctxMnu_Path_Browse_Folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(fb.SelectedPath))
                {
                    if (fb.SelectedPath[0] != '\"')
                    {
                        fb.SelectedPath = "\"" + fb.SelectedPath + "\"";
                    }
                    tbShortcutPath.Text = fb.SelectedPath;
                }
            }
        }

        private void ctxMnu_Path_OpenParentDir_Click(object sender, EventArgs e)
        {
            CommonUtil.OpenProgramParent(tbShortcutPath.Text);
        }

        private void btnBrowse_MouseUp(object sender, MouseEventArgs e)
        {
            ctxMnu_Path.Show(btnBrowse, new Point(e.X, e.Y));
        }
    }
}
