using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties.Forms
{
    public partial class ColorPickerPopupForm : Form
    {
        public ColorPickerPopupForm()
        {
            InitializeComponent();
            PredefinedColors = new[]
            {
                Color.White,
                Color.Black,
                Color.Gray,
                Color.DarkGray,
                Color.Red,
                Color.DarkRed,
                Color.Yellow,
                Color.DarkOliveGreen,
                Color.Lime,
                Color.Green,
                Color.Cyan,
                Color.DarkCyan,
                Color.Blue,
                Color.DarkBlue,
                Color.Magenta,
                Color.DarkMagenta,
            };
        }

        public Color Color { get; set; }

        public Color[] PredefinedColors { get; set; }

        private void ColorPickerPopupForm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void ColorPickerPopupForm_Load(object sender, EventArgs e)
        {
            foreach (var color in PredefinedColors)
            {
                var button = new ColorPickerSwatchButton(color)
                {
                    Width = 23,
                    Height = 23,
                    Margin = Padding.Empty,
                };

                button.Click += (s, e) =>
                {
                    if (s is ColorPickerSwatchButton button1)
                    {
                        Color = button1.Color;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                };

                flowLayoutPanel.Controls.Add(button);
            }
        }

        private void OtherButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Color;

            Opacity = 0;

            DialogResult = colorDialog.ShowDialog(Owner);
            Color = colorDialog.Color;

            Close();
        }
    }

    public class ColorPickerSwatchButton : Control
    {
        private readonly Brush brush;
        private bool hover;

        public ColorPickerSwatchButton(Color color)
        {
            Color = color;
            brush = new SolidBrush(color);
        }

        public Color Color { get; }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            var rect = new Rectangle(Point.Empty, Size);

            var colorSurface = rect;
            colorSurface.Inflate(-3, -3);

            pevent.Graphics.FillRectangle(brush, colorSurface);

            if (hover)
            {
                var hoverRect = rect;
                hoverRect.Width--;
                hoverRect.Height--;

                pevent.Graphics.DrawRectangle(Pens.Black, hoverRect);

                hoverRect.Inflate(-1, -1);
                pevent.Graphics.DrawRectangle(Pens.White, hoverRect);

                hoverRect.Inflate(-1, -1);
                pevent.Graphics.DrawRectangle(Pens.Black, hoverRect);
            }
            else
            {
                var sunkRect = rect;
                sunkRect.Inflate(-2, -2);
                ControlPaint.DrawBorder3D(pevent.Graphics, sunkRect, Border3DStyle.Sunken);
            }
        }
    }
}