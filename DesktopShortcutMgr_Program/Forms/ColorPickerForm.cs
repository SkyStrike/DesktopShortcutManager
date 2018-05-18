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
    /// Color picker from Known Color
    /// </summary>
    public partial class ColorPickerForm : Form
    {
        /// <summary>
        /// Get/Sets the Selected color
        /// </summary>
        public string SelectedColor { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ColorPickerForm()
        {
            InitializeComponent();
        }

        private void frmColorPicker_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedColor))
                ucKnownColorPicker1.SetDefaultColor(SelectedColor);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedColor = ucKnownColorPicker1.GetSelectedColor();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
