using System;
using System.ComponentModel.DataAnnotations;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class OrderSearchViewModel : SearchViewModel
    {
        [Display(Name="Owner")]
        public int? CustomerId { get; set; }

        [Display(Name="Order Number")]
        public int? OrderId { get; set; }

        [Display(Name = "Order Status")]
        public OmsStatus? StatusId { get; set; }

        [Display(Name="Owner Type")]
        public OmsCustomerType? CustomerType { get; set; }
        public string CustomerName { get; set; }
    }

    public class OrderSearchResultItem
    {
        public int OrderId { get; set; }
        [Display(Name="Owner")]
        public string CustomerName { get; set; }
        [Display(Name="Status")]
        public string StatusName { get; set; }
        [Display(Name="Req. Process Date")]
        public DateTime? RequestedProcessDate { get; set; }
        public DateTime? ProcessDate { get; set; }
    }
}
