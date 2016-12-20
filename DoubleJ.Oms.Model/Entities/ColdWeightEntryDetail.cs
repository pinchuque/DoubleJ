using System;

namespace DoubleJ.Oms.Model.Entities
{
    public class ColdWeightEntryDetail : EntityBase
    {
        public ColdWeightEntryDetail()
        {
            CreatedDate = DateTime.Now;
        }

        public int ColdWeightId { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Weight { get; set; }

        public virtual ColdWeightEntry ColdWeight { get; set; }
    }
}
