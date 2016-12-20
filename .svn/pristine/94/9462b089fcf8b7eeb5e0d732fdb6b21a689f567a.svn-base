using System.ComponentModel;
using System.Runtime.CompilerServices;

using DoubleJ.Oms.LabelManager.Annotations;


namespace DoubleJ.Oms.LabelManager.Models
{
    public class Headers : INotifyPropertyChanged
    {
        private BindingList<string> _bagBox;
        private BindingList<string> _bagBoxShort;

        public BindingList<string> BagBox
        {
            get { return _bagBox; }
            set
            {
                if (Equals(value, _bagBox)) return;
                _bagBox = value;
                OnPropertyChanged();
            }
        }

        public BindingList<string> BagBoxShort
        {
            get { return _bagBoxShort; }
            set
            {
                if (Equals(value, _bagBoxShort)) return;
                _bagBoxShort = value;
                OnPropertyChanged();
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