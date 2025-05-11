using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ModManager
{
    public partial class MainForm : Form
    {
        private const string CURRENT_MANAGER_VERSION = "1.0.0";
        private const string MANAGER_VERSION_URL = "https://raw.githubusercontent.com/Longno12/Encryptic/main/version.txt";
        private const string MANAGER_DOWNLOAD_URL = "https://github.com/Longno12/Encryptic/releases/latest/download/EncrypticModManager.exe";
        private const string BEPINEX_LATEST_URL = "https://api.github.com/repos/BepInEx/BepInEx/releases/latest";
        private const string BEPINEX_DOWNLOAD_URL = "https://github.com/BepInEx/BepInEx/releases/latest/download/BepInEx_win_x64_5.4.23.3.zip";
        private const string BEPINEX_CONFIG_URL = "https://raw.githubusercontent.com/iiDk-the-actual/ModInfo/refs/heads/main/BepInEx.cfg";

        private string gamePath;
        private bool isBepInExInstalled = false;
        private string gameVersion = "Unknown";
        private TabPage currentTab;
        private Updater updater;

        private readonly string[] possiblePaths =
        {
            @"C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag",
            @"D:\SteamLibrary\steamapps\common\Gorilla Tag",
            @"C:\Program Files\Oculus\Software\Software\another-axiom-gorilla-tag"
        };

        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
            versionLabel.Text = $"v{CURRENT_MANAGER_VERSION}";
            updater = new Updater(this, Log, UpdateStatus, ShowProgress);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DetectGamePath();

            if (chkAutoUpdate.Checked)
            {
                CheckForUpdatesAsync();
            }
        }

        #region Logging

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

            // Check if BepInEx is installed
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

            // Try to detect game version
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
                // Check for mod manager updates
                await updater.CheckForUpdatesAsync(CURRENT_MANAGER_VERSION, chkAutoUpdate.Checked);

                // Check for BepInEx updates
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ModManager");
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

        private async Task DownloadAndInstallUpdateAsync(string newVersion)
        {
            try
            {
                UpdateStatus("Downloading update...");
                ShowProgress(true, 0);
                Log($"Downloading update v{newVersion}...");

                // Create temp directory for the update
                string tempDir = Path.Combine(Path.GetTempPath(), "EncrypticModManagerUpdate");
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
                Directory.CreateDirectory(tempDir);

                // Download the update
                string zipPath = Path.Combine(tempDir, "update.zip");
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += (s, args) =>
                    {
                        ShowProgress(true, args.ProgressPercentage);
                    };

                    await client.DownloadFileTaskAsync(MANAGER_DOWNLOAD_URL, zipPath);
                }

                ShowProgress(true, 100);
                Log("Download complete. Preparing to install update...");

                // Extract the update to the temp directory
                ZipFile.ExtractToDirectory(zipPath, tempDir);

                // Create the updater script
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
                    // Start the updater and exit the application
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

        private void btnCheckForUpdates_Click(object sender, EventArgs e)
        {
            CheckForUpdatesAsync();
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

                // Download BepInEx
                Log("Downloading BepInEx...");
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += (s, args) =>
                    {
                        ShowProgress(true, args.ProgressPercentage);
                    };

                    await client.DownloadFileTaskAsync(BEPINEX_DOWNLOAD_URL, zipPath);
                }

                ShowProgress(true, 50);
                Log("Extracting BepInEx...");

                // Extract BepInEx
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

                ShowProgress(true, 80);
                Log("Creating directories...");

                // Create necessary directories
                Directory.CreateDirectory(Path.Combine(gamePath, "BepInEx", "config"));
                Directory.CreateDirectory(Path.Combine(gamePath, "BepInEx", "plugins"));

                // Download config
                Log("Downloading BepInEx configuration...");
                string cfgPath = Path.Combine(gamePath, "BepInEx", "config", "BepInEx.cfg");

                using (var client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(BEPINEX_CONFIG_URL, cfgPath);
                }

                // Clean up
                File.Delete(zipPath);

                ShowProgress(true, 100);
                Log("BepInEx installed successfully.");
                UpdateStatus("Installation complete.");

                MessageBox.Show("BepInEx has been installed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update UI
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

        private void btnInstallMenu_Click(object sender, EventArgs e)
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

            // Menu installation logic (placeholder for now)
            Log("Menu installation not yet implemented.");
            MessageBox.Show("This feature is coming soon.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Mods Management

        private void RefreshModsList()
        {
            modListView.Items.Clear();

            if (string.IsNullOrEmpty(gamePath) || !isBepInExInstalled)
            {
                return;
            }

            try
            {
                string pluginsPath = Path.Combine(gamePath, "BepInEx", "plugins");
                if (!Directory.Exists(pluginsPath))
                {
                    return;
                }

                foreach (var file in Directory.GetFiles(pluginsPath, "*.dll", SearchOption.AllDirectories))
                {
                    string fileName = Path.GetFileName(file);
                    string modName = Path.GetFileNameWithoutExtension(file);
                    string version = "Unknown";
                    string status = "Enabled";

                    if (file.Contains(".disabled"))
                    {
                        status = "Disabled";
                    }

                    ListViewItem item = new ListViewItem(modName);
                    item.SubItems.Add(version);
                    item.SubItems.Add(status);
                    item.Tag = file;
                    modListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Log($"Error refreshing mods list: {ex.Message}");
            }
        }

        private void btnInstallMod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gamePath) || !isBepInExInstalled)
            {
                MessageBox.Show("BepInEx must be installed first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Mod Files (*.dll)|*.dll|All Files (*.*)|*.*";
                dialog.Title = "Select Mod File";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string pluginsPath = Path.Combine(gamePath, "BepInEx", "plugins");
                        string destFile = Path.Combine(pluginsPath, Path.GetFileName(dialog.FileName));

                        File.Copy(dialog.FileName, destFile, true);
                        Log($"Mod installed: {Path.GetFileName(dialog.FileName)}");

                        RefreshModsList();
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

            try
            {
                string modPath = modListView.SelectedItems[0].Tag.ToString();
                string modName = modListView.SelectedItems[0].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to uninstall {modName}?",
                    "Confirm Uninstall",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    File.Delete(modPath);
                    Log($"Mod uninstalled: {modName}");
                    RefreshModsList();
                }
            }
            catch (Exception ex)
            {
                Log($"Error uninstalling mod: {ex.Message}");
                MessageBox.Show($"Error uninstalling mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnableMod_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a mod to enable.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string modPath = modListView.SelectedItems[0].Tag.ToString();
                string status = modListView.SelectedItems[0].SubItems[2].Text;

                if (status == "Enabled")
                {
                    MessageBox.Show("This mod is already enabled.", "Already Enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string newPath = modPath.Replace(".disabled", "");
                File.Move(modPath, newPath);
                Log($"Mod enabled: {modListView.SelectedItems[0].Text}");
                RefreshModsList();
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

            try
            {
                string modPath = modListView.SelectedItems[0].Tag.ToString();
                string status = modListView.SelectedItems[0].SubItems[2].Text;

                if (status == "Disabled")
                {
                    MessageBox.Show("This mod is already disabled.", "Already Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string newPath = modPath + ".disabled";
                File.Move(modPath, newPath);
                Log($"Mod disabled: {modListView.SelectedItems[0].Text}");
                RefreshModsList();
            }
            catch (Exception ex)
            {
                Log($"Error disabling mod: {ex.Message}");
                MessageBox.Show($"Error disabling mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshMods_Click(object sender, EventArgs e)
        {
            RefreshModsList();
        }

        #endregion

        #region Settings

        private void LoadSettings()
        {
            try
            {
                // Load game path
                if (Properties.Settings.Default.GamePath != null &&
                    !string.IsNullOrEmpty(Properties.Settings.Default.GamePath) &&
                    Directory.Exists(Properties.Settings.Default.GamePath))
                {
                    gamePath = Properties.Settings.Default.GamePath;
                }

                // Load other settings
                chkAutoUpdate.Checked = Properties.Settings.Default.AutoUpdate;
                chkStartWithWindows.Checked = Properties.Settings.Default.StartWithWindows;
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
                Properties.Settings.Default.GamePath = gamePath;
                Properties.Settings.Default.AutoUpdate = chkAutoUpdate.Checked;
                Properties.Settings.Default.StartWithWindows = chkStartWithWindows.Checked;
                Properties.Settings.Default.Save();

                // Handle startup with Windows
                SetStartupWithWindows(chkStartWithWindows.Checked);
            }
            catch (Exception ex)
            {
                Log($"Error saving settings: {ex.Message}");
            }
        }

        private void SetStartupWithWindows(bool enable)
        {
            try
            {
                string appName = "EncrypticModManager";
                string appPath = Application.ExecutablePath;

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (enable)
                    {
                        key.SetValue(appName, appPath);
                    }
                    else
                    {
                        if (key.GetValue(appName) != null)
                        {
                            key.DeleteValue(appName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Error setting startup: {ex.Message}");
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Log("Settings saved.");
            MessageBox.Show("Settings saved successfully.", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to reset all settings to default?",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                LoadSettings();
                Log("Settings reset to default.");
                MessageBox.Show("Settings have been reset to default.", "Settings Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == modsTab)
            {
                RefreshModsList();
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
        }

        // Add the Discord button click handler after the btnClearLog_Click method
        private void btnDiscord_Click(object sender, EventArgs e)
        {
            try
            {
                // Open IIDK's Discord server invite in the default browser
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://discord.gg/iidk",
                    UseShellExecute = true
                });
                Log("Opening Discord invite...");
            }
            catch (Exception ex)
            {
                Log($"Error opening Discord invite: {ex.Message}");
                MessageBox.Show($"Error opening Discord invite: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
