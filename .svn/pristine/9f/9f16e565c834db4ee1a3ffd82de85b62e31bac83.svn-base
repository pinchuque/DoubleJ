using System.Collections.Generic;
using DoubleJ.Oms.Model.Definitions;

namespace DoubleJ.Oms.Model.Entities
{
    public class Status : IEntity
    {
        public Status()
        {
            Order = new List<Order>();
        }

        public OmsStatus Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public int GetId()
        {
            return (int) Id;
        }
    }
}