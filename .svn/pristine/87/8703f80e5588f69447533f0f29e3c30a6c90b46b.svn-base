using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DoubleJ.Oms.Domain.Definitions;


namespace DoubleJ.Oms.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            CustomerTypeId = OmsCustomerType.Fabrication;
            CustomerProductData = new List<CustomerProductData>();
            OrderDetail = new List<OrderDetail>();
            OrderCombos = new List<OrderCombo>();
            Gtin = 90853685002011m;
        }

        public string Upc { get; set; }
        public string EnglishDescription { get; set; }
        public string GermanDescription { get; set; }
        public string FrenchDescription { get; set; }
        public string ItalianDescription { get; set; }
        public string SwedishDescription { get; set; }
        public int PrimalCutId { get; set; }
        //public int? SubPrimalCutId { get; set; }
        public int? TrimCutId { get; set; }
        public int? SpeciesId { get; set; }

        public string Code { get; set; }
        public decimal Gtin { get; set; }

        [Display(Name = "Price Per Pound")]
        public decimal? PricePerPound { get; set; }

        [Display(Name = "Owner Type")]
        public OmsCustomerType? CustomerTypeId { get; set; }

        public int BoxSizeId { get; set; }
        public int BagSizeId { get; set; }
        public int BagPieceQuantity { get; set; }
        public int BoxBagQuantity { get; set; }
        public bool IsOffal { get; set; }
        public bool IsActive { get; set; }
      
        public virtual ICollection<CustomerProductData> CustomerProductData { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<OrderCombo> OrderCombos { get; set; }
       
        public virtual CaseSize BoxSizeEntity { get; set; }
        public virtual CaseSize BagSizeEntity { get; set; }
        public virtual PrimalCut PrimalCut { get; set; }
        //public virtual SubPrimalCut SubPrimalCut { get; set; }
        public virtual TrimCut TrimCut { get; set; }
        public virtual Species Species { get; set; }
        public virtual CustomerType CustomerType { get; set; }

        #region NutritionInfo

        public string NutritionDescription { get; set; }
        public string NutritionServingSize { get; set; }
        public string NutritionServingContainer { get; set; }
        public int? NutritionCalories { get; set; }
        public int? NutritionCaloriesFat { get; set; }
        public int? NutritionTotalFat { get; set; }
        public decimal? NutritionSatFat { get; set; }
        public decimal? NutritionTransFat { get; set; }
        public decimal? NutritionPolyFat { get; set; }
        public decimal? NutritionMonoFat { get; set; }
        public int? NutritionCholesterol { get; set; }
        public int? NutritionSodium { get; set; }
        public int? NutritionCarbs { get; set; }
        public int? NutritionProtein { get; set; }
        public int? NutritionVitA { get; set; }
        public int? NutritionVitC { get; set; }
        public int? NutritionCalcium { get; set; }
        public int? NutritionIron { get; set; }

        #endregion
    }
}