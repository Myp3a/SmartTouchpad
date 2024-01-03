using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmartTouchpad
{
    public partial class ButtonData : System.Windows.Controls.UserControl
    {
        public string KeyName
        {
            get { return (string)GetValue(KeyNameProperty); }
            set { SetValue(KeyNameProperty, value); }
        }

        public static readonly DependencyProperty KeyNameProperty =
            DependencyProperty.Register("KeyName", typeof(string), typeof(ButtonData), new PropertyMetadata("Unknown"));

        public int ActionType
        {
            get { return (int)GetValue(ActionTypeProperty); }
            set { SetValue(ActionTypeProperty, value); }
        }

        public static readonly DependencyProperty ActionTypeProperty =
            DependencyProperty.Register("ActionType", typeof(int), typeof(ButtonData), new PropertyMetadata(0));

        public string AppPath
        {
            get { return (string)GetValue(AppPathProperty); }
            set { SetValue(AppPathProperty, value); }
        }

        public static readonly DependencyProperty AppPathProperty =
            DependencyProperty.Register("AppPath", typeof(string), typeof(ButtonData), new PropertyMetadata(""));

        public string AppArguments
        {
            get { return (string)GetValue(AppArgumentsProperty); }
            set { SetValue(AppArgumentsProperty, value); }
        }

        public static readonly DependencyProperty AppArgumentsProperty =
            DependencyProperty.Register("AppArguments", typeof(string), typeof(ButtonData), new PropertyMetadata(""));

        public List<int> KeybindKeys
        {
            get { return (List<int>)GetValue(KeybindKeysProperty); }
            set { SetValue(KeybindKeysProperty, value); }
        }

        public static readonly DependencyProperty KeybindKeysProperty =
            DependencyProperty.Register("KeybindKeys", typeof(List<int>), typeof(ButtonData), new PropertyMetadata(new List<int>()));

        public ButtonData()
        {
            InitializeComponent();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ApplicationArguments == null || KeybindField == null) return;
            switch (ActionTypeComboBox.SelectedIndex)
            {
                case 0:
                    ApplicationArguments.Visibility = Visibility.Hidden;
                    KeybindField.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    ApplicationArguments.Visibility = Visibility.Visible;
                    KeybindField.Visibility = Visibility.Hidden; 
                    break;
                case 2:
                    ApplicationArguments.Visibility = Visibility.Hidden;
                    KeybindField.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void PreventInput(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!KeybindKeys.Contains((int)e.Key)) KeybindKeys.Add((int)e.Key);
            string text = "";
            text = String.Join(" + ", KeybindKeys.Select(key => (Key)key).ToArray());
            ClearButton.Content = "Stop";
            (sender as System.Windows.Controls.TextBox).Text = text;
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            if ((string)ClearButton.Content == "Clear")
            {
                KeybindTextBox.Text = "Press to edit...";
                KeybindKeys.Clear();
            }
            if ((string)ClearButton.Content == "Stop") ClearButton.Content = "Clear"; 
        }

        private void KeyContainer_Loaded(object sender, RoutedEventArgs e)
        {
            if (KeybindKeys.Count == 0) KeybindTextBox.Text = "Press to edit...";
            KeybindTextBox.Text = String.Join(" + ", KeybindKeys.Select(key => (Key)key).ToArray());
        }
    }
}
