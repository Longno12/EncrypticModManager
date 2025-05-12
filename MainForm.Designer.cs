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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.dashboardTab = new System.Windows.Forms.TabPage();
            this.dashboardMainPanel = new System.Windows.Forms.Panel();
            this.launchPanel = new System.Windows.Forms.Panel();
            this.btnLaunchGame = new System.Windows.Forms.Button();
            this.actionsPanel = new System.Windows.Forms.Panel();
            this.btnInstallMenu = new System.Windows.Forms.Button();
            this.btnInstallBepInEx = new System.Windows.Forms.Button();
            this.gameInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.lblGameVersion = new System.Windows.Forms.Label();
            this.lblGamePath = new System.Windows.Forms.Label();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseGame = new System.Windows.Forms.Button();
            this.modsTab = new System.Windows.Forms.TabPage();
            this.modListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearchMods = new System.Windows.Forms.TextBox();
            this.modControlPanel = new System.Windows.Forms.Panel();
            this.btnRefreshMods = new System.Windows.Forms.Button();
            this.btnDisableMod = new System.Windows.Forms.Button();
            this.btnEnableMod = new System.Windows.Forms.Button();
            this.btnUninstallMod = new System.Windows.Forms.Button();
            this.btnInstallMod = new System.Windows.Forms.Button();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.chkAutoInstallUpdates = new System.Windows.Forms.CheckBox();
            this.chkDarkTheme = new System.Windows.Forms.CheckBox();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.creditsTab = new System.Windows.Forms.TabPage();
            this.creditsPanel = new System.Windows.Forms.Panel();
            this.btnDiscord = new System.Windows.Forms.Button();
            this.lblCreditsText = new System.Windows.Forms.Label();
            this.lblCreditsTitle = new System.Windows.Forms.Label();
            this.logPanel = new System.Windows.Forms.Panel();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.versionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.headerPanel = new System.Windows.Forms.Panel();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.logoLabel = new System.Windows.Forms.Label();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.creditsButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.modsButton = new System.Windows.Forms.Button();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoIcon = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.dashboardTab.SuspendLayout();
            this.dashboardMainPanel.SuspendLayout();
            this.launchPanel.SuspendLayout();
            this.actionsPanel.SuspendLayout();
            this.gameInfoGroupBox.SuspendLayout();
            this.modsTab.SuspendLayout();
            this.modControlPanel.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.creditsTab.SuspendLayout();
            this.creditsPanel.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoIcon)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.dashboardTab);
            this.tabControl.Controls.Add(this.modsTab);
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.Controls.Add(this.creditsTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // dashboardTab
            // 
            this.dashboardTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.dashboardTab.Controls.Add(this.dashboardMainPanel);
            this.dashboardTab.Location = new System.Drawing.Point(4, 5);
            this.dashboardTab.Name = "dashboardTab";
            this.dashboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.dashboardTab.Size = new System.Drawing.Size(792, 441);
            this.dashboardTab.TabIndex = 0;
            this.dashboardTab.Text = "Dashboard";
            // 
            // dashboardMainPanel
            // 
            this.dashboardMainPanel.Controls.Add(this.launchPanel);
            this.dashboardMainPanel.Controls.Add(this.actionsPanel);
            this.dashboardMainPanel.Controls.Add(this.gameInfoGroupBox);
            this.dashboardMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardMainPanel.Location = new System.Drawing.Point(3, 3);
            this.dashboardMainPanel.Name = "dashboardMainPanel";
            this.dashboardMainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.dashboardMainPanel.Size = new System.Drawing.Size(786, 435);
            this.dashboardMainPanel.TabIndex = 0;
            // 
            // launchPanel
            // 
            this.launchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.launchPanel.Controls.Add(this.btnLaunchGame);
            this.launchPanel.Location = new System.Drawing.Point(20, 350);
            this.launchPanel.Name = "launchPanel";
            this.launchPanel.Size = new System.Drawing.Size(746, 65);
            this.launchPanel.TabIndex = 2;
            // 
            // btnLaunchGame
            // 
            this.btnLaunchGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunchGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLaunchGame.FlatAppearance.BorderSize = 0;
            this.btnLaunchGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunchGame.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunchGame.ForeColor = System.Drawing.Color.White;
            this.btnLaunchGame.Location = new System.Drawing.Point(0, 0);
            this.btnLaunchGame.Name = "btnLaunchGame";
            this.btnLaunchGame.Size = new System.Drawing.Size(746, 65);
            this.btnLaunchGame.TabIndex = 0;
            this.btnLaunchGame.Text = "Launch Game";
            this.btnLaunchGame.UseVisualStyleBackColor = false;
            this.btnLaunchGame.Click += new System.EventHandler(this.btnLaunchGame_Click);
            // 
            // actionsPanel
            // 
            this.actionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsPanel.Controls.Add(this.btnInstallMenu);
            this.actionsPanel.Controls.Add(this.btnInstallBepInEx);
            this.actionsPanel.Location = new System.Drawing.Point(20, 220);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Size = new System.Drawing.Size(746, 100);
            this.actionsPanel.TabIndex = 1;
            // 
            // btnInstallMenu
            // 
            this.btnInstallMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnInstallMenu.FlatAppearance.BorderSize = 0;
            this.btnInstallMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallMenu.ForeColor = System.Drawing.Color.White;
            this.btnInstallMenu.Location = new System.Drawing.Point(373, 0);
            this.btnInstallMenu.Name = "btnInstallMenu";
            this.btnInstallMenu.Size = new System.Drawing.Size(373, 100);
            this.btnInstallMenu.TabIndex = 1;
            this.btnInstallMenu.Text = "Install Menu";
            this.btnInstallMenu.UseVisualStyleBackColor = false;
            this.btnInstallMenu.Click += new System.EventHandler(this.btnInstallMenu_Click);
            // 
            // btnInstallBepInEx
            // 
            this.btnInstallBepInEx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnInstallBepInEx.FlatAppearance.BorderSize = 0;
            this.btnInstallBepInEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallBepInEx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallBepInEx.ForeColor = System.Drawing.Color.White;
            this.btnInstallBepInEx.Location = new System.Drawing.Point(0, 0);
            this.btnInstallBepInEx.Name = "btnInstallBepInEx";
            this.btnInstallBepInEx.Size = new System.Drawing.Size(373, 100);
            this.btnInstallBepInEx.TabIndex = 0;
            this.btnInstallBepInEx.Text = "Reinstall BepInEx";
            this.btnInstallBepInEx.UseVisualStyleBackColor = false;
            this.btnInstallBepInEx.Click += new System.EventHandler(this.btnInstallBepInEx_Click);
            // 
            // gameInfoGroupBox
            // 
            this.gameInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameInfoGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.gameInfoGroupBox.Controls.Add(this.lblGameVersion);
            this.gameInfoGroupBox.Controls.Add(this.lblGamePath);
            this.gameInfoGroupBox.Controls.Add(this.lblGameStatus);
            this.gameInfoGroupBox.Controls.Add(this.label3);
            this.gameInfoGroupBox.Controls.Add(this.label2);
            this.gameInfoGroupBox.Controls.Add(this.label1);
            this.gameInfoGroupBox.Controls.Add(this.btnBrowseGame);
            this.gameInfoGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameInfoGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGroupBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoGroupBox.Location = new System.Drawing.Point(20, 20);
            this.gameInfoGroupBox.Name = "gameInfoGroupBox";
            this.gameInfoGroupBox.Size = new System.Drawing.Size(746, 170);
            this.gameInfoGroupBox.TabIndex = 0;
            this.gameInfoGroupBox.TabStop = false;
            this.gameInfoGroupBox.Text = "Game Information";
            // 
            // lblGameVersion
            // 
            this.lblGameVersion.AutoSize = true;
            this.lblGameVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameVersion.ForeColor = System.Drawing.Color.White;
            this.lblGameVersion.Location = new System.Drawing.Point(150, 120);
            this.lblGameVersion.Name = "lblGameVersion";
            this.lblGameVersion.Size = new System.Drawing.Size(65, 17);
            this.lblGameVersion.TabIndex = 6;
            this.lblGameVersion.Text = "Unknown";
            // 
            // lblGamePath
            // 
            this.lblGamePath.AutoSize = true;
            this.lblGamePath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamePath.ForeColor = System.Drawing.Color.White;
            this.lblGamePath.Location = new System.Drawing.Point(150, 80);
            this.lblGamePath.Name = "lblGamePath";
            this.lblGamePath.Size = new System.Drawing.Size(341, 17);
            this.lblGamePath.TabIndex = 5;
            this.lblGamePath.Text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Gorilla Tag";
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblGameStatus.Location = new System.Drawing.Point(150, 40);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(58, 17);
            this.lblGameStatus.TabIndex = 4;
            this.lblGameStatus.Text = "Modded";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label3.Location = new System.Drawing.Point(20, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Game Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(20, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Game Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game Status:";
            // 
            // btnBrowseGame
            // 
            this.btnBrowseGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnBrowseGame.FlatAppearance.BorderSize = 0;
            this.btnBrowseGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseGame.ForeColor = System.Drawing.Color.White;
            this.btnBrowseGame.Location = new System.Drawing.Point(640, 75);
            this.btnBrowseGame.Name = "btnBrowseGame";
            this.btnBrowseGame.Size = new System.Drawing.Size(86, 28);
            this.btnBrowseGame.TabIndex = 0;
            this.btnBrowseGame.Text = "Browse...";
            this.btnBrowseGame.UseVisualStyleBackColor = false;
            this.btnBrowseGame.Click += new System.EventHandler(this.btnBrowseGame_Click);
            // 
            // modsTab
            // 
            this.modsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.modsTab.Controls.Add(this.modListView);
            this.modsTab.Controls.Add(this.txtSearchMods);
            this.modsTab.Controls.Add(this.modControlPanel);
            this.modsTab.Location = new System.Drawing.Point(4, 5);
            this.modsTab.Name = "modsTab";
            this.modsTab.Padding = new System.Windows.Forms.Padding(3);
            this.modsTab.Size = new System.Drawing.Size(792, 441);
            this.modsTab.TabIndex = 1;
            this.modsTab.Text = "Mods";
            // 
            // modListView
            // 
            this.modListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.modListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.modListView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modListView.ForeColor = System.Drawing.Color.White;
            this.modListView.FullRowSelect = true;
            this.modListView.HideSelection = false;
            this.modListView.Location = new System.Drawing.Point(20, 60);
            this.modListView.Name = "modListView";
            this.modListView.Size = new System.Drawing.Size(752, 315);
            this.modListView.TabIndex = 2;
            this.modListView.UseCompatibleStateImageBehavior = false;
            this.modListView.View = System.Windows.Forms.View.Details;
            this.modListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.modListView_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
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
            // txtSearchMods
            // 
            this.txtSearchMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSearchMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchMods.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchMods.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchMods.Location = new System.Drawing.Point(20, 20);
            this.txtSearchMods.Name = "txtSearchMods";
            this.txtSearchMods.Size = new System.Drawing.Size(752, 25);
            this.txtSearchMods.TabIndex = 1;
            this.txtSearchMods.Text = "Search mods...";
            //this.txtSearchMods.TextChanged += new System.EventHandler(this.txtSearchMods_TextChanged);
            // 
            // modControlPanel
            // 
            this.modControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.modControlPanel.Controls.Add(this.btnRefreshMods);
            this.modControlPanel.Controls.Add(this.btnDisableMod);
            this.modControlPanel.Controls.Add(this.btnEnableMod);
            this.modControlPanel.Controls.Add(this.btnUninstallMod);
            this.modControlPanel.Controls.Add(this.btnInstallMod);
            this.modControlPanel.Location = new System.Drawing.Point(20, 385);
            this.modControlPanel.Name = "modControlPanel";
            this.modControlPanel.Size = new System.Drawing.Size(752, 40);
            this.modControlPanel.TabIndex = 0;
            // 
            // btnRefreshMods
            // 
            this.btnRefreshMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnRefreshMods.FlatAppearance.BorderSize = 0;
            this.btnRefreshMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshMods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshMods.ForeColor = System.Drawing.Color.White;
            this.btnRefreshMods.Location = new System.Drawing.Point(652, 5);
            this.btnRefreshMods.Name = "btnRefreshMods";
            this.btnRefreshMods.Size = new System.Drawing.Size(95, 30);
            this.btnRefreshMods.TabIndex = 4;
            this.btnRefreshMods.Text = "Refresh";
            this.btnRefreshMods.UseVisualStyleBackColor = false;
            this.btnRefreshMods.Click += new System.EventHandler(this.btnRefreshMods_Click);
            // 
            // btnDisableMod
            // 
            this.btnDisableMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDisableMod.FlatAppearance.BorderSize = 0;
            this.btnDisableMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisableMod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisableMod.ForeColor = System.Drawing.Color.White;
            this.btnDisableMod.Location = new System.Drawing.Point(305, 5);
            this.btnDisableMod.Name = "btnDisableMod";
            this.btnDisableMod.Size = new System.Drawing.Size(95, 30);
            this.btnDisableMod.TabIndex = 3;
            this.btnDisableMod.Text = "Disable";
            this.btnDisableMod.UseVisualStyleBackColor = false;
            this.btnDisableMod.Click += new System.EventHandler(this.btnDisableMod_Click);
            // 
            // btnEnableMod
            // 
            this.btnEnableMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnEnableMod.FlatAppearance.BorderSize = 0;
            this.btnEnableMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnableMod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnableMod.ForeColor = System.Drawing.Color.White;
            this.btnEnableMod.Location = new System.Drawing.Point(205, 5);
            this.btnEnableMod.Name = "btnEnableMod";
            this.btnEnableMod.Size = new System.Drawing.Size(95, 30);
            this.btnEnableMod.TabIndex = 2;
            this.btnEnableMod.Text = "Enable";
            this.btnEnableMod.UseVisualStyleBackColor = false;
            this.btnEnableMod.Click += new System.EventHandler(this.btnEnableMod_Click);
            // 
            // btnUninstallMod
            // 
            this.btnUninstallMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnUninstallMod.FlatAppearance.BorderSize = 0;
            this.btnUninstallMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUninstallMod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUninstallMod.ForeColor = System.Drawing.Color.White;
            this.btnUninstallMod.Location = new System.Drawing.Point(105, 5);
            this.btnUninstallMod.Name = "btnUninstallMod";
            this.btnUninstallMod.Size = new System.Drawing.Size(95, 30);
            this.btnUninstallMod.TabIndex = 1;
            this.btnUninstallMod.Text = "Uninstall";
            this.btnUninstallMod.UseVisualStyleBackColor = false;
            this.btnUninstallMod.Click += new System.EventHandler(this.btnUninstallMod_Click);
            // 
            // btnInstallMod
            // 
            this.btnInstallMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnInstallMod.FlatAppearance.BorderSize = 0;
            this.btnInstallMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallMod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallMod.ForeColor = System.Drawing.Color.White;
            this.btnInstallMod.Location = new System.Drawing.Point(5, 5);
            this.btnInstallMod.Name = "btnInstallMod";
            this.btnInstallMod.Size = new System.Drawing.Size(95, 30);
            this.btnInstallMod.TabIndex = 0;
            this.btnInstallMod.Text = "Install";
            this.btnInstallMod.UseVisualStyleBackColor = false;
            this.btnInstallMod.Click += new System.EventHandler(this.btnInstallMod_Click);
            // 
            // settingsTab
            // 
            this.settingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.settingsTab.Controls.Add(this.settingsPanel);
            this.settingsTab.Location = new System.Drawing.Point(4, 5);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Size = new System.Drawing.Size(792, 441);
            this.settingsTab.TabIndex = 2;
            this.settingsTab.Text = "Settings";
            // 
            // settingsPanel
            // 
            this.settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.settingsPanel.Controls.Add(this.btnHelp);
            this.settingsPanel.Controls.Add(this.btnResetSettings);
            this.settingsPanel.Controls.Add(this.btnSaveSettings);
            this.settingsPanel.Controls.Add(this.chkAutoInstallUpdates);
            this.settingsPanel.Controls.Add(this.chkDarkTheme);
            this.settingsPanel.Controls.Add(this.chkStartWithWindows);
            this.settingsPanel.Controls.Add(this.chkAutoUpdate);
            this.settingsPanel.Location = new System.Drawing.Point(20, 20);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(752, 405);
            this.settingsPanel.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(652, 365);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(95, 30);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnResetSettings.FlatAppearance.BorderSize = 0;
            this.btnResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetSettings.ForeColor = System.Drawing.Color.White;
            this.btnResetSettings.Location = new System.Drawing.Point(105, 365);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(95, 30);
            this.btnResetSettings.TabIndex = 5;
            this.btnResetSettings.Text = "Reset";
            this.btnResetSettings.UseVisualStyleBackColor = false;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveSettings.FlatAppearance.BorderSize = 0;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(5, 365);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(95, 30);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // chkAutoInstallUpdates
            // 
            this.chkAutoInstallUpdates.AutoSize = true;
            this.chkAutoInstallUpdates.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoInstallUpdates.ForeColor = System.Drawing.Color.White;
            this.chkAutoInstallUpdates.Location = new System.Drawing.Point(20, 110);
            this.chkAutoInstallUpdates.Name = "chkAutoInstallUpdates";
            this.chkAutoInstallUpdates.Size = new System.Drawing.Size(175, 21);
            this.chkAutoInstallUpdates.TabIndex = 3;
            this.chkAutoInstallUpdates.Text = "Auto-install updates when available";
            this.chkAutoInstallUpdates.UseVisualStyleBackColor = true;
            // 
            // chkDarkTheme
            // 
            this.chkDarkTheme.AutoSize = true;
            this.chkDarkTheme.Checked = true;
            this.chkDarkTheme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDarkTheme.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDarkTheme.ForeColor = System.Drawing.Color.White;
            this.chkDarkTheme.Location = new System.Drawing.Point(20, 80);
            this.chkDarkTheme.Name = "chkDarkTheme";
            this.chkDarkTheme.Size = new System.Drawing.Size(96, 21);
            this.chkDarkTheme.TabIndex = 2;
            this.chkDarkTheme.Text = "Dark Theme";
            this.chkDarkTheme.UseVisualStyleBackColor = true;
            this.chkDarkTheme.CheckedChanged += new System.EventHandler(this.chkDarkTheme_CheckedChanged);
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStartWithWindows.ForeColor = System.Drawing.Color.White;
            this.chkStartWithWindows.Location = new System.Drawing.Point(20, 50);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(136, 21);
            this.chkStartWithWindows.TabIndex = 1;
            this.chkStartWithWindows.Text = "Start with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.AutoSize = true;
            this.chkAutoUpdate.Checked = true;
            this.chkAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoUpdate.ForeColor = System.Drawing.Color.White;
            this.chkAutoUpdate.Location = new System.Drawing.Point(20, 20);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(175, 21);
            this.chkAutoUpdate.TabIndex = 0;
            this.chkAutoUpdate.Text = "Check for updates on startup";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // creditsTab
            // 
            this.creditsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.creditsTab.Controls.Add(this.creditsPanel);
            this.creditsTab.Location = new System.Drawing.Point(4, 5);
            this.creditsTab.Name = "creditsTab";
            this.creditsTab.Size = new System.Drawing.Size(792, 441);
            this.creditsTab.TabIndex = 3;
            this.creditsTab.Text = "Credits";
            // 
            // creditsPanel
            // 
            this.creditsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creditsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.creditsPanel.Controls.Add(this.btnDiscord);
            this.creditsPanel.Controls.Add(this.lblCreditsText);
            this.creditsPanel.Controls.Add(this.lblCreditsTitle);
            this.creditsPanel.Location = new System.Drawing.Point(20, 20);
            this.creditsPanel.Name = "creditsPanel";
            this.creditsPanel.Size = new System.Drawing.Size(752, 405);
            this.creditsPanel.TabIndex = 0;
            // 
            // btnDiscord
            // 
            this.btnDiscord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDiscord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDiscord.FlatAppearance.BorderSize = 0;
            this.btnDiscord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscord.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscord.ForeColor = System.Drawing.Color.White;
            this.btnDiscord.Location = new System.Drawing.Point(276, 250);
            this.btnDiscord.Name = "btnDiscord";
            this.btnDiscord.Size = new System.Drawing.Size(200, 40);
            this.btnDiscord.TabIndex = 2;
            this.btnDiscord.Text = "Join Discord";
            this.btnDiscord.UseVisualStyleBackColor = false;
            this.btnDiscord.Click += new System.EventHandler(this.btnDiscord_Click);
            // 
            // lblCreditsText
            // 
            this.lblCreditsText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCreditsText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsText.ForeColor = System.Drawing.Color.White;
            this.lblCreditsText.Location = new System.Drawing.Point(176, 120);
            this.lblCreditsText.Name = "lblCreditsText";
            this.lblCreditsText.Size = new System.Drawing.Size(400, 100);
            this.lblCreditsText.TabIndex = 1;
            this.lblCreditsText.Text = "CREDITS\r\n\r\nSpecial thanks to iidk " + "for the Bepinex cfg Join his Discord below.";
            this.lblCreditsText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCreditsTitle
            // 
            this.lblCreditsTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCreditsTitle.AutoSize = true;
            this.lblCreditsTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblCreditsTitle.Location = new System.Drawing.Point(271, 80);
            this.lblCreditsTitle.Name = "lblCreditsTitle";
            this.lblCreditsTitle.Size = new System.Drawing.Size(210, 30);
            this.lblCreditsTitle.TabIndex = 0;
            this.lblCreditsTitle.Text = "Encryptic";
            // 
            // logPanel
            // 
            this.logPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.logPanel.Controls.Add(this.logTextBox);
            this.logPanel.Controls.Add(this.logLabel);
            this.logPanel.Controls.Add(this.btnClearLog);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logPanel.Location = new System.Drawing.Point(200, 450);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(800, 150);
            this.logPanel.TabIndex = 1;
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextBox.ForeColor = System.Drawing.Color.White;
            this.logTextBox.Location = new System.Drawing.Point(20, 30);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(760, 100);
            this.logTextBox.TabIndex = 2;
            this.logTextBox.Text = "";
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.logLabel.Location = new System.Drawing.Point(20, 10);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(32, 17);
            this.logLabel.TabIndex = 1;
            this.logLabel.Text = "Log";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.ForeColor = System.Drawing.Color.White;
            this.btnClearLog.Location = new System.Drawing.Point(720, 5);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(60, 22);
            this.btnClearLog.TabIndex = 0;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar,
            this.versionLabel});
            this.statusStrip.Location = new System.Drawing.Point(200, 600);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 2;
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
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.headerPanel.Controls.Add(this.minimizeButton);
            this.headerPanel.Controls.Add(this.closeButton);
            this.headerPanel.Controls.Add(this.logoLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1000, 40);
            this.headerPanel.TabIndex = 3;
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Location = new System.Drawing.Point(920, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(40, 40);
            this.minimizeButton.TabIndex = 2;
            this.minimizeButton.Text = "−";
            this.minimizeButton.UseVisualStyleBackColor = false;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(960, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(40, 40);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "×";
            this.closeButton.UseVisualStyleBackColor = false;
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(12, 9);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(188, 21);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "Encryptic Mod Manager";
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.sidebarPanel.Controls.Add(this.creditsButton);
            this.sidebarPanel.Controls.Add(this.settingsButton);
            this.sidebarPanel.Controls.Add(this.modsButton);
            this.sidebarPanel.Controls.Add(this.dashboardButton);
            this.sidebarPanel.Controls.Add(this.logoPanel);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 40);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(200, 582);
            this.sidebarPanel.TabIndex = 4;
            // 
            // creditsButton
            // 
            this.creditsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.creditsButton.FlatAppearance.BorderSize = 0;
            this.creditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.creditsButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsButton.ForeColor = System.Drawing.Color.White;
            this.creditsButton.Location = new System.Drawing.Point(0, 250);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(200, 50);
            this.creditsButton.TabIndex = 4;
            this.creditsButton.Text = "Credits";
            this.creditsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.creditsButton.UseVisualStyleBackColor = true;
            this.creditsButton.Click += new System.EventHandler(this.creditsButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Location = new System.Drawing.Point(0, 200);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(200, 50);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.Text = "Settings";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // modsButton
            // 
            this.modsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.modsButton.FlatAppearance.BorderSize = 0;
            this.modsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modsButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsButton.ForeColor = System.Drawing.Color.White;
            this.modsButton.Location = new System.Drawing.Point(0, 150);
            this.modsButton.Name = "modsButton";
            this.modsButton.Size = new System.Drawing.Size(200, 50);
            this.modsButton.TabIndex = 2;
            this.modsButton.Text = "Mods";
            this.modsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modsButton.UseVisualStyleBackColor = true;
            this.modsButton.Click += new System.EventHandler(this.modsButton_Click);
            // 
            // dashboardButton
            // 
            this.dashboardButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardButton.FlatAppearance.BorderSize = 0;
            this.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton.ForeColor = System.Drawing.Color.White;
            this.dashboardButton.Location = new System.Drawing.Point(0, 100);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(200, 50);
            this.dashboardButton.TabIndex = 1;
            this.dashboardButton.Text = "Dashboard";
            this.dashboardButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.logoIcon);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(200, 100);
            this.logoPanel.TabIndex = 0;
            // 
            // logoIcon
            // 
            //this.logoIcon.Image = System.Drawing.Image.FromFile("logoIcon.png");  will be added in a later date
            this.logoIcon.Location = new System.Drawing.Point(50, 10);
            this.logoIcon.Name = "logoIcon";
            this.logoIcon.Size = new System.Drawing.Size(100, 80);
            this.logoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoIcon.TabIndex = 0;
            this.logoIcon.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tabControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 40);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1000, 622);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.logPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryptic Mod Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.dashboardTab.ResumeLayout(false);
            this.dashboardMainPanel.ResumeLayout(false);
            this.launchPanel.ResumeLayout(false);
            this.actionsPanel.ResumeLayout(false);
            this.gameInfoGroupBox.ResumeLayout(false);
            this.gameInfoGroupBox.PerformLayout();
            this.modsTab.ResumeLayout(false);
            this.modsTab.PerformLayout();
            this.modControlPanel.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.creditsTab.ResumeLayout(false);
            this.creditsPanel.ResumeLayout(false);
            this.creditsPanel.PerformLayout();
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.sidebarPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoIcon)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage dashboardTab;
        private System.Windows.Forms.TabPage modsTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.TabPage creditsTab;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel versionLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel dashboardMainPanel;
        private System.Windows.Forms.GroupBox gameInfoGroupBox;
        private System.Windows.Forms.Button btnBrowseGame;
        private System.Windows.Forms.Label lblGameVersion;
        private System.Windows.Forms.Label lblGamePath;
        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel actionsPanel;
        private System.Windows.Forms.Button btnInstallMenu;
        private System.Windows.Forms.Button btnInstallBepInEx;
        private System.Windows.Forms.Panel launchPanel;
        private System.Windows.Forms.Button btnLaunchGame;
        private System.Windows.Forms.Panel modControlPanel;
        private System.Windows.Forms.Button btnRefreshMods;
        private System.Windows.Forms.Button btnDisableMod;
        private System.Windows.Forms.Button btnEnableMod;
        private System.Windows.Forms.Button btnUninstallMod;
        private System.Windows.Forms.Button btnInstallMod;
        private System.Windows.Forms.TextBox txtSearchMods;
        private System.Windows.Forms.ListView modListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.CheckBox chkAutoInstallUpdates;
        private System.Windows.Forms.CheckBox chkDarkTheme;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.CheckBox chkAutoUpdate;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Panel creditsPanel;
        private System.Windows.Forms.Label lblCreditsTitle;
        private System.Windows.Forms.Label lblCreditsText;
        private System.Windows.Forms.Button btnDiscord;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.PictureBox logoIcon;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button creditsButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button modsButton;
        private System.Windows.Forms.Panel mainPanel;
    }
}
