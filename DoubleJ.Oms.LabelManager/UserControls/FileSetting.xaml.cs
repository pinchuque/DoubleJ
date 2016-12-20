using System.Windows;

namespace DoubleJ.Oms.LabelManager.UserControls
{
    /// <summary>
    /// Interaction logic for FileSetting.xaml
    /// </summary>
    public partial class FileSetting
    {
        public FileSetting()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(FileSetting), new UIPropertyMetadata(""));

        private void SelectFile(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog { Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*" };
            var result = ofd.ShowDialog();
            if (result == false) return;

            Value = ofd.FileName;
        }
    }
}
