using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetByCustomer(int customerId);
        IEnumerable<Product> GetByCustomerType(OmsCustomerType? customerType);
        IEnumerable<Product> GetOffalProducts();
        Product GetOffalProduct(int productId);
        IQueryable<Product> GetAllQueryable();
    }
}