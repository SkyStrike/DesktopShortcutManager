using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrashReporterLibrary
{
    public partial class CrashReporter : Form
    {
        public Exception ex { get; set; }
        public CrashReporter()
        {
            InitializeComponent();
        }

        public CrashReporter(Exception ex)
        {
            InitializeComponent();
            this.ex = ex;
        }

        private void frmCrashReporter_Load(object sender, EventArgs e)
        {
            tbException.Text = GetExceptionText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File (*.txt)|*.txt";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                {
                    sw.WriteLine(tbException.Text);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private string GetExceptionText()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(string.Format("Source: {0}", ex.Source))
                .AppendLine(string.Format("Message: {0}", ex.Message))
                .AppendLine("Stack Trace: ")
                .AppendLine(ex.StackTrace);

            return sb.ToString();
        }

        private void cbWrapText_CheckedChanged(object sender, EventArgs e)
        {
            tbException.WordWrap = cbWrapText.Checked;
        }
    }
}
