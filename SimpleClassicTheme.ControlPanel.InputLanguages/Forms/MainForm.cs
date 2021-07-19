using Microsoft.Win32;

using System;
using System.Windows.Forms;

using Windows.Win32.UI.TextServices;

using static Windows.Win32.PInvoke;

namespace SimpleClassicTheme.ControlPanel.InputLanguages.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            treeView.ImageList = GetImageList();
        }

        public void LoadLayouts()
        {
            var layouts = new HKL[100];
            GetKeyboardLayoutList(layouts);

            var kbdLayoutsKey = Registry.LocalMachine.OpenSubKey(@$"SYSTEM\CurrentControlSet\Control\Keyboard Layouts");

            foreach (HKL hkl in layouts)
            {
                if (hkl == IntPtr.Zero)
                {
                    break;
                }

                string layoutName;

                int lw = unchecked((short)((uint)hkl.Value >> 16));
                var hex = $"{lw:X2}";
                using (var key = kbdLayoutsKey.OpenSubKey("00000" + hex))
                {
                    layoutName = (string)key.GetValue("Layout Text");
                }

                var tn = new TreeNode(layoutName);

                treeView.Nodes.Add(tn);
            }
        }

        private static ImageList GetImageList()
        {
            var imageList = new ImageList();

            imageList.Images.Add(Properties.Resources.Bullet);
            imageList.Images.Add("Keyboard", Properties.Resources.Keyboard);

            return imageList;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new AddInputLanguageForm())
            {
                dialog.ShowDialog();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadLayouts();
        }
    }
}