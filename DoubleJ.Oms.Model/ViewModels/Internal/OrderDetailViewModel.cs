using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public enum OmsEntryMode
    {
        Add,
        Edit
    };


    public class OrderDetailViewModel
    {
        public OmsEntryMode OmsEntryMode { get; set; }

        [Display(Name = "Order Number")]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Owner")]
        public string CustomerName { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Display(Name = "Requested Process Date")]
        public DateTime RequestedProcessDate { get; set; }

        [Display(Name = "Expected Head Number")]
        public int ExpectedHeadNumber { get; set; }

        public bool BagEnable { get; set; }
        public bool IsEditable { get; set; }
        public OrderDetailViewModel()
        {
            IsEditable = true;
        }
    }

    public class OrderDetailItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [UIHint("OrderDetailProduct")]
        public OrderDetailProductItem Product { get; set; }

        [Display(Name = "Product")]
        [Required(ErrorMessage = "required")]
        public int ProductId { get; set; }


        [Display(Name = "Quantity"), Required(ErrorMessage = "required")]
        [DataType("Quantity")]
        public int PieceQuantity { get; set; }

        [Display(Name = "#Pieces/Bag")]
        [ReadOnly(true)]
        public int BagPieceQuantity { get; set; }

        [Display(Name = "#Bags/Box")]
        [ReadOnly(true)]
        public int BoxBagQuantity { get; set; }


        [Display(Name = "Ship To"), Required(ErrorMessage = "required")]
        public int CustomerLocationId { get; set; }

        public OrderDetailCustomerLocationItem CustomerLocation { get; set; }
    }

    public class OrderDetailProductItem
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
    }
   
    public class OrderDetailCustomerLocationItem : IComparable
    {
        public int? CustomerLocationId { get; set; }
        [DisplayName("Owner's Customer Name")]
        public string CustomerLocationName { get; set; }

        public int CompareTo(object obj)
        {
            return String.Compare(CustomerLocationName, ((OrderDetailCustomerLocationItem)obj).CustomerLocationName, StringComparison.Ordinal);
        }
    }
}
