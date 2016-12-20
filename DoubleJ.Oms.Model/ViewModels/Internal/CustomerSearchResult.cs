using System.ComponentModel;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class CustomerSearchResult
    {
        public int CustomerId { get; set; }
        [DisplayName("Owner Name")]
        public string CustomerName { get; set; }
        [DisplayName("Owner's Customers")]
        public string Location { get; set; }
        [DisplayName("Owner Type")]
        public OmsCustomerType CustomerType { get; set; }
    }
    
}