using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties.Forms
{
    public partial class MainForm : Form
    {
        private static readonly Rectangle monitorRect = new(16, 17, 152, 112);
        private static Image wallpaperPreview;

        public MainForm()
        {
            InitializeComponent();
        }

        public WallpaperMode Mode => (WallpaperMode)positionComboBox.SelectedItem;

        private static Image GenerateWallpaperPreview(string filePath, WallpaperMode mode)
        {
            try
            {
                static int center(int parent, int child)
                {
                    return (parent / 2) - (child / 2);
                }

                var wallpaperBitmap = Image.FromFile(filePath);
                var previewBitmap = new Bitmap(1024, 768);
                using (var graphics = Graphics.FromImage(previewBitmap))
                {
                    switch (mode)
                    {
                        case WallpaperMode.Center:
                            var x = center(previewBitmap.Width, wallpaperBitmap.Width);
                            var y = center(previewBitmap.Width, wallpaperBitmap.Height);
                            graphics.DrawImage(wallpaperBitmap, x, y);
                            break;

                        case WallpaperMode.Tile:
                            using (var tileTextureBrush = new TextureBrush(wallpaperBitmap, WrapMode.Tile))
                            {
                                graphics.FillRectangle(tileTextureBrush, 0, 0, previewBitmap.Width, previewBitmap.Height);
                            }
                            break;

                        case WallpaperMode.Stretch:
                            var stretchRect = new Rectangle(Point.Empty, previewBitmap.Size);
                            graphics.DrawImage(wallpaperBitmap, stretchRect);
                            break;

                        default:
                            return wallpaperBitmap;
                    }

                    wallpaperBitmap.Dispose();
                    return previewBitmap;
                }
            }
            catch
            {
                return null;
            }
        }

        private void AddWallpaper(string filePath, bool select = false)
        {
            var ext = Path.GetExtension(filePath);

            if (!imageList.Images.ContainsKey(ext))
            {
                var icon = Icon.ExtractAssociatedIcon(filePath);
                imageList.Images.Add(ext, new Icon(icon, 16, 16));
            }

            var lvi = new ListViewItem()
            {
                ImageKey = ext,
                Text = Path.GetFileNameWithoutExtension(filePath),
                Tag = filePath,
                Selected = select,
            };

            backgroundListView.Items.Add(lvi);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
            // applyButton.Enabled = false;
        }

        private void ApplySettings()
        {
            Wallpaper.Mode = Mode;

            if (GetSelectedWallpaperItem() is ListViewItem lvi && lvi.Tag is string filePath)
            {
                Wallpaper.Path = filePath;
            }

            Wallpaper.Color = desktopColorButton.Color;

            Wallpaper.BroadcastChanges();
        }

        private void BackgroundListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWallpaperPreview();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            wallpaperOpenFileDialog.ShowDialog();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckUserWallpaper()
        {
            foreach (ListViewItem item in backgroundListView.Items)
            {
                var isSelected = item.Tag is string filePath && filePath == Wallpaper.Path;
                if (isSelected)
                {
                    item.Selected = true;
                    return;
                }
            }

            AddWallpaper(Wallpaper.Path, true);
        }

        private void CustomizeDesktopButton_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "rundll32.exe",
                Arguments = "shell32.dll,Control_RunDLL desk.cpl,,0",
                UseShellExecute = true,
            });
        }

        private void DesktopMonitorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(SystemBrushes.Desktop, monitorRect);

            if (wallpaperPreview != null)
            {
                e.Graphics.DrawImage(wallpaperPreview, monitorRect);
            }
        }

        private ListViewItem GetSelectedWallpaperItem()
        {
            if (backgroundListView.SelectedItems.Count != 0)
            {
                return backgroundListView.SelectedItems[0];
            }

            return null;
        }

        private void LoadDesktopSettings()
        {
            foreach (var wallpaperMode in Enum.GetValues<WallpaperMode>())
            {
                positionComboBox.Items.Add(wallpaperMode);
            }

            positionComboBox.SelectedItem = Wallpaper.Mode;
            desktopColorButton.Color = Wallpaper.Color;
            LoadWallpapers();
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

        private void LoadWallpapers()
        {
            backgroundListView.Items.Clear();

            var solidColorItem = new ListViewItem
            {
                Text = "None",
                Tag = string.Empty,
            };

            backgroundListView.Items.Add(solidColorItem);

            var wallpaperPath = @"C:\Windows\web\wallpaper";
            var files = Directory.GetFiles(wallpaperPath, "*.*", SearchOption.AllDirectories);

            foreach (var filePath in files)
            {
                // try
                // {
                //     Image.FromFile(filePath).Dispose();
                // }
                // catch
                // {
                //     continue;
                // }

                AddWallpaper(filePath);
            }

            if (string.IsNullOrWhiteSpace(Wallpaper.Path))
            {
                solidColorItem.Selected = true;
            }
            else
            {
                CheckUserWallpaper();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDisplaySettings();
            LoadDesktopSettings();
            LoadScreenSaverSettings();
        }

        private void MonitorPowerButton_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("powercfg.cpl") { UseShellExecute = true });
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
            Close();
        }

        private void PositionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWallpaperPreview();
        }

        private void RefreshWallpaperPreview()
        {
            if (GetSelectedWallpaperItem() is ListViewItem item && item.Tag is string filePath)
            {
                wallpaperPreview = GenerateWallpaperPreview(filePath, Mode);
            }

            desktopMonitorPictureBox.Invalidate();
        }

        private void WallpaperOpenFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Wallpaper.Path = wallpaperOpenFileDialog.FileName;
            CheckUserWallpaper();
        }
    }
}