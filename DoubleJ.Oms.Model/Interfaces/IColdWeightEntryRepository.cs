using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface IColdWeightEntryRepository : IGenericRepository<ColdWeightEntry>
    {
        ColdWeightEntry GetByOrderId(int orderId);
    }
}
