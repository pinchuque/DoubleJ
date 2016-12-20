using System.Collections.Generic;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface ICustomerProductCodeRepository
    {
        IEnumerable<CustomerProductCode> GetByProduct(int productId);
        void Add(CustomerProductCode customerProductCode);
        void Remove(CustomerProductCode customerProductCode);
        void Save();
    }
}