using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace DoubleJ.Oms.LabelManager.UserControls
{
    /// <summary>
    /// Interaction logic for ProcessDateControl.xaml
    /// </summary>
    public partial class ProcessDateControl : UserControl
    {
        public ProcessDateControl()
        {
            InitializeComponent();
        }

        private void DecreaseDate(object sender, RoutedEventArgs e)
        {
            var date = DataContext as DateTime?;
            if (date != null)
            {
                date = date.Value.AddDays(-1);
                DataContext = date;
            }
        }

        private void IncreaseDate(object sender, RoutedEventArgs e)
        {
            var date = DataContext as DateTime?;
            if (date != null)
            {
                date = date.Value.AddDays(1);
                DataContext = date;
            }
        }

        private void RadDateTimePicker_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = sender as RadDatePicker;
            if (datePicker != null)
            {
                DataContext = datePicker.SelectedDate;
            }
        }
    }
}
