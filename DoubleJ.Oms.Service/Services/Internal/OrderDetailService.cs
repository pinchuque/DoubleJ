using System;
using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Service.Interfaces;


namespace DoubleJ.Oms.Service.Services.Internal
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly ICustomerLocationRepository _customerLocationRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISpeciesRepository _speciesRepository;
        private readonly ICustomerProductDataRepository _customerProductDataRepository;


        public OrderDetailService(IOrderDetailRepository orderDetailRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            ICustomerLocationRepository customerLocationRepository, ISpeciesRepository speciesRepository,
            ICustomerProductDataRepository customerProductDataRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerLocationRepository = customerLocationRepository;
            _speciesRepository = speciesRepository;
            _customerProductDataRepository = customerProductDataRepository;
        }

        public OrderDetailViewModel Get(int orderId, OmsEntryMode mode)
        {
            var order = _orderRepository.Get(orderId);

            var viewModel = new OrderDetailViewModel
            {
                OmsEntryMode = mode,
                OrderId = orderId,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer.Name,
                StatusName = order.Status.Name,
                RequestedProcessDate = order.RequestedProcessDate,
                ExpectedHeadNumber = order.ExpectedHeadNumber,
                BagEnable = order.BagEnable,
            };

            return viewModel;
        }

        public IEnumerable<OrderDetailItem> GetItems(int orderId)
        {
            var orderDetails = _orderDetailRepository
                .GetAllByOrder(orderId)
                .ToArray();
            List<OrderDetailItem> orderDetailitems = new List<OrderDetailItem>();
            foreach (var orderDetail in orderDetails)
            {
                var orderDetailItem = new OrderDetailItem()
                {
                    Id = orderDetail.Id,
                    OrderId = orderDetail.OrderId,
                    PieceQuantity = orderDetail.PieceQuantity,
                    ProductId = orderDetail.ProductId,
                    CustomerLocationId = orderDetail.CustomerLocationId,
                    CustomerLocation = new OrderDetailCustomerLocationItem
                    {
                        CustomerLocationId = orderDetail.CustomerLocationId,
                        CustomerLocationName = orderDetail.CustomerLocation.Name
                    },
                    Product = new OrderDetailProductItem
                    {
                        ProductId = orderDetail.ProductId,
                        ProductName = ProductService.GetFormattedProductName(orderDetail.Product)
                    },
                };
                var product = orderDetail.Product;
                var items =
                    product.CustomerProductData.Where(x => x.CustomerId == orderDetail.Order.CustomerId);
                var customerProduct = items.FirstOrDefault();
                if (customerProduct != null)
                {
                    orderDetailItem.BagPieceQuantity = customerProduct.PieceQuantity.HasValue
                        ? customerProduct.PieceQuantity.GetValueOrDefault()
                        : 0;
                    orderDetailItem.BoxBagQuantity = customerProduct.BoxQuantity.HasValue
                        ? customerProduct.BoxQuantity.GetValueOrDefault()
                        : 0;
                }
                else
                {
                    orderDetailItem.BagPieceQuantity = orderDetail.Product.BagPieceQuantity;
                    orderDetailItem.BoxBagQuantity = orderDetail.Product.BoxBagQuantity;        
                }
                orderDetailitems.Add(orderDetailItem);
            }

            return orderDetailitems;
        }

        public IEnumerable<OrderDetailProductItem> GetAllProducts(Order order)
        {
            var activeSpecies = order.ColdWeightEntries.SelectMany(x => x.ColdWeightEntryDetails).ToList();
            var species = activeSpecies.Select(x => x.AnimalLabel.Species.BaseSpecies);
            var result = _productRepository
                .GetAll()
                .Where(x => x.IsActive && x.CustomerTypeId == order.Customer.CustomerTypeId && species.Contains(x.Species.BaseSpecies))
                .Select(prod => new OrderDetailProductItem
                {
                    ProductId = prod.Id,
                    ProductName = ProductService.GetFormattedProductName(prod)
                })
                .OrderBy(x => x.ProductName);
            return result;
        }

        public IEnumerable<OrderDetailProductItem> GetProductsByCustomer(int customerId)
        {
            var result = _productRepository
                .GetByCustomer(customerId)
                .Select(prod => new OrderDetailProductItem
                {
                    ProductId = prod.Id,
                    ProductName = ProductService.GetFormattedProductName(prod)
                })
                .OrderBy(x => x.ProductName);

            return result;
        }

        public IEnumerable<OrderDetailCustomerLocationItem> GetCustomerLocations(int customerId)
        {
            var result = _customerLocationRepository
                .FindAll(x => x.CustomerId == customerId)
                .Select(location => new OrderDetailCustomerLocationItem
                {
                    CustomerLocationId = location.Id,
                    CustomerLocationName = location.Name
                });

            return result;
        }

        private void FillOrderDetail(OrderDetail orderDetail, OrderDetailItem orderDetailItem)
        {
            orderDetail.ProductId = orderDetailItem.ProductId;
            orderDetail.CustomerLocationId = orderDetailItem.CustomerLocationId;
            var customer = _orderRepository.Get(orderDetail.OrderId);
            var customerProduct = _customerProductDataRepository.GetByProduct(orderDetailItem.ProductId).FirstOrDefault(x=>x.CustomerId == customer.CustomerId);
            if (customerProduct != null)
            {
                if (customerProduct.BoxQuantity.HasValue)
                {
                    orderDetailItem.BagPieceQuantity = customerProduct.PieceQuantity.GetValueOrDefault();
                }
                if (customerProduct.PieceQuantity.HasValue)
                {
                    orderDetailItem.BoxBagQuantity = customerProduct.BoxQuantity.GetValueOrDefault();
                }
            }
            orderDetail.PieceQuantity = Math.Abs(orderDetailItem.PieceQuantity);
            orderDetail.BoxQuantity = CalculateBoxQuantity(Math.Abs(orderDetailItem.PieceQuantity),
                Math.Abs(orderDetailItem.BagPieceQuantity), Math.Abs(orderDetailItem.BoxBagQuantity));

        }

        public int Add(OrderDetailItem orderDetailItem)
        {
            var orderDetail = new OrderDetail {OrderId = orderDetailItem.OrderId};

            FillOrderDetail(orderDetail, orderDetailItem);

            _orderDetailRepository.Add(orderDetail);
            _orderDetailRepository.Save();

            return orderDetail.Id;
        }

        public void Edit(OrderDetailItem orderDetailItem)
        {
            var orderDetail = _orderDetailRepository.Get(orderDetailItem.Id);

            FillOrderDetail(orderDetail, orderDetailItem);

            _orderDetailRepository.Save();
        }

        public void Delete(OrderDetailItem orderDetailItem)
        {
            Delete(orderDetailItem.Id);
        }

        public void Delete(int orderDetailId)
        {
            var orderDetail = _orderDetailRepository.Get(orderDetailId);
            _orderDetailRepository.Remove(orderDetail);
            _orderDetailRepository.Save();
        }

        private int CalculateBoxQuantity(int pieces, int piecesPerBag, int bagsPerBox)
        {
            if (piecesPerBag == 0 || bagsPerBox == 0) return 0;

            var bagQuantity = (pieces + piecesPerBag - 1) / piecesPerBag;
            return (bagQuantity + bagsPerBox) / bagsPerBox;
        }
        
    }
}