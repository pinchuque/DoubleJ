using System.Collections.Generic;


namespace DoubleJ.Oms.Domain.Entities
{
    public class Region : EntityBase
    {
        public Region()
        {
            OrderBornRegion = new List<Order>();
            OrderProductOfRegion = new List<Order>();
            OrderRaisedRegion = new List<Order>();
            OrderSlaughteredRegion = new List<Order>();
        }

        public string Name { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Order> OrderBornRegion { get; set; }
        public virtual ICollection<Order> OrderProductOfRegion { get; set; }
        public virtual ICollection<Order> OrderRaisedRegion { get; set; }
        public virtual ICollection<Order> OrderSlaughteredRegion { get; set; }
    }
}