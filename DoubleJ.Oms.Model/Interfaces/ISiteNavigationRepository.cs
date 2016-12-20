using System.Collections.Generic;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface ISiteNavigationRepository : IGenericRepository<SiteNavigation>
    {
        IEnumerable<SiteNavigation> GetAllActive();
    }
}