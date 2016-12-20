using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using DoubleJ.Oms.LabelManager.Annotations;

using Telerik.Windows.Controls;


namespace DoubleJ.Oms.LabelManager.Models
{
    public class OrdersConstructorViewModel : INotifyPropertyChanged
    {
        private string _productNameHeader;

        public string ProductNameHeader
        {
            get { return _productNameHeader; }
            set
            {
                if (value == _productNameHeader) return;
                _productNameHeader = value;
                OnPropertyChanged();
            }
        }

        public string QtyHeader { get; set; }
        public string WeightHeader { get; set; }
        public string ShipToHeader { get; set; }

        public BindingList<OrderConstructorViewModel> Orders { get; set; }
        public BindingList<OrderConstructorViewModel> Constructor { get; set; }
        public BindingList<SelectListItemModel> Locations { get; set; }

        public ICommand Add
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    var source = (OrderConstructorViewModel) o;
                    Orders.Add(new OrderConstructorViewModel
                    {
                        ProductName = source.ProductName,
                        Qty = source.Qty,
                        ShipTo = source.ShipTo,
                        Weight = source.Weight
                    });
                }, o =>
                {
                    var source = (OrderConstructorViewModel) o;
                    return source != null && source.Weight > 0 && source.Qty > 0;
                });
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