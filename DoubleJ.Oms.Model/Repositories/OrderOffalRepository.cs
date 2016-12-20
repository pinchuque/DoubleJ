using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class OrderOffalRepository : GenericRepository<OrderOffal>, IOrderOffalRepository
    {
        public OrderOffalRepository(IOmsContext context) : base(context)
        {
        }
    }
}