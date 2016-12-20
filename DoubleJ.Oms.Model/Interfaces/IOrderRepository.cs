using System.Collections.Generic;

using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.Model.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetBySearchCriteria(int? customerId, int? orderId, OmsStatus? statusId, OmsCustomerType? customerType);
        IEnumerable<Order> GetByStatus(List<OmsStatus> statusList);
    }
}