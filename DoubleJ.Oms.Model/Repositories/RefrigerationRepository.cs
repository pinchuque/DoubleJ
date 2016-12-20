using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
	public class RefrigerationRepository : GenericRepository<Refrigeration>, IRefrigerationRepository
	{
		public RefrigerationRepository(IOmsContext context) : base(context)
		{
		}
	}
}
