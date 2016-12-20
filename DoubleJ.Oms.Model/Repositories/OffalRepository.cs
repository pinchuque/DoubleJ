using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class OffalRepository : GenericRepository<Offal>, IOffalRepository
    {
        public OffalRepository(IOmsContext context) : base(context)
        {
        }
    }
}