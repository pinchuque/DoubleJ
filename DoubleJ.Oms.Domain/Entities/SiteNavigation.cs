namespace DoubleJ.Oms.Domain.Entities
{
    public class SiteNavigation : EntityBase
    {
        public SiteNavigation()
        {
            IsActive = true;
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}