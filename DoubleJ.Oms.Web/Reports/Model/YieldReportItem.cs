using System;
using System.Collections.Generic;

namespace DoubleJ.Oms.Web.Reports.Model
{
    public class YieldReportItem
    {
        private decimal _weight;
        public string ItemCode { get; set; }
        public string Description { get; set; }

        public int Bxs { get; set; }
        public decimal Weight
          {
            get { return _weight; }
            set { _weight = Math.Round(value, 2); }
        }
    }

    public class YieldReportModel
    {
        public decimal ColdWeight { get; set; }
        public int Carcasses { get; set; }

        public List<YieldReportItem> Items { get; set; }

        public string FileName { get; set; }

        public DateTime? SlaughterDate { get; set; }

        public string KillDate
        {
            get { return SlaughterDate.HasValue ? SlaughterDate.Value.ToShortDateString() : string.Empty; }
        }
        public DateTime? ProcessDate { get; set; }

        public string FabDate
        {
            get { return ProcessDate.HasValue ? ProcessDate.Value.ToShortDateString() : string.Empty; }
        }
    }
}