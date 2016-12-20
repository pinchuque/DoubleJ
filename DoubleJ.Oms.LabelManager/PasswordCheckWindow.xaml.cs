using System.Windows;

using DoubleJ.Oms.Settings;


namespace DoubleJ.Oms.LabelManager
{
    /// <summary>
    /// Interaction logic for PasswordCheckWindow.xaml
    /// </summary>
    public partial class PasswordCheckWindow
    {
        public PasswordCheckWindow()
        {
            InitializeComponent();
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = CheckPassword(PassWord.Password);
            Close();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private static bool CheckPassword(string password)
        {
            return SettingsManager.Current.Password == password;
        }
    }
}