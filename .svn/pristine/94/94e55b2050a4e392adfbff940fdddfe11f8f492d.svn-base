using System.Web.Mvc;

using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Service.Interfaces;
using DoubleJ.Oms.Service.Services;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using MuscovyTechnology.Mvc.Notification;


namespace DoubleJ.Oms.Web.Areas.Internal.Controllers
{
    public class LabelsController : Controller
    {
        private readonly ILabelService _labelService;

        private readonly IScaleService _scaleService;

        public LabelsController(IScaleService scaleService, ILabelService labelService)
        {
            _scaleService = scaleService;
            _labelService = labelService;
        }

        public ActionResult Index(int? OrderId)
        {
            ViewBag.Orders = _labelService.GetOrders();
            return View(_labelService.Get(OrderId));
        }

        public PartialViewResult BagLabelGrid(int id)
        {
            return PartialView("_Bag", _labelService.GetLabelGridDefinition(id));
        }

        public PartialViewResult BoxLabelGrid(int id)
        {
            return PartialView("_Box", _labelService.GetLabelGridDefinition(id));
        }

        public ActionResult BagLabelGrid_Read([DataSourceRequest] DataSourceRequest request, int orderId)
        {
            return Json(_labelService.GetBagGridItems(orderId).ToDataSourceResult(request));
        }

        public ActionResult BoxLabelGrid_Read([DataSourceRequest] DataSourceRequest request, int orderId)
        {
            return Json(_labelService.GetBoxGridItems(orderId).ToDataSourceResult(request));
        }

        public JsonResult WeightAndPrint(int id, OmsLabelType labelType)
        {
            var status = _scaleService.WeighAndLabel(id, labelType);
            if (status != OmsScaleWeighStatus.Success)
            {
                this.ShowNotification(NotificationType.Error, _scaleService.GetScaleStatusMessage(status));
            }

            return Json(new {status}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DisconnectScale()
        {
            SessionService.Get().BagScale.Dispose();
            SessionService.Get().BagScale = null;

            return Json(new {}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            return View(_labelService.Get(id));
        }

        public JsonResult Reprint(int labelId, double poundWeight, int labelType)
        {
            _labelService.UpdateLabel(labelId, poundWeight, (OmsLabelType)labelType);
            return Json(new {}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Remove(int labelId)
        {
            _labelService.RemoveLabel(labelId);
            return Json(new {}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LabelEditGrid_Read([DataSourceRequest] DataSourceRequest request, int id)
        {
            return Json(_labelService.GetPrintedLabels(id).ToDataSourceResult(request));
        }
    }
}