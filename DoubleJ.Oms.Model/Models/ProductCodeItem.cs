using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Model.Models
{
    public class ProductCodeItem : CheckBoxItem
    {
        [StringLength(15)]
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }

        [StringLength(25)]
        [DisplayName("Product Description")]
        public string ProductDescription { get; set; }

        [Range(typeof(decimal), "10000000000000", "99999999999999")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        [DisplayName("GTIN")]
        public decimal? Gtin { get; set; }

        [DisplayName("Price per Pound")]
        public decimal? PricePerPound { get; set; }
        public string Upc { get; set; }

        [DisplayName("Box Size")]
        public CaseSize BoxSize { get; set; }

        [DisplayName("Bag Size")]
        public CaseSize BagSize { get; set; }
    }

    public class CustomerProductItem : ProductCodeItem
    {
        [DisplayName("Bag Size")]
        public CaseSize BagSize { get; set; }

        [DisplayName("Box Size")]
        public CaseSize BoxSize { get; set; }


        [DisplayName("Box Quantity")]
        public int? BoxQuantity { get; set; }

        [DisplayName("Piece Quantity")]
        public int? PieceQuantity { get; set; }

        public CustomerProductItem()
        {
        }
    }
}
