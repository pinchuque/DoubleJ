using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class RibTypeRepository : GenericRepository<RibType>, IRibTypeRepository
    {
        public RibTypeRepository(IOmsContext context)
            : base(context)
        {
        }
    }
}
