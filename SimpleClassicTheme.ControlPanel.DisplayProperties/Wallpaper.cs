using Microsoft.Win32;

using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

using static SimpleClassicTheme.ControlPanel.DisplayProperties.NativeMethods;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties
{
    public static class Wallpaper
    {
        private static readonly RegistryKey colorsKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
        private static readonly RegistryKey desktopKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

        public static Color Color
        {
            get
            {
                var rawColor = (string)colorsKey.GetValue("Background", "0 0 0");
                var split = rawColor.Split(' ').Select(int.Parse).ToArray();

                return Color.FromArgb(split[0], split[1], split[2]);
            }

            set
            {
                colorsKey.SetValue("Background", $"{value.R} {value.G} {value.B}");
            }
        }

        public static WallpaperMode Mode
        {
            get
            {
                var rawTile = desktopKey.GetValue("TileWallpaper", "0");
                if (rawTile is string tile && tile == "1")
                {
                    return WallpaperMode.Tile;
                }

                var rawStyle = desktopKey.GetValue("WallpaperStyle", "0");
                if (rawStyle is string style && int.TryParse(style, out var styleInt))
                {
                    return (WallpaperMode)styleInt;
                }

                return WallpaperMode.Center;
            }
            set
            {
                var tileValue = value == WallpaperMode.Tile ? "1" : "0";
                desktopKey.SetValue("TileWallpaper", tileValue);

                var styleValue = value == WallpaperMode.Tile ? "0" : ((int)value).ToString();
                desktopKey.SetValue("WallpaperStyle", styleValue);
            }
        }

        public static string Path
        {
            get
            {
                return desktopKey.GetValue("Wallpaper", string.Empty) as string;
            }
            set
            {
                desktopKey.SetValue("Wallpaper", value);
            }
        }

        public static void BroadcastChanges()
        {
            if (SystemParametersInfoW(SPI_SETDESKWALLPAPER, 0, Path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE) == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
}