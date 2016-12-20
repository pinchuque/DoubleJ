using System;
using System.Collections.Generic;

namespace DoubleJ.Oms.Web.Reports.Model
{
    public class ProductionManifestDetailModel
    {
        public string PoNumber { get; set; }

        public string SubCaption
        {
            get { return string.Format("{0} sold to {1} {2} kill", Company, ShipTo, KillDate); }
        }

        public string Company { get; set; }
        public string ShipTo { get; set; }

        public string KillDate
        {
            get { return SlaughterDate.HasValue ? SlaughterDate.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? SlaughterDate { get; set; }
        public string FileName { get; set; }
    }
}