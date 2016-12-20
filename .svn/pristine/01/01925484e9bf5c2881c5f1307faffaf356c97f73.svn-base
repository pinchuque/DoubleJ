using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class CustomerProductDataRepository : ICustomerProductDataRepository
    {
        private readonly IOmsContext _context;

        public CustomerProductDataRepository(IOmsContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomerProductData> GetByProduct(int productId)
        {
           return _context.CustomerProductData.Where(cpc => cpc.ProductId == productId);
        }
        public IEnumerable<CustomerProductData> GetByCustomer(int customerId)
        {
            return _context.CustomerProductData.Where(x => x.CustomerId == customerId);
        }

        public void Add(CustomerProductData customerProductData)
        {
            _context.CustomerProductData.Add(customerProductData);
        }

        public void Remove(CustomerProductData customerProductData)
        {
            _context.CustomerProductData.Remove(customerProductData);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void AddRange(List<CustomerProductData> customerProductListData)
        {
            _context.BulkInsert(customerProductListData);
        }

    }
}
