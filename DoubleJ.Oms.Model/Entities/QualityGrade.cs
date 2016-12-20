using System.Collections.Generic;

namespace DoubleJ.Oms.Model.Entities
{
    public class QualityGrade : EntityBase
    {
        public QualityGrade()
        {
            Product = new List<Product>();
            ColdWeightEntries = new List<ColdWeightEntry>();
        }

        public string Name { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ColdWeightEntry> ColdWeightEntries { get; set; }
    }
}