using System.Collections.Generic;


namespace DoubleJ.Oms.Domain.Entities
{
    public class PrimalCut : EntityBase
    {
        public PrimalCut()
        {
            Product = new List<Product>();
        }

        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string TextColor { get; set; }
        public string BackgroundColor { get; set; }
        public int BackgroundSort { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}