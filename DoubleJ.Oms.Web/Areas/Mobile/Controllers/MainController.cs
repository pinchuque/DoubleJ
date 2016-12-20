using System.Web.Mvc;

using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Model.ViewModels.Mobile;
using DoubleJ.Oms.Service.Interfaces;


namespace DoubleJ.Oms.Web.Areas.Mobile.Controllers
{
    [AllowAnonymous]
    public class MainController : Controller
    {
        private readonly ILabelService _labelService;

        public MainController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        public ViewResult Index()
        {
            ViewBag.mainTitle = "Main Menu";
            return View();
        }

        public ActionResult SnLookup()
        {
            ViewBag.mainTitle = "SN Lookup";
            return View();
        }

        [HttpPost]
        public ActionResult SnLookup(string serialNumber)
        {
            ViewBag.mainTitle = "SN Lookup";
            if (!string.IsNullOrEmpty(serialNumber))
            {
                return View(_labelService.GetBySn(serialNumber));
            }
            return RedirectToAction("SnLookup");
        }

        public ActionResult ResetLocation(string serialNumber)
        {
            _labelService.ResetLocation(serialNumber);
            return RedirectToAction("SnLookup");
        }

        public ActionResult OrderFulfillment()
        {
            ViewBag.mainTitle = "Order FulFillment";
            ViewBag.CompletedOrders = _labelService.GetByStatus(new[]
            {
                OmsStatus.Completed,
                OmsStatus.InProcess,
            });

            return View();
        }

        [HttpPost]
        public ActionResult OrderFulfillment(int orderId)
        {
            var destinations = _labelService.GetOrderLocations(orderId);
            return destinations.Count == 1
                ? RedirectToAction("OrderFulfillmentComplete", new {orderId, destinationId = destinations[0].Id})
                : RedirectToAction("OrderFulfillmentDestination", new {orderId});
        }

        public ActionResult OrderFulfillmentDestination(int orderId)
        {
            var destinations = _labelService.GetOrderLocations(orderId);
            ViewBag.mainTitle = "Order Fulfillment";
            ViewBag.OrderId = orderId;
            ViewBag.Destinations = destinations;
            return View();
        }

        [HttpPost]
        public ActionResult OrderFulfillmentDestination(int orderId, int? destinationId)
        {
            ViewBag.mainTitle = "Order Fulfillment";
            if (destinationId != null)
            {
                return RedirectToAction("OrderFulfillmentComplete", new {orderId, destinationId});
            }
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult OrderFulfillmentComplete(int orderId, int? destinationId, string message = null)
        {
            ViewBag.mainTitle = "Order Fulfillment";
            var order = _labelService.GetOrder(orderId);
            var model = new OrderFulfillmentViewModel
            {
                OrderId = orderId,
                DestinationId = destinationId,
                Expected = order.ExpectedHeadNumber,
                Count = order.ReceivedHeadNumber,
                Message = message
            };
            return View("OrderFulfillmentComplete", model);
        }

        [HttpPost]
        public ActionResult OrderFulfillmentComplete(string serialNumber, int orderId, int? destinationId)
        {
            ViewBag.mainTitle = "Order Fulfillment";
            var order = _labelService.GetOrder(orderId);
            var aresult = _labelService.Associate(serialNumber);
            var model = new OrderFulfillmentViewModel
            {
                OrderId = orderId,
                DestinationId = destinationId,
                Expected = order.ExpectedHeadNumber,
                Count = order.ReceivedHeadNumber,
                Message = aresult ? string.Empty : "Invalid SN",
            };
            return View(model);
        }

        public ActionResult CompleteAction(int orderId, int destinationId)
        {
            if (_labelService.IsCompleted(orderId, destinationId))
            {
                _labelService.Complete(orderId);
                return RedirectToAction("Index");
            }

            return OrderFulfillmentComplete(orderId, destinationId, "Order not complete: Additional Product Pending");
        }

        public ActionResult PendingProducts(int orderId, int destinationId)
        {
            ViewBag.mainTitle = "Pending Products";
            ViewBag.OrderId = orderId;
            ViewBag.DestinationId = destinationId;
            return View(_labelService.GetPendingProducts(orderId, destinationId));
        }

        public ActionResult AllocatedProducts(int orderId, int destinationId)
        {
            ViewBag.mainTitle = "Allocated Products";
            ViewBag.OrderId = orderId;
            ViewBag.DestinationId = destinationId;
            return View(_labelService.GetAllocatedProducts(orderId, destinationId));
        }

        public ActionResult RemovePendingLabel(int labelId, int orderid, int destid)
        {
            _labelService.RemoveLabel(labelId);
            return RedirectToAction("PendingProducts", new {orderId = orderid, destinationId = destid});
        }

        public ActionResult RemoveAllocatedLabel(int labelId, int orderid, int destid)
        {
            _labelService.RemoveLabel(labelId);
            return RedirectToAction("AllocatedProducts", new {orderId = orderid, destinationId = destid});
        }
    }
}