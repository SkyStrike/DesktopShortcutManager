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
    /// <para>Created Date  : 26 Oct 2009</para>
    /// <para>Modified By   : -</para>
    /// <para>Modified Date : -</para>
    /// <para>---------------------------------------------------------------</para>
    /// <para></para>
    /// <para>Changes</para>
    /// <para>---------------------------------------------------------------</para>
    /// <para></para>
    /// <para>Description</para>
    /// <para>---------------------------------------------------------------</para>
    /// Custom Sorting Window
    /// </summary>
    public partial class CustomSortingForm : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomSortingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the Sorted View
        /// </summary>
        /// <returns></returns>
        public ListView UpdatedListView()
        {
            return listView1;
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 26 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Default Constructor with 2 parameter. This will initialize the items in the listview
        /// </summary>
        /// <param name="lvParent"></param>
        /// <param name="imgList"></param>
        public CustomSortingForm(ListView lvParent, ImageList imgList)
        {
            InitializeComponent();

            //Sets the listview imagelist
            listView1.SmallImageList = imgList;
            listView1.LargeImageList = imgList;

            //Set to list mode
            listView1.View = View.List;

            //Insert item. Not able to add directly (Just like datarow, 1 instance cannot exists in multiple table)
            foreach (ListViewItem item in lvParent.Items)
            {
                //Clone item and add
                ListViewItem itm = (ListViewItem)item.Clone();
                itm.BackColor = Color.Transparent;
                listView1.Items.Add(itm);
            }
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 26 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Cancel Changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 26 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Save Changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 26 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Move item to top
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveTop_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null) { return; }
            if (listView1.SelectedItems[0].Index < 0) { return; }

            if (listView1.SelectedItems[0].Index != 0)
            {
                ListViewItem objSelectedItem = getSelectedItem();
                listView1.Items.RemoveAt(getSelectedItemIndex());

                listView1.Items.Insert(0, objSelectedItem);
                objSelectedItem.Selected = true;
                listView1.Focus();
            }

        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 26 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Move item Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null) { return; }
            if (listView1.SelectedItems[0].Index < 0) { return; }

            if (listView1.SelectedItems[0].Index != 0)
            {
                int intInitialSelectedIndex = getSelectedItemIndex();

                ListViewItem objSelectedItem = getSelectedItem();
                listView1.Items.RemoveAt(intInitialSelectedIndex);

                listView1.Items.Insert(intInitialSelectedIndex - 1, objSelectedItem);
                objSelectedItem.Selected = true;
                listView1.Focus();
            }
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 26 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Move item down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null) { return; }
            if (listView1.SelectedItems[0].Index < 0) { return; }

            if (listView1.SelectedItems[0].Index != (listView1.Items.Count - 1))
            {
                int intInitialSelectedIndex = getSelectedItemIndex();

                ListViewItem objSelectedItem = getSelectedItem();
                listView1.Items.RemoveAt(intInitialSelectedIndex);

                listView1.Items.Insert(intInitialSelectedIndex + 1, objSelectedItem);
                objSelectedItem.Selected = true;
                listView1.Focus();
            }
        }


        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 26 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Move item to bottom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null) { return; }
            if (listView1.SelectedItems[0].Index < 0) { return; }

            if (listView1.SelectedItems[0].Index != (listView1.Items.Count - 1))
            {
                int intInitialSelectedIndex = getSelectedItemIndex();

                ListViewItem objSelectedItem = getSelectedItem();
                listView1.Items.RemoveAt(intInitialSelectedIndex);

                listView1.Items.Insert((listView1.Items.Count), objSelectedItem);
                objSelectedItem.Selected = true;
                listView1.Focus();
            }
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 26 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Gets the first selected item index
        /// </summary>
        /// <returns></returns>
        private int getSelectedItemIndex()
        {
            return listView1.SelectedItems[0].Index;
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 26 Oct 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Gets the first selected item
        /// </summary>
        /// <returns></returns>
        private ListViewItem getSelectedItem()
        {
            return listView1.SelectedItems[0];
        }
    }
}
