using System.Collections.Generic;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class TrimCutRepository : GenericRepository<TrimCut>, ITrimCutRepository
    {
        public TrimCutRepository(IOmsContext context) : base(context)
        {
        }

        public override IEnumerable<TrimCut> GetAll()
        {
            return FindAndSort(trimCut => trimCut.SortOrder);
        }
    }
}
