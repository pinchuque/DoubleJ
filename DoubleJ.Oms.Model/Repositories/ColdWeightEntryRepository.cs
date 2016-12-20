using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class ColdWeightEntryRepository : GenericRepository<ColdWeightEntry>, IColdWeightEntryRepository
    {
        public ColdWeightEntryRepository(IOmsContext context)
            : base(context)
        {
        }

        public ColdWeightEntry GetByOrderId(int orderId)
        {
            
            return Context.ColdWeightEntry.FirstOrDefault(cwe => cwe.OrderId == orderId);
        }
    }
}
