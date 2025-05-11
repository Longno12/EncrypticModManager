using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager
{
    public class Updater
    {
        private const string MANAGER_VERSION_URL = "https://raw.githubusercontent.com/Longno12/Encryptic/main/version.txt";
        private const string MANAGER_DOWNLOAD_URL = "https://github.com/Longno12/Encryptic/releases/latest/download/EncrypticModManager.exe";

        private readonly Form parentForm;
        private readonly Action<string> logCallback;
        private readonly Action<string> statusCallback;
        private readonly Action<bool, int> progressCallback;

        public Updater(Form parentForm, Action<string> logCallback, Action<string> statusCallback, Action<bool, int> progressCallback)
        {
            this.parentForm = parentForm;
            this.logCallback = logCallback;
            this.statusCallback = statusCallback;
            this.progressCallback = progressCallback;
        }

        public async Task<bool> CheckForUpdatesAsync(string currentVersion, bool autoInstall = false)
        {
            try
            {
                logCallback("Checking for updates...");
                statusCallback("Checking for updates...");

                // Check for mod manager updates
                using (var client = new WebClient())
                {
                    string latestVersion = await client.DownloadStringTaskAsync(MANAGER_VERSION_URL);
                    latestVersion = latestVersion.Trim();

                    if (latestVersion != currentVersion)
                    {
                        logCallback($"Update available: {latestVersion}");

                        if (autoInstall)
                        {
                            await DownloadAndInstallUpdateAsync(latestVersion);
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show(
                                $"A new version of Encryptic Mod Manager is available: {latestVersion}\nWould you like to download and install it now?",
                                "Update Available",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);

                            if (result == DialogResult.Yes)
                            {
                                await DownloadAndInstallUpdateAsync(latestVersion);
                                return true;
                            }
                        }
                    }
                    else
                    {
                        logCallback("Mod Manager is up to date.");
                    }
                }

                statusCallback("Ready.");
                return false;
            }
            catch (Exception ex)
            {
                logCallback($"Update check failed: {ex.Message}");
                statusCallback("Update check failed.");
                return false;
            }
        }

        private async Task DownloadAndInstallUpdateAsync(string newVersion)
        {
            try
            {
                logCallback($"Downloading update v{newVersion}...");
                statusCallback("Downloading update...");
                progressCallback(true, 0);

                string tempPath = Path.Combine(Path.GetTempPath(), "EncrypticModManager_new.exe");
                string currentExePath = Application.ExecutablePath;

                // Delete any existing temp file
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }

                // Download the new version
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += (s, e) =>
                    {
                        progressCallback(true, e.ProgressPercentage);
                    };

                    await client.DownloadFileTaskAsync(MANAGER_DOWNLOAD_URL, tempPath);
                }

                progressCallback(true, 100);
                logCallback("Download complete. Installing update...");
                statusCallback("Installing update...");

                // Create a batch file to replace the executable after the application exits
                string batchPath = Path.Combine(Path.GetTempPath(), "update_encryptic.bat");

                // The batch file will:
                // 1. Wait for the current process to exit
                // 2. Copy the new executable over the old one
                // 3. Start the new executable
                // 4. Delete itself

                string batchContent = $@"
@echo off
echo Updating Encryptic Mod Manager to v{newVersion}...
timeout /t 2 /nobreak > nul

:check
tasklist /fi ""PID eq {Process.GetCurrentProcess().Id}"" | find ""{Process.GetCurrentProcess().Id}"" > nul
if not errorlevel 1 (
    timeout /t 1 /nobreak > nul
    goto check
)

echo Replacing files...
copy /y ""{tempPath}"" ""{currentExePath}""
if errorlevel 1 (
    echo Failed to update. Please try again.
    pause
    exit /b 1
)

echo Starting new version...
start """" ""{currentExePath}""

echo Cleaning up...
del ""{tempPath}""
del ""%~f0""
";

                File.WriteAllText(batchPath, batchContent);

                // Start the batch file
                Process.Start(new ProcessStartInfo
                {
                    FileName = batchPath,
                    WindowStyle = ProcessWindowStyle.Hidden
                });

                // Show a message to the user
                MessageBox.Show(
                    $"Update to version {newVersion} has been downloaded.\nThe application will now close and update.",
                    "Update Ready",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Close the application to allow the update to proceed
                parentForm.Invoke(new Action(() => Application.Exit()));
            }
            catch (Exception ex)
            {
                logCallback($"Update failed: {ex.Message}");
                statusCallback("Update failed.");
                progressCallback(false, 0);

                MessageBox.Show(
                    $"Failed to update: {ex.Message}\nPlease try again later or download the update manually.",
                    "Update Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}