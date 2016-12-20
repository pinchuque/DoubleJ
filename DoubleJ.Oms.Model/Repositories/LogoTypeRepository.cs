using System.Collections.Generic;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class LogoTypeRepository : GenericRepository<LogoType>, ILogoTypeRepository
    {
        public LogoTypeRepository(IOmsContext context) : base(context)
        {
        }

        public override IEnumerable<LogoType> GetAll()
        {
            return FindAndSort(logoType => logoType.SortOrder);
        }
    }
}
