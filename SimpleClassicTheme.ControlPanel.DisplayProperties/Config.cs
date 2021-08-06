using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleClassicTheme.Common.Configuration;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties
{
    class Config : ConfigBase<Config>
    {
        public Config() : base("SimpleClassicThemeControlPanel", ConfigType.ControlPanel)
        {
        }

        public bool ShowEnergyStar { get; set; }

        public int ScreenSaverLayout { get; set; }

        /// <summary>
        /// Adds modern Windows wallpaper positions like "Fill", "Fit" and "Span".
        /// </summary>
        public bool EnableExtendedWallpaperPositions { get; set; }

        public bool EnableEffectsTab { get; set; } = false;
    }

    public enum ScreenSaverSettingsLayout
    {
        Classic,
        WindowsXP,
    }
}
