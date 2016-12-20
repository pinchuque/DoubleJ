using System.Collections.Generic;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        public RegionRepository(IOmsContext context) : base(context)
        {
        }

        public override IEnumerable<Region> GetAll()
        {
            return FindAndSort(region => region.SortOrder);
        }
    }
}
