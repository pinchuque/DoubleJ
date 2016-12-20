using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using DoubleJ.Oms.LabelManager.Annotations;

using Telerik.Windows.Controls;


namespace DoubleJ.Oms.LabelManager.Models
{
    public class ManualWeightPanelViewModel : INotifyPropertyChanged
    {
        private string _returnValue;
        private string _quantity;

        public int MaxDigits { get; set; }
        public int DigitsAfterDecimalPoint { get; set; }

        public ManualWeightPanelViewModel()
        {
            DigitsAfterDecimalPoint = 3;
            MaxDigits = 10;
            ReturnValue = "0";
            Quantity = "1";
        }

        public ICommand PointCommand
        {
            get { return new DelegateCommand(OnPointChanged, OnPointCanExcecute); }
        }

        private bool OnPointCanExcecute(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                return textBox.Name != "Quantity" && (AllowDecimalPoint && !HasPoint(textBox.Text) && textBox.Text.Length < MaxDigits - 1);
            }
            return true;
        }

        private void OnPointChanged(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                textBox.Text += ".";
                textBox.CaretIndex = textBox.Text.Length;
            }
            UpdateCommands();
        }

        public ICommand KeyCommand
        {
            get { return new DelegateCommand(OnKeyExcecute, OnKeyCanExcecute); }
        }

        private bool OnKeyCanExcecute(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                return !(HasPoint(textBox.Text) && Condition1(textBox.Text)) && textBox.Text.Length < MaxDigits;
            }
            return true;
        }

        private void OnKeyExcecute(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                textBox.Text = IsZero(textBox.Text) ? (string) o : textBox.Text += o;
                textBox.CaretIndex = textBox.Text.Length;
            }
            UpdateCommands();
        }

        public ICommand ZeroCommand
        {
            get { return new DelegateCommand(OnZeroExecute, OnZeroCanExecute); }
        }

        private bool OnZeroCanExecute(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                return !(IsZero(textBox.Text) || (HasPoint(textBox.Text) && Condition1(textBox.Text))) && textBox.Text.Length < MaxDigits;
            }
            return true;
        }

        private void OnZeroExecute(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                textBox.Text = textBox.Text + "0";
                textBox.CaretIndex = textBox.Text.Length;
            }
            UpdateCommands();
        }


        public ICommand ClearCommand
        {
            get { return new DelegateCommand(OnClearExecute, OnClearCanExecute); }
        }

        private bool OnClearCanExecute(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                return !IsZero(textBox.Text);
            }
            return true;
        }

        private void OnClearExecute(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                textBox.Text = "0";
            }
            UpdateCommands();
        }

        public ICommand BackspaceCommand
        {
            get { return new DelegateCommand(OnBackspaceExecute, OnBackspaceCanExecute); }
        }

        private bool OnBackspaceCanExecute(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                return !IsZero(textBox.Text);
            }
            return true;
        }

        private void OnBackspaceExecute(object o)
        {
            var textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                textBox.Text = textBox.Text.Length > 1 ? textBox.Text.Remove(textBox.Text.Length - 1) : "0";
                textBox.CaretIndex = textBox.Text.Length;
            }
            UpdateCommands();
        }

        public static bool IsZero(string text)
        {
            return text == "0";
        }

        public static bool HasPoint(string text)
        {
            return text.Contains(".");
        }

        public bool Condition1(string text)
        {
            return text.Length - text.LastIndexOf(".", StringComparison.Ordinal) > DigitsAfterDecimalPoint;
        }

        public bool AllowDecimalPoint
        {
            get { return DigitsAfterDecimalPoint > 0; }
        }

        public string ReturnValue
        {
            get { return _returnValue; }
            set
            {
                if (value == _returnValue) return;
                _returnValue = value;
                OnPropertyChanged();
                UpdateCommands();
            }
        }

        public string Quantity
        {
            get { return _quantity; }
            set
            {
                if (value == _quantity) return;
                _quantity = value;
                OnPropertyChanged();
                UpdateCommands();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateCommands(object sender, RoutedEventArgs routedEventArgs)
        {
            UpdateCommands();
        }

        public void UpdateCommands()
        {
            OnPropertyChanged("KeyCommand");
            OnPropertyChanged("PointCommand");
            OnPropertyChanged("ZeroCommand");
            OnPropertyChanged("ClearCommand");
            OnPropertyChanged("BackspaceCommand");
        }
    }
}