using System.Collections.Generic;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface ICustomerLocationRepository : IGenericRepository<CustomerLocation>
    {
        bool IsExistCustomerLocationEmail(string email, int customerId, int locationId);

        ICollection<CustomerLocation> GetCustomerLocation(int orderId);

    }
}