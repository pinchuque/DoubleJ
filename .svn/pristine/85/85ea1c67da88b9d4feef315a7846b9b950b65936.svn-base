using System;
using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IOmsContext context)
            : base(context)
        {
        }

        public IEnumerable<Product> GetByCustomer(int customerId)
        {
            return Context.CustomerProductData.Where(cpc => cpc.CustomerId == customerId).Select(cpc => cpc.Product).Where(x=>x.IsOffal==false);
        }

        public IEnumerable<Product> GetByCustomerType(OmsCustomerType? customerType)
        {
            return Query().Where(cpc => (cpc.CustomerTypeId == customerType || !customerType.HasValue) && cpc.IsOffal == false);
        }

        public IEnumerable<Product> GetOffalProducts()
        {
            return Context.Product.Where(cpc => cpc.IsOffal);
        }

        public override IEnumerable<Product> GetAll()
        {
            return Context.Product.Where(cpc => cpc.IsOffal==false);
        }


        public IQueryable<Product> GetAllQueryable()
        {
            return Context.Product.Where(cpc => cpc.IsOffal == false);
        }
        public override Product Get(int productId)
        {
            var product = Context.Product.Find(productId);
            if (!product.IsOffal) return product;
            throw new Exception("This product doesn't exist");
        }

        public Product GetOffalProduct(int productId)
        {
            var product = Context.Product.Find(productId);
            if (product.IsOffal) return product;
            throw new Exception("This product doesn't exist");
        }
    }
}
