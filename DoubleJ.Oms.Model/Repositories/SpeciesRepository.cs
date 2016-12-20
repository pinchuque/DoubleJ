using System.Collections.Generic;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class SpeciesRepository : GenericRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(IOmsContext context) : base(context)
        {
        }

        public override IEnumerable<Species> GetAll()
        {
            return FindAndSort(species => species.SortOrder);
        }

        public IEnumerable<Species> GetSortedByName()
        {
            return FindAndSort(species => species.Name);
        }
    }
}
