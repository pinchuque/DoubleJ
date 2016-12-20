using System.Collections.Generic;

namespace DoubleJ.Oms.Model.Entities
{
    public class Offal : EntityBase
    {
        public Offal()
        {
            OrderOffals = new List<OrderOffal>();
        }

        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<OrderOffal> OrderOffals { get; set; }
    }
}