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
    public partial class TextDisplayForm : Form
    {
        /// <summary>
        /// Sets the Title of the Form
        /// </summary>
        public string  FormTitle { get; set; }

        /// <summary>
        /// Sets the Content of the Textbox
        /// </summary>
        public string TextContent { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TextDisplayForm()
        {
            InitializeComponent();
            CommonUtil.SetApplicationFont(Controls);
        }

        /// <summary>
        /// Constructor with initialization parameters to set Form Title and Content
        /// </summary>
        /// <param name="FormTitle"></param>
        /// <param name="TextContent"></param>
        public TextDisplayForm(string FormTitle, string TextContent)
        {
            this.FormTitle = FormTitle;
            this.TextContent = TextContent;

            InitializeComponent();
        }

        private void frmTextDisplay_Load(object sender, EventArgs e)
        {
            this.Text = FormTitle;
            tbTextContent.Text = TextContent;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Document (*.txt)|*.txt";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                {
                    sw.WriteLine(tbTextContent.Text);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
