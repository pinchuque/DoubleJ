using System.Collections.Generic;


namespace DoubleJ.Oms.Domain.Entities
{
    public class Species : EntityBase
    {
        public Species()
        {
            Product = new List<Product>();
            AnimalLabels = new List<AnimalLabel>();
        }

        public string Name { get; set; }
        public int? SortOrder { get; set; }
        public string BaseSpecies { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<AnimalLabel> AnimalLabels { get; set; } 
    }
}