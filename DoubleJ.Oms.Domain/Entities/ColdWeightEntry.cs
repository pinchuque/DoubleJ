using System;
using System.Collections.Generic;
using DoubleJ.Oms.Domain.Definitions;


namespace DoubleJ.Oms.Domain.Entities
{
    public class ColdWeightEntry : EntityBase
    {
        public ColdWeightEntry()
        {
            CreatedDate = DateTime.Now;

            ColdWeightEntryDetails = new List<ColdWeightEntryDetail>();
        }

        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? QualityGradeId { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalWeight { get; set; }
        public TrackAnimal TrackAnimalId { get; set; }
        public virtual Order Order { get; set; }
        public virtual QualityGrade QualityGrade { get; set; }

        public virtual ICollection<ColdWeightEntryDetail> ColdWeightEntryDetails { get; set; }
    }
}