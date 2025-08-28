using FontAwesome.Sharp;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager
{
    public partial class MainForm : Form
    {
        #region P/Invoke and Constants
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private const string CURRENT_MANAGER_VERSION = "1.0.0";
        private const string MANAGER_VERSION_URL = "https://raw.githubusercontent.com/Longno12/Encryptic/main/version.txt";
        private const string MANAGER_DOWNLOAD_URL = "https://github.com/Longno12/Encryptic/releases/latest/download/EncrypticModManager.exe";
        private const string BEPINEX_LATEST_URL = "https://api.github.com/repos/BepInEx/BepInEx/releases/latest";
        private const string BEPINEX_DOWNLOAD_URL = "https://github.com/BepInEx/BepInEx/releases/latest/download/BepInEx_win_x64_5.4.23.3.zip";
        private const string BEPINEX_CONFIG_URL = "https://raw.githubusercontent.com/iiDk-the-actual/ModInfo/refs/heads/main/BepInEx.cfg";
        #endregion

        #region Fields
        private string gamePath;
        private bool isBepInExInstalled = false;
        private readonly List<ListViewItem> allModItems = new List<ListViewItem>();
        private readonly Color colorBackgroundPrimary = Color.FromArgb(30, 30, 30);
        private readonly Color colorBackgroundSecondary = Color.FromArgb(45, 45, 48);
        private readonly Color colorSurface = Color.FromArgb(60, 60, 60);
        private readonly Color colorAccent = Color.FromArgb(0, 122, 204);
        private readonly Color colorTextPrimary = Color.FromArgb(241, 241, 241);
        private readonly Color colorTextSecondary = Color.FromArgb(160, 160, 160);

        private readonly string[] possiblePaths =
        {
            @"C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag",
            @"D:\SteamLibrary\steamapps\common\Gorilla Tag",
            @"C:\Program Files\Oculus\Software\Software\another-axiom-gorilla-tag"
        };
        #endregion

        public MainForm()
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

            this.headerPanel.MouseDown += HeaderPanel_MouseDown;
            this.logoLabel.MouseDown += HeaderPanel_MouseDown;
            this.closeButton.Click += (s, e) => Application.Exit();
            this.minimizeButton.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            LoadSettings();
            ApplyTheme(Properties.Settings.Default.DarkTheme);
            SetPlaceholderText(txtSearchMods, "Search mods...");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            ApplyModernStyling();
            DetectGamePath();
            if (toggleAutoUpdate.Checked)
            {
                CheckForUpdatesAsync();
            }
            SetupTooltips();
            UpdateSidebarSelection();
        }

        #region Modern UI & Styling
        private void ApplyModernStyling()
        {
            int radius = 12;
            ApplyRoundedCorners(btnLaunchGame, radius);
            ApplyRoundedCorners(btnInstallBepInEx, radius);
            ApplyRoundedCorners(btnInstallMenu, radius);
            ApplyRoundedCorners(btnBrowseGame, radius);
            ApplyRoundedCorners(btnSaveSettings, radius);
            ApplyRoundedCorners(btnResetSettings, radius);
            ApplyRoundedCorners(btnHelp, radius);
            ApplyRoundedCorners(btnDiscord, radius);
            ApplyRoundedCorners(btnInstallMod, radius);
            ApplyRoundedCorners(btnUninstallMod, radius);
            ApplyRoundedCorners(btnEnableMod, radius);
            ApplyRoundedCorners(btnDisableMod, radius);
            ApplyRoundedCorners(btnRefreshMods, radius);
            ApplyRoundedCorners(btnClearLog, radius);
            ApplyRoundedCorners(searchPanel, 8);
            ApplyCardPaintStyle(gameInfoCard);
            ApplyCardPaintStyle(actionsCard);
            ApplyCardPaintStyle(settingsCard);
            ApplyCardPaintStyle(creditsCard);
            SetupModernIcons();
            ModernizeListView();

            searchIcon.Image = IconChar.Search.ToBitmap(16, 16, colorTextSecondary);
            statusStrip.Renderer = new ModernStatusStripRenderer(colorBackgroundSecondary);
        }

        private void SetupModernIcons()
        {
            Action<Button, IconChar> setIcon = (button, icon) =>
            {
                button.Image = icon.ToBitmap(16, 16, colorTextPrimary);
                button.ImageAlign = ContentAlignment.MiddleLeft;
                button.TextAlign = ContentAlignment.MiddleRight;
                button.TextImageRelation = TextImageRelation.ImageBeforeText;
                button.Padding = new Padding(8, 0, 8, 0);
            };

            setIcon(btnInstallBepInEx, IconChar.Download);
            setIcon(btnInstallMenu, IconChar.PuzzlePiece);
            setIcon(btnLaunchGame, IconChar.Play);
            setIcon(btnBrowseGame, IconChar.FolderOpen);
            setIcon(btnInstallMod, IconChar.Plus);
            setIcon(btnUninstallMod, IconChar.Trash);
            setIcon(btnEnableMod, IconChar.Check);
            setIcon(btnDisableMod, IconChar.Ban);
            setIcon(btnRefreshMods, IconChar.Sync);
            setIcon(btnSaveSettings, IconChar.Save);
            setIcon(btnResetSettings, IconChar.Undo);
            setIcon(btnHelp, IconChar.QuestionCircle);
            setIcon(btnDiscord, IconChar.Discord);
            setIcon(btnClearLog, IconChar.Eraser);

            dashboardButton.Image = IconChar.Home.ToBitmap(22, 22, colorTextPrimary);
            modsButton.Image = IconChar.PuzzlePiece.ToBitmap(22, 22, colorTextPrimary);
            settingsButton.Image = IconChar.Cog.ToBitmap(22, 22, colorTextPrimary);
            creditsButton.Image = IconChar.InfoCircle.ToBitmap(22, 22, colorTextPrimary);
        }


        private void ApplyRoundedCorners(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
            control.Resize += (s, e) =>
            {
                if (control.IsHandleCreated)
                    control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
            };
        }

        private void ApplyCardPaintStyle(Panel card)
        {
            card.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(colorAccent, 2))
                {
                    e.Graphics.DrawLine(borderPen, 0, 0, card.Width, 0);
                }
            };
        }

        private void ModernizeListView()
        {
            modListView.OwnerDraw = true;

            modListView.DrawColumnHeader += (s, e) =>
            {
                using (SolidBrush headerBrush = new SolidBrush(colorBackgroundSecondary))
                {
                    e.Graphics.FillRectangle(headerBrush, e.Bounds);
                }
                TextRenderer.DrawText(e.Graphics, modListView.Columns[e.ColumnIndex].Text,
                    new Font(modListView.Font, FontStyle.Bold), e.Bounds, colorTextPrimary,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.GlyphOverhangPadding);
            };

            modListView.DrawItem += (s, e) =>
            {
                if (e.State.HasFlag(ListViewItemStates.Selected))
                {
                    using (SolidBrush selectionBrush = new SolidBrush(Color.FromArgb(80, colorAccent.R, colorAccent.G, colorAccent.B)))
                    {
                        e.Graphics.FillRectangle(selectionBrush, e.Bounds);
                    }
                }
                else
                {
                    e.DrawBackground();
                }

                // --- FIX APPLIED HERE ---
                // If the item has focus, draw the focus rectangle around the entire row.
                // This is done in DrawItem because it applies to the whole item, not a sub-item.
                if (e.State.HasFlag(ListViewItemStates.Focused))
                {
                    e.DrawFocusRectangle();
                }
            };

            modListView.DrawSubItem += (s, e) =>
            {
                // Let DrawItem handle the background coloring for the entire row.
                // We call DrawBackground here to ensure transparency is handled correctly for sub-items.
                e.DrawBackground();
                if (e.ColumnIndex == 2)
                {
                    string status = e.SubItem.Text;
                    Color statusColor = (status == "Enabled") ? Color.MediumSeaGreen : Color.IndianRed;
                    using (SolidBrush statusBrush = new SolidBrush(statusColor))
                    {
                        e.Graphics.FillEllipse(statusBrush, e.Bounds.Left + 8, e.Bounds.Top + (e.Bounds.Height / 2) - 5, 10, 10);
                    }
                    TextRenderer.DrawText(e.Graphics, status, modListView.Font,
                        new Rectangle(e.Bounds.Left + 24, e.Bounds.Top, e.Bounds.Width - 24, e.Bounds.Height),
                        colorTextPrimary, TextFormatFlags.VerticalCenter);
                }
                else
                {
                    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, modListView.Font, e.Bounds, colorTextPrimary, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.GlyphOverhangPadding);
                }

                // --- FIX APPLIED HERE ---
                // The incorrect logic that caused the errors has been completely removed from this event handler.
            };
        }

        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
        }
        #endregion

        #region Core Logic (Logging, Updates, Installation)

        private void Log(string message)
        {
            if (InvokeRequired) { Invoke(new Action<string>(Log), message); return; }
            logTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            logTextBox.ScrollToCaret();
        }

        private void UpdateStatus(string message)
        {
            if (InvokeRequired) { Invoke(new Action<string>(UpdateStatus), message); return; }
            statusLabel.Text = message;
        }

        private void DetectGamePath()
        {
            Log("Detecting game installation...");
            gamePath = Properties.Settings.Default.GamePath;

            if (!string.IsNullOrEmpty(gamePath) && Directory.Exists(gamePath))
            {
                Log($"Game found from settings: {gamePath}");
                UpdateGameInfo();
                return;
            }

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
            Log("Game not found. Please select manually.");
        }

        private void UpdateGameInfo()
        {
            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
            {
                lblGameStatus.Text = "Not Found";
                lblGameStatus.ForeColor = Color.IndianRed;
                lblGamePath.Text = "Please select your game path...";
                return;
            }

            lblGamePath.Text = gamePath;
            isBepInExInstalled = Directory.Exists(Path.Combine(gamePath, "BepInEx"));

            if (isBepInExInstalled)
            {
                lblGameStatus.Text = "Modded";
                lblGameStatus.ForeColor = Color.MediumSeaGreen;
                btnInstallBepInEx.Text = "Reinstall BepInEx";
            }
            else
            {
                lblGameStatus.Text = "Vanilla";
                lblGameStatus.ForeColor = Color.Gold;
                btnInstallBepInEx.Text = "Install BepInEx";
            }
        }

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
                        if (toggleAutoInstallUpdates.Checked)
                        {
                            // Will be added back next Update      Note By 2025Joe
                            // This method was not provided for correction but would be called here.
                            // await DownloadAndInstallUpdateAsync(latestVersion);
                            Log("Auto-update is enabled. (Update download logic is a placeholder).");
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show(
                                $"A new version of the Mod Manager is available: v{latestVersion}\n\nWould you like to update now?",
                                "Update Available",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);

                            if (result == DialogResult.Yes)
                            {// Same With The Note Above
                                // await DownloadAndInstallUpdateAsync(latestVersion);
                                Log("User chose to update. (Update download logic is a placeholder).");
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
        private async Task AnimateProgressBar(ToolStripProgressBar bar, int targetValue)
        {
            int startValue = bar.Value;
            int steps = 15;
            int delay = 15;

            for (int i = 1; i <= steps; i++)
            {
                int value = startValue + ((targetValue - startValue) * i / steps);
                bar.Value = Math.Min(Math.Max(bar.Minimum, value), bar.Maximum);
                await Task.Delay(delay);
            }
            bar.Value = Math.Min(Math.Max(bar.Minimum, targetValue), bar.Maximum);
        }
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
                ShowProgress(true, 0);
                Log("Starting BepInEx installation...");

                string zipPath = Path.Combine(Path.GetTempPath(), "BepInEx.zip");

                Log("Downloading BepInEx...");
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += async (s, args) =>
                    {
                        await AnimateProgressBar(progressBar, args.ProgressPercentage);
                    };

                    await client.DownloadFileTaskAsync(new Uri(BEPINEX_DOWNLOAD_URL), zipPath);
                }

                await AnimateProgressBar(progressBar, 100);
                Log("Extracting BepInEx...");

                // --- FIX IS HERE ---
                // Manually extract files to support older .NET Frameworks and ensure overwrite.
                // We run this in a background thread to keep the UI responsive.
                await Task.Run(() =>
                {
                    using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            string destinationPath = Path.Combine(gamePath, entry.FullName);
                            if (entry.FullName.EndsWith("/") || entry.FullName.EndsWith("\\"))
                            {
                                Directory.CreateDirectory(destinationPath);
                                continue;
                            }
                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                            entry.ExtractToFile(destinationPath, true);
                        }
                    }
                });

                await AnimateProgressBar(progressBar, 100);
                Log("Downloading BepInEx configuration...");
                string cfgPath = Path.Combine(gamePath, "BepInEx", "config", "BepInEx.cfg");
                Directory.CreateDirectory(Path.GetDirectoryName(cfgPath));

                using (var client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(new Uri(BEPINEX_CONFIG_URL), cfgPath);
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
        private void btnInstallMod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gamePath) || !isBepInExInstalled)
            {
                MessageBox.Show("Please ensure BepInEx is installed and the game path is set correctly.", "Cannot Install Mod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.Filter = "Mod files (*.dll)|*.dll";
                dialog.Title = "Select Mod to Install";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string targetPath = Path.Combine(gamePath, "BepInEx", "plugins", Path.GetFileName(dialog.FileName));
                        File.Copy(dialog.FileName, targetPath, true);
                        Log($"Mod installed: {Path.GetFileName(dialog.FileName)}");
                        RefreshModList();
                    }
                    catch (Exception ex)
                    {
                        Log($"Failed to install mod: {ex.Message}");
                        MessageBox.Show($"Error installing mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnEnableMod_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a mod to enable.", "No Mod Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListViewItem selectedItem = modListView.SelectedItems[0];
            if (selectedItem.SubItems[2].Text == "Enabled") return;

            string modName = selectedItem.Text;
            try
            {
                string disabledPath = Path.Combine(gamePath, "BepInEx", "plugins", modName + ".dll.disabled");
                string enabledPath = Path.Combine(gamePath, "BepInEx", "plugins", modName + ".dll");
                File.Move(disabledPath, enabledPath);
                Log($"Mod enabled: {modName}");
                RefreshModList();
            }
            catch (Exception ex)
            {
                Log($"Failed to enable mod: {ex.Message}");
                MessageBox.Show($"Error enabling mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisableMod_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a mod to disable.", "No Mod Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListViewItem selectedItem = modListView.SelectedItems[0];
            if (selectedItem.SubItems[2].Text == "Disabled") return;
            string modName = selectedItem.Text;
            try
            {
                string enabledPath = Path.Combine(gamePath, "BepInEx", "plugins", modName + ".dll");
                string disabledPath = Path.Combine(gamePath, "BepInEx", "plugins", modName + ".dll.disabled");
                File.Move(enabledPath, disabledPath);
                Log($"Mod disabled: {modName}");
                RefreshModList();
            }
            catch (Exception ex)
            {
                Log($"Failed to disable mod: {ex.Message}");
                MessageBox.Show($"Error disabling mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUninstallMod_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a mod to uninstall.", "No Mod Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListViewItem selectedItem = modListView.SelectedItems[0];
            string modName = selectedItem.Text;
            string modStatus = selectedItem.SubItems[2].Text;
            string extension = (modStatus == "Disabled") ? ".dll.disabled" : ".dll";

            if (MessageBox.Show($"Are you sure you want to permanently delete {modName}?", "Confirm Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string modPath = Path.Combine(gamePath, "BepInEx", "plugins", modName + extension);
                    File.Delete(modPath);
                    Log($"Mod uninstalled: {modName}");
                    RefreshModList();
                }
                catch (Exception ex)
                {
                    Log($"Failed to uninstall mod: {ex.Message}");
                    MessageBox.Show($"Error uninstalling mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnRefreshMods_Click(object sender, EventArgs e)
        {
            Log("Manually refreshing mod list...");
            RefreshModList();
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
                if (MessageBox.Show("BepInEx is required to install mods. Would you like to install it now?", "BepInEx Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnInstallBepInEx_Click(sender, e);
                }
                return;
            }

            try
            {
                UpdateStatus("Installing menu...");
                ShowProgress(true, 0);

                string pluginsPath = Path.Combine(gamePath, "BepInEx", "plugins");
                Directory.CreateDirectory(pluginsPath);

                string targetPath = Path.Combine(pluginsPath, menuName);

                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += async (s, args) => {
                        await AnimateProgressBar(progressBar, args.ProgressPercentage);
                    };
                    Log($"Downloading {menuName}...");
                    await client.DownloadFileTaskAsync(new Uri(menuDownloadUrl), targetPath);
                }

                await AnimateProgressBar(progressBar, 100);
                UpdateStatus("Menu installed successfully.");
                Log($"{menuName} installed successfully.");
                MessageBox.Show($"{menuName} has been installed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UpdateStatus("Installation failed.");
                Log($"Error installing menu: {ex.Message}");
                MessageBox.Show($"Failed to install the menu.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ShowProgress(false);
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

                    Task.Delay(3000).ContinueWith(t =>
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                btnLaunchGame.Enabled = true;
                                btnLaunchGame.Text = "Launch Game";
                                UpdateStatus("Ready.");
                            }));
                        }
                        else
                        {
                            btnLaunchGame.Enabled = true;
                            btnLaunchGame.Text = "Launch Game";
                            UpdateStatus("Ready.");
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
                btnLaunchGame.Enabled = true;
                btnLaunchGame.Text = "Launch Game";
            }
        }
        private void btnBrowseGame_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog { Description = "Select Gorilla Tag installation folder" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    gamePath = dialog.SelectedPath;
                    UpdateGameInfo();
                    SaveSettings();
                }
            }
        }
        #endregion

        #region Settings
        private void LoadSettings()
        {
            Properties.Settings.Default.Reload();
            toggleAutoUpdate.Checked = Properties.Settings.Default.AutoUpdate;
            toggleStartWithWindows.Checked = Properties.Settings.Default.StartWithWindows;
            toggleDarkTheme.Checked = Properties.Settings.Default.DarkTheme;
            toggleAutoInstallUpdates.Checked = Properties.Settings.Default.AutoInstallUpdates;
            gamePath = Properties.Settings.Default.GamePath;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.AutoUpdate = toggleAutoUpdate.Checked;
            Properties.Settings.Default.StartWithWindows = toggleStartWithWindows.Checked;
            Properties.Settings.Default.DarkTheme = toggleDarkTheme.Checked;
            Properties.Settings.Default.AutoInstallUpdates = toggleAutoInstallUpdates.Checked;
            Properties.Settings.Default.GamePath = gamePath;
            Properties.Settings.Default.Save();
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (toggleStartWithWindows.Checked)
                    rk.SetValue("EncrypticModManager", Application.ExecutablePath);
                else
                    rk.DeleteValue("EncrypticModManager", false);
            }
            catch (Exception ex)
            {
                Log($"Could not set startup preference: {ex.Message}");
            }

            Log("Settings saved.");
        }

        private void btnSaveSettings_Click(object sender, EventArgs e) { SaveSettings(); }
        private void btnResetSettings_Click(object sender, EventArgs e) { Properties.Settings.Default.Reset(); LoadSettings(); }
        private void toggleDarkTheme_CheckedChanged(object sender, EventArgs e) => ApplyTheme(toggleDarkTheme.Checked);

        private void ApplyTheme(bool isDark)
        {
            // In this version, we assume dark theme is always on. 
            // A full light theme would require changing all color fields and re-applying them.
            this.BackColor = colorBackgroundPrimary;
            this.ForeColor = colorTextPrimary;
        }
        #endregion

        #region Mods Management
        private void RefreshModList()
        {
            if (string.IsNullOrEmpty(gamePath) || !isBepInExInstalled) return;
            try
            {
                modListView.Items.Clear();
                allModItems.Clear();

                string pluginsPath = Path.Combine(gamePath, "BepInEx", "plugins");
                if (!Directory.Exists(pluginsPath)) { Directory.CreateDirectory(pluginsPath); return; }

                allModItems.AddRange(Directory.GetFiles(pluginsPath, "*.dll").Select(f => CreateListViewItem(f, "Enabled")));
                allModItems.AddRange(Directory.GetFiles(pluginsPath, "*.dll.disabled").Select(f => CreateListViewItem(f, "Disabled", ".disabled")));

                modListView.Items.AddRange(allModItems.OrderBy(i => i.Text).ToArray());
                Log("Mod list refreshed.");
            }
            catch (Exception ex) { Log($"Error refreshing mods: {ex.Message}"); }
        }

        private ListViewItem CreateListViewItem(string filePath, string status, string extToRemove = "")
        {
            string fileName = Path.GetFileName(filePath).Replace(extToRemove, "");
            var item = new ListViewItem(fileName);
            try
            {
                item.SubItems.Add(FileVersionInfo.GetVersionInfo(filePath).FileVersion ?? "N/A");
            }
            catch { item.SubItems.Add("N/A"); }
            item.SubItems.Add(status);
            return item;
        }

        private void txtSearchMods_TextChanged(object sender, EventArgs e)
        {
            modListView.BeginUpdate();
            modListView.Items.Clear();
            string searchText = (txtSearchMods.Text == "Search mods...") ? "" : txtSearchMods.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                modListView.Items.AddRange(allModItems.ToArray());
            }
            else
            {
                modListView.Items.AddRange(allModItems.Where(i => i.Text.ToLower().Contains(searchText)).ToArray());
            }
            modListView.EndUpdate();
        }
        #endregion

        #region Navigation and Other Event Handlers
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSidebarSelection();
            if (tabControl.SelectedIndex == 1) RefreshModList();
        }

        private void UpdateSidebarSelection()
        {
            foreach (var button in sidebarPanel.Controls.OfType<Button>())
            {
                button.BackColor = colorBackgroundSecondary;
                button.Invalidate();
            }
            if (tabControl.SelectedIndex >= 0)
            {
                var selectedButton = sidebarPanel.Controls.OfType<Button>().FirstOrDefault(b => (int)b.Tag == tabControl.SelectedIndex);
                if (selectedButton != null)
                {
                    selectedButton.BackColor = colorSurface;
                }
            }
        }

        private void SidebarButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                tabControl.SelectedIndex = (int)button.Tag;
            }
        }

        private void SidebarButton_Paint(object sender, PaintEventArgs e)
        {
            var button = sender as Button;
            if (button != null && tabControl.SelectedIndex == (int)button.Tag)
            {
                using (var accentBrush = new SolidBrush(colorAccent))
                {
                    e.Graphics.FillRectangle(accentBrush, 0, 0, 4, button.Height);
                }
            }
        }

        private void SetPlaceholderText(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = colorTextSecondary;
            textBox.GotFocus += (s, e) => { if (textBox.Text == placeholder) { textBox.Text = ""; textBox.ForeColor = colorTextPrimary; } };
            textBox.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(textBox.Text)) { textBox.Text = placeholder; textBox.ForeColor = colorTextSecondary; } };
        }

        private void btnDiscord_Click(object sender, EventArgs e) => Process.Start("https://discord.gg/IIDK");
        private void btnClearLog_Click(object sender, EventArgs e) => logTextBox.Clear();
        private void SetupTooltips() { }
        #endregion
    }

    #region Custom Renderers
    public class ModernStatusStripRenderer : ToolStripProfessionalRenderer
    {
        private readonly Color backColor;
        public ModernStatusStripRenderer(Color backColor) : base(new ModernColorTable(backColor)) { this.backColor = backColor; }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }
    }
    public class ModernColorTable : ProfessionalColorTable
    {
        private readonly Color backColor;
        public ModernColorTable(Color backColor) { this.backColor = backColor; }
        public override Color StatusStripGradientBegin => backColor;
        public override Color StatusStripGradientEnd => backColor;
    }
    #endregion
}