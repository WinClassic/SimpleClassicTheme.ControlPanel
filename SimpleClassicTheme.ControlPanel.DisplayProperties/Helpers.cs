using System;
using System.Diagnostics;
using System.IO;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties
{
    internal static class Helpers
    {
        public static void ExecuteControlPanelItem(string itemName)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "rundll32.exe",
                Arguments = "shell32.dll,Control_RunDLL " + itemName + ",,0",
                UseShellExecute = true,
            });
        }

        public static string[] GetThemeSearchPaths()
        {
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            var windows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            // var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            return new string[]
            {
                Path.Combine(programFiles, "Plus!", "Themes"),
                Path.Combine(windows, "Resources", "Themes"),
                Path.Combine(appData, "Microsoft", "Windows", "Themes"),
                // documents
            };
        }
    }
}
