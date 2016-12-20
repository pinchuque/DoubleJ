

using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class PackageSizeRepository : GenericRepository<PackageSize>, IPackageSizeRepository
    {
        public PackageSizeRepository(IOmsContext context)
            : base(context)
        {
        }
    }
}
