using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Service.Interfaces;

namespace DoubleJ.Oms.Service.Services.Internal
{
    public class OrderReportService : IOrderReportService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderReportService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderReportViewModel Get(int orderId)
        {
            var order = _orderRepository.Get(orderId);
            var viewModel = new OrderReportViewModel
            {
                OrderId = orderId,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer.Name,
                StatusName = order.Status.Name,
                RequestedProcessDate = order.RequestedProcessDate,
                ExpectedHeadNumber = order.ExpectedHeadNumber
            };

            return viewModel;
        }
        
    }
}
