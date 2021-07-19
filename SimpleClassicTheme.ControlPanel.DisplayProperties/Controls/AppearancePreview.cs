using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties.Controls
{
    public partial class AppearancePreview : UserControl
    {
        public AppearancePreview()
        {
            InitializeComponent();
            // SystemColors = FakeSystemColors.GetReal();
        }

        private static void PaintTitleBar(Graphics g, int x, int y, int width, TitleBarData data)
        {
            Color leftColor = data.Active ? SystemColors.ActiveCaption : SystemColors.InactiveCaption;
            Color rightColor = data.Active ? SystemColors.GradientActiveCaption : SystemColors.GradientInactiveCaption;

            var gradientStart = new Point(x, y);
            var gradientStop = new Point(x + width, y);

            var bgBrush = new LinearGradientBrush(gradientStart, gradientStop, leftColor, rightColor);

            g.FillRectangle(bgBrush, x, y, width, 18);

            var fgBrush = data.Active ? SystemBrushes.ActiveCaptionText : SystemBrushes.InactiveCaptionText;

            g.DrawString(data.Caption, SystemFonts.CaptionFont, fgBrush, new Rectangle(x, y, width - 2, 18), new StringFormat()
            {
                LineAlignment = StringAlignment.Center
            });

            if (!data.OnlyClose)
            {
                PaintTitleBarButton(g, x + width - 52, y + 2, CaptionButton.Minimize); // 0
                PaintTitleBarButton(g, x + width - 36, y + 2, CaptionButton.Maximize); // 1
            }

            PaintTitleBarButton(g, x + width - 18, y + 2, CaptionButton.Close); // r
        }

        private static void PaintTitleBarButton(Graphics g, int x, int y, CaptionButton icon)
        {
            var rect = new Rectangle(x, y, 16, 14);

            //g.FillRectangle(SystemBrushes.Control, rect);
            ControlPaint.DrawCaptionButton(g, rect, icon, ButtonState.Normal);

            //using (var font = new Font("Marlett", 8, GraphicsUnit.Point))
            //{
            //    g.DrawString(icon.ToString(), font, SystemBrushes.ControlText, rect);
            //}
        }

        private static void PaintWindow(Graphics g, Rectangle rect, TitleBarData titleBar)
        {
            g.FillRectangle(SystemBrushes.Control, rect);
            ControlPaint.DrawBorder3D(g, rect, Border3DStyle.Raised);

            PaintTitleBar(g, rect.X + 4, rect.Y + 4, rect.Width - 8, titleBar);
        }

        private void AppearancePreview_Load(object sender, EventArgs e)
        {
        }

        private void AppearancePreview_Paint(object sender, PaintEventArgs e)
        {
            Rectangle windowRect;
            TitleBarData windowTitleBar;

            // "Inactive Window" window

            windowRect = new Rectangle(16, 8, 305, 139);
            windowTitleBar = new() { Active = false, Caption = "Inactive Window", OnlyClose = false };

            PaintWindow(e.Graphics, windowRect, windowTitleBar);

            // "Active Window" window

            windowRect = new Rectangle(20, 31, 323, 121);
            windowTitleBar = new() { Active = true, Caption = "Active Window", OnlyClose = false };

            PaintWindow(e.Graphics, windowRect, windowTitleBar);

            e.Graphics.DrawString("Normal", SystemFonts.MenuFont, SystemBrushes.MenuText, windowRect.X + 5, windowRect.Y + 25);

            //ControlPaint.DrawStringDisabled(e.Graphics, "Disabled", SystemFonts.MenuFont, SystemColors.MenuText, new Rectangle(54, 19))

            var windowContentRect = new Rectangle(windowRect.X + 4, windowRect.Y + 41, 315, 76);
            e.Graphics.FillRectangle(SystemBrushes.Window, windowContentRect);
            ControlPaint.DrawBorder3D(e.Graphics, windowContentRect, Border3DStyle.Sunken);

            var windowContentTextFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
            e.Graphics.DrawString("Window Text", windowContentTextFont, SystemBrushes.WindowText, windowContentRect.X + 4, windowContentRect.Y + 4);

            // "Message Box" window

            windowRect = new Rectangle(28, 110, 207, 63);
            windowTitleBar = new() { Active = true, Caption = "Message Box", OnlyClose = true };

            PaintWindow(e.Graphics, windowRect, windowTitleBar);

            e.Graphics.DrawString("Message Text", SystemFonts.MessageBoxFont, SystemBrushes.ControlText, windowRect.X + 4, windowRect.Y + 24);

            var buttonRect = new Rectangle(windowRect.X + 67, windowRect.Y + 33, 72, 24);
            ControlPaint.DrawButton(e.Graphics, buttonRect, ButtonState.Normal);
            e.Graphics.DrawString("OK", SystemFonts.MessageBoxFont, SystemBrushes.ControlText, buttonRect, new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            });
        }
    }

    public record TitleBarData
    {
        public string Caption { get; init; }
        public bool Active { get; init; }
        public bool OnlyClose { get; init; }
    }
}