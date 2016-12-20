using System.Collections.Generic;

namespace DoubleJ.Oms.Model.Entities
{
    public class PrimalCut : EntityBase
    {
        public PrimalCut()
        {
            Product = new List<Product>();
        }

        public string Name { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}