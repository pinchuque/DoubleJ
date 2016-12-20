using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class CaseTypeRepository : GenericRepository<CaseType>, ICaseTypeRepository
    {
        public CaseTypeRepository(IOmsContext context) : base(context)
        {
        }
    }
}