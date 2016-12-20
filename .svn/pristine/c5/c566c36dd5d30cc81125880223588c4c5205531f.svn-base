using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class CustomerLocationRepository : GenericRepository<CustomerLocation>, ICustomerLocationRepository
    {
        public CustomerLocationRepository(IOmsContext context) : base(context)
        {
        }

        public IEnumerable<CustomerLocation> GetAll(int customerId)
        {
            return FindAll(location => location.CustomerId == customerId);
        }

        public bool IsExistCustomerLocationEmail(string email, int customerId, int locationId)
        {
            return
                Context.CustomerLocation.Where(x => x.CustomerId == customerId)
                    .Any(x => x.Email == email && x.Id != locationId);
        }

        public ICollection<CustomerLocation> GetCustomerLocation(int orderId)
        {
            var firstOrDefault = Context.Order.FirstOrDefault(x => x.Id == orderId);
            if (firstOrDefault != null)
                return firstOrDefault.Customer.CustomerLocation;
            return null;
        }
    }
}
