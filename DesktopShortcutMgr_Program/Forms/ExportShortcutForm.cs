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
    /// <summary>
    /// Form to export shortcuts in groups
    /// </summary>
    public partial class ExportShortcutForm : Form
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ExportShortcutForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cblGroups.CheckedItems.Count == 0)
            {
                MessageBox.Show("At least a group must be selected");
                return;
            }

            List<string> selectedGroups = new List<string>();
            foreach (string items in cblGroups.CheckedItems)
            {
                selectedGroups.Add(items);
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string group in selectedGroups)
                {
                    ExportGroup(group, fbd.SelectedPath, cbRemoveInvalidItems.Checked);
                }

                if (MessageBox.Show("Export Completed. Open directory now?", "Export Completed", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fbd.SelectedPath);
                }
            }
        }

        /// <summary>
        /// Exports Shortcuts in Group
        /// </summary>
        /// <param name="GroupName"></param>
        /// <param name="RemoveInvalid"></param>
        public void ExportGroup(string GroupName, bool RemoveInvalid)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExportGroup(GroupName, fbd.SelectedPath, RemoveInvalid);

                if (MessageBox.Show("Export Completed. Open directory now?", "Export Completed", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fbd.SelectedPath);
                }
            }
        }

        /// <summary>
        /// Exports Shortcuts in Group to selected folder
        /// </summary>
        /// <param name="GroupName"></param>
        /// <param name="Directory"></param>
        /// <param name="RemoveInvalid"></param>
        private void ExportGroup(string GroupName, string Directory, bool RemoveInvalid)
        {
            string directoryName = GroupName;
            foreach (char c in System.IO.Path.GetInvalidPathChars())
            {
                directoryName = GroupName.Replace(c.ToString(), "_");
            }

            while (System.IO.Directory.Exists(System.IO.Path.Combine(Directory, directoryName)))
            {
                directoryName = GroupName + "__" + DateTime.Now.Millisecond.ToString();
            }

            string strShortcutFile = AppConfig.GetShortcutFile(GroupName);
            string SaveToDirectory = System.IO.Path.Combine(Directory, directoryName);


            if (!System.IO.Directory.Exists(SaveToDirectory))
                System.IO.Directory.CreateDirectory(SaveToDirectory);

			List<ShortcutItem> files = ShortcutUtil.GetShortcuts(GroupName);
			if (files != null && files.Count > 0)
			{
				foreach (ShortcutItem item in files)
				{
					item.CreateDesktopShortcut(SaveToDirectory, RemoveInvalid);
				}
			}
		}

        private void frmExportShortcut_Load(object sender, EventArgs e)
        {
            foreach (string s in ShortcutUtil.GetShortcutGroupNames())
            {
                cblGroups.Items.Add(s);
            }
        }
    }
}
