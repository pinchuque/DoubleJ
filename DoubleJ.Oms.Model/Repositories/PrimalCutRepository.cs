using System.Collections.Generic;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class PrimalCutRepository : GenericRepository<PrimalCut>, IPrimalCutRepository
    {
        public PrimalCutRepository(IOmsContext context) : base(context)
        {
        }

        public override IEnumerable<PrimalCut> GetAll()
        {
            return FindAndSort(primalCut => primalCut.SortOrder);
        }
    }
}
