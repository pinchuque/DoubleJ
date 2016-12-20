using System.Web.Mvc;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Service.Services;
using Ninject;

namespace DoubleJ.Oms.Web.Controllers
{
    public class NavigationController : Controller
    {
        [Inject]
        public SiteNavigationService SiteNavigationService { get; set; }

        public PartialViewResult _Site(OmsSiteNavigation selected)
        {
            return PartialView(SiteNavigationService.GetList(selected));
        }
    }
}