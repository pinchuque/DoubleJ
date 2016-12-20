using System.Linq;
using System.Web.Mvc;

using DoubleJ.Oms.Model.Extensions;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels.Internal.Fulfillment;
using DoubleJ.Oms.Model.ViewModels.Mobile;
using DoubleJ.Oms.Service.Interfaces;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;


namespace DoubleJ.Oms.Web.Areas.Internal.Controllers
{
    public class FulfillmentController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILabelRepository _labelRepository;
        private readonly ILabelService _labelService;

        public FulfillmentController(IOrderRepository orderRepository, ILabelRepository labelRepository, ILabelService labelService)
        {
            _orderRepository = orderRepository;
            _labelRepository = labelRepository;
            _labelService = labelService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByOrder(string q)
        {
            int id;
            if (!int.TryParse(q, out id))
            {
                return Content("Error. Please try different value.");
            }

            var order = _orderRepository.Get(id);
            if (order == null) return new EmptyResult();

            var model = new SearchByOrderViewModel
            {
                OrderId = order.Id,
                CustomerName = order.With(x => x.Customer).Return(x => x.Name),
                Status = order.With(x => x.Status).With(x => x.Name)
            };

            return PartialView("SearchByOrderResult", model);
        }

        [HttpPost]
        public ActionResult SearchBySn(string q)
        {
            var label = _labelRepository.GetAll().FirstOrDefault(x => x.SerialNumber == q);
            if (label == null) return new EmptyResult();

            var model = new SearchBySnViewModel
            {
                OrderId = label.With(x => x.OrderDetail).With(x => (int?)x.OrderId) ?? 0,
                ItemCode = label.ItemCode,
                SerialNumber = label.SerialNumber,
                Status = label.With(x => x.CurrentLocation).With(x => x.Name)
            };

            return PartialView("SearchBySNResult", model);
        }

        public ActionResult ViewDetails(int orderId)
        {
            return View(orderId);
        }

        public ActionResult GetPendingLabels([DataSourceRequest] DataSourceRequest request, int orderid)
        {
            var labels = _labelService.GetPendingProducts(orderid);
            return Json(labels.ToDataSourceResult(request));
        }

        public ActionResult GetAllocatedLabels([DataSourceRequest] DataSourceRequest request, int orderid)
        {
            var labels = _labelService.GetAllocatedProducts(orderid);
            return Json(labels.ToDataSourceResult(request));
        }

        public ActionResult RemovePendingLabel([DataSourceRequest] DataSourceRequest request, ProductViewModel product, int labeId)
        {
            _labelService.RemoveLabel(labeId);
            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult RemoveAllocatedLabel([DataSourceRequest] DataSourceRequest request, ProductViewModel product, int labeId)
        {
            _labelService.RemoveLabel(labeId);
            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
    }
}