using System.Collections.Generic;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface ICustomerProductDataRepository
    {
        IEnumerable<CustomerProductData> GetByProduct(int productId);
        void Add(CustomerProductData customerProductData);
        void Remove(CustomerProductData customerProductData);
        void Save();
        void AddRange(List<CustomerProductData> customerProductListData);
        IEnumerable<CustomerProductData> GetByCustomer(int customerId);
    }
}