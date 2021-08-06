using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;

using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

using Icon = System.Drawing.Icon;

using static Windows.Win32.UI.WindowsAndMessaging.SYSTEM_PARAMETERS_INFO_ACTION;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties.Forms
{
    public partial class MainForm
    {
        public void LoadEffects()
        {
            using (var root = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", false))
            {
                int i = 0;

                root.GetSubKeyNames().ToList().ForEach(name =>
                {
                    using (var clsidKey = root.OpenSubKey(name))
                    using (var defaultIconKey = clsidKey.OpenSubKey("DefaultIcon"))
                    {
                        if (defaultIconKey == null)
                        {
                            return;
                        }

                        var path = (string)defaultIconKey.GetValue(null, string.Empty);
                        var iconInfo = SplitIconPath(path);

                        HICON hIcon;

                        unsafe
                        {
                            fixed (char* szFileName = iconInfo.Path)
                            {
                                var result = PInvoke.PrivateExtractIcons(
                                    szFileName, iconInfo.Index,
                                    32, 32,
                                    &hIcon,
                                    null,
                                    1,
                                    0);
                            }
                        }

                        var icon = Icon.FromHandle(hIcon);

                        effectsImageList.Images.Add(icon);

                        var lvi = new ListViewItem()
                        {
                            ImageIndex = i++,
                            Text = (string)clsidKey.GetValue(null, string.Empty)
                        };

                        desktopIconsListView.Items.Add(lvi);



                    }
                });
            }

            // PInvoke.Control_RunDLL.
            bool fontSmoothing, dragFullWindows;

            unsafe
            {
                PInvoke.SystemParametersInfo(SPI_GETFONTSMOOTHING, 0, &fontSmoothing, fWinIni: 0);
                PInvoke.SystemParametersInfo(SPI_GETDRAGFULLWINDOWS, 0, &dragFullWindows, fWinIni: 0);

            }

            fontSmoothingCheckBox.Checked = fontSmoothing;
            windowContentsCheckBox.Checked = dragFullWindows;
        }

        public (string Path, int Index) SplitIconPath(string value)
        {
            var split = value.Split(',');

            var index = split.Length == 2 ? int.Parse(split[1]) : 0;
            return (split[0], index);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            int piIconIndex = 0;

            unsafe
            {
                var defaultIconPath = @"C:\Windows\system32\shell32.dll";
                fixed (char* pszIconPath = defaultIconPath)
                {
                    var result = PInvoke.PickIconDlg((HWND)Handle, pszIconPath, (uint)defaultIconPath.Length + 1, &piIconIndex);
                }
            }
        }
    }
}
