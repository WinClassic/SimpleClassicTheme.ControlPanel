using SimpleClassicTheme.ControlPanel.DisplayProperties.Forms;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties.Controls
{
    public class ColorButton : Button
    {
        private Brush brush;
        private Color color;

        public ColorButton()
        {
            Color = Color.White;
        }

        public event EventHandler<EventArgs> ColorChanged;

        public Color Color
        {
            get => color;
            set
            {
                color = value;
                brush = new SolidBrush(color);

                ColorChanged?.Invoke(this, EventArgs.Empty);

                Invalidate();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            var buttonScreenLocation = PointToScreen(Point.Empty);
            var picker = new ColorPickerPopupForm
            {
                Left = buttonScreenLocation.X,
                Top = buttonScreenLocation.Y + Height,
            };

            var owner = FindForm();
            picker.Show(owner);

            picker.Disposed += (s, e) =>
            {
                if (picker.DialogResult == DialogResult.OK)
                {
                    Color = picker.Color;
                }

                Focus();
            };
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            var colorSurface = new Rectangle(4, 3, Width - 20, Height - 8);
            pevent.Graphics.FillRectangle(brush, colorSurface);

            //colorSurface.Inflate(-1, -1);
            pevent.Graphics.DrawRectangle(SystemPens.ControlText, colorSurface);

            var dividerX = Width - 12;
            var dividerX2 = dividerX + 1;
            var dividerY = 3;
            var dividerY2 = dividerY + colorSurface.Height;

            pevent.Graphics.DrawLine(SystemPens.ControlDark, dividerX, dividerY, dividerX, dividerY2);
            pevent.Graphics.DrawLine(SystemPens.ControlLightLight, dividerX2, dividerY, dividerX2, dividerY2);

            var downOffsetY = (Height / 2f) - 1.5f;
            var downOffset = new Point(Width - 9, (int)downOffsetY);

            var downPoints = new Point[]
            {
                downOffset,
                new Point(downOffset.X + 5, downOffset.Y),
                new Point(downOffset.X + 2, downOffset.Y + 3),
            };

            pevent.Graphics.FillPolygon(SystemBrushes.ControlText, downPoints);
        }
    }
}