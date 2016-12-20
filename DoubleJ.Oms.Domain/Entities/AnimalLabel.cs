using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoubleJ.Oms.Domain.Entities
{
    public class AnimalLabel : EntityBase
    {
        public AnimalLabel()
        {
            ColdWeightEntryDetails = new List<ColdWeightEntryDetail>();
        }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public bool IsOrganic { get; set; }

        [ForeignKey("SpeciesId")]
        public virtual Species Species{ get; set; }

        public virtual ICollection<ColdWeightEntryDetail> ColdWeightEntryDetails { get; set; } 
    }
}