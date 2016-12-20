using System.Collections.Generic;

using DoubleJ.Oms.Domain.Definitions;


namespace DoubleJ.Oms.Domain.Entities
{
    public class LogoType : IEntity
    {
        public LogoType()
        {
            Customer = new List<Customer>();
        }

        public OmsLogoType Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }

        public int GetId()
        {
            return (int) Id;
        }
    }
}