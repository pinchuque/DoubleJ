using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Model.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Service.Interfaces;
using NLog;

namespace DoubleJ.Oms.Service.Services.Internal
{
    public class OrderSearchService : IOrderSearchService
    {
        private readonly IOrderRepository _orderRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public OrderSearchService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderSearchResultItem> Search(OrderSearchViewModel viewModel)
        {
            Logger.Debug("Order Search - Order Number:" + viewModel.OrderId);
            return
                _orderRepository.GetBySearchCriteria(viewModel.CustomerId, viewModel.OrderId.HasValue ? viewModel.OrderId.ToString() : null, viewModel.StatusId)
                                .Select(MapToResultItem)
                                .OrderByDescending(x => x.OrderId)
                                .ToList();
        }

        private static OrderSearchResultItem MapToResultItem(Order order)
        {
            return new OrderSearchResultItem
                {
                    OrderId = order.Id,
                    CustomerName = order.Customer.Name,
                    StatusName = order.Status.Name,
                    RequestedProcessDate = order.RequestedProcessDate
                };
        }
    }
}