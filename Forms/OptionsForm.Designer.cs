namespace DesktopShortcutMgr.Forms
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.gbxGeneral_Effects = new System.Windows.Forms.GroupBox();
            this.lblRecommendedDimension = new System.Windows.Forms.Label();
            this.tbBackgroundImage = new System.Windows.Forms.TextBox();
            this.cbUseBackgroundImage = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlExpandContractStyle = new System.Windows.Forms.ComboBox();
            this.gbxGeneral_Appearance = new System.Windows.Forms.GroupBox();
            this.cbShowMiniPnl = new System.Windows.Forms.CheckBox();
            this.lblOpacityValue = new System.Windows.Forms.Label();
            this.lblShortcutBarTextColor = new System.Windows.Forms.Label();
            this.pbShortcutBarTextColor = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblShortcutBarColor = new System.Windows.Forms.Label();
            this.pbShortcutBarColor = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.trackBarHeight = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.cbRunOnStartup = new System.Windows.Forms.CheckBox();
            this.tabBehaviour = new System.Windows.Forms.TabPage();
            this.cbSupressPrompt_MultiProgramLaunch = new System.Windows.Forms.CheckBox();
            this.tabDefaultIconMapping = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDefaultIconMapping = new System.Windows.Forms.DataGridView();
            this.tabGroupOrder = new System.Windows.Forms.TabPage();
            this.btnMoveToBottom = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveToTop = new System.Windows.Forms.Button();
            this.lbGroups = new System.Windows.Forms.ListBox();
            this.tabMaintenance = new System.Windows.Forms.TabPage();
            this.gbxSystemConfig = new System.Windows.Forms.GroupBox();
            this.lnkIconFolder = new System.Windows.Forms.LinkLabel();
            this.lnkConfigurationFolder = new System.Windows.Forms.LinkLabel();
            this.lnkShortcutFolder = new System.Windows.Forms.LinkLabel();
            this.tbConfigFolder = new System.Windows.Forms.TextBox();
            this.tbShortcutFolder = new System.Windows.Forms.TextBox();
            this.tbIconsFolder = new System.Windows.Forms.TextBox();
            this.gbxPatchModule = new System.Windows.Forms.GroupBox();
            this.btnLaunchPatcher = new System.Windows.Forms.Button();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.lnkVisitBlog = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlButtons.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.gbxGeneral_Effects.SuspendLayout();
            this.gbxGeneral_Appearance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShortcutBarTextColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShortcutBarColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHeight)).BeginInit();
            this.tabBehaviour.SuspendLayout();
            this.tabDefaultIconMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefaultIconMapping)).BeginInit();
            this.tabGroupOrder.SuspendLayout();
            this.tabMaintenance.SuspendLayout();
            this.gbxSystemConfig.SuspendLayout();
            this.gbxPatchModule.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSubmit);
            this.pnlButtons.Location = new System.Drawing.Point(481, 408);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(163, 29);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(3, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Save";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabBehaviour);
            this.tabControl1.Controls.Add(this.tabDefaultIconMapping);
            this.tabControl1.Controls.Add(this.tabGroupOrder);
            this.tabControl1.Controls.Add(this.tabMaintenance);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 390);
            this.tabControl1.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.gbxGeneral_Effects);
            this.tabGeneral.Controls.Add(this.gbxGeneral_Appearance);
            this.tabGeneral.Controls.Add(this.cbRunOnStartup);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(624, 364);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // gbxGeneral_Effects
            // 
            this.gbxGeneral_Effects.Controls.Add(this.lblRecommendedDimension);
            this.gbxGeneral_Effects.Controls.Add(this.tbBackgroundImage);
            this.gbxGeneral_Effects.Controls.Add(this.cbUseBackgroundImage);
            this.gbxGeneral_Effects.Controls.Add(this.label3);
            this.gbxGeneral_Effects.Controls.Add(this.ddlExpandContractStyle);
            this.gbxGeneral_Effects.Location = new System.Drawing.Point(3, 226);
            this.gbxGeneral_Effects.Name = "gbxGeneral_Effects";
            this.gbxGeneral_Effects.Size = new System.Drawing.Size(615, 100);
            this.gbxGeneral_Effects.TabIndex = 10;
            this.gbxGeneral_Effects.TabStop = false;
            this.gbxGeneral_Effects.Text = "Effects";
            // 
            // lblRecommendedDimension
            // 
            this.lblRecommendedDimension.AutoSize = true;
            this.lblRecommendedDimension.Location = new System.Drawing.Point(378, 66);
            this.lblRecommendedDimension.Name = "lblRecommendedDimension";
            this.lblRecommendedDimension.Size = new System.Drawing.Size(108, 13);
            this.lblRecommendedDimension.TabIndex = 11;
            this.lblRecommendedDimension.Text = "Recommended Size: ";
            // 
            // tbBackgroundImage
            // 
            this.tbBackgroundImage.Enabled = false;
            this.tbBackgroundImage.Location = new System.Drawing.Point(160, 63);
            this.tbBackgroundImage.Name = "tbBackgroundImage";
            this.tbBackgroundImage.Size = new System.Drawing.Size(212, 20);
            this.tbBackgroundImage.TabIndex = 10;
            this.tbBackgroundImage.Click += new System.EventHandler(this.tbBackgroundImage_Click);
            // 
            // cbUseBackgroundImage
            // 
            this.cbUseBackgroundImage.AutoSize = true;
            this.cbUseBackgroundImage.Location = new System.Drawing.Point(16, 65);
            this.cbUseBackgroundImage.Name = "cbUseBackgroundImage";
            this.cbUseBackgroundImage.Size = new System.Drawing.Size(138, 17);
            this.cbUseBackgroundImage.TabIndex = 9;
            this.cbUseBackgroundImage.Text = "Use Background Image";
            this.cbUseBackgroundImage.UseVisualStyleBackColor = true;
            this.cbUseBackgroundImage.CheckedChanged += new System.EventHandler(this.cbUseBackgroundImage_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Expand/Contract Style";
            // 
            // ddlExpandContractStyle
            // 
            this.ddlExpandContractStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlExpandContractStyle.FormattingEnabled = true;
            this.ddlExpandContractStyle.Location = new System.Drawing.Point(160, 26);
            this.ddlExpandContractStyle.Name = "ddlExpandContractStyle";
            this.ddlExpandContractStyle.Size = new System.Drawing.Size(212, 21);
            this.ddlExpandContractStyle.TabIndex = 7;
            // 
            // gbxGeneral_Appearance
            // 
            this.gbxGeneral_Appearance.Controls.Add(this.cbShowMiniPnl);
            this.gbxGeneral_Appearance.Controls.Add(this.lblOpacityValue);
            this.gbxGeneral_Appearance.Controls.Add(this.lblShortcutBarTextColor);
            this.gbxGeneral_Appearance.Controls.Add(this.pbShortcutBarTextColor);
            this.gbxGeneral_Appearance.Controls.Add(this.label5);
            this.gbxGeneral_Appearance.Controls.Add(this.lblShortcutBarColor);
            this.gbxGeneral_Appearance.Controls.Add(this.pbShortcutBarColor);
            this.gbxGeneral_Appearance.Controls.Add(this.label4);
            this.gbxGeneral_Appearance.Controls.Add(this.trackBarOpacity);
            this.gbxGeneral_Appearance.Controls.Add(this.trackBarHeight);
            this.gbxGeneral_Appearance.Controls.Add(this.label1);
            this.gbxGeneral_Appearance.Controls.Add(this.lblOpacity);
            this.gbxGeneral_Appearance.Location = new System.Drawing.Point(6, 6);
            this.gbxGeneral_Appearance.Name = "gbxGeneral_Appearance";
            this.gbxGeneral_Appearance.Size = new System.Drawing.Size(612, 214);
            this.gbxGeneral_Appearance.TabIndex = 9;
            this.gbxGeneral_Appearance.TabStop = false;
            this.gbxGeneral_Appearance.Text = "Appearance";
            // 
            // cbShowMiniPnl
            // 
            this.cbShowMiniPnl.AutoSize = true;
            this.cbShowMiniPnl.Location = new System.Drawing.Point(13, 176);
            this.cbShowMiniPnl.Name = "cbShowMiniPnl";
            this.cbShowMiniPnl.Size = new System.Drawing.Size(110, 17);
            this.cbShowMiniPnl.TabIndex = 13;
            this.cbShowMiniPnl.Text = "Show Small Icons";
            this.cbShowMiniPnl.UseVisualStyleBackColor = true;
            // 
            // lblOpacityValue
            // 
            this.lblOpacityValue.AutoSize = true;
            this.lblOpacityValue.Location = new System.Drawing.Point(297, 96);
            this.lblOpacityValue.Name = "lblOpacityValue";
            this.lblOpacityValue.Size = new System.Drawing.Size(10, 13);
            this.lblOpacityValue.TabIndex = 6;
            this.lblOpacityValue.Text = "-";
            // 
            // lblShortcutBarTextColor
            // 
            this.lblShortcutBarTextColor.AutoSize = true;
            this.lblShortcutBarTextColor.Location = new System.Drawing.Point(160, 151);
            this.lblShortcutBarTextColor.Name = "lblShortcutBarTextColor";
            this.lblShortcutBarTextColor.Size = new System.Drawing.Size(10, 13);
            this.lblShortcutBarTextColor.TabIndex = 12;
            this.lblShortcutBarTextColor.Text = "-";
            this.lblShortcutBarTextColor.Click += new System.EventHandler(this.ShortcutBarTextColor_Click);
            // 
            // pbShortcutBarTextColor
            // 
            this.pbShortcutBarTextColor.Location = new System.Drawing.Point(138, 148);
            this.pbShortcutBarTextColor.Name = "pbShortcutBarTextColor";
            this.pbShortcutBarTextColor.Size = new System.Drawing.Size(16, 16);
            this.pbShortcutBarTextColor.TabIndex = 11;
            this.pbShortcutBarTextColor.TabStop = false;
            this.pbShortcutBarTextColor.Click += new System.EventHandler(this.ShortcutBarTextColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Shortcut Bar Text Color";
            // 
            // lblShortcutBarColor
            // 
            this.lblShortcutBarColor.AutoSize = true;
            this.lblShortcutBarColor.Location = new System.Drawing.Point(160, 121);
            this.lblShortcutBarColor.Name = "lblShortcutBarColor";
            this.lblShortcutBarColor.Size = new System.Drawing.Size(10, 13);
            this.lblShortcutBarColor.TabIndex = 9;
            this.lblShortcutBarColor.Text = "-";
            this.lblShortcutBarColor.Click += new System.EventHandler(this.ShortcutbarColor_Click);
            // 
            // pbShortcutBarColor
            // 
            this.pbShortcutBarColor.Location = new System.Drawing.Point(138, 118);
            this.pbShortcutBarColor.Name = "pbShortcutBarColor";
            this.pbShortcutBarColor.Size = new System.Drawing.Size(16, 16);
            this.pbShortcutBarColor.TabIndex = 8;
            this.pbShortcutBarColor.TabStop = false;
            this.pbShortcutBarColor.Click += new System.EventHandler(this.ShortcutbarColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Shortcut Bar Color";
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(138, 67);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Minimum = 10;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(395, 45);
            this.trackBarOpacity.TabIndex = 5;
            this.trackBarOpacity.Value = 10;
            this.trackBarOpacity.Scroll += new System.EventHandler(this.trackBarOpacity_Scroll);
            // 
            // trackBarHeight
            // 
            this.trackBarHeight.Location = new System.Drawing.Point(138, 19);
            this.trackBarHeight.Maximum = 100;
            this.trackBarHeight.Minimum = 10;
            this.trackBarHeight.Name = "trackBarHeight";
            this.trackBarHeight.Size = new System.Drawing.Size(395, 45);
            this.trackBarHeight.TabIndex = 1;
            this.trackBarHeight.Value = 10;
            this.trackBarHeight.Scroll += new System.EventHandler(this.trackBarHeight_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Shortcut Bar Height";
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(10, 67);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(43, 13);
            this.lblOpacity.TabIndex = 4;
            this.lblOpacity.Text = "Opacity";
            // 
            // cbRunOnStartup
            // 
            this.cbRunOnStartup.AutoSize = true;
            this.cbRunOnStartup.Location = new System.Drawing.Point(6, 341);
            this.cbRunOnStartup.Name = "cbRunOnStartup";
            this.cbRunOnStartup.Size = new System.Drawing.Size(145, 17);
            this.cbRunOnStartup.TabIndex = 2;
            this.cbRunOnStartup.Text = "Run on Windows Startup";
            this.cbRunOnStartup.UseVisualStyleBackColor = true;
            // 
            // tabBehaviour
            // 
            this.tabBehaviour.Controls.Add(this.cbSupressPrompt_MultiProgramLaunch);
            this.tabBehaviour.Location = new System.Drawing.Point(4, 22);
            this.tabBehaviour.Name = "tabBehaviour";
            this.tabBehaviour.Padding = new System.Windows.Forms.Padding(3);
            this.tabBehaviour.Size = new System.Drawing.Size(624, 364);
            this.tabBehaviour.TabIndex = 4;
            this.tabBehaviour.Text = "Behaviour";
            this.tabBehaviour.UseVisualStyleBackColor = true;
            // 
            // cbSupressPrompt_MultiProgramLaunch
            // 
            this.cbSupressPrompt_MultiProgramLaunch.AutoSize = true;
            this.cbSupressPrompt_MultiProgramLaunch.Location = new System.Drawing.Point(6, 6);
            this.cbSupressPrompt_MultiProgramLaunch.Name = "cbSupressPrompt_MultiProgramLaunch";
            this.cbSupressPrompt_MultiProgramLaunch.Size = new System.Drawing.Size(319, 17);
            this.cbSupressPrompt_MultiProgramLaunch.TabIndex = 0;
            this.cbSupressPrompt_MultiProgramLaunch.Text = "Supress Prompting when launching multiple selected programs";
            this.cbSupressPrompt_MultiProgramLaunch.UseVisualStyleBackColor = true;
            // 
            // tabDefaultIconMapping
            // 
            this.tabDefaultIconMapping.Controls.Add(this.label2);
            this.tabDefaultIconMapping.Controls.Add(this.dgvDefaultIconMapping);
            this.tabDefaultIconMapping.Location = new System.Drawing.Point(4, 22);
            this.tabDefaultIconMapping.Name = "tabDefaultIconMapping";
            this.tabDefaultIconMapping.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefaultIconMapping.Size = new System.Drawing.Size(624, 364);
            this.tabDefaultIconMapping.TabIndex = 2;
            this.tabDefaultIconMapping.Text = "Default Icon Mappings";
            this.tabDefaultIconMapping.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Note: All Icons must be in the \"icons\" folder";
            // 
            // dgvDefaultIconMapping
            // 
            this.dgvDefaultIconMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefaultIconMapping.Location = new System.Drawing.Point(3, 3);
            this.dgvDefaultIconMapping.Name = "dgvDefaultIconMapping";
            this.dgvDefaultIconMapping.Size = new System.Drawing.Size(615, 307);
            this.dgvDefaultIconMapping.TabIndex = 0;
            // 
            // tabGroupOrder
            // 
            this.tabGroupOrder.Controls.Add(this.btnMoveToBottom);
            this.tabGroupOrder.Controls.Add(this.btnMoveDown);
            this.tabGroupOrder.Controls.Add(this.btnMoveUp);
            this.tabGroupOrder.Controls.Add(this.btnMoveToTop);
            this.tabGroupOrder.Controls.Add(this.lbGroups);
            this.tabGroupOrder.Location = new System.Drawing.Point(4, 22);
            this.tabGroupOrder.Name = "tabGroupOrder";
            this.tabGroupOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroupOrder.Size = new System.Drawing.Size(624, 364);
            this.tabGroupOrder.TabIndex = 3;
            this.tabGroupOrder.Text = "Group Ordering";
            this.tabGroupOrder.UseVisualStyleBackColor = true;
            // 
            // btnMoveToBottom
            // 
            this.btnMoveToBottom.Location = new System.Drawing.Point(524, 192);
            this.btnMoveToBottom.Name = "btnMoveToBottom";
            this.btnMoveToBottom.Size = new System.Drawing.Size(94, 23);
            this.btnMoveToBottom.TabIndex = 4;
            this.btnMoveToBottom.Text = "Move to Bottom";
            this.btnMoveToBottom.UseVisualStyleBackColor = true;
            this.btnMoveToBottom.Click += new System.EventHandler(this.btnMoveToBottom_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(524, 163);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(94, 23);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(524, 112);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(94, 23);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveToTop
            // 
            this.btnMoveToTop.Location = new System.Drawing.Point(524, 83);
            this.btnMoveToTop.Name = "btnMoveToTop";
            this.btnMoveToTop.Size = new System.Drawing.Size(94, 23);
            this.btnMoveToTop.TabIndex = 1;
            this.btnMoveToTop.Text = "Move to Top";
            this.btnMoveToTop.UseVisualStyleBackColor = true;
            this.btnMoveToTop.Click += new System.EventHandler(this.btnMoveToTop_Click);
            // 
            // lbGroups
            // 
            this.lbGroups.FormattingEnabled = true;
            this.lbGroups.Location = new System.Drawing.Point(3, 3);
            this.lbGroups.Name = "lbGroups";
            this.lbGroups.Size = new System.Drawing.Size(515, 316);
            this.lbGroups.TabIndex = 0;
            // 
            // tabMaintenance
            // 
            this.tabMaintenance.Controls.Add(this.gbxSystemConfig);
            this.tabMaintenance.Controls.Add(this.gbxPatchModule);
            this.tabMaintenance.Location = new System.Drawing.Point(4, 22);
            this.tabMaintenance.Name = "tabMaintenance";
            this.tabMaintenance.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaintenance.Size = new System.Drawing.Size(624, 364);
            this.tabMaintenance.TabIndex = 5;
            this.tabMaintenance.Text = "Maintenance";
            this.tabMaintenance.UseVisualStyleBackColor = true;
            // 
            // gbxSystemConfig
            // 
            this.gbxSystemConfig.Controls.Add(this.lnkIconFolder);
            this.gbxSystemConfig.Controls.Add(this.lnkConfigurationFolder);
            this.gbxSystemConfig.Controls.Add(this.lnkShortcutFolder);
            this.gbxSystemConfig.Controls.Add(this.tbConfigFolder);
            this.gbxSystemConfig.Controls.Add(this.tbShortcutFolder);
            this.gbxSystemConfig.Controls.Add(this.tbIconsFolder);
            this.gbxSystemConfig.Location = new System.Drawing.Point(6, 65);
            this.gbxSystemConfig.Name = "gbxSystemConfig";
            this.gbxSystemConfig.Size = new System.Drawing.Size(612, 103);
            this.gbxSystemConfig.TabIndex = 3;
            this.gbxSystemConfig.TabStop = false;
            this.gbxSystemConfig.Text = "System Configuration Files (Read-Only)";
            // 
            // lnkIconFolder
            // 
            this.lnkIconFolder.AutoSize = true;
            this.lnkIconFolder.Location = new System.Drawing.Point(47, 75);
            this.lnkIconFolder.Name = "lnkIconFolder";
            this.lnkIconFolder.Size = new System.Drawing.Size(60, 13);
            this.lnkIconFolder.TabIndex = 4;
            this.lnkIconFolder.TabStop = true;
            this.lnkIconFolder.Text = "Icon Folder";
            this.toolTip1.SetToolTip(this.lnkIconFolder, "Click to go to Icon Folder");
            // 
            // lnkConfigurationFolder
            // 
            this.lnkConfigurationFolder.AutoSize = true;
            this.lnkConfigurationFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkConfigurationFolder.Location = new System.Drawing.Point(6, 49);
            this.lnkConfigurationFolder.Name = "lnkConfigurationFolder";
            this.lnkConfigurationFolder.Size = new System.Drawing.Size(101, 13);
            this.lnkConfigurationFolder.TabIndex = 4;
            this.lnkConfigurationFolder.TabStop = true;
            this.lnkConfigurationFolder.Text = "Configuration Folder";
            this.toolTip1.SetToolTip(this.lnkConfigurationFolder, "Click to go to Config Folder");
            // 
            // lnkShortcutFolder
            // 
            this.lnkShortcutFolder.AutoSize = true;
            this.lnkShortcutFolder.Location = new System.Drawing.Point(28, 23);
            this.lnkShortcutFolder.Name = "lnkShortcutFolder";
            this.lnkShortcutFolder.Size = new System.Drawing.Size(79, 13);
            this.lnkShortcutFolder.TabIndex = 4;
            this.lnkShortcutFolder.TabStop = true;
            this.lnkShortcutFolder.Text = "Shortcut Folder";
            this.toolTip1.SetToolTip(this.lnkShortcutFolder, "Click to go to Shortcut Folder");
            // 
            // tbConfigFolder
            // 
            this.tbConfigFolder.Location = new System.Drawing.Point(113, 46);
            this.tbConfigFolder.Name = "tbConfigFolder";
            this.tbConfigFolder.ReadOnly = true;
            this.tbConfigFolder.Size = new System.Drawing.Size(420, 20);
            this.tbConfigFolder.TabIndex = 3;
            // 
            // tbShortcutFolder
            // 
            this.tbShortcutFolder.Location = new System.Drawing.Point(113, 20);
            this.tbShortcutFolder.Name = "tbShortcutFolder";
            this.tbShortcutFolder.ReadOnly = true;
            this.tbShortcutFolder.Size = new System.Drawing.Size(420, 20);
            this.tbShortcutFolder.TabIndex = 1;
            // 
            // tbIconsFolder
            // 
            this.tbIconsFolder.Location = new System.Drawing.Point(113, 72);
            this.tbIconsFolder.Name = "tbIconsFolder";
            this.tbIconsFolder.ReadOnly = true;
            this.tbIconsFolder.Size = new System.Drawing.Size(420, 20);
            this.tbIconsFolder.TabIndex = 1;
            // 
            // gbxPatchModule
            // 
            this.gbxPatchModule.Controls.Add(this.btnLaunchPatcher);
            this.gbxPatchModule.Location = new System.Drawing.Point(6, 6);
            this.gbxPatchModule.Name = "gbxPatchModule";
            this.gbxPatchModule.Size = new System.Drawing.Size(612, 53);
            this.gbxPatchModule.TabIndex = 2;
            this.gbxPatchModule.TabStop = false;
            this.gbxPatchModule.Text = "Patch Module";
            // 
            // btnLaunchPatcher
            // 
            this.btnLaunchPatcher.Location = new System.Drawing.Point(6, 19);
            this.btnLaunchPatcher.Name = "btnLaunchPatcher";
            this.btnLaunchPatcher.Size = new System.Drawing.Size(189, 23);
            this.btnLaunchPatcher.TabIndex = 1;
            this.btnLaunchPatcher.Text = "Launch Patcher Interface";
            this.btnLaunchPatcher.UseVisualStyleBackColor = true;
            this.btnLaunchPatcher.Click += new System.EventHandler(this.btnLaunchPatcher_Click);
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.tableLayoutPanel);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(551, 364);
            this.tabAbout.TabIndex = 1;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.lnkVisitBlog, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(545, 358);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(173, 352);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(185, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(357, 17);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(185, 35);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(357, 17);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Location = new System.Drawing.Point(185, 70);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(357, 17);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompanyName.Location = new System.Drawing.Point(185, 105);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(357, 17);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "Company Name";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(185, 143);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(357, 173);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            // 
            // lnkVisitBlog
            // 
            this.lnkVisitBlog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkVisitBlog.AutoSize = true;
            this.lnkVisitBlog.Location = new System.Drawing.Point(182, 345);
            this.lnkVisitBlog.Name = "lnkVisitBlog";
            this.lnkVisitBlog.Size = new System.Drawing.Size(135, 13);
            this.lnkVisitBlog.TabIndex = 3;
            this.lnkVisitBlog.TabStop = true;
            this.lnkVisitBlog.Text = "Checkout Project at Github";
            this.lnkVisitBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVisitBlog_LinkClicked);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(656, 449);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.pnlButtons.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.gbxGeneral_Effects.ResumeLayout(false);
            this.gbxGeneral_Effects.PerformLayout();
            this.gbxGeneral_Appearance.ResumeLayout(false);
            this.gbxGeneral_Appearance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShortcutBarTextColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShortcutBarColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHeight)).EndInit();
            this.tabBehaviour.ResumeLayout(false);
            this.tabBehaviour.PerformLayout();
            this.tabDefaultIconMapping.ResumeLayout(false);
            this.tabDefaultIconMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefaultIconMapping)).EndInit();
            this.tabGroupOrder.ResumeLayout(false);
            this.tabMaintenance.ResumeLayout(false);
            this.gbxSystemConfig.ResumeLayout(false);
            this.gbxSystemConfig.PerformLayout();
            this.gbxPatchModule.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.CheckBox cbRunOnStartup;
        private System.Windows.Forms.TrackBar trackBarHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.Label lblOpacityValue;
        private System.Windows.Forms.TabPage tabDefaultIconMapping;
        private System.Windows.Forms.DataGridView dgvDefaultIconMapping;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabGroupOrder;
        private System.Windows.Forms.ListBox lbGroups;
        private System.Windows.Forms.Button btnMoveToTop;
        private System.Windows.Forms.Button btnMoveToBottom;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlExpandContractStyle;
        private System.Windows.Forms.GroupBox gbxGeneral_Effects;
        private System.Windows.Forms.GroupBox gbxGeneral_Appearance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBackgroundImage;
        private System.Windows.Forms.CheckBox cbUseBackgroundImage;
        private System.Windows.Forms.Label lblRecommendedDimension;
        private System.Windows.Forms.PictureBox pbShortcutBarColor;
        private System.Windows.Forms.Label lblShortcutBarColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblShortcutBarTextColor;
        private System.Windows.Forms.PictureBox pbShortcutBarTextColor;
        private System.Windows.Forms.TabPage tabBehaviour;
        private System.Windows.Forms.CheckBox cbSupressPrompt_MultiProgramLaunch;
        private System.Windows.Forms.CheckBox cbShowMiniPnl;
        private System.Windows.Forms.TabPage tabMaintenance;
        private System.Windows.Forms.Button btnLaunchPatcher;
        private System.Windows.Forms.GroupBox gbxSystemConfig;
        private System.Windows.Forms.GroupBox gbxPatchModule;
        private System.Windows.Forms.TextBox tbConfigFolder;
        private System.Windows.Forms.TextBox tbShortcutFolder;
        private System.Windows.Forms.TextBox tbIconsFolder;
        private System.Windows.Forms.LinkLabel lnkIconFolder;
        private System.Windows.Forms.LinkLabel lnkConfigurationFolder;
        private System.Windows.Forms.LinkLabel lnkShortcutFolder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel lnkVisitBlog;
    }
}