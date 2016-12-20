using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.Models;
using DoubleJ.Oms.Model.ViewModels.Internal;


namespace DoubleJ.Oms.Model.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IOmsContext context)
            : base(context)
        {
        }

        public IEnumerable<Customer> GetAllActive()
        {
            return FindAll(customer => customer.IsActive && !customer.IsArchived).OrderBy(customer => customer.Name);
        }

        public IEnumerable<Customer> GetActiveByName(string customerName)
        {
            return FindAll(customer => customer.IsActive && !customer.IsArchived && customer.Name.ToLowerInvariant().Contains(customerName.ToLowerInvariant())).OrderBy(customer => customer.Name);
        }

        public List<CustomerSearchResult> Search(CustomerSearchViewModel model)
        {
            var customers = SearchCustomers(model.Name, model.Product, model.Order, model.CustomerType).ToArray();
            var result = customers
                .Select(customer => new CustomerSearchResult
                {
                    CustomerId = customer.Id,
                    CustomerName = customer.Name,
                    Location = GetLocation(customer.CustomerLocation),
                    CustomerType = customer.CustomerTypeId
                })
                .ToList();

            return result;
        }

        public IEnumerable<Customer> SearchCustomers(string name, string productCode, int? orderNumber, OmsCustomerType? customerType)
        {
            var customers = Query().Where(x => !x.IsArchived).Include(x => x.CustomerLocation);

            if (!string.IsNullOrEmpty(name))
            {
                var lowerCaseName = name.ToLower();
                customers = customers.Where(x => x.Name.ToLower().Contains(lowerCaseName));
            }

            if (!string.IsNullOrEmpty(productCode))
            {
                return customers.Where(x => x.CustomerProductData.Any(z => z.ProductCode == productCode)).ToArray();
            }

            if (orderNumber.HasValue)
            {
                return customers.Where(x => x.Order.Any(z => z.Id == orderNumber.Value)).ToArray();
            }

            if (customerType != null)
            {
                return customers.Where(x => x.CustomerTypeId == customerType).ToArray();
            }

            return customers.ToArray();
        }

        protected string GetLocation(ICollection<CustomerLocation> locations)
        {
            return locations == null || locations.Count == 0
                ? string.Empty
                : string.Join(";", locations.Select(location => location.Name).ToArray());
        }

        public IEnumerable<CustomerProductItem> GetProductDataByCustomer(int customerId)
        {
            var productQuery = Context.CustomerProductData
                .Where(x => x.CustomerId == customerId)
                .Select(x => new CustomerProductItem
                {
                    Id = x.Product.Id,
                    Name = x.Product.EnglishDescription,
                    Upc = x.Product.Upc,
                    Gtin = x.Gtin,
                    PricePerPound = x.PricePerPound,
                    ProductCode = x.ProductCode,
                    ProductDescription = x.ProductDescription,
                    BagSize = x.BagSizeEntity,
                    BoxSize = x.BoxSizeEntity,
                    IsSelected = true,
                });

            List<CustomerProductItem> cpi = new List<CustomerProductItem>();
            foreach (var x in productQuery)
            {
                cpi.Add(new CustomerProductItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    BagSize = x.BagSize != null ? new CaseSize() { Name = x.BagSize.Name, Id = x.BagSize.Id } : null,
                    BoxSize = x.BoxSize != null ? new CaseSize() { Name = x.BoxSize.Name, Id = x.BoxSize.Id } : null,
                    ProductCode = x.ProductCode,
                    PricePerPound = x.PricePerPound,
                    IsSelected = x.IsSelected,
                    Gtin = x.Gtin,
                });
            }
            return cpi;
        }

        public IEnumerable<ProductCodeItem> GetCustomersProductData(int productId)
        {
            var customerProducts = Context.CustomerProductData
                .Where(cpd => cpd.ProductId == productId )
                .Join(Context.Customer, x => x.CustomerId, x => x.Id, (model, customer) => new
                {
                    CustomerProductData = model,
                    Customer = customer
                })
                .Select(x => new ProductCodeItem
                {
                    Id = x.Customer.Id,
                    Name = x.Customer.Name,

                    IsSelected = true,
                   // BoxSize = x.CustomerProductData.BoxSizeEntity,
                   // BagSize = x.CustomerProductData.BagSizeEntity,
                    ProductCode = x.CustomerProductData.ProductCode,
                    Gtin = x.CustomerProductData.Gtin,
                    PricePerPound = x.CustomerProductData.PricePerPound,
                    ProductDescription = x.CustomerProductData.ProductDescription,
                });

            var queryable = customerProducts.Select(cp => cp.Id);
            var product = Context.Product.Single(p => p.Id == productId);
            var customers = Context.Customer
                .Where(c => !queryable.Contains(c.Id) && !c.IsArchived)
                .Select(x => new ProductCodeItem
                {
                    Id = x.Id,
                    Name = x.Name,

                    IsSelected = false,

                    ProductCode = product.Code,
                    Gtin = product.Gtin,
                    PricePerPound = product.PricePerPound,
                    ProductDescription = product.EnglishDescription,
                });

            return customerProducts.Concat(customers).OrderBy(p => p.Name);

            //var productQuery = Context.CustomerProductData
            //    .Join(Context.Product, cpd => cpd.ProductId, p => p.Id, (productData, product) => new
            //    {
            //        CustomerProductData = productData,
            //        Product = product
            //    })
            //    .Join(Context.OrderDetail, x => x.CustomerProductData.ProductId, x => x.ProductId, (model, orderDetail) => new
            //    {
            //        model.Product,
            //        model.CustomerProductData,
            //        OrderDetail = orderDetail
            //    })
            //    .Join(Context.Order, x => x.OrderDetail.OrderId, x => x.Id, (model, order) => new
            //    {
            //        model.Product,
            //        model.CustomerProductData,
            //        model.OrderDetail,
            //        Order = order
            //    })
            //    .Join(Context.Customer, x => x.CustomerProductData.CustomerId, x => x.Id, (model, customer) => new
            //    {
            //        model.Product,
            //        model.CustomerProductData,
            //        model.OrderDetail,
            //        model.Order,
            //        Customer = customer
            //    })
            //    .Where(x => x.CustomerProductData.ProductId == productId)
            //    .Select(x => new 
            //    {
            //        ProductId = x.Product.Id,
            //        CustomerId = x.Customer.Id,
            //        Name = x.Customer.Name,
            //        Upc = x.Product.Upc,

            //        IsSelected = x.Customer.Order.Any(z => z.OrderDetail.Any(y => y.ProductId == productId)),

            //        ProductCode = x.CustomerProductData.ProductCode,
            //        Gtin = x.CustomerProductData.Gtin,
            //        PricePerPound = x.CustomerProductData.PricePerPound,
            //        ProductDescription = x.CustomerProductData.ProductDescription,
            //    }).Distinct();

            //return productQuery
            //    .Select(x => new ProductCodeItem
            //    {
            //        Id = x.ProductId,
            //        Name = x.Name,
            //        Upc = x.Upc,

            //        IsSelected = x.IsSelected,

            //        ProductCode = x.ProductCode,
            //        Gtin = x.Gtin,
            //        PricePerPound = x.PricePerPound,
            //        ProductDescription = x.ProductDescription,
            //    })
            //    .OrderBy(x => x.Name);

            var result = Context.Customer
                .Include(x => x.CustomerProductData)
                .Include(x => x.Order)
                .SelectMany(customer => customer.CustomerProductData.Select(customerProductData => new ProductCodeItem
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    IsSelected = customer.Order.Any(x => x.OrderDetail.Any(y => y.ProductId == productId)),
                    ProductCode = customerProductData.ProductCode,
                    Gtin = customerProductData.Gtin,
                    PricePerPound = customerProductData.PricePerPound,
                    ProductDescription = customerProductData.ProductDescription,
                }))
                .Distinct()
                .OrderBy(x => x.Name);

            return result;

            //var customers = Context
            //    .Product
            //    .Join(Context.OrderDetail, x => x.Id, x => x.ProductId, (product, orderDetail) => new
            //    {
            //        Product = product,
            //        OrderDetail = orderDetail,
            //    })
            //    .Join(Context.Order, x => x.OrderDetail.OrderId, x => x.Id, (model, order) => new
            //    {
            //        model.Product,
            //        model.OrderDetail,
            //        Order = order,
            //    })
            //    .Join(Context.Customer, x => x.Order.CustomerId, x => x.Id, (model, customer) => new
            //    {
            //        model.Product,
            //        model.OrderDetail,
            //        model.Order,
            //        Customer = customer,
            //    })
            //    .Where(x => x.Product.Id == productId)
            //    .Select(x => x.Customer)
            //    .Distinct();

            //var result = customers
            //    .GroupJoin(Context.CustomerProductData.Where(x => x.ProductId == productId), x => x.Id, x => x.CustomerId, (customer, customerProductData) => new
            //    {
            //        Customer = customer,
            //        CustomerProductData = customerProductData
            //    })
            //    .SelectMany(x => x.CustomerProductData.DefaultIfEmpty(), (x, customerProductData) => new ProductCodeItem
            //    {
            //        Id = x.Customer.Id,
            //        Name = x.Customer.Name,
            //        IsSelected = true,
            //        ProductCode = customerProductData.ProductCode,
            //        Gtin = customerProductData.Gtin,
            //        PricePerPound = customerProductData.PricePerPound,
            //        ProductDescription = customerProductData.ProductDescription,
            //    })
            //    .OrderBy(x => x.Name);

            //return result.ToArray();
        }

        public IEnumerable<ProductCodeItem> GetCustomersProductData()
        {
            var result = Context.Customer
                .Include(x => x.CustomerProductData)
                .SelectMany(customer => customer.CustomerProductData.Select(customerProductData => new ProductCodeItem
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    ProductCode = customerProductData.ProductCode,
                    Gtin = customerProductData.Gtin,
                    PricePerPound = customerProductData.PricePerPound,
                    ProductDescription = customerProductData.ProductDescription,
                }))
                .Distinct()
                .OrderBy(x => x.Name);

            return result;
        }

        public IEnumerable<ProductCodeItem> GetCustomerProductItems(int productId)
        {
            var result = Context.Customer
                .GroupJoin(Context.CustomerProductData.Where(x => x.ProductId == productId), x => x.Id, x => x.CustomerId, (customer, customerProductData) => new
                {
                    Customer = customer,
                    CustomerProductData = customerProductData
                })
                .SelectMany(x => x.CustomerProductData.DefaultIfEmpty(), (x, customerProductData) => new ProductCodeItem
                {
                    Id = x.Customer.Id,
                    Name = x.Customer.Name,
                    IsSelected = x.CustomerProductData.Any(data => data.ProductId == productId),
                    ProductCode = customerProductData.ProductCode,
                    Gtin = customerProductData.Gtin,
                    PricePerPound = customerProductData.PricePerPound,
                    ProductDescription = customerProductData.ProductDescription,
                });

            return result.ToList();
        }
    }
}