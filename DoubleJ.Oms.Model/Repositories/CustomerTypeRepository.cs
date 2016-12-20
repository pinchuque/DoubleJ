using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class CustomerTypeRepository : GenericRepository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(IOmsContext context) : base(context)
        {
        }
    }
}