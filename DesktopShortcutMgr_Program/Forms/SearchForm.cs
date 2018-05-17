using DesktopShortcutMgr.Entity;
using DesktopShortcutMgr.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopShortcutMgr
{
    /// <summary>
    /// <para>Created By    : YUKUANG</para>
    /// <para>Created Date  : 03 Sep 2009</para>
    /// <para>Modified By   : -</para>
    /// <para>Modified Date : -</para>
    /// <para>---------------------------------------------------------------</para>
    /// <para></para>
    /// <para>Changes</para>
    /// <para>---------------------------------------------------------------</para>
    /// <para></para>
    /// <para>Description</para>
    /// <para>---------------------------------------------------------------</para>
    /// Search for Shortcut
    /// </summary>
    public partial class SearchForm : Form
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lvSearchResult.Items.Clear();
            lvSearchResult.Groups.Clear();

            if (string.IsNullOrEmpty(ddlShortcutFile.Text))
            {
                //search all shortcut files
                foreach (string sGroup in ddlShortcutFile.Items)
                {
                    if (!string.IsNullOrEmpty(sGroup))
                    {
                        DataTable dt = SearchGroup(sGroup, tbShortcutName.Text);
                        if (dt == null || dt.Rows.Count > 0)
                        {
							lvSearchResult.ShowGroups = true;
							lvSearchResult.GridLines = true;
							ListViewGroup grp = new ListViewGroup(sGroup, sGroup);
							lvSearchResult.Groups.Add(grp);


							List<ShortcutItem> d = ShortcutUtil.ConvertToShortcut(dt);
							foreach (var item in d)
							{
								AddItem(item);
							}
						}
                    }
                }
            }
            else
            {
                DataTable dt = SearchGroup(ddlShortcutFile.Text, tbShortcutName.Text);
                if (dt == null || dt.Rows.Count > 0)
                {
					lvSearchResult.ShowGroups = true;
					lvSearchResult.GridLines = true;
					ListViewGroup grp = new ListViewGroup(ddlShortcutFile.Text, ddlShortcutFile.Text);
					lvSearchResult.Groups.Add(grp);

					List<ShortcutItem> d = ShortcutUtil.ConvertToShortcut(dt);
					foreach (var item in d)
					{
						AddItem(item);
					}
				}
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            List<string> l = ShortcutUtil.GetShortcutGroupNames();
            l.Insert(0, "");
            ddlShortcutFile.DataSource = l;
            lvSearchResult.View = View.Tile;
        }

        private DataTable SearchGroup(string sGroup, string sSearchCrit)
        {
            if (string.IsNullOrEmpty(sGroup)) return null;
            sSearchCrit = sSearchCrit.Replace("'", "''");
            DataSet ds = new DataSet();
            if (System.IO.File.Exists(AppConfig.GetShortcutFile(sGroup)))
            {
                ds.ReadXml(AppConfig.GetShortcutFile(sGroup));
                ds.Tables[0].DefaultView.RowFilter = "text LIKE '%" + sSearchCrit + "%' OR application LIKE '%" + sSearchCrit + "%'";
				ds.Tables[0].TableName = sGroup;
				return ds.Tables[0].DefaultView.ToTable();
            }
            else
            {
                return null;
            }
        }


		//Adds shortcut into the listview
		private void AddItem(ShortcutItem item)
        {
            Icon icn = null;

            //Load icon from path. If empty, try use the icons in the mappings
            if (string.IsNullOrEmpty(item.IconPath))
            {

                string strApplicationPart = CommonUtil.GetApplicationPart(item.Application);

                if (System.IO.Directory.Exists(strApplicationPart))
                {
                    //folder
                    icn = IconMapperUtil.GetDefaultIcon("folder");
                }
                else
                {
                    //get the default icons
                    string strExt = System.IO.Path.GetExtension(strApplicationPart).ToLower();
                    icn = IconMapperUtil.GetDefaultIcon(strExt);
                }
            }
            else
            {
                //Find in the icon folder first. if it exists, use it
                if (System.IO.File.Exists(AppConfig.GetIconMapFile(item.IconPath)))
                {
                    icn = CommonUtil.GetIcon(AppConfig.GetIconMapFile(item.IconPath));
                }

                //Locate the physical file directly. If exists, use it
                else if (System.IO.File.Exists(item.IconPath))
                {
                    icn = CommonUtil.GetIcon(item.IconPath);
                }

                //Use default icon
                else
                {
                    string strExt = System.IO.Path.GetExtension(item.Application).ToLower();
                    icn = IconMapperUtil.GetDefaultIcon(strExt);
                }
            }

            //Add item to list so that it is viewable in the list
            imageList1.Images.Add(icn);

            //create listview item
            ListViewItem l = new ListViewItem();
            l.ImageIndex = imageList1.Images.Count - 1;
            l.Text = item.Text; // +"\n" + item.strApplication;
            l.Name = Guid.NewGuid().ToString();
            l.ToolTipText = item.Application;
            l.Tag = item;
            l.Group = lvSearchResult.Groups[item.GroupName];

            //Add list view item
            lvSearchResult.Items.Add(l);
        }

        private void lvSearchResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if there is something selected, then try to execute
            if (lvSearchResult.SelectedItems != null)
            {
                if (lvSearchResult.SelectedItems.Count > 0)
                {
                    if (lvSearchResult.SelectedItems.Count > 1)
                    {
                        //Launching multiple program, prompt for confirmation

                        bool blnSupressPrompt = Properties.Settings.Default.SupressPromptMultipleProgram;
                        bool blnProceed = false;
                        if (!blnSupressPrompt)
                        {
                            blnProceed = MessageBox.Show(
                                "You are about to launch more than 1 program.\nThis may cause the computer to lag/hang.\nDo you wish to continue? \n\nTo turn off this prompt, check the option in \n\t[Options] \n\t\t> [Behaviour] \n\t\t\t> 'Supress Prompting when launching multiple selected programs'",
                                "Multiple Program Launch",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                        }
                        else
                        {
                            blnProceed = true;
                        }

                        if (blnProceed)
                        {
                            foreach (ListViewItem liSelectedItem in lvSearchResult.SelectedItems)
                            {
                                if (liSelectedItem != null)
                                    CommonUtil.ExecuteProgram((ShortcutItem)liSelectedItem.Tag);
                            }
                        }
                    }
                    else
                    {
                        //Launching single program
                        if (lvSearchResult.SelectedItems[0] != null)
                        {
							CommonUtil.ExecuteProgram(GetSelectedApplicationPathFromListView());
                        }
                    }
                }
            }
        }

        private void lvSearchResult_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem itm;
                itm = lvSearchResult.GetItemAt(e.X, e.Y);
                if (itm != null)
                {
                    this.ctxMnuListViewItem.Show(this.lvSearchResult, new Point(e.X, e.Y));
                }
            }
        }

        private void ctxMnuListViewItem_Execute_Click(object sender, EventArgs e)
        {
            CommonUtil.ExecuteProgram(GetSelectedApplicationPathFromListView());
        }

        private ShortcutItem GetSelectedApplicationPathFromListView()
        {
            return (ShortcutItem)lvSearchResult.SelectedItems[0].Tag;
        }

		//Opens the program'strFilename parent directory
		private void ctxMnuListViewItem_OpenDirectory_Click(object sender, EventArgs e)
        {
            CommonUtil.OpenProgramParent(GetSelectedApplicationPathFromListView());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }

}
