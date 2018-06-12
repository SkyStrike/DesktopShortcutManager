using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using DesktopShortcutMgr.Modules;
using System.Collections.Generic;
using DesktopShortcutMgr.Entity;
using DesktopShortcutMgr.UserControls;

namespace DesktopShortcutMgr.Forms
{
    public partial class OptionsForm : Form
    {
		//Get/Sets the Parent Form
		public MainForm opener { get; set; }

        string StartupShortcutLocation = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "ShortcutManager.lnk");

        public OptionsForm()
        {
            InitializeComponent();
        }

		public OptionsForm(MainForm opener)
        {
            InitializeComponent();
            this.opener = opener;
        }

		private void frmOptions_Load(object sender, EventArgs e)
        {
            LoadTabGeneral();
            LoadTabBehaviour();
            loadTabAbout();
            LoadTabDefaultIconsMappings();
            LoadTabGroupOrdering();
            LoadTabMaintenance();

            lnkVisitBlog.Tag = Properties.Settings.Default.GitHubUrl;
			lnkVisitBlog.Text += " at: " + Properties.Settings.Default.GitHubUrl;

		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RestoreTabGeneral();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving options. Please review error message: " + ex.ToString());
            }
            finally
            {

            }
        }

        private void SaveSettings()
        {
            SaveTabGeneral();
            SaveTabBehaviour();
            SaveTabDefaultIconMappings();
            SaveTabGroupOrdering();

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            this.DialogResult = DialogResult.OK;
        }


        #region Tab - General

        private delegate void ChangeShortcutBarColor(Color c);
        private event ChangeShortcutBarColor delChangeShortcutBarColor;
        private event ChangeShortcutBarColor delChangeShortcutBarTextColor;

		//Loads the General Tab
		private void LoadTabGeneral()
        {
            //Populate the dropdown list
            ddlExpandContractStyle.Items.AddRange(System.Enum.GetNames(typeof(ExpandContractStyle)));

            //sets the inital value from the settings

            //Trackbar default value
            trackBarHeight.Value = Properties.Settings.Default.IntialHeight;

            //Shortcutbar opacity
            trackBarOpacity.Value = ((int)(Properties.Settings.Default.Opacity * 100));
            lblOpacityValue.Text = trackBarOpacity.Value.ToString() + "%";

            //Shortcutbar Display Style
            ddlExpandContractStyle.Text = System.Enum.GetName(typeof(ExpandContractStyle), Properties.Settings.Default.ExpandContractStyle);

            //Startup Settings
            cbRunOnStartup.Checked = System.IO.File.Exists(StartupShortcutLocation);

            //Shotcutbar Background image
            tbBackgroundImage.Text = Properties.Settings.Default.BackgroundImagePath;
            cbUseBackgroundImage.Checked = !string.IsNullOrEmpty(Properties.Settings.Default.BackgroundImagePath);
            lblRecommendedDimension.Text += opener.GetListViewWidth().ToString() + " x " + opener.GetListViewHeight().ToString();


            //ShortcutBar Color
            pbShortcutBarColor.BackColor = Color.FromName(Properties.Settings.Default.ShortcutBarColor);
            lblShortcutBarColor.Text = Properties.Settings.Default.ShortcutBarColor;

            //ShortcutBar Text Color
            pbShortcutBarTextColor.BackColor = Color.FromName(Properties.Settings.Default.ShortcutBarTextColor);
            lblShortcutBarTextColor.Text = Properties.Settings.Default.ShortcutBarTextColor;


            //Show/Hide MiniPanel
            cbShowMiniPnl.Checked = Properties.Settings.Default.ShowMiniPanel;

            //Sets the delegates functions
            this.delChangeShortcutBarColor += new ChangeShortcutBarColor(frmOptions_delChangeShortcutBarColor);
            this.delChangeShortcutBarTextColor += new ChangeShortcutBarColor(frmOptions_delChangeShortcutBarTextColor);
        }

		//Restore the detaults for General Tab
		private void RestoreTabGeneral()
        {
            //Restore initial settings value
            trackBarHeight.Value = Properties.Settings.Default.IntialHeight;
            trackBarOpacity.Value = ((int)(Properties.Settings.Default.Opacity * 100));

            //restore defaults on the parent window
            if (opener != null)
            {
                int intNewHeight = (int)(opener.GetScreenHeight() * 1.0 * (trackBarHeight.Value / 100.0));
                opener.ConfigureThis(intNewHeight);

                double dblOpacity = (trackBarOpacity.Value / 100.0);
                opener.SetOpacity(dblOpacity);
                lblOpacityValue.Text = trackBarOpacity.Value.ToString() + "%";

                opener.ChangeBackgroundImage(Properties.Settings.Default.BackgroundImagePath);
                opener.ChangeShortcutBarColor(Color.FromName(Properties.Settings.Default.ShortcutBarColor));
                opener.ChangeShortcutBarTextColor(Color.FromName(Properties.Settings.Default.ShortcutBarTextColor));
            }
        }

		//Changes the height of the parent window
		private void trackBarHeight_Scroll(object sender, EventArgs e)
        {
            if (opener != null)
            {
                int intNewHeight = (int)(opener.GetScreenHeight() * 1.0 * (trackBarHeight.Value / 100.0));
                opener.ConfigureThis(intNewHeight);
            }
        }

		//change the opacity of the parent window
		private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            if (opener != null)
            {
                double dblOpacity = (trackBarOpacity.Value / 100.0);
                opener.SetOpacity(dblOpacity);
                lblOpacityValue.Text = trackBarOpacity.Value.ToString() + "%";
            }
        }

		//saves the General Tab settings
		private void SaveTabGeneral()
        {
            Properties.Settings.Default.IntialHeight = trackBarHeight.Value;
            Properties.Settings.Default.Opacity = trackBarOpacity.Value / 100.0;

            if (cbUseBackgroundImage.Checked)
            {
                Properties.Settings.Default.BackgroundImagePath = tbBackgroundImage.Text;
            }
            else
            {
                Properties.Settings.Default.BackgroundImagePath = "";
            }

            Properties.Settings.Default.ShortcutBarColor = lblShortcutBarColor.Text;
            Properties.Settings.Default.ShortcutBarTextColor = lblShortcutBarTextColor.Text;

            ExpandContractStyle expandContractStyle = (ExpandContractStyle)Enum.Parse(typeof(ExpandContractStyle), ddlExpandContractStyle.Text, true);
            Properties.Settings.Default.ExpandContractStyle = ((int)expandContractStyle);


            CreateStartupShortcut(cbRunOnStartup.Checked);
            
            Properties.Settings.Default.ShowMiniPanel = cbShowMiniPnl.Checked;
        }

		//Creates or Remove startup shortcut from Startup folder
		private void CreateStartupShortcut(bool create)
        {
            if (create)
            {
                IWshRuntimeLibrary.WshShellClass shell = null;
                IWshRuntimeLibrary.IWshShortcut link = null;
                try
                {
                    shell = new IWshRuntimeLibrary.WshShellClass();
                    link = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(StartupShortcutLocation);
                    link.TargetPath = Application.ExecutablePath;
                    link.WorkingDirectory = AppConfig.CurrentDirectory;
                    link.Save();
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(
                        string.Format("You do not have sufficient access rights to create the shortcut in the Startup directory (\"{0}\")", Environment.GetFolderPath(Environment.SpecialFolder.Startup))
                    );
                }
                catch (Exception)
                {
                    MessageBox.Show(
                            string.Format(
                                "Unable to create the shortcut in startup folder. Please try again later or add it manually in \"{0}\".\nIf problem persist, you may have insufficient rights to perform this action.",
                                Environment.GetFolderPath(Environment.SpecialFolder.Startup))
                        );
                }
                finally
                {
                    shell = null;
                    link = null;
                }
            }
            else
            {
                if (System.IO.File.Exists(StartupShortcutLocation))
                {
                    try
                    {
                        System.IO.File.Delete(StartupShortcutLocation);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show(
                            string.Format("You do not have sufficient access rights to remove the shortcut from the Startup directory (\"{0}\")",Environment.GetFolderPath(Environment.SpecialFolder.Startup))
                        );
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            string.Format(
                                "Unable to remove the shortcut from folder. Please try again later or remove it manually from \"{0}\"\nIf problem persist, you may have insufficient rights to perform this action.",
                                StartupShortcutLocation)
                        );
                    }
                }
            }
        }

        private void cbUseBackgroundImage_CheckedChanged(object sender, EventArgs e)
        {
            tbBackgroundImage.Enabled = cbUseBackgroundImage.Checked;
        }

        private void tbBackgroundImage_Click(object sender, EventArgs e)
        {
            BrowseForBackground();
        }

		//Browse for background. Opens a open file dialog
		private void BrowseForBackground()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|gif (*.gif)|*.gif|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbBackgroundImage.Text = ofd.FileName;
                opener.ChangeBackgroundImage(tbBackgroundImage.Text);
            }
        }

        private void ShortcutbarColor_Click(object sender, EventArgs e)
        {
            ShowColorPicker(lblShortcutBarColor, pbShortcutBarColor, delChangeShortcutBarColor);
        }

        private void ShortcutBarTextColor_Click(object sender, EventArgs e)
        {
            ShowColorPicker(lblShortcutBarTextColor, pbShortcutBarTextColor, delChangeShortcutBarTextColor);
        }

        private void frmOptions_delChangeShortcutBarTextColor(Color c)
        {
            opener.ChangeShortcutBarTextColor(c);
        }

        private void frmOptions_delChangeShortcutBarColor(Color c)
        {
            opener.ChangeShortcutBarColor(c);
        }

        private void ShowColorPicker(Label lblToUpdate, PictureBox pbToUpdate, Delegate delFunction)
        {
            ColorPickerForm frm = new ColorPickerForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Color c = Color.FromName(frm.SelectedColor);
                pbToUpdate.BackColor = c;
                lblToUpdate.Text = frm.SelectedColor;

                if (opener != null)
                    delFunction.DynamicInvoke(new object[] { c });
            }
        }

        public enum ExpandContractStyle
        {
            Hover,
            Appear
        }

        #endregion

        #region Tab - Behaviour

        private void LoadTabBehaviour()
        {
            bool blnSupressPrompt = Properties.Settings.Default.SupressPromptMultipleProgram;
            cbSupressPrompt_MultiProgramLaunch.Checked = blnSupressPrompt;
        }

        private void SaveTabBehaviour()
        {
            Properties.Settings.Default.SupressPromptMultipleProgram = cbSupressPrompt_MultiProgramLaunch.Checked;
        }

        #endregion

        #region Tab - About

        private void loadTabAbout()
        {
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;

            Assembly asm;

            this.textBoxDescription.AppendText(
                Environment.NewLine +
                Environment.NewLine +
                "External Loaded Libraries" +
                Environment.NewLine +
                "----------------------------------------------------------------------------" +
                Environment.NewLine);

            asm = Assembly.GetAssembly(typeof(CrashReporterForm));
            this.textBoxDescription.AppendText(FormatDescription(asm));
        }

        private string FormatDescription(Assembly asm)
        {
            string s = "";
            object[] attributes = asm.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "")
                {
                    s += titleAttribute.Title;
                }
            }
            else
            {
                s += System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }

            s += " " + asm.GetName().Version + Environment.NewLine;


            attributes = asm.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length != 0)
            {
                if (!string.IsNullOrEmpty(((AssemblyDescriptionAttribute)attributes[0]).Description))
                {
                    s += ((AssemblyDescriptionAttribute)attributes[0]).Description + Environment.NewLine;
                }
            }

            attributes = null;
            return s + Environment.NewLine;
        }

		#region Assembly Attribute Accessors

		//Get Program Title
		public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

		//Get Program Version
		public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

		//Get Program Description
		public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

		//Get Product Name
		public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

		//Get Copyright
		public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

		//Get Company
		public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

		#endregion


		#endregion

		#region Tab - Default Icon Mappings

		//Loads the default icon mapping tab
		private void LoadTabDefaultIconsMappings()
        {
            dgvDefaultIconMapping.DataSource = IconMapperUtil.GetIconMapDataTable();
        }

		//save the default icon mapping tab settings
		private void SaveTabDefaultIconMappings()
        {
			DataTable dt = (DataTable) dgvDefaultIconMapping.DataSource;
			IconMapperUtil.UpdateIconMapping(dt);
        }

		#endregion

		#region Tab - Group Ordering

		//Load the tab: Group Ordering
		private void LoadTabGroupOrdering()
        {
            try
            {
				List<string> groupNames = ShortcutUtil.GetShortcutGroupNames();
				foreach (string groupName in groupNames)
				{
					lbGroups.Items.Add(groupName);
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Tab: Group Ordering: " + ex.ToString());
            }
        }

        private void SaveTabGroupOrdering()
        {
			List<ShortcutGroupItem> groupNames = new List<ShortcutGroupItem>();
			foreach (string item in lbGroups.Items)
            {
				ShortcutGroupItem i = new ShortcutGroupItem()
				{
					Name = item.ToString()
				};
				groupNames.Add(i);
			}

			ShortcutGroup group = new ShortcutGroup()
			{
				Items = groupNames
			};
			ShortcutUtil.UpdateGroup(group);
		}

        #region Move Up/ Move Bottom
        private void btnMoveToTop_Click(object sender, EventArgs e)
        {
            if (lbGroups.SelectedIndex < 0) { return; }
            if (lbGroups.SelectedIndex != 0)
            {
                object objSelectedItem = lbGroups.SelectedItem;
                lbGroups.Items.RemoveAt(lbGroups.SelectedIndex);
                lbGroups.Items.Insert(0, objSelectedItem);
                lbGroups.SelectedItem = objSelectedItem;
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lbGroups.SelectedIndex < 0) { return; }

            if (lbGroups.SelectedIndex != 0)
            {
                int intInitialSelectedIndex = lbGroups.SelectedIndex;

                object objSelectedItem = lbGroups.SelectedItem;
                lbGroups.Items.RemoveAt(intInitialSelectedIndex);

                lbGroups.Items.Insert(intInitialSelectedIndex - 1, objSelectedItem);
                lbGroups.SelectedItem = objSelectedItem;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lbGroups.SelectedIndex < 0) { return; }

            if (lbGroups.SelectedIndex != (lbGroups.Items.Count - 1))
            {
                int intInitialSelectedIndex = lbGroups.SelectedIndex;

                object objSelectedItem = lbGroups.SelectedItem;
                lbGroups.Items.RemoveAt(intInitialSelectedIndex);

                lbGroups.Items.Insert(intInitialSelectedIndex + 1, objSelectedItem);
                lbGroups.SelectedItem = objSelectedItem;
            }
        }

        private void btnMoveToBottom_Click(object sender, EventArgs e)
        {
            if (lbGroups.SelectedIndex < 0) { return; }

            if (lbGroups.SelectedIndex != (lbGroups.Items.Count - 1))
            {
                int intInitialSelectedIndex = lbGroups.SelectedIndex;

                object objSelectedItem = lbGroups.SelectedItem;
                lbGroups.Items.RemoveAt(intInitialSelectedIndex);

                lbGroups.Items.Insert((lbGroups.Items.Count), objSelectedItem);
                lbGroups.SelectedItem = objSelectedItem;
            }
        }

        #endregion

        private void btnRemoveUnusedIcos_Click(object sender, EventArgs e)
        {
			(new Patcher()).ApplyPatch(Patcher.Commands.ClearUnusedIcons);
        }



        #endregion

        #region Tab - Maintenance

        private void LoadTabMaintenance()
        {
            tbShortcutFolder.Text = AppConfig.ShortcutFolder;
            tbConfigFolder.Text = AppConfig.ConfigFolder;
            tbIconsFolder.Text = AppConfig.IconFolder;

            lnkShortcutFolder.Tag = AppConfig.ShortcutFolder;
            lnkConfigurationFolder.Tag = AppConfig.ConfigFolder;
            lnkIconFolder.Tag = AppConfig.IconFolder;

            lnkShortcutFolder.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelExecuteTagContent_Click);
            lnkConfigurationFolder.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelExecuteTagContent_Click);
            lnkIconFolder.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelExecuteTagContent_Click);

        }

        private void LinkLabelExecuteTagContent_Click(object sender, EventArgs e)
        {
            if (sender is LinkLabel)
            {
                LinkLabel lbl = (LinkLabel)sender;
				CommonUtil.JustExecute(lbl.Tag.ToString());
            }
        }


        private void btnLaunchPatcher_Click(object sender, EventArgs e)
        {
            PatcherForm frm = new PatcherForm();
            frm.ShowDialog();
        }
        #endregion

        
        private void lnkVisitBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			System.Diagnostics.Process.Start(lnkVisitBlog.Tag.ToString());
		}
    }
}
