using System;
using System.Collections.Generic;

namespace DoubleJ.Oms.Web.Reports.Model
{
    public class ProductionManifestModel
    {
        public DateTime? SlaughterDate { get; set; }

        public string Date
        {
            get
            {
                return SlaughterDate.HasValue ? SlaughterDate.Value.ToShortDateString() : string.Empty;
            }
        }

        public string OrderNumber { get; set; }
        public string SubCaption { get; set; }
        public string FileName { get; set; }
    }
}