using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using DoubleJ.Oms.LabelManager.Annotations;

using Telerik.Windows.Controls;


namespace DoubleJ.Oms.LabelManager.Models
{
    public class NumericKeyboardViewModel : INotifyPropertyChanged
    {
        private string _returnValue;

        public int MaxDigits { get; set; }
        public int DigitsAfterDecimalPoint { get; set; }

        public NumericKeyboardViewModel()
        {
            DigitsAfterDecimalPoint = 3;
            MaxDigits = 10;
            ReturnValue = "0";
        }

        public ICommand PointCommand
        {
            get { return new DelegateCommand(o => ReturnValue += ".", o => AllowDecimalPoint && !HasPoint && ReturnValue.Length < MaxDigits - 1); }
        }

        public ICommand KeyCommand
        {
            get
            {
                return new DelegateCommand(o => ReturnValue = IsZero ? (string) o : ReturnValue += o,
                    o => !(HasPoint && Condition1) && ReturnValue.Length < MaxDigits);
            }
        }

        public ICommand ZeroCommand
        {
            get
            {
                return new DelegateCommand(o => ReturnValue = ReturnValue + "0",
                    o => !(IsZero || (HasPoint && Condition1)) && ReturnValue.Length < MaxDigits);
            }
        }

        public ICommand ClearCommand
        {
            get { return new DelegateCommand(o => ReturnValue = "0", o => !IsZero); }
        }

        public ICommand BackspaceCommand
        {
            get
            {
                return
                    new DelegateCommand(
                        o => ReturnValue = ReturnValue.Length > 1 ? ReturnValue.Remove(ReturnValue.Length - 1) : "0",
                        o => !IsZero);
            }
        }

        public bool IsZero
        {
            get { return ReturnValue == "0"; }
        }

        public bool HasPoint
        {
            get { return ReturnValue.Contains("."); }
        }

        public bool Condition1
        {
            get
            {
                return ReturnValue.Length - ReturnValue.LastIndexOf(".", StringComparison.Ordinal) >
                       DigitsAfterDecimalPoint;
            }
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
                OnPropertyChanged("PointCommand");
                OnPropertyChanged("ZeroCommand");
                OnPropertyChanged("ClearCommand");
                OnPropertyChanged("BackspaceCommand");
                OnPropertyChanged("KeyCommand");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}