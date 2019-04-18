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
    /// <para>Created By    : YUKUANG</para>
    /// <para>Created Date  : Undated July 2008</para>
    /// <para>Modified By   : -</para>
    /// <para>Modified Date : -</para>
    /// <para>---------------------------------------------------------------</para>
    /// <para></para>
    /// <para>Changes</para>
    /// <para>---------------------------------------------------------------</para>
    /// <para></para>
    /// <para>Description</para>
    /// <para>---------------------------------------------------------------</para>
    /// </summary>
    public partial class TextReturnerForm : Form
    {
        /// <summary>
        /// Get/Sets the Text to return
        /// </summary>
        public string strReturnText { get; set; }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : Undated July 2008</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// </summary>
        public TextReturnerForm()
        {
            InitializeComponent();
            CommonUtil.SetApplicationFont(Controls);
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : Undated July 2008</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// </summary>
        /// <param name="strFormName"></param>
        /// <param name="strLabelName"></param>
        /// <param name="strButtonText"></param>
        public TextReturnerForm(string strFormName, string strLabelName, string strButtonText)
        {
            InitializeComponent();
            CommonUtil.SetApplicationFont(Controls);

            this.Text = strFormName;
            lblLabel.Text = strLabelName;
            btnSubmit.Text = strButtonText;
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : Undated July 2008</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// </summary>
        /// <param name="strInitialText"></param>
        /// <param name="blnSelected"></param>
        public void SetInitialText(string strInitialText, bool blnSelected)
        {
            tbReturnText.Text = strInitialText;
            if (blnSelected)
            {
                tbReturnText.SelectAll();
            }
        }

        /// <summary>
        /// Sets the width of the form
        /// </summary>
        /// <param name="newWidth">New Width Size</param>
        public void SetWidth(int newWidth)
        {
            this.Width = newWidth;
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : Undated July 2008</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            strReturnText = tbReturnText.Text;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// <para>Created By    : YUKUANG</para>
        /// <para>Created Date  : Undated July 2008</para>
        /// <para>Modified By   : -</para>
        /// <para>Modified Date : -</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Changes</para>
        /// <para>---------------------------------------------------------------</para>
        /// <para></para>
        /// <para>Description</para>
        /// <para>---------------------------------------------------------------</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTextReturner_Shown(object sender, System.EventArgs e)
        {
            tbReturnText.Focus();
        }

    }
}
