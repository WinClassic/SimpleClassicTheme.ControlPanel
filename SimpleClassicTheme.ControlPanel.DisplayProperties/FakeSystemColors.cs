using System.Drawing;

namespace SimpleClassicTheme.ControlPanel.DisplayProperties
{
    public class FakeSystemColors
    {
        public Color ActiveCaption;
        public Color Desktop;
        public Color GradientActiveCaption;
        public Color GradientInactiveCaption;
        public Color InactiveCaption;
        public Color Control { get; internal set; }

        public static FakeSystemColors GetReal()
        {
            return new()
            {
                Desktop = SystemColors.Desktop,
                ActiveCaption = SystemColors.ActiveCaption,
                InactiveCaption = SystemColors.InactiveCaption,
                GradientActiveCaption = SystemColors.GradientActiveCaption,
                GradientInactiveCaption = SystemColors.GradientInactiveCaption,
            };
        }
    }
}