using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SimpleClassicTheme.Common.Configuration;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties.Forms
{
    public partial class MainForm : Form
    {
        private static Rectangle s_monitorRect;
        private static Image s_monitorImage;
        private DirtyFlags _dirtySettings = DirtyFlags.None;
        private DirtyFlags DirtySettings
        {
            get => _dirtySettings;
            set
            {
                _dirtySettings = value;
                applyButton.Enabled = _dirtySettings != DirtyFlags.None;
            }
        }
        
        public MainForm()
        {
            InitializeComponent();

            var extensions = string.Join(";", s_wallpaperExtensions.Select(ext => '*' + ext));
            wallpaperOpenFileDialog.Filter = $"All Picture Files ({extensions})|{extensions}";

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void ApplySettings()
        {
            if (DirtySettings.HasFlag(DirtyFlags.Desktop))
            {
                Wallpaper.Mode = Mode;
                Wallpaper.Color = desktopColorButton.Color;

                if (GetSelectedWallpaperItem() is ListViewItem lvi && lvi.Tag is string filePath)
                {
                    Wallpaper.Path = filePath;
                }

                Wallpaper.BroadcastChanges();
            }

            DirtySettings = DirtyFlags.None;

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void LoadDisplaySettings()
        {
            displayComboBox.Items.Clear();
        }

        private void LoadScreenSaverSettings()
        {
            numericUpDown1.Value = ScreenSaver.TimeOut / 60;
            passwordProtectedCheckBox.Checked = ScreenSaver.PasswordProtected;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bool useXP = GlobalConfig.Default.TargetAppearance >= TargetAppearance.WindowsXP;
            if (useXP)
            {
                s_monitorRect = new(16, 17, 152, 112);
                s_monitorImage = Properties.Resources.MonitorXP;
                energyStarPictureBox.Image = Properties.Resources.EnergyStarXP;
            }
            else
            {
                s_monitorRect = new(16, 17, 152, 112);
                s_monitorImage = Properties.Resources.Monitor;
                energyStarPictureBox.Image = Properties.Resources.EnergyStar;
            }

            screenSaverPreviewPictureBox.Image = s_monitorImage;
            desktopMonitorPictureBox.Image = s_monitorImage;

            LoadThemeSettings();
            LoadDisplaySettings();
            LoadDesktopSettings();
            LoadEffects();
            LoadScreenSaverSettings();

            DirtySettings = DirtyFlags.None;

        }

        private void MonitorPowerButton_Click(object sender, EventArgs e)
        {
            Helpers.ExecuteControlPanelItem("powercfg.cpl");
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
            Close();
        }

    }
}