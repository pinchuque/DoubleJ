using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;


namespace DoubleJ.Oms.Model.Repositories
{
    public class BoxSizeRepository : GenericRepository<BoxSize>, IBoxSizeRepository
    {
        public BoxSizeRepository(IOmsContext context)
            : base(context)
        {
        }
    }
}