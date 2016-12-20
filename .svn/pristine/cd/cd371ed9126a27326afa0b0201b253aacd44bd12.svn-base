using System.Collections.Generic;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IOrderDetailService
    {
        OrderDetailViewModel Get(int orderId, OmsEntryMode mode);
        IEnumerable<OrderDetailItem> GetItems(int orderId);
        IEnumerable<OrderDetailProductItem> GetProductsByCustomer(int customerId);
        IEnumerable<OrderDetailProductItem> GetAllProducts(Order order);
        IEnumerable<OrderDetailCustomerLocationItem> GetCustomerLocations(int customerId);

        int Add(OrderDetailItem orderDetailItem);
        void Edit(OrderDetailItem orderDetailItem);
        void Delete(OrderDetailItem orderDetailItem);
        void Delete(int orderDetailId);
        
    }
}