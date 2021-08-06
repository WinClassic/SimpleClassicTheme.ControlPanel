using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties.Forms
{
    public partial class MainForm
    {
        public void LoadThemeSettings()
        {
            List<string> themes = new();

            foreach (var directory in Helpers.GetThemeSearchPaths())
            {
                if (Directory.Exists(directory))
                {
                    try
                    {
                        var files = Directory.GetFiles(directory, "*.theme", SearchOption.AllDirectories);
                        themes.AddRange(files);
                    }
                    catch
                    {
                    }
                }
            }

            themeComboBox.Items.AddRange(themes.Select(Path.GetFileNameWithoutExtension).ToArray());


        }
    }
}
