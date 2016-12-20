using System.Collections.Generic;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Domain.Entities
{
    public class CustomerType : IEntity
    {
        public CustomerType()
        {
            Customer = new List<Customer>();
            CaseSizes = new List<CaseSize>();
        }

        public OmsCustomerType Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<CaseSize> CaseSizes { get; set; }

        public int GetId()
        {
            return (int)Id;
        }
    }
}
