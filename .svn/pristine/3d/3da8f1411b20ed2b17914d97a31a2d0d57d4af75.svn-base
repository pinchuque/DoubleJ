namespace DoubleJ.Oms.Web.Reports.Model
{
    public class ShippingManifestModel : ProductionManifestModel
    {
        public string TopCaption
        {
            get
            {
                return string.Format("{0} sold to {1}", Company, ShipTo);
            }
        }

        public string Company { get; set; }
        public string ShipTo { get; set; }
    }
}