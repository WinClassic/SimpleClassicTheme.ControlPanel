namespace SimpleClassicTheme.ControlPanel.DisplayProperties
{
    public class ComboBoxItem<T>
    {
        public ComboBoxItem(string friendlyName, T value)
        {
            FriendlyName = friendlyName;
            Value = value;
        }

        public string FriendlyName { get; set; }
        public T Value { get; set; }

        public static implicit operator T(ComboBoxItem<T> other) => other.Value;

        public override string ToString() => FriendlyName;
    };
}