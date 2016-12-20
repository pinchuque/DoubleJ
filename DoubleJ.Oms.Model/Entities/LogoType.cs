using System.Collections.Generic;
using DoubleJ.Oms.Model.Definitions;

namespace DoubleJ.Oms.Model.Entities
{
    public class LogoType : IEntity
    {
        public LogoType()
        {
            Customer = new List<Customer>();
            Order = new List<Order>();
        }

        public OmsLogoType Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Order> Order { get; set; }

        public int GetId()
        {
            return (int) Id;
        }
    }
}