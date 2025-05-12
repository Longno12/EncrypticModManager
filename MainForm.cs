using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using FontAwesome.Sharp;

namespace ModManager
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private const string CURRENT_MANAGER_VERSION = "1.0.0";
        private const string MANAGER_VERSION_URL = "https://raw.githubusercontent.com/Longno12/Encryptic/main/version.txt";
        private const string MANAGER_DOWNLOAD_URL = "https://github.com/Longno12/Encryptic/releases/latest/download/EncrypticModManager.exe";
        private const string BEPINEX_LATEST_URL = "https://api.github.com/repos/BepInEx/BepInEx/releases/latest";
        private const string BEPINEX_DOWNLOAD_URL = "https://github.com/BepInEx/BepInEx/releases/latest/download/BepInEx_win_x64_5.4.23.3.zip";
        private const string BEPINEX_CONFIG_URL = "https://raw.githubusercontent.com/iiDk-the-actual/ModInfo/refs/heads/main/BepInEx.cfg";

        private string gamePath;
        private bool isBepInExInstalled = false;
        private string gameVersion = "Unknown";
        private Color accentColor = Color.FromArgb(0, 122, 204);
        private Color darkBackground = Color.FromArgb(28, 28, 28);
        private Color mediumBackground = Color.FromArgb(45, 45, 48);
        private Color lightBackground = Color.FromArgb(60, 60, 60);
        private Color textBoxBackground = Color.FromArgb(30, 30, 30);

        private readonly string[] possiblePaths =
        {
            @"C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag",
            @"D:\SteamLibrary\steamapps\common\Gorilla Tag",
            @"C:\Program Files\Oculus\Software\Software\another-axiom-gorilla-tag"
        };

        public MainForm()
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 15, 15));
            this.headerPanel.MouseDown += HeaderPanel_MouseDown;
            this.logoLabel.MouseDown += HeaderPanel_MouseDown;
            this.closeButton.Click += (s, e) => Application.Exit();
            this.minimizeButton.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            this.dashboardButton.Click += (s, e) => tabControl.SelectedIndex = 0;
            this.modsButton.Click += (s, e) => tabControl.SelectedIndex = 1;
            this.settingsButton.Click += (s, e) => tabControl.SelectedIndex = 2;
            this.creditsButton.Click += (s, e) => tabControl.SelectedIndex = 3;
            SetupSidebarButtonHover(dashboardButton);
            SetupSidebarButtonHover(modsButton);
            SetupSidebarButtonHover(settingsButton);
            SetupSidebarButtonHover(creditsButton);
            LoadSettings();
            versionLabel.Text = $"v{CURRENT_MANAGER_VERSION}";
            ApplyTheme(Properties.Settings.Default.DarkTheme);
            SetPlaceholderText(txtSearchMods, "Search mods...");
        }

        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void SetupSidebarButtonHover(Button button)
        {
            button.MouseEnter += (s, e) => {
                button.BackColor = Color.FromArgb(45, 45, 48);
            };

            button.MouseLeave += (s, e) => {
                button.BackColor = Color.FromArgb(37, 37, 38);
            };

            button.Paint += (s, e) => {
                if (button == dashboardButton && tabControl.SelectedIndex == 0 ||
                    button == modsButton && tabControl.SelectedIndex == 1 ||
                    button == settingsButton && tabControl.SelectedIndex == 2 ||
                    button == creditsButton && tabControl.SelectedIndex == 3)
                {
                    e.Graphics.FillRectangle(new SolidBrush(accentColor), new Rectangle(0, 0, 5, button.Height));
                }
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            ApplyModernStyling();
            SetupModernIcons();
            ModernizeListView();
            DetectGamePath();
            if (chkAutoUpdate.Checked)
            {
                CheckForUpdatesAsync();
            }
            SetupTooltips();
            UpdateSidebarSelection();
        }

        private void UpdateSidebarSelection()
        {
            dashboardButton.Invalidate();
            modsButton.Invalidate();
            settingsButton.Invalidate();
            creditsButton.Invalidate();
        }

        #region Modern UI Enhancements

        private void ApplyModernStyling()
        {
            ApplyRoundedCorners(btnLaunchGame, 8);
            ApplyRoundedCorners(btnInstallBepInEx, 8);
            ApplyRoundedCorners(btnInstallMenu, 8);
            ApplyRoundedCorners(btnBrowseGame, 8);
            ApplyRoundedCorners(btnSaveSettings, 8);
            ApplyRoundedCorners(btnResetSettings, 8);
            ApplyRoundedCorners(btnHelp, 8);
            ApplyRoundedCorners(btnDiscord, 8);
            ApplyRoundedCorners(btnInstallMod, 8);
            ApplyRoundedCorners(btnUninstallMod, 8);
            ApplyRoundedCorners(btnEnableMod, 8);
            ApplyRoundedCorners(btnDisableMod, 8);
            ApplyRoundedCorners(btnRefreshMods, 8);
            ApplyRoundedCorners(btnClearLog, 8);
            AddButtonHoverEffects();
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += TabControl_DrawItem;
            txtSearchMods.BorderStyle = BorderStyle.None;
            Panel searchPanel = new Panel
            {
                Height = txtSearchMods.Height + 6,
                Dock = DockStyle.Top,
                Padding = new Padding(10, 3, 10, 3),
                BackColor = textBoxBackground
            };
            modsTab.Controls.Add(searchPanel);
            modsTab.Controls.Remove(txtSearchMods);
            searchPanel.Controls.Add(txtSearchMods);
            txtSearchMods.Dock = DockStyle.Fill;

            PictureBox searchIcon = new PictureBox
            {
                Image = IconChar.Search.ToBitmap(16, 16, Color.Gray),
                SizeMode = PictureBoxSizeMode.CenterImage,
                Width = 20,
                Dock = DockStyle.Right
            };
            searchPanel.Controls.Add(searchIcon);

            logPanel.Paint += (s, args) => {
                args.Graphics.DrawLine(new Pen(Color.FromArgb(60, 60, 60), 1),
                    0, 0, logPanel.Width, 0);
            };

            statusStrip.BackColor = Color.FromArgb(37, 37, 38);
            statusStrip.ForeColor = Color.White;
            statusStrip.Renderer = new ModernStatusStripRenderer();

            AddShadowEffect(gameInfoGroupBox);
            AddShadowEffect(settingsPanel);
            AddShadowEffect(creditsPanel);
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage page = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);


            using (SolidBrush backBrush = new SolidBrush(mediumBackground))
            {
                g.FillRectangle(backBrush, tabRect);
            }


            if (tabControl.SelectedIndex == e.Index)
            {
                using (SolidBrush accentBrush = new SolidBrush(accentColor))
                {
                    g.FillRectangle(accentBrush, new Rectangle(tabRect.X, tabRect.Bottom - 3, tabRect.Width, 3));
                }
            }
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            if (control == null) return;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(control.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(control.Width - radius * 2, control.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(0, control.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseAllFigures();
                control.Region = new Region(path);
            }

            control.Resize += (s, e) => {
                ApplyRoundedCorners(control, radius);
            };
        }

        private void AddButtonHoverEffects()
        {
            foreach (Control control in GetAllControls(this))
            {
                if (control is Button button &&
                    button != closeButton &&
                    button != minimizeButton &&
                    button != dashboardButton &&
                    button != modsButton &&
                    button != settingsButton &&
                    button != creditsButton)
                {
                    Color originalColor = button.BackColor;
                    Color hoverColor = GetLighterColor(originalColor, 30);
                    Color pressColor = GetDarkerColor(originalColor, 20);

                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = hoverColor;
                    button.FlatAppearance.MouseDownBackColor = pressColor;
                }
            }
        }

        private Control[] GetAllControls(Control container)
        {
            List<Control> controlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                controlList.Add(c);
                controlList.AddRange(GetAllControls(c));
            }
            return controlList.ToArray();
        }

        private Color GetLighterColor(Color color, int amount)
        {
            return Color.FromArgb(
                Math.Min(color.R + amount, 255),
                Math.Min(color.G + amount, 255),
                Math.Min(color.B + amount, 255));
        }

        private Color GetDarkerColor(Color color, int amount)
        {
            return Color.FromArgb(
                Math.Max(color.R - amount, 0),
                Math.Max(color.G - amount, 0),
                Math.Max(color.B - amount, 0));
        }

        private void SetupModernIcons()
        {
            btnInstallBepInEx.Image = IconChar.Download.ToBitmap(16, 16, Color.White);
            btnInstallBepInEx.ImageAlign = ContentAlignment.MiddleLeft;
            btnInstallBepInEx.TextAlign = ContentAlignment.MiddleRight;
            btnInstallBepInEx.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInstallBepInEx.Padding = new Padding(5, 0, 0, 0);
            btnInstallMenu.Image = IconChar.PuzzlePiece.ToBitmap(16, 16, Color.White);
            btnInstallMenu.ImageAlign = ContentAlignment.MiddleLeft;
            btnInstallMenu.TextAlign = ContentAlignment.MiddleRight;
            btnInstallMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInstallMenu.Padding = new Padding(5, 0, 0, 0);
            btnLaunchGame.Image = IconChar.Play.ToBitmap(16, 16, Color.White);
            btnLaunchGame.ImageAlign = ContentAlignment.MiddleLeft;
            btnLaunchGame.TextAlign = ContentAlignment.MiddleRight;
            btnLaunchGame.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLaunchGame.Padding = new Padding(5, 0, 0, 0);
            btnBrowseGame.Image = IconChar.FolderOpen.ToBitmap(16, 16, Color.White);
            btnBrowseGame.ImageAlign = ContentAlignment.MiddleLeft;
            btnBrowseGame.TextAlign = ContentAlignment.MiddleRight;
            btnBrowseGame.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInstallMod.Image = IconChar.Plus.ToBitmap(16, 16, Color.White);
            btnInstallMod.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUninstallMod.Image = IconChar.Trash.ToBitmap(16, 16, Color.White);
            btnUninstallMod.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEnableMod.Image = IconChar.Check.ToBitmap(16, 16, Color.White);
            btnEnableMod.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDisableMod.Image = IconChar.Ban.ToBitmap(16, 16, Color.White);
            btnDisableMod.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefreshMods.Image = IconChar.Sync.ToBitmap(16, 16, Color.White);
            btnRefreshMods.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveSettings.Image = IconChar.Save.ToBitmap(16, 16, Color.White);
            btnSaveSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnResetSettings.Image = IconChar.Undo.ToBitmap(16, 16, Color.White);
            btnResetSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHelp.Image = IconChar.QuestionCircle.ToBitmap(16, 16, Color.White);
            btnHelp.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDiscord.Image = IconChar.Discord.ToBitmap(16, 16, Color.White);
            btnDiscord.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClearLog.Image = IconChar.Eraser.ToBitmap(16, 16, Color.White);
            btnClearLog.TextImageRelation = TextImageRelation.ImageBeforeText;
            dashboardButton.Image = IconChar.Home.ToBitmap(24, 24, Color.White);
            dashboardButton.ImageAlign = ContentAlignment.MiddleLeft;
            dashboardButton.TextAlign = ContentAlignment.MiddleLeft;
            dashboardButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            dashboardButton.Padding = new Padding(20, 0, 0, 0);
            modsButton.Image = IconChar.PuzzlePiece.ToBitmap(24, 24, Color.White);
            modsButton.ImageAlign = ContentAlignment.MiddleLeft;
            modsButton.TextAlign = ContentAlignment.MiddleLeft;
            modsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            modsButton.Padding = new Padding(20, 0, 0, 0);
            settingsButton.Image = IconChar.Cog.ToBitmap(24, 24, Color.White);
            settingsButton.ImageAlign = ContentAlignment.MiddleLeft;
            settingsButton.TextAlign = ContentAlignment.MiddleLeft;
            settingsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            settingsButton.Padding = new Padding(20, 0, 0, 0);
            creditsButton.Image = IconChar.InfoCircle.ToBitmap(24, 24, Color.White);
            creditsButton.ImageAlign = ContentAlignment.MiddleLeft;
            creditsButton.TextAlign = ContentAlignment.MiddleLeft;
            creditsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            creditsButton.Padding = new Padding(20, 0, 0, 0);
        }

        private void AddShadowEffect(Control control)
        {
            control.Paint += (s, e) => {
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(shadowBrush,
                        new Rectangle(2, control.Height - 2, control.Width - 4, 4));
                }
            };
        }

        private void ModernizeListView()
        {
            modListView.OwnerDraw = true;
            modListView.DrawItem += (s, e) => {e.DrawBackground();

                ListViewItem item = modListView.Items[e.ItemIndex];
                if (e.ItemIndex % 2 == 0)
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), e.Bounds);
                else
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), e.Bounds);

                if (item.Selected)
                {
                    using (SolidBrush selectionBrush = new SolidBrush(Color.FromArgb(70, 0, 122, 204)))
                    {
                        e.Graphics.FillRectangle(selectionBrush, e.Bounds);
                    }
                }

                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    Rectangle subItemBounds = item.SubItems[i].Bounds;
                    Color textColor = Color.White;
                    if (i == 2) // Status column
                    {
                        if (item.SubItems[i].Text == "Enabled")
                            textColor = Color.LightGreen;
                        else if (item.SubItems[i].Text == "Disabled")
                            textColor = Color.LightCoral;
                    }

                    e.Graphics.DrawString(item.SubItems[i].Text, modListView.Font,
                        new SolidBrush(textColor), subItemBounds.Left + 3, subItemBounds.Top + 2);
                }

                e.DrawFocusRectangle();
            };

            modListView.DrawColumnHeader += (s, e) => {

                using (SolidBrush headerBrush = new SolidBrush(Color.FromArgb(60, 60, 60)))
                {
                    e.Graphics.FillRectangle(headerBrush, e.Bounds);
                }

                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.DrawString(modListView.Columns[e.ColumnIndex].Text,
                        new Font(modListView.Font, FontStyle.Bold), textBrush,
                        e.Bounds.Left + 3, e.Bounds.Top + 3);
                }

                using (Pen linePen = new Pen(Color.FromArgb(80, 80, 80), 1))
                {
                    e.Graphics.DrawLine(linePen, e.Bounds.Left, e.Bounds.Bottom - 1,
                        e.Bounds.Right, e.Bounds.Bottom - 1);
                }
            };
        }

        private void SetupTooltips()
        {
            toolTip.SetToolTip(btnInstallBepInEx, "Install or reinstall BepInEx framework");
            toolTip.SetToolTip(btnInstallMenu, "Install the Encryptic menu mod");
            toolTip.SetToolTip(btnLaunchGame, "Launch Gorilla Tag with current mods");
            toolTip.SetToolTip(btnBrowseGame, "Browse for Gorilla Tag installation folder");
            toolTip.SetToolTip(chkAutoUpdate, "Automatically check for updates when starting the manager");
            toolTip.SetToolTip(chkStartWithWindows, "Start the mod manager when Windows starts");
            toolTip.SetToolTip(chkDarkTheme, "Toggle between dark and light theme");
            toolTip.SetToolTip(chkAutoInstallUpdates, "Automatically install manager updates when available");
            toolTip.SetToolTip(btnSaveSettings, "Save all settings");
            toolTip.SetToolTip(btnResetSettings, "Reset all settings to default");
            toolTip.SetToolTip(btnHelp, "Show help documentation");
            toolTip.SetToolTip(btnInstallMod, "Install a new mod from file");
            toolTip.SetToolTip(btnUninstallMod, "Uninstall the selected mod");
            toolTip.SetToolTip(btnEnableMod, "Enable the selected mod");
            toolTip.SetToolTip(btnDisableMod, "Disable the selected mod");
            toolTip.SetToolTip(btnRefreshMods, "Refresh the mod list");
            toolTip.SetToolTip(btnDiscord, "Join the IIDK Discord server");
            toolTip.SetToolTip(btnClearLog, "Clear the log");
            toolTip.SetToolTip(dashboardButton, "Go to Dashboard");
            toolTip.SetToolTip(modsButton, "Manage Mods");
            toolTip.SetToolTip(settingsButton, "Change Settings");
            toolTip.SetToolTip(creditsButton, "View Credits");
        }

        #endregion

        #region Animation Effects

        private async Task AnimateProgressBar(ToolStripProgressBar progressBar, int targetValue)
        {
            int startValue = progressBar.Value;
            int steps = 20;

            for (int i = 1; i <= steps; i++)
            {
                int value = startValue + ((targetValue - startValue) * i / steps);
                progressBar.Value = value;
                await Task.Delay(10);
            }
        }

        private async Task FadeInControl(Control control, int duration = 500)
        {
            if (control is Form form)
            {
                form.Opacity = 0;
                form.Visible = true;
                double opacity = 0;
                int formSteps = 20;
                int delay = duration / formSteps;
                for (int i = 0; i <= formSteps; i++)
                {
                    opacity = (double)i / formSteps;
                    form.Opacity = opacity;
                    await Task.Delay(delay);
                }
                form.Opacity = 1;
            }
            else
            {
                control.Visible = true;
                byte[] alphaValues = new byte[10];
                for (int i = 0; i < alphaValues.Length; i++)
                {
                    alphaValues[i] = (byte)(((i + 1) * 255) / alphaValues.Length);
                }
                int stepDelay = duration / alphaValues.Length;
                Panel fadePanel = new Panel
                {
                    Size = control.Size,
                    Location = control.Location,
                    BackColor = control.BackColor,
                    Parent = control.Parent
                };
                Control originalParent = control.Parent;
                Point originalLocation = control.Location;
                control.Parent = fadePanel;
                control.Location = new Point(0, 0);

                int controlIndex = originalParent.Controls.IndexOf(control);
                if (controlIndex >= 0)
                {
                    originalParent.Controls.SetChildIndex(fadePanel, controlIndex);
                }


                for (int i = 0; i < alphaValues.Length; i++)
                {
                    fadePanel.BackColor = Color.FromArgb(alphaValues[i], fadePanel.BackColor);
                    control.Refresh();
                    await Task.Delay(stepDelay);
                }


                control.Parent = originalParent;
                control.Location = originalLocation;
                fadePanel.Dispose();
            }
        }

        #endregion

        #region Logging

        private void SafeExecute(Action action, string errorMessage)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Log($"{errorMessage}: {ex.Message}");
                MessageBox.Show($"{errorMessage}\n\nDetails: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Log(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), message);
                return;
            }

            logTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
            logTextBox.ScrollToCaret();
        }

        private void UpdateStatus(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateStatus), message);
                return;
            }

            statusLabel.Text = message;
        }

        #endregion

        private void SetPlaceholderText(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (sender, e) => {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.White;
                }
            };

            textBox.LostFocus += (sender, e) => {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        #region Game Detection

        private void DetectGamePath()
        {
            Log("Detecting game installation...");

            foreach (var path in possiblePaths)
            {
                if (Directory.Exists(path))
                {
                    gamePath = path;
                    Log($"Game found at: {gamePath}");
                    UpdateGameInfo();
                    return;
                }
            }

            Log("Game not found in default locations. Please select manually.");
            lblGameStatus.Text = "Not Found";
            lblGameStatus.ForeColor = Color.Red;
            lblGamePath.Text = "Not Detected";
        }

        private void UpdateGameInfo()
        {
            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
            {
                lblGameStatus.Text = "Not Found";
                lblGameStatus.ForeColor = Color.Red;
                lblGamePath.Text = "Not Detected";
                return;
            }

            lblGamePath.Text = gamePath;
            isBepInExInstalled = Directory.Exists(Path.Combine(gamePath, "BepInEx"));

            if (isBepInExInstalled)
            {
                lblGameStatus.Text = "Modded";
                lblGameStatus.ForeColor = Color.LimeGreen;
                btnInstallBepInEx.Text = "Reinstall BepInEx";
            }
            else
            {
                lblGameStatus.Text = "Vanilla";
                lblGameStatus.ForeColor = Color.Yellow;
                btnInstallBepInEx.Text = "Install BepInEx";
            }

            try
            {
                string versionFilePath = Path.Combine(gamePath, "Gorilla Tag_Data", "StreamingAssets", "VERSION");
                if (File.Exists(versionFilePath))
                {
                    gameVersion = File.ReadAllText(versionFilePath).Trim();
                    lblGameVersion.Text = gameVersion;
                }
                else
                {
                    lblGameVersion.Text = "Unknown";
                }
            }
            catch (Exception ex)
            {
                Log($"Error detecting game version: {ex.Message}");
                lblGameVersion.Text = "Error";
            }
        }

        private void btnBrowseGame_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select Gorilla Tag installation folder";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    gamePath = dialog.SelectedPath;
                    Log($"Custom path selected: {gamePath}");
                    UpdateGameInfo();
                    SaveSettings();
                }
            }
        }

        #endregion

        #region Updates

        private async Task CheckForUpdatesAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ModManager");

                    string latestVersion = await httpClient.GetStringAsync(MANAGER_VERSION_URL);
                    latestVersion = latestVersion.Trim();

                    if (latestVersion != CURRENT_MANAGER_VERSION)
                    {
                        Log($"New manager version available: {latestVersion}");

                        if (chkAutoInstallUpdates.Checked)
                        {
                            await DownloadAndInstallUpdateAsync(latestVersion);
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show(
                                $"A new version of the Mod Manager is available: v{latestVersion}\n\nWould you like to update now?",
                                "Update Available",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);

                            if (result == DialogResult.Yes)
                            {
                                await DownloadAndInstallUpdateAsync(latestVersion);
                            }
                        }
                    }
                    else
                    {
                        Log("Mod Manager is up to date.");
                    }

                    var json = await httpClient.GetStringAsync(BEPINEX_LATEST_URL);
                    string tag = JsonDocument.Parse(json).RootElement.GetProperty("tag_name").GetString();

                    if (!tag.Contains("5.4.23"))
                    {
                        Log($"New BepInEx version available: {tag}");
                        MessageBox.Show(
                            $"A new version of BepInEx is available: {tag}\nYou can install it from the Dashboard.",
                            "Update Available",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        Log("BepInEx is up to date.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Update check failed: {ex.Message}");
                UpdateStatus("Update check failed.");
            }
        }


        // Coming soon
        private async Task DownloadAndInstallUpdateAsync(string newVersion)
        {
            try
            {
                UpdateStatus("Downloading update...");
                ShowProgress(true, 0);
                Log($"Downloading update v{newVersion}...");
                string tempDir = Path.Combine(Path.GetTempPath(), "EncrypticModManagerUpdate");
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
                Directory.CreateDirectory(tempDir);
                string zipPath = Path.Combine(tempDir, "update.zip");
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += (s, args) =>
                    {
                        AnimateProgressBar(progressBar, args.ProgressPercentage);
                    };

                    await client.DownloadFileTaskAsync(MANAGER_DOWNLOAD_URL, zipPath);
                }
                await AnimateProgressBar(progressBar, 100);
                Log("Download complete. Preparing to install update...");
                ZipFile.ExtractToDirectory(zipPath, tempDir);
                string updaterPath = Path.Combine(tempDir, "updater.bat");
                string appPath = Application.ExecutablePath;
                string appDir = Path.GetDirectoryName(appPath);

                // Create a batch file that will:
                // 1. Wait for the current process to exit
                // 2. Copy the new files over the old ones
                // 3. Start the updated application
                // 4. Delete itself
                string updaterScript =
                    $@"@echo off
echo Updating Encryptic Mod Manager to v{newVersion}...
timeout /t 2 /nobreak > nul
xcopy ""{tempDir}\*.*"" ""{appDir}"" /E /H /C /I /Y
start """" ""{appPath}""
del ""{updaterPath}""
exit";

                File.WriteAllText(updaterPath, updaterScript);

                // Ask the user to confirm the update
                DialogResult result = MessageBox.Show(
                    $"Update v{newVersion} has been downloaded and is ready to install.\nThe application will restart to complete the update.\n\nInstall now?",
                    "Update Ready",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = updaterPath,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    Process.Start(startInfo);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Log($"Update failed: {ex.Message}");
                UpdateStatus("Update failed.");
                ShowProgress(false);
                MessageBox.Show($"Failed to update: {ex.Message}", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Installation

        private async void btnInstallBepInEx_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
            {
                MessageBox.Show("Game path not set. Please select the game folder first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                UpdateStatus("Installing BepInEx...");
                ShowProgress(true, 10);
                Log("Starting BepInEx installation...");

                string zipPath = Path.Combine(Path.GetTempPath(), "BepInEx.zip");

                Log("Downloading BepInEx...");
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += (s, args) =>
                    {
                        AnimateProgressBar(progressBar, args.ProgressPercentage);
                    };

                    await client.DownloadFileTaskAsync(BEPINEX_DOWNLOAD_URL, zipPath);
                }

                await AnimateProgressBar(progressBar, 50);
                Log("Extracting BepInEx...");


                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string destinationPath = Path.Combine(gamePath, entry.FullName);
                        string directoryPath = Path.GetDirectoryName(destinationPath);

                        if (!string.IsNullOrEmpty(directoryPath))
                            Directory.CreateDirectory(directoryPath);

                        if (!entry.FullName.EndsWith("/"))
                            entry.ExtractToFile(destinationPath, true);
                    }
                }

                await AnimateProgressBar(progressBar, 80);
                Log("Creating directories...");

                Directory.CreateDirectory(Path.Combine(gamePath, "BepInEx", "config"));
                Directory.CreateDirectory(Path.Combine(gamePath, "BepInEx", "plugins"));

                Log("Downloading BepInEx configuration...");
                string cfgPath = Path.Combine(gamePath, "BepInEx", "config", "BepInEx.cfg");

                using (var client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(BEPINEX_CONFIG_URL, cfgPath);
                }
                File.Delete(zipPath);
                await AnimateProgressBar(progressBar, 100);
                Log("BepInEx installed successfully.");
                UpdateStatus("Installation complete.");
                MessageBox.Show("BepInEx has been installed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGameInfo();
            }
            catch (Exception ex)
            {
                Log($"Installation failed: {ex.Message}");
                UpdateStatus("Installation failed.");
                MessageBox.Show($"Error: {ex.Message}", "Installation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private void ShowProgress(bool visible, int value = 0)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool, int>(ShowProgress), visible, value);
                return;
            }

            progressBar.Visible = visible;
            if (visible)
            {
                progressBar.Value = value;
            }
        }

        private async void btnInstallMenu_Click(object sender, EventArgs e)
        {
            string menuDownloadUrl = "https://github.com/Longno12/MenuDownload/releases/download/game/Project.Encryptic.dll";
            string menuName = "Project.Encryptic.dll";

            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
            {
                MessageBox.Show("Game path not set. Please select the game folder first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isBepInExInstalled)
            {
                DialogResult result = MessageBox.Show(
                    "BepInEx is required to install mods. Would you like to install it now?",
                    "BepInEx Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    btnInstallBepInEx_Click(sender, e);
                    return;
                }
                else
                {
                    return;
                }
            }

            try
            {
                UpdateStatus("Installing menu...");
                ShowProgress(true, 0);

                string pluginsPath = Path.Combine(gamePath, "BepInEx", "plugins");
                if (!Directory.Exists(pluginsPath))
                {
                    Directory.CreateDirectory(pluginsPath);
                }

                string targetPath = Path.Combine(pluginsPath, menuName);

                using (HttpClient client = new HttpClient())
                {
                    Log($"Downloading {menuName}...");

                    for (int i = 0; i <= 100; i += 5)
                    {
                        await AnimateProgressBar(progressBar, i);
                        await Task.Delay(50);
                    }

                    byte[] data = await client.GetByteArrayAsync(menuDownloadUrl);
                    File.WriteAllBytes(targetPath, data);
                }

                ShowProgress(false);
                UpdateStatus("Menu installed successfully.");
                Log($"{menuName} installed successfully.");

                MessageBox.Show($"{menuName} has been installed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowProgress(false);
                UpdateStatus("Installation failed.");
                Log($"Error installing menu: {ex.Message}");
                MessageBox.Show("Failed to install the menu.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLaunchGame_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
            {
                MessageBox.Show("Game path not set. Please select the game folder first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string exePath = Path.Combine(gamePath, "Gorilla Tag.exe");
                if (File.Exists(exePath))
                {
                    Log("Launching game...");
                    UpdateStatus("Launching game...");

                    btnLaunchGame.Enabled = false;
                    btnLaunchGame.Text = "Launching...";

                    // Restore button after delay
                    Task.Delay(3000).ContinueWith(t => {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() => {
                                btnLaunchGame.Enabled = true;
                                btnLaunchGame.Text = "Launch Game";
                                UpdateStatus("Ready.");
                            }));
                        }
                    });

                    Process.Start(exePath);
                }
                else
                {
                    Log("Game executable not found.");
                    MessageBox.Show("Game executable not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log($"Failed to launch game: {ex.Message}");
                MessageBox.Show($"Failed to launch game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void ApplyTheme(bool darkMode)
        {
            var backColor = darkMode ? Color.FromArgb(28, 28, 28) : SystemColors.Control;
            var foreColor = darkMode ? Color.White : SystemColors.ControlText;
            var controlColor = darkMode ? Color.FromArgb(60, 60, 60) : SystemColors.ControlLight;
            var textBoxColor = darkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            this.BackColor = backColor;
            this.ForeColor = foreColor;
            ApplyThemeToControls(this.Controls, backColor, foreColor, controlColor, textBoxColor);
            logTextBox.BackColor = textBoxColor;
            logTextBox.ForeColor = foreColor;
            modListView.BackColor = textBoxColor;
            modListView.ForeColor = foreColor;
            txtSearchMods.BackColor = textBoxColor;
            txtSearchMods.ForeColor = foreColor;
            accentColor = darkMode ? Color.FromArgb(0, 122, 204) : Color.FromArgb(0, 102, 204);
            btnLaunchGame.BackColor = accentColor;
            btnSaveSettings.BackColor = accentColor;
        }

        private void ApplyThemeToControls(Control.ControlCollection controls, Color backColor, Color foreColor, Color controlColor, Color textBoxColor)
        {
            foreach (Control control in controls)
            {
                if (control is TabPage tabPage)
                {
                    tabPage.BackColor = backColor;
                    tabPage.ForeColor = foreColor;
                }

                control.BackColor = control is TextBoxBase || control is ListView ? textBoxColor :
                                  control is Button ? controlColor : backColor;
                control.ForeColor = foreColor;

                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
                }

                if (control.HasChildren)
                {
                    ApplyThemeToControls(control.Controls, backColor, foreColor, controlColor, textBoxColor);
                }
            }
        }

        private void chkDarkTheme_CheckedChanged(object sender, EventArgs e)
        {
            ApplyTheme(chkDarkTheme.Checked);
            SaveSettings();
        }

        #region Help System

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Form helpForm = new Form
            {
                Text = "Encryptic Mod Manager Help",
                Size = new Size(500, 400),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = darkBackground,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f)
            };

            TabControl helpTabs = new TabControl
            {
                Dock = DockStyle.Fill,
                DrawMode = TabDrawMode.OwnerDrawFixed
            };

            helpTabs.DrawItem += (s, args) => {
                Graphics g = args.Graphics;
                TabPage page = helpTabs.TabPages[args.Index];
                Rectangle tabRect = helpTabs.GetTabRect(args.Index);

                using (SolidBrush backBrush = new SolidBrush(mediumBackground))
                {
                    g.FillRectangle(backBrush, tabRect);
                }

                if (helpTabs.SelectedIndex == args.Index)
                {
                    using (SolidBrush accentBrush = new SolidBrush(accentColor))
                    {
                        g.FillRectangle(accentBrush, new Rectangle(tabRect.X, tabRect.Bottom - 3, tabRect.Width, 3));
                    }
                }

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                using (SolidBrush textBrush = new SolidBrush(helpTabs.SelectedIndex == args.Index ? Color.White : Color.LightGray))
                {
                    g.DrawString(page.Text, helpTabs.Font, textBrush, tabRect, sf);
                }
            };

            TabPage dashboardHelp = new TabPage("Dashboard")
            {
                BackColor = mediumBackground,
                ForeColor = Color.White
            };

            RichTextBox dashboardText = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = mediumBackground,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Text = "Dashboard Tab\n\n" +
                       "• Game Information: Shows the status, path, and version of your Gorilla Tag installation\n\n" +
                       "• Install BepInEx: Installs the mod framework required for all mods\n\n" +
                       "• Install Menu: Installs the Encryptic menu mod\n\n" +
                       "• Launch Game: Starts Gorilla Tag with your current mods"
            };

            TabPage modsHelp = new TabPage("Mods")
            {
                BackColor = mediumBackground,
                ForeColor = Color.White
            };

            RichTextBox modsText = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = mediumBackground,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Text = "Mods Tab\n\n" +
                       "• Install: Add a new mod from a .dll file\n\n" +
                       "• Uninstall: Remove the selected mod\n\n" +
                       "• Enable/Disable: Toggle mods on or off without removing them\n\n" +
                       "• Refresh: Update the mod list\n\n" +
                       "• Search: Filter mods by name"
            };

            modsHelp.Controls.Add(modsText);

            TabPage settingsHelp = new TabPage("Settings")
            {
                BackColor = mediumBackground,
                ForeColor = Color.White
            };

            RichTextBox settingsText = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = mediumBackground,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Text = "Settings Tab\n\n" +
                       "• Check for updates: Automatically check for manager updates on startup\n\n" +
                       "• Start with Windows: Launch the mod manager when your computer starts\n\n" +
                       "• Dark Theme: Toggle between dark and light interface\n\n" +
                       "• Auto-install updates: Automatically install updates when available\n\n" +
                       "• Save: Apply and save your settings\n\n" +
                       "• Reset: Restore default settings"
            };

            settingsHelp.Controls.Add(settingsText);

            TabPage troubleHelp = new TabPage("Troubleshooting")
            {
                BackColor = mediumBackground,
                ForeColor = Color.White
            };

            RichTextBox troubleText = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = mediumBackground,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Text = "Troubleshooting\n\n" +
                       "• Game not found: Use the Browse button to locate your Gorilla Tag installation\n\n" +
                       "• Mods not working: Make sure BepInEx is installed correctly\n\n" +
                       "• Game crashes: Try disabling mods one by one to find the problematic one\n\n" +
                       "• Update issues: If automatic updates fail, download the latest version manually\n\n"
                       //"• For more help, join our Discord server from the Credits tab"
            };

            troubleHelp.Controls.Add(troubleText);

            helpTabs.TabPages.Add(dashboardHelp);
            helpTabs.TabPages.Add(modsHelp);
            helpTabs.TabPages.Add(settingsHelp);
            helpTabs.TabPages.Add(troubleHelp);

            Button closeHelpButton = new Button
            {
                Text = "Close",
                BackColor = accentColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Bottom,
                Height = 40
            };

            closeHelpButton.FlatAppearance.BorderSize = 0;
            closeHelpButton.Click += (s, args) => helpForm.Close();
            helpForm.Controls.Add(helpTabs);
            helpForm.Controls.Add(closeHelpButton);
            helpForm.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, helpForm.Width, helpForm.Height, 15, 15));
            helpForm.ShowDialog();
        }

        #endregion

        #region Settings

        private void LoadSettings()
        {
            try
            {
                chkAutoUpdate.Checked = Properties.Settings.Default.AutoUpdate;
                chkStartWithWindows.Checked = Properties.Settings.Default.StartWithWindows;
                chkDarkTheme.Checked = Properties.Settings.Default.DarkTheme;
                chkAutoInstallUpdates.Checked = Properties.Settings.Default.AutoInstallUpdates;
                gamePath = Properties.Settings.Default.GamePath;

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (key != null)
                    {
                        chkStartWithWindows.Checked = key.GetValue("EncrypticModManager") != null;
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Error loading settings: {ex.Message}");
            }
        }

        private void SaveSettings()
        {
            try
            {
                Properties.Settings.Default.AutoUpdate = chkAutoUpdate.Checked;
                Properties.Settings.Default.StartWithWindows = chkStartWithWindows.Checked;
                Properties.Settings.Default.DarkTheme = chkDarkTheme.Checked;
                Properties.Settings.Default.AutoInstallUpdates = chkAutoInstallUpdates.Checked;
                Properties.Settings.Default.GamePath = gamePath;
                Properties.Settings.Default.Save();
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (key != null)
                    {
                        if (chkStartWithWindows.Checked)
                        {
                            key.SetValue("EncrypticModManager", Application.ExecutablePath);
                        }
                        else
                        {
                            key.DeleteValue("EncrypticModManager", false);
                        }
                    }
                }

                Log("Settings saved successfully.");
            }
            catch (Exception ex)
            {
                Log($"Error saving settings: {ex.Message}");
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
            btnSaveSettings.Enabled = false;
            btnSaveSettings.Text = "Saved!";
            Task.Delay(1500).ContinueWith(t => {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => {
                        btnSaveSettings.Enabled = true;
                        btnSaveSettings.Text = "Save";
                    }));
                }
            });
        }

        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to reset all settings to default?",
                "Reset Settings",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                LoadSettings();
                ApplyTheme(chkDarkTheme.Checked);
                Log("Settings reset to default.");
            }
        }

        #endregion

        #region Mods Management

        private void btnInstallMod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
            {
                MessageBox.Show("Game path not set. Please select the game folder first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isBepInExInstalled)
            {
                DialogResult result = MessageBox.Show(
                    "BepInEx is required to install mods. Would you like to install it now?",
                    "BepInEx Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    btnInstallBepInEx_Click(sender, e);
                    return;
                }
                else
                {
                    return;
                }
            }

            using (System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.Filter = "DLL Files|*.dll";
                dialog.Title = "Select a mod to install";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileName = Path.GetFileName(dialog.FileName);
                        string targetPath = Path.Combine(gamePath, "BepInEx", "plugins", fileName);
                        File.Copy(dialog.FileName, targetPath, true);
                        Log($"Mod installed: {fileName}");
                        MessageBox.Show($"Mod {fileName} installed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshModList();
                    }
                    catch (Exception ex)
                    {
                        Log($"Error installing mod: {ex.Message}");
                        MessageBox.Show($"Error installing mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUninstallMod_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a mod to uninstall.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string modName = modListView.SelectedItems[0].Text;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to uninstall {modName}?",
                "Confirm Uninstall",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string modPath = Path.Combine(gamePath, "BepInEx", "plugins", modName);
                    if (File.Exists(modPath))
                    {
                        File.Delete(modPath);
                        Log($"Mod uninstalled: {modName}");
                        MessageBox.Show($"Mod {modName} uninstalled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshModList();
                    }
                    else
                    {
                        Log($"Mod file not found: {modPath}");
                        MessageBox.Show("Mod file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error uninstalling mod: {ex.Message}");
                    MessageBox.Show($"Error uninstalling mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEnableMod_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a mod to enable.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string modName = modListView.SelectedItems[0].Text;
            string status = modListView.SelectedItems[0].SubItems[2].Text;

            if (status == "Enabled")
            {
                MessageBox.Show($"{modName} is already enabled.", "Already Enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string disabledPath = Path.Combine(gamePath, "BepInEx", "plugins", modName + ".disabled");
                string enabledPath = Path.Combine(gamePath, "BepInEx", "plugins", modName);

                if (File.Exists(disabledPath))
                {
                    File.Move(disabledPath, enabledPath);
                    Log($"Mod enabled: {modName}");
                    MessageBox.Show($"Mod {modName} enabled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshModList();
                }
                else
                {
                    Log($"Disabled mod file not found: {disabledPath}");
                    MessageBox.Show("Disabled mod file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log($"Error enabling mod: {ex.Message}");
                MessageBox.Show($"Error enabling mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisableMod_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a mod to disable.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string modName = modListView.SelectedItems[0].Text;
            string status = modListView.SelectedItems[0].SubItems[2].Text;

            if (status == "Disabled")
            {
                MessageBox.Show($"{modName} is already disabled.", "Already Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string enabledPath = Path.Combine(gamePath, "BepInEx", "plugins", modName);
                string disabledPath = Path.Combine(gamePath, "BepInEx", "plugins", modName + ".disabled");

                if (File.Exists(enabledPath))
                {
                    File.Move(enabledPath, disabledPath);
                    Log($"Mod disabled: {modName}");
                    MessageBox.Show($"Mod {modName} disabled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshModList();
                }
                else
                {
                    Log($"Enabled mod file not found: {enabledPath}");
                    MessageBox.Show("Enabled mod file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log($"Error disabling mod: {ex.Message}");
                MessageBox.Show($"Error disabling mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshMods_Click(object sender, EventArgs e)
        {
            RefreshModList();
        }

        private void RefreshModList()
        {
            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
            {
                return;
            }

            try
            {
                modListView.Items.Clear();

                string pluginsPath = Path.Combine(gamePath, "BepInEx", "plugins");
                if (!Directory.Exists(pluginsPath))
                {
                    return;
                }
                foreach (string file in Directory.GetFiles(pluginsPath, "*.dll"))
                {
                    string fileName = Path.GetFileName(file);
                    ListViewItem item = new ListViewItem(fileName);
                    try
                    {
                        FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(file);
                        item.SubItems.Add(versionInfo.FileVersion ?? "Unknown");
                    }
                    catch
                    {
                        item.SubItems.Add("Unknown");
                    }

                    item.SubItems.Add("Enabled");
                    modListView.Items.Add(item);
                }

                foreach (string file in Directory.GetFiles(pluginsPath, "*.dll.disabled"))
                {
                    string fileName = Path.GetFileName(file);
                    fileName = fileName.Substring(0, fileName.Length - 9);

                    ListViewItem item = new ListViewItem(fileName);
                    try
                    {
                        FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(file);
                        item.SubItems.Add(versionInfo.FileVersion ?? "Unknown");
                    }
                    catch
                    {
                        item.SubItems.Add("Unknown");
                    }

                    item.SubItems.Add("Disabled");
                    modListView.Items.Add(item);
                }

                Log("Mod list refreshed.");
            }
            catch (Exception ex)
            {
                Log($"Error refreshing mod list: {ex.Message}");
            }
        }

        /*private void txtSearchMods_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchMods.Text == "Search mods..." || string.IsNullOrEmpty(txtSearchMods.Text))
            {
                RefreshModList();
                return;
            }

            string searchText = txtSearchMods.Text.ToLower();

            foreach (ListViewItem item in modListView.Items)
            {
                if (item.Text.ToLower().Contains(searchText))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }*/

        private void modListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            modListView.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        #endregion

        private void btnDiscord_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://discord.gg/IIDK");
            }
            catch (Exception ex)
            {
                Log($"Error opening Discord link: {ex.Message}");
                MessageBox.Show($"Error opening Discord link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
            Log("Log cleared.");
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSidebarSelection();
            switch (tabControl.SelectedIndex)
            {
                case 0: // Dashboard
                    UpdateGameInfo();
                    break;
                case 1: // Mods
                    RefreshModList();
                    break;
                case 2: // Settings
                    // Nothing special needed
                    break;
                case 3: // Credits
                    // Nothing special needed
                    break;
            }
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void modsButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void creditsButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }
    }
    public class ModernStatusStripRenderer : ToolStripProfessionalRenderer
    {
        public ModernStatusStripRenderer() : base(new ModernColorTable())
        {
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Don't draw the border
        }
    }

    public class ModernColorTable : ProfessionalColorTable
    {
        public override Color StatusStripGradientBegin => Color.FromArgb(37, 37, 38);
        public override Color StatusStripGradientEnd => Color.FromArgb(37, 37, 38);
    }


    public class ListViewItemComparer : System.Collections.IComparer
    {
        private int column;

        public ListViewItemComparer(int column)
        {
            this.column = column;
        }

        public int Compare(object x, object y)
        {
            return string.Compare(
                ((ListViewItem)x).SubItems[column].Text,
                ((ListViewItem)y).SubItems[column].Text);
        }
    }
}
