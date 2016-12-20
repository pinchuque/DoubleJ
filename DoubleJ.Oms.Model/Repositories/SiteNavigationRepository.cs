using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class SiteNavigationRepository : GenericRepository<SiteNavigation>, ISiteNavigationRepository
    {
        public SiteNavigationRepository(IOmsContext context) : base(context)
        {
        }

        public IEnumerable<SiteNavigation> GetAllActive()
        {
            return FindAll(nav => nav.IsActive).OrderBy(nav => nav.SortOrder);
        }
    }
}
