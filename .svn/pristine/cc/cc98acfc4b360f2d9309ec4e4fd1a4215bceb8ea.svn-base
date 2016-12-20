using System.Collections.Generic;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetAllByOrder(int orderId);
        IEnumerable<OrderDetail> GetAllByOrderProduct(int orderId, int productId);
        OrderDetail GetLabelInfo(int id);
        IEnumerable<Product> GetAllByCustomerLocationandOrderId(int customerLocationId, int orderId);
        OrderDetail LastOrderDetail();
    }
}