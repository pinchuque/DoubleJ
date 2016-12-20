using System.ComponentModel;
using System.Runtime.CompilerServices;

using DoubleJ.Oms.LabelManager.Annotations;


namespace DoubleJ.Oms.LabelManager.Models
{
    public class OrderConstructorViewModel : INotifyPropertyChanged
    {
        private int _id;
        private int _locationId;
        private int _orderDetailId;
        private int _productId;
        private string _productName;
        private int _qty;
        private string _shipTo;
        private decimal _weight;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value == _productId) return;
                _productId = value;
                OnPropertyChanged();
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (value == _productName) return;
                _productName = value;
                OnPropertyChanged();
                OnPropertyChanged("Add");
            }
        }

        public int Qty
        {
            get { return _qty; }
            set
            {
                if (value == _qty) return;
                _qty = value;
                OnPropertyChanged();
                OnPropertyChanged("Add");
            }
        }

        public decimal Weight
        {
            get { return _weight; }
            set
            {
                if (value == _weight) return;
                _weight = value;
                OnPropertyChanged();
                OnPropertyChanged("Add");
            }
        }

        public string ShipTo
        {
            get { return _shipTo; }
            set
            {
                if (value == _shipTo) return;
                _shipTo = value;
                OnPropertyChanged();
                OnPropertyChanged("Add");
            }
        }

        public int LocationId
        {
            get { return _locationId; }
            set
            {
                if (value == _locationId) return;
                _locationId = value;
                OnPropertyChanged();
            }
        }

        public int OrderDetailId
        {
            get { return _orderDetailId; }
            set
            {
                if (value == _orderDetailId) return;
                _orderDetailId = value;
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