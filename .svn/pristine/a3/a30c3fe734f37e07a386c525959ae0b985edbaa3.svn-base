using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.LabelManager.Models;


namespace DoubleJ.Oms.LabelManager
{
    /// <summary>
    /// Interaction logic for NumericKeyboard.xaml
    /// </summary>
    public partial class ManualWeightPanel
    {
        private readonly ManualWeightPanelViewModel _viewModel;
        public event EventHandler<SubmitNumberEventArgs> SubmitNumber;

        public ManualWeightPanel(int digitsAfterDecimalPoint, int maxDigits, string value = null, LabelManagerWindow parent = null)
        {
            InitializeComponent();

            decimal v;
            value = decimal.TryParse(value, out v) ? v.ToString(CultureInfo.InvariantCulture) : null;

            _viewModel = new ManualWeightPanelViewModel
            {
                DigitsAfterDecimalPoint = digitsAfterDecimalPoint,
                MaxDigits = maxDigits,
                ReturnValue = value ?? "0"
            };
           
            this.Quantity.GotFocus += _viewModel.UpdateCommands;
            this.ReturnNumber.GotFocus += _viewModel.UpdateCommands;

            DataContext = _viewModel;
            if (parent != null)
            {
                if (parent.CustomerType == OmsCustomerType.Custom)
                {
                    FocusManager.SetFocusedElement(this, Quantity);
                }
                else
                {
                    FocusManager.SetFocusedElement(this, ReturnNumber);
                }
            }
        }

        private void SubmitNumberClick(object sender, RoutedEventArgs e)
        {
            if (SubmitNumber != null)
            {
                SubmitNumber(this, new SubmitNumberEventArgs {Value = _viewModel.ReturnValue, Quantity = _viewModel.Quantity});
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
            return v && l.ToString(CultureInfo.InvariantCulture) == s;
        }

        private static bool IsValidDecimal(string s)
        {
            decimal d;
            var v = decimal.TryParse(s, out d);

            //Very strange condition
            return v && d.ToString(CultureInfo.InvariantCulture) == s;
        }

        private void Quantity_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var quantityTextbox = sender as TextBox;
            if (quantityTextbox != null)
            {
                if (quantityTextbox.Text == "1")
                {
                    quantityTextbox.Text = "";
                }
            }
        }
    }
}