using Microsoft.Win32;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties
{
    public static class ScreenSaver
    {
        private static readonly RegistryKey desktopKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

        public static bool Enabled
        {
            get
            {
                return (string)desktopKey.GetValue("ScreenSaverActive", "0") == "1";
            }
            set
            {
                desktopKey.SetValue("ScreenSaverActive", value ? "1" : "0");
            }
        }

        public static bool PasswordProtected
        {
            get
            {
                return (string)desktopKey.GetValue("ScreenSaverIsSecure", "0") == "1";
            }
            set
            {
                desktopKey.SetValue("ScreenSaverIsSecure", value ? "1" : "0");
            }
        }

        public static int TimeOut
        {
            get
            {
                var defaultValue = (15 * 60).ToString();
                return int.Parse((string)desktopKey.GetValue("ScreenSaverTimeOut", defaultValue));
            }
            set
            {
                desktopKey.SetValue("ScreenSaverTimeOut", value.ToString());
            }
        }
    }
}