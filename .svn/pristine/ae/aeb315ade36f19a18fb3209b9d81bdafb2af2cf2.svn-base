using System.Collections.Generic;

namespace DoubleJ.Oms.Model.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            CustomerProductCode = new List<CustomerProductCode>();
            OrderDetail = new List<OrderDetail>();
            OrderCombos = new List<OrderCombo>();
        }

        public string Upc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GermanDescription { get; set; }
        public string FrenchDescription { get; set; }
        public string ItalianDescription { get; set; }
        public string SwedishDescription { get; set; }
        public int PrimalCutId { get; set; }
        public int? SubPrimalCutId { get; set; }
        public int? TrimCutId { get; set; }
        public int? SpeciesId { get; set; }
        public int? QualityGradeId { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }

        public virtual ICollection<CustomerProductCode> CustomerProductCode { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<OrderCombo> OrderCombos { get; set; }

        public virtual PrimalCut PrimalCut { get; set; }
        public virtual SubPrimalCut SubPrimalCut { get; set; }
        public virtual TrimCut TrimCut { get; set; }
        public virtual Species Species { get; set; }
        public virtual QualityGrade QualityGrade { get; set; }
    }

    public class ProductDTO
    {
        public int Id { get; set; }
        public string Upc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GermanDescription { get; set; }
        public string FrenchDescription { get; set; }
        public string ItalianDescription { get; set; }
        public string SwedishDescription { get; set; }
        public int PrimalCutId { get; set; }
        public int? SubPrimalCutId { get; set; }
        public int? TrimCutId { get; set; }
        public int? SpeciesId { get; set; }
        public int? QualityGradeId { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
    }
}