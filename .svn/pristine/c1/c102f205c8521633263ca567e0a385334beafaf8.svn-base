using System.ComponentModel.DataAnnotations;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class ProductSearchViewModel : SearchViewModel
    {
        [Display(Name = "Product ID")]
        public string Upc { get; set; }

        [Display(Name = "Product ID")]
        public int? Id { get; set; }
        
        [Display(Name="Product Description")]
        public string Description { get; set; }

        [Display(Name="Primal")]
        public int? PrimalCutId { get; set; }

        //[Display(Name = "Sub-Primal")]
        //public int? SubPrimalCutId { get; set; }

        [Display(Name = "Trim")]
        public int? TrimCutId { get; set; }

        [Display(Name = "Species")]
        public int? SpeciesId { get; set; }

        [Display(Name = "Owner Type")]
        public OmsCustomerType? CustomerType { get; set; }
    }

    public class ProductSearchResultItem
    {
        public int ProductId { get; set; }
        public string Upc { get; set;}
        public string Description { get; set; }
    }
}
