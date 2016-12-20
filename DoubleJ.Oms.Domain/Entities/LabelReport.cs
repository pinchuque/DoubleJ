using System;
using System.Collections.Generic;

namespace DoubleJ.Oms.Domain.Entities
{
    public class LabelReport
    {
        public DateTime Date { get; set; }
        public List<LabelReportItem> Items { get; set; }

        public LabelReport()
        {
            Items = new List<LabelReportItem>();
        }
    }
}