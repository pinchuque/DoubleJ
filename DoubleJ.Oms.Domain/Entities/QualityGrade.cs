using System.Collections.Generic;


namespace DoubleJ.Oms.Domain.Entities
{
    public class QualityGrade : EntityBase
    {
        public QualityGrade()
        {
            ColdWeightEntries = new List<ColdWeightEntryDetail>();
        }

        public string Name { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<ColdWeightEntryDetail> ColdWeightEntries { get; set; }
    }
}