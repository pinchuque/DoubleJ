using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Model.ViewModels
{
    public class SiteNavigationItem
    {
        public OmsSiteNavigation SiteNavigation { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsSelected { get; set; }
    }
}