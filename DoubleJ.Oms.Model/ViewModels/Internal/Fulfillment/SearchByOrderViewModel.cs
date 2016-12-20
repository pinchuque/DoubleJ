using System.ComponentModel;

namespace DoubleJ.Oms.Model.ViewModels.Internal.Fulfillment
{
    public class SearchByOrderViewModel
    {
        public int OrderId { get; set; }
        [DisplayName("Owner Name")]
        public string CustomerName { get; set; }
        public string Status { get; set; }
    }
}
