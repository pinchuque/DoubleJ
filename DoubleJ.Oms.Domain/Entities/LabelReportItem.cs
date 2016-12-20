using System.Collections.Generic;

namespace DoubleJ.Oms.Domain.Entities
{
    public class LabelReportItem
    {
        public string CustomerName { get; set; }
        public List<ProductQuantityItem> Products { get; set; }

        public LabelReportItem()
        {
            Products = new List<ProductQuantityItem>();
        }
    }
}