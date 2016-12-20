using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Model.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class CustomerProductCodeRepository : ICustomerProductCodeRepository
    {
        private readonly IOmsContext _context;

        public CustomerProductCodeRepository(IOmsContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomerProductCode> GetByProduct(int productId)
        {
           return _context.CustomerProductCode.Where(cpc => cpc.ProductId == productId);
        }

        public void Add(CustomerProductCode customerProductCode)
        {
            _context.CustomerProductCode.Add(customerProductCode);
        }

        public void Remove(CustomerProductCode customerProductCode)
        {
            _context.CustomerProductCode.Remove(customerProductCode);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
