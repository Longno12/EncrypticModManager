namespace ModManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.dashboardTab = new System.Windows.Forms.TabPage();
            this.btnLaunchGame = new System.Windows.Forms.Button();
            this.btnInstallMenu = new System.Windows.Forms.Button();
            this.btnInstallBepInEx = new System.Windows.Forms.Button();
            this.gameInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.btnBrowseGame = new System.Windows.Forms.Button();
            this.lblGameVersion = new System.Windows.Forms.Label();
            this.lblGamePath = new System.Windows.Forms.Label();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.modsTab = new System.Windows.Forms.TabPage();
            this.modListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modControlPanel = new System.Windows.Forms.Panel();
            this.btnRefreshMods = new System.Windows.Forms.Button();
            this.btnDisableMod = new System.Windows.Forms.Button();
            this.btnEnableMod = new System.Windows.Forms.Button();
            this.btnUninstallMod = new System.Windows.Forms.Button();
            this.btnInstallMod = new System.Windows.Forms.Button();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.creditsTab = new System.Windows.Forms.TabPage();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnDiscord = new System.Windows.Forms.Button();
            this.lblIIDKCredit = new System.Windows.Forms.Label();
            this.lblCreditsTitle = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.versionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.logPanel = new System.Windows.Forms.Panel();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.chkAutoInstallUpdates = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.dashboardTab.SuspendLayout();
            this.gameInfoGroupBox.SuspendLayout();
            this.modsTab.SuspendLayout();
            this.modControlPanel.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.creditsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.dashboardTab);
            this.tabControl.Controls.Add(this.modsTab);
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.Controls.Add(this.creditsTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 411);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // dashboardTab
            // 
            this.dashboardTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dashboardTab.Controls.Add(this.btnLaunchGame);
            this.dashboardTab.Controls.Add(this.btnInstallMenu);
            this.dashboardTab.Controls.Add(this.btnInstallBepInEx);
            this.dashboardTab.Controls.Add(this.gameInfoGroupBox);
            this.dashboardTab.Location = new System.Drawing.Point(4, 24);
            this.dashboardTab.Name = "dashboardTab";
            this.dashboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.dashboardTab.Size = new System.Drawing.Size(776, 383);
            this.dashboardTab.TabIndex = 0;
            this.dashboardTab.Text = "Dashboard";
            // 
            // btnLaunchGame
            // 
            this.btnLaunchGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunchGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLaunchGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunchGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunchGame.ForeColor = System.Drawing.Color.White;
            this.btnLaunchGame.Location = new System.Drawing.Point(520, 200);
            this.btnLaunchGame.Name = "btnLaunchGame";
            this.btnLaunchGame.Size = new System.Drawing.Size(200, 40);
            this.btnLaunchGame.TabIndex = 3;
            this.btnLaunchGame.Text = "Launch Game";
            this.btnLaunchGame.UseVisualStyleBackColor = false;
            this.btnLaunchGame.Click += new System.EventHandler(this.btnLaunchGame_Click);
            // 
            // btnInstallMenu
            // 
            this.btnInstallMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnInstallMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallMenu.ForeColor = System.Drawing.Color.White;
            this.btnInstallMenu.Location = new System.Drawing.Point(270, 200);
            this.btnInstallMenu.Name = "btnInstallMenu";
            this.btnInstallMenu.Size = new System.Drawing.Size(200, 40);
            this.btnInstallMenu.TabIndex = 2;
            this.btnInstallMenu.Text = "Install Menu";
            this.btnInstallMenu.UseVisualStyleBackColor = false;
            this.btnInstallMenu.Click += new System.EventHandler(this.btnInstallMenu_Click);
            // 
            // btnInstallBepInEx
            // 
            this.btnInstallBepInEx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnInstallBepInEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallBepInEx.ForeColor = System.Drawing.Color.White;
            this.btnInstallBepInEx.Location = new System.Drawing.Point(20, 200);
            this.btnInstallBepInEx.Name = "btnInstallBepInEx";
            this.btnInstallBepInEx.Size = new System.Drawing.Size(200, 40);
            this.btnInstallBepInEx.TabIndex = 1;
            this.btnInstallBepInEx.Text = "Install BepInEx";
            this.btnInstallBepInEx.UseVisualStyleBackColor = false;
            this.btnInstallBepInEx.Click += new System.EventHandler(this.btnInstallBepInEx_Click);
            // 
            // gameInfoGroupBox
            // 
            this.gameInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameInfoGroupBox.Controls.Add(this.btnBrowseGame);
            this.gameInfoGroupBox.Controls.Add(this.lblGameVersion);
            this.gameInfoGroupBox.Controls.Add(this.lblGamePath);
            this.gameInfoGroupBox.Controls.Add(this.lblGameStatus);
            this.gameInfoGroupBox.Controls.Add(this.label3);
            this.gameInfoGroupBox.Controls.Add(this.label2);
            this.gameInfoGroupBox.Controls.Add(this.label1);
            this.gameInfoGroupBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoGroupBox.Location = new System.Drawing.Point(20, 20);
            this.gameInfoGroupBox.Name = "gameInfoGroupBox";
            this.gameInfoGroupBox.Size = new System.Drawing.Size(736, 150);
            this.gameInfoGroupBox.TabIndex = 0;
            this.gameInfoGroupBox.TabStop = false;
            this.gameInfoGroupBox.Text = "Game Information";
            // 
            // btnBrowseGame
            // 
            this.btnBrowseGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnBrowseGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseGame.Location = new System.Drawing.Point(600, 60);
            this.btnBrowseGame.Name = "btnBrowseGame";
            this.btnBrowseGame.Size = new System.Drawing.Size(100, 30);
            this.btnBrowseGame.TabIndex = 6;
            this.btnBrowseGame.Text = "Browse...";
            this.btnBrowseGame.UseVisualStyleBackColor = false;
            this.btnBrowseGame.Click += new System.EventHandler(this.btnBrowseGame_Click);
            // 
            // lblGameVersion
            // 
            this.lblGameVersion.AutoSize = true;
            this.lblGameVersion.Location = new System.Drawing.Point(150, 110);
            this.lblGameVersion.Name = "lblGameVersion";
            this.lblGameVersion.Size = new System.Drawing.Size(67, 15);
            this.lblGameVersion.TabIndex = 5;
            this.lblGameVersion.Text = "Detecting...";
            // 
            // lblGamePath
            // 
            this.lblGamePath.AutoSize = true;
            this.lblGamePath.Location = new System.Drawing.Point(150, 70);
            this.lblGamePath.Name = "lblGamePath";
            this.lblGamePath.Size = new System.Drawing.Size(67, 15);
            this.lblGamePath.TabIndex = 4;
            this.lblGamePath.Text = "Detecting...";
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Location = new System.Drawing.Point(150, 30);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(67, 15);
            this.lblGameStatus.TabIndex = 3;
            this.lblGameStatus.Text = "Detecting...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label3.Location = new System.Drawing.Point(20, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Game Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Game Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Status:";
            // 
            // modsTab
            // 
            this.modsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.modsTab.Controls.Add(this.modListView);
            this.modsTab.Controls.Add(this.modControlPanel);
            this.modsTab.Location = new System.Drawing.Point(4, 24);
            this.modsTab.Name = "modsTab";
            this.modsTab.Padding = new System.Windows.Forms.Padding(3);
            this.modsTab.Size = new System.Drawing.Size(776, 383);
            this.modsTab.TabIndex = 1;
            this.modsTab.Text = "Mods";
            // 
            // modListView
            // 
            this.modListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.modListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.modListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modListView.ForeColor = System.Drawing.Color.White;
            this.modListView.FullRowSelect = true;
            this.modListView.HideSelection = false;
            this.modListView.Location = new System.Drawing.Point(3, 3);
            this.modListView.Name = "modListView";
            this.modListView.Size = new System.Drawing.Size(770, 327);
            this.modListView.TabIndex = 1;
            this.modListView.UseCompatibleStateImageBehavior = false;
            this.modListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mod Name";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Version";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 100;
            // 
            // modControlPanel
            // 
            this.modControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.modControlPanel.Controls.Add(this.btnRefreshMods);
            this.modControlPanel.Controls.Add(this.btnDisableMod);
            this.modControlPanel.Controls.Add(this.btnEnableMod);
            this.modControlPanel.Controls.Add(this.btnUninstallMod);
            this.modControlPanel.Controls.Add(this.btnInstallMod);
            this.modControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.modControlPanel.Location = new System.Drawing.Point(3, 330);
            this.modControlPanel.Name = "modControlPanel";
            this.modControlPanel.Size = new System.Drawing.Size(770, 50);
            this.modControlPanel.TabIndex = 0;
            // 
            // btnRefreshMods
            // 
            this.btnRefreshMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnRefreshMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshMods.ForeColor = System.Drawing.Color.White;
            this.btnRefreshMods.Location = new System.Drawing.Point(670, 10);
            this.btnRefreshMods.Name = "btnRefreshMods";
            this.btnRefreshMods.Size = new System.Drawing.Size(80, 30);
            this.btnRefreshMods.TabIndex = 4;
            this.btnRefreshMods.Text = "Refresh";
            this.btnRefreshMods.UseVisualStyleBackColor = false;
            this.btnRefreshMods.Click += new System.EventHandler(this.btnRefreshMods_Click);
            // 
            // btnDisableMod
            // 
            this.btnDisableMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDisableMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisableMod.ForeColor = System.Drawing.Color.White;
            this.btnDisableMod.Location = new System.Drawing.Point(330, 10);
            this.btnDisableMod.Name = "btnDisableMod";
            this.btnDisableMod.Size = new System.Drawing.Size(80, 30);
            this.btnDisableMod.TabIndex = 3;
            this.btnDisableMod.Text = "Disable";
            this.btnDisableMod.UseVisualStyleBackColor = false;
            this.btnDisableMod.Click += new System.EventHandler(this.btnDisableMod_Click);
            // 
            // btnEnableMod
            // 
            this.btnEnableMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnEnableMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnableMod.ForeColor = System.Drawing.Color.White;
            this.btnEnableMod.Location = new System.Drawing.Point(230, 10);
            this.btnEnableMod.Name = "btnEnableMod";
            this.btnEnableMod.Size = new System.Drawing.Size(80, 30);
            this.btnEnableMod.TabIndex = 2;
            this.btnEnableMod.Text = "Enable";
            this.btnEnableMod.UseVisualStyleBackColor = false;
            this.btnEnableMod.Click += new System.EventHandler(this.btnEnableMod_Click);
            // 
            // btnUninstallMod
            // 
            this.btnUninstallMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnUninstallMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUninstallMod.ForeColor = System.Drawing.Color.White;
            this.btnUninstallMod.Location = new System.Drawing.Point(130, 10);
            this.btnUninstallMod.Name = "btnUninstallMod";
            this.btnUninstallMod.Size = new System.Drawing.Size(80, 30);
            this.btnUninstallMod.TabIndex = 1;
            this.btnUninstallMod.Text = "Uninstall";
            this.btnUninstallMod.UseVisualStyleBackColor = false;
            this.btnUninstallMod.Click += new System.EventHandler(this.btnUninstallMod_Click);
            // 
            // btnInstallMod
            // 
            this.btnInstallMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnInstallMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallMod.ForeColor = System.Drawing.Color.White;
            this.btnInstallMod.Location = new System.Drawing.Point(30, 10);
            this.btnInstallMod.Name = "btnInstallMod";
            this.btnInstallMod.Size = new System.Drawing.Size(80, 30);
            this.btnInstallMod.TabIndex = 0;
            this.btnInstallMod.Text = "Install";
            this.btnInstallMod.UseVisualStyleBackColor = false;
            this.btnInstallMod.Click += new System.EventHandler(this.btnInstallMod_Click);
            // 
            // settingsTab
            // 
            this.settingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.settingsTab.Controls.Add(this.btnResetSettings);
            this.settingsTab.Controls.Add(this.btnSaveSettings);
            this.settingsTab.Controls.Add(this.chkStartWithWindows);
            this.settingsTab.Controls.Add(this.chkAutoUpdate);
            this.settingsTab.Controls.Add(this.chkAutoInstallUpdates);
            this.settingsTab.Location = new System.Drawing.Point(4, 24);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Size = new System.Drawing.Size(776, 383);
            this.settingsTab.TabIndex = 2;
            this.settingsTab.Text = "Settings";
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSettings.ForeColor = System.Drawing.Color.White;
            this.btnResetSettings.Location = new System.Drawing.Point(550, 330);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(100, 30);
            this.btnResetSettings.TabIndex = 3;
            this.btnResetSettings.Text = "Reset";
            this.btnResetSettings.UseVisualStyleBackColor = false;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(656, 330);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(100, 30);
            this.btnSaveSettings.TabIndex = 2;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.ForeColor = System.Drawing.Color.White;
            this.chkStartWithWindows.Location = new System.Drawing.Point(20, 60);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(127, 19);
            this.chkStartWithWindows.TabIndex = 1;
            this.chkStartWithWindows.Text = "Start with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.AutoSize = true;
            this.chkAutoUpdate.ForeColor = System.Drawing.Color.White;
            this.chkAutoUpdate.Location = new System.Drawing.Point(20, 20);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(225, 19);
            this.chkAutoUpdate.TabIndex = 0;
            this.chkAutoUpdate.Text = "Automatically check for updates on start";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // chkAutoInstallUpdates
            // 
            this.chkAutoInstallUpdates.AutoSize = true;
            this.chkAutoInstallUpdates.ForeColor = System.Drawing.Color.White;
            this.chkAutoInstallUpdates.Location = new System.Drawing.Point(20, 100);
            this.chkAutoInstallUpdates.Name = "chkAutoInstallUpdates";
            this.chkAutoInstallUpdates.Size = new System.Drawing.Size(250, 19);
            this.chkAutoInstallUpdates.TabIndex = 4;
            this.chkAutoInstallUpdates.Text = "Automatically install updates when available";
            this.chkAutoInstallUpdates.UseVisualStyleBackColor = true;
            // 
            // creditsTab
            // 
            this.creditsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.creditsTab.Controls.Add(this.pictureBoxLogo);
            this.creditsTab.Controls.Add(this.btnDiscord);
            this.creditsTab.Controls.Add(this.lblIIDKCredit);
            this.creditsTab.Controls.Add(this.lblCreditsTitle);
            this.creditsTab.Location = new System.Drawing.Point(4, 24);
            this.creditsTab.Name = "creditsTab";
            this.creditsTab.Size = new System.Drawing.Size(776, 383);
            this.creditsTab.TabIndex = 3;
            this.creditsTab.Text = "Credits";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(20, 120);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // btnDiscord
            // 
            this.btnDiscord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDiscord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscord.ForeColor = System.Drawing.Color.White;
            this.btnDiscord.Location = new System.Drawing.Point(320, 65);
            this.btnDiscord.Name = "btnDiscord";
            this.btnDiscord.Size = new System.Drawing.Size(120, 30);
            this.btnDiscord.TabIndex = 2;
            this.btnDiscord.Text = "Join Discord";
            this.btnDiscord.UseVisualStyleBackColor = false;
            this.btnDiscord.Click += new System.EventHandler(this.btnDiscord_Click);
            // 
            // lblIIDKCredit
            // 
            this.lblIIDKCredit.AutoSize = true;
            this.lblIIDKCredit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIIDKCredit.ForeColor = System.Drawing.Color.White;
            this.lblIIDKCredit.Location = new System.Drawing.Point(20, 70);
            this.lblIIDKCredit.Name = "lblIIDKCredit";
            this.lblIIDKCredit.Size = new System.Drawing.Size(290, 20);
            this.lblIIDKCredit.TabIndex = 1;
            this.lblIIDKCredit.Text = "IIDK - BepInEx Configuration and Support";
            // 
            // lblCreditsTitle
            // 
            this.lblCreditsTitle.AutoSize = true;
            this.lblCreditsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsTitle.ForeColor = System.Drawing.Color.White;
            this.lblCreditsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCreditsTitle.Name = "lblCreditsTitle";
            this.lblCreditsTitle.Size = new System.Drawing.Size(76, 25);
            this.lblCreditsTitle.TabIndex = 0;
            this.lblCreditsTitle.Text = "Credits";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar,
            this.versionLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 411);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(42, 17);
            this.statusLabel.Text = "Ready.";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Visible = false;
            // 
            // versionLabel
            // 
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(40, 17);
            this.versionLabel.Text = "v1.0.0";
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.logTextBox);
            this.logPanel.Controls.Add(this.logLabel);
            this.logPanel.Controls.Add(this.btnClearLog);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logPanel.Location = new System.Drawing.Point(0, 433);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(784, 128);
            this.logPanel.TabIndex = 2;
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(784, 128);
            this.logPanel.TabIndex = 2;
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextBox.ForeColor = System.Drawing.Color.White;
            this.logTextBox.Location = new System.Drawing.Point(0, 23);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(784, 105);
            this.logTextBox.TabIndex = 0;
            this.logTextBox.Text = "";
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logLabel.ForeColor = System.Drawing.Color.White;
            this.logLabel.Location = new System.Drawing.Point(12, 5);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(28, 15);
            this.logLabel.TabIndex = 1;
            this.logLabel.Text = "Log";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.ForeColor = System.Drawing.Color.White;
            this.btnClearLog.Location = new System.Drawing.Point(704, 0);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 2;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.logPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryptic Mod Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.dashboardTab.ResumeLayout(false);
            this.gameInfoGroupBox.ResumeLayout(false);
            this.gameInfoGroupBox.PerformLayout();
            this.modsTab.ResumeLayout(false);
            this.modControlPanel.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            this.creditsTab.ResumeLayout(false);
            this.creditsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage dashboardTab;
        private System.Windows.Forms.TabPage modsTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.TabPage creditsTab;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel versionLabel;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.GroupBox gameInfoGroupBox;
        private System.Windows.Forms.Button btnBrowseGame;
        private System.Windows.Forms.Label lblGameVersion;
        private System.Windows.Forms.Label lblGamePath;
        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLaunchGame;
        private System.Windows.Forms.Button btnInstallMenu;
        private System.Windows.Forms.Button btnInstallBepInEx;
        private System.Windows.Forms.Panel modControlPanel;
        private System.Windows.Forms.Button btnRefreshMods;
        private System.Windows.Forms.Button btnDisableMod;
        private System.Windows.Forms.Button btnEnableMod;
        private System.Windows.Forms.Button btnUninstallMod;
        private System.Windows.Forms.Button btnInstallMod;
        private System.Windows.Forms.ListView modListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.CheckBox chkAutoUpdate;
        private System.Windows.Forms.Label lblCreditsTitle;
        private System.Windows.Forms.Label lblIIDKCredit;
        private System.Windows.Forms.Button btnDiscord;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.CheckBox chkAutoInstallUpdates;
    }
}
