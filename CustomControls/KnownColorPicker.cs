using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
    /// <summary>
    /// <para>Created By    : YUKUANG</para>
    /// <para>Created Date  : 06 Nov 2009</para>
    /// <para>Modified By   : -</para>
    /// <para>Modified Date : -</para>
    /// <para>---------------------------------------------------------------</para>
    /// <para></para>
    /// <para>Changes</para>
    /// <para>---------------------------------------------------------------</para>
    /// <para></para>
    /// <para>Description</para>
    /// <para>---------------------------------------------------------------</para>
    /// ColorPicker control from known colors in a TreeView
    /// </summary>
    public partial class KnownColorPicker : UserControl
    {
        public KnownColorPicker()
        {
            InitializeComponent();
            PopulateColors();
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 06 Nov 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Does the population of the colors in the treeview
        /// </summary>
        public void PopulateColors()
        {
            //Create new image list for treeview
            ImageList list = new ImageList();

            //Assign it to the tree
            tvColors.ImageList = list;


            //Gets all known color
            string[] strColors = System.Enum.GetNames(typeof(KnownColor));

            //Create a new bitmap to contain the colors
            foreach (string strColor in strColors)
            {
                Bitmap image1 = new Bitmap(32, 32);

                //create the graphics control from the bitmap image
                Graphics gr = Graphics.FromImage(image1);

                //Create the brush with the color to use
                Brush p1 = new SolidBrush(Color.FromName(strColor));

                //fill the rectangle
                gr.FillRectangle(p1, 0, 0, image1.Width, image1.Height);

                //add the image to the imagelist
                list.Images.Add(image1);



                //Create a new tree node
                TreeNode node = new TreeNode(strColor);

                //set the image to use
                node.ImageIndex = list.Images.Count - 1;
                node.SelectedImageIndex = list.Images.Count - 1;

                //set the value of the node
                node.Tag = strColor;

                //add to the tree
                tvColors.Nodes.Add(node);
            }
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 06 Nov 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Sets the default color
        /// </summary>
        /// <param name="strColor"></param>
        public void SetDefaultColor(string strColor)
        {
            foreach (TreeNode node in tvColors.Nodes)
            {
                if (node.Text == strColor)
                {
                    tvColors.SelectedNode = node;
                    break;
                }
            }
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : 06 Nov 2009</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// Gets the selected color in the tree
        /// </summary>
        /// <returns></returns>
        public string GetSelectedColor() { return tvColors.SelectedNode.Text.ToString(); }
    }

}
