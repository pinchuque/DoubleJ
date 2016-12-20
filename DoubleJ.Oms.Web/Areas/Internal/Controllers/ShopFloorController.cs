using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Service.Services.Internal;


namespace DoubleJ.Oms.Web.Areas.Internal.Controllers
{
    [AllowAnonymous]
    public class ShopFloorController : Controller
    {
        private readonly IOrderComboRepository _orderComboRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderOffalRepository _orderOffalRepository;
        private readonly IOrderRepository _orderRepository;

        public ShopFloorController(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IOrderOffalRepository orderOffalRepository,
            IOrderComboRepository orderComboRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderOffalRepository = orderOffalRepository;
            _orderComboRepository = orderComboRepository;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Refresh()
        {
            var activeOrders = _orderRepository.Query().Where(x => x.StatusId == OmsStatus.InProcess);
            if (!activeOrders.Any())
            {
                return Content("Orders not found");
            }

            return View("_ActiveOrders", activeOrders.ToArray());
        }

        public ActionResult LoadOrder(Order activeOrder)
        {
            var orderDetails = _orderDetailRepository
                .Query()
                .Include(x => x.Label)
                .Where(x => x.OrderId == activeOrder.Id && x.Product != null && !x.Product.Upc.Contains("-Y"));

            var locations = orderDetails
                .ToArray()
                .Select(x => new KeyValuePair<int, string>(x.CustomerLocation.Id, x.CustomerLocation.Name))
                .Distinct()
                .ToDictionary(x => x.Key, x => x.Value);

            var products = orderDetails
                .Select(x => x.Product)
                .Distinct()
                .ToArray()
                .ToDictionary(x => x.Id, ProductService.GetFormattedProductName);

            var productItems = products
                .Select(product => new
                {
                    ProductId = product.Key,
                    Items = locations
                        .Join(orderDetails, x => new { CustomerLocationId = x.Key, ProductId = product.Key }, x => new {x.CustomerLocationId, x.ProductId }, (location, orderDetail) => new
                        {
                            LocationId = location.Key,
                            BagCompleted = orderDetail.Label.Count(label => label.TypeId == OmsLabelType.Bag),
                            BoxCompleted = orderDetail.Label.Count(label => label.TypeId == OmsLabelType.Box), 
                            orderDetail.BoxQuantity, 
                            orderDetail.Product.BoxBagQuantity
                        })
                        .ToArray(),
                })
                .ToArray();

            var bags = productItems
                .Select(x => new ShopFloorItem
                {
                    ProductId = x.ProductId,
                    Items = x.Items
                        .Select(item => new ShopFloorItem.CompletionStatus
                        {
                            LocationId = item.LocationId,
                            Completed = item.BagCompleted,
                            Total = item.BoxBagQuantity * item.BoxQuantity
                        })
                        .ToArray(),
                })
                .ToArray();

            var boxes = productItems
                .Select(x => new ShopFloorItem
                {
                    ProductId = x.ProductId,
                    Items = x.Items
                        .Select(item => new ShopFloorItem.CompletionStatus
                        {
                            LocationId = item.LocationId,
                            Completed = item.BoxCompleted,
                            Total = item.BoxQuantity
                        })
                        .ToArray(),
                })
                .ToArray();

            var orderOffals = _orderOffalRepository
                .Query()
                .Where(x => x.OrderId == activeOrder.Id)
                .ToArray();

            var offalItems = orderOffals
                .Select(x => new ComboOffalItem
                {
                    ProductName = x.Offal.Name,
                    QtyWeight = GetQtyWeight(x.Quantity, x.Weight),
                    ShipTo = x.CustomerLocation.Name,
                })
                .ToArray();

            var orderCombos = _orderComboRepository
                .Query()
                .Where(x => x.OrderId == activeOrder.Id)
                .ToArray();

            var combos = orderCombos
                .Select(x => new ComboOffalItem
                {
                    ProductName = ProductService.GetFormattedProductName(x.Product),
                    QtyWeight = GetQtyWeight(x.Quantity, x.Weight),
                    ShipTo = x.CustomerLocation.Name,
                })
                .ToArray();

            var model = new ShopFloorViewModel
            {
                OrderId = activeOrder.Id.ToString(CultureInfo.InvariantCulture),

                Bags = bags,
                Boxes = boxes,

                Locations = locations,
                Products = products,

                Offals = offalItems,
                Combos = combos,
            };

            return PartialView("_LabelsSummary", model);
        }

        private static string GetQtyWeight(int quantity, decimal weight)
        {
            return string.Format("{0} x {1}lbs", quantity, weight);
        }
    }
}