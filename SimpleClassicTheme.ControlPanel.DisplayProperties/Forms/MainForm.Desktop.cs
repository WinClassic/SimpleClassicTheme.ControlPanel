using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties.Forms
{
    public partial class MainForm
    {
        private Image _wallpaperPreview;

        private static readonly string[] s_wallpaperExtensions = new[]
{
            ".bmp",
            ".gif",
            ".jpg",
            ".jpeg",
            ".dib",
            ".png",
        };

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
                        case WallpaperMode.Center: { 
                            var x = center(previewBitmap.Width, wallpaperBitmap.Width);
                            var y = center(previewBitmap.Width, wallpaperBitmap.Height);
                            graphics.DrawImage(wallpaperBitmap, x, y);
                        } break;

                        case WallpaperMode.Tile:
                            using (var tileTextureBrush = new TextureBrush(wallpaperBitmap, WrapMode.Tile))
                            {
                                graphics.FillRectangle(tileTextureBrush, 0, 0, previewBitmap.Width, previewBitmap.Height);
                            }
                            break;

                        case WallpaperMode.Fit:
                            {
                                if (previewBitmap.Width > previewBitmap.Height)
                                {
                                    var scale = previewBitmap.Width / (float)wallpaperBitmap.Width;

                                    var width = (int)(wallpaperBitmap.Width * scale);
                                    var height = (int)(wallpaperBitmap.Height * scale);

                                    var x = center(previewBitmap.Width, width);
                                    var y = center(previewBitmap.Height, height);

                                    var rect = new Rectangle(x, y, width, height);
                                    graphics.DrawImage(wallpaperBitmap, rect);
                                }
                                break;
                            } 

                        case WallpaperMode.Fill:
                            {
                                if (previewBitmap.Width > previewBitmap.Height)
                                {
                                    var scale = previewBitmap.Height / (float)wallpaperBitmap.Height;

                                    var width = (int)(wallpaperBitmap.Width * scale);
                                    var height = (int)(wallpaperBitmap.Height * scale);

                                    var x = center(previewBitmap.Width, width);
                                    var y = center(previewBitmap.Height, height);

                                    var rect = new Rectangle(x, y, width, height);
                                    graphics.DrawImage(wallpaperBitmap, rect);
                                }
                                break;
                            }

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
            var ext = Path.GetExtension(filePath).ToLowerInvariant();

            // Check if file path has valid extension
            if (!s_wallpaperExtensions.Contains(ext))
            {
                return;
            }

            if (!wallpaperImageList.Images.ContainsKey(ext))
            {
                var icon = Icon.ExtractAssociatedIcon(filePath);
                wallpaperImageList.Images.Add(ext, new Icon(icon, 16, 16));
            }

            var lvi = new ListViewItem
            {
                ImageKey = ext,
                Text = Path.GetFileNameWithoutExtension(filePath),
                Tag = filePath,
            };

            backgroundListView.Items.Add(lvi);

            if (select)
            {
                FocusItem(lvi);
            }
        }

        /// <summary>
        /// Selects the list item that corresponds to the provided <paramref name="filePath"/>, if none was found a new one will be created and selected.
        /// </summary>
        private void CheckUserWallpaper(string filePath)
        {
            foreach (ListViewItem item in backgroundListView.Items)
            {
                var isSelected = item.Tag is string itemPath && itemPath == filePath;
                if (isSelected)
                {
                    FocusItem(item);
                    return;
                }
            }

            AddWallpaper(filePath, true);
        }
        private static void FocusItem(ListViewItem item)
        {
            item.Selected = true;
            item.EnsureVisible();
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

        private void LoadWallpapers()
        {
            backgroundListView.Items.Clear();

            var solidColorItem = new ListViewItem
            {
                Text = "None",
                Tag = string.Empty,
            };

            backgroundListView.Items.Add(solidColorItem);

            var windowsPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            var wallpaperDirectoryPath = Path.Combine(windowsPath, "Web", "Wallpaper");
            var files = Directory.GetFiles(wallpaperDirectoryPath, "*.*", SearchOption.AllDirectories);

            files = files.OrderBy(Path.GetFileName).ToArray();

            foreach (var filePath in files)
            {
                AddWallpaper(filePath);
            }

            var wallpaperPath = Wallpaper.Path;
            if (string.IsNullOrWhiteSpace(wallpaperPath))
            {
                FocusItem(solidColorItem);
            }
            else
            {
                CheckUserWallpaper(wallpaperPath);
            }

            backgroundListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void WallpaperOpenFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CheckUserWallpaper(wallpaperOpenFileDialog.FileName);
            backgroundListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void DesktopColorButton_ColorChanged(object sender, EventArgs e)
        {
            RefreshWallpaperPreview();
            DirtySettings |= DirtyFlags.Desktop;
        }
        private void PositionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWallpaperPreview();
            DirtySettings |= DirtyFlags.Desktop;
        }

        private void RefreshWallpaperPreview()
        {
            if (GetSelectedWallpaperItem() is ListViewItem item && item.Tag is string filePath)
            {
                _wallpaperPreview = GenerateWallpaperPreview(filePath, Mode);
            }

            desktopMonitorPictureBox.Invalidate();
        }

        private void CustomizeDesktopButton_Click(object sender, EventArgs e)
        {
            Helpers.ExecuteControlPanelItem("desk.cpl");
        }

        private void DesktopMonitorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using (var backgroundBrush = new SolidBrush(desktopColorButton.Color))
            {
                e.Graphics.FillRectangle(backgroundBrush, s_monitorRect);
            }
            
            if (_wallpaperPreview != null)
            {
                e.Graphics.DrawImage(_wallpaperPreview, s_monitorRect);
            }
        }
        private void BackgroundListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWallpaperPreview();
            DirtySettings |= DirtyFlags.Desktop;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            wallpaperOpenFileDialog.ShowDialog();
        }


    }
}
