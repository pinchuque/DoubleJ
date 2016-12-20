using System.Linq;
using System.Web;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels;
using DoubleJ.Oms.Service.Interfaces;

namespace DoubleJ.Oms.Service.Services
{
    public class SiteNavigationService : ISiteNavigationService
    {
        private readonly ISiteNavigationRepository _siteNavigationRepository;

        public SiteNavigationService(ISiteNavigationRepository siteNavigationRepository)
        {
            _siteNavigationRepository = siteNavigationRepository;
        }

        public SiteNavigationViewModel GetList(OmsSiteNavigation selected)
        {
            var items = _siteNavigationRepository
                .GetAllActive()
                .Select(MapToViewModel)
                .ToList();

            var viewModel = new SiteNavigationViewModel
            {
                Items = items,
            };

            //set the selected item
            viewModel.Items.First(navItems => navItems.SiteNavigation == selected).IsSelected = true;
            return viewModel;
        }

        private static SiteNavigationItem MapToViewModel(SiteNavigation siteNav)
        {
            return new SiteNavigationItem
            {
                SiteNavigation = (OmsSiteNavigation) siteNav.Id,
                Name = siteNav.Name,
                Url = siteNav.Url != null ? VirtualPathUtility.ToAbsolute(siteNav.Url) : "#"
            };
        }
    }
}