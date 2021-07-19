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

            var dividerRect = new Rectangle(Width - 12, 4, 2, colorSurface.Height);
            ControlPaint.DrawBorder3D(pevent.Graphics, dividerRect, Border3DStyle.Flat);
        }
    }
}