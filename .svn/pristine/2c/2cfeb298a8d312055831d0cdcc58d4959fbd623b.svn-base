using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using DoubleJ.Oms.LabelManager.Models;


namespace DoubleJ.Oms.LabelManager
{
    /// <summary>
    /// Interaction logic for NumericKeyboard.xaml
    /// </summary>
    public partial class NumericKeyboard
    {
        private readonly NumericKeyboardViewModel _viewModel;
        public event EventHandler<SubmitNumberEventArgs> SubmitNumber;

        public NumericKeyboard(int digitsAfterDecimalPoint, int maxDigits, string value = null)
        {
            InitializeComponent();

            decimal v;
            value = decimal.TryParse(value, out v) ? v.ToString(CultureInfo.InvariantCulture) : null;

            _viewModel = new NumericKeyboardViewModel
            {
                DigitsAfterDecimalPoint = digitsAfterDecimalPoint,
                MaxDigits = maxDigits,
                ReturnValue = value ?? "0"
            };

            DataContext = _viewModel;
        }

        private void SubmitNumberClick(object sender, RoutedEventArgs e)
        {
            if (SubmitNumber != null)
            {
                SubmitNumber(this, new SubmitNumberEventArgs {Value = _viewModel.ReturnValue});
            }

            Close();
        }

        private void ReturnNumber_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var test = ((TextBox) sender).Text + e.Text;

            e.Handled = !(_viewModel.DigitsAfterDecimalPoint == 0 ? IsValidLong(test) : IsValidDecimal(test));
        }


        private static bool IsValidLong(string s)
        {
            long l;
            var v = long.TryParse(s, out l);

            //Very strange condition
            return v && l.ToString() == s;
        }

        private static bool IsValidDecimal(string s)
        {
            decimal d;
            var v = decimal.TryParse(s, out d);

            //Very strange condition
            return v && d.ToString() == s;
        }
    }
}