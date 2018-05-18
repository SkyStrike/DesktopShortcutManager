using DesktopShortcutMgr.Modules;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DesktopShortcutMgr.Forms
{
    public partial class PatcherForm : Form
    {
        ///// <summary>
        ///// Patch Config Path. Contains Icon Path, GroupName settings location and shortcut locations etx
        ///// </summary>
        //public string PatcherConfig { get; set; }

        /// <summary>
        /// For Execution of commands to be done in threads
        /// </summary>
        BackgroundWorker bgw = null;

        /// <summary>
        /// The main object to call when patching
        /// </summary>
        Patcher patcher = null;

        /// <summary>
        /// Default Constructor, nothing special
        /// </summary>
        public PatcherForm()
        {
            InitializeComponent();
        }

        //public PatcherForm(string PatcherConfig)
        //{
        //    InitializeComponent();
        //    this.PatcherConfig = PatcherConfig;
        //}

        /// <summary>
        /// Form Load. If no config, exit subroutine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PatcherInterface_Load(object sender, EventArgs e)
        {
            //Adds command available
            lbPatchCommands.Items.AddRange(Patcher.GetCommands());
        }

        /// <summary>
        /// Start Patching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecutePatch_Click(object sender, EventArgs e)
        {
            ExecuteSelectedCommand();
        }

        /// <summary>
        /// Start Patching too...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbPatchCommands_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExecuteSelectedCommand();
        }

        /// <summary>
        /// The real function to start patching based on the selected command
        /// </summary>
        private void ExecuteSelectedCommand()
        {
            if (lbPatchCommands.SelectedItem != null)
            {
                if (MessageBox.Show(
                    string.Format("Are you sure you want to execute command: {0}", lbPatchCommands.SelectedItem.ToString()),
                    "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    bgw = new BackgroundWorker();
                    bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                    bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);

                    patcher = new Patcher();
                    patcher.parentForm = this;

                    object[] param = new object[] { patcher, lbPatchCommands.SelectedItem.ToString() };
                    bgw.RunWorkerAsync(param);
                }
            }
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tbConsole.Text += Environment.NewLine + Environment.NewLine;

            tbConsole.Focus();
            tbConsole.Select(tbConsole.Text.Length, 0);
            tbConsole.ScrollToCaret();
        }

        /// <summary>
        /// Start the execution of the patch command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] param = (object[])e.Argument;
            Patcher p = (Patcher)param[0];
            p.ApplyPatch(param[1].ToString(), ref tbConsole);
        }

        /// <summary>
        /// Appends to the console textbox with a line
        /// </summary>
        /// <param name="x"></param>
        public void AppendConsoleLine(string x)
        {
            tbConsole.AppendText(x);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
