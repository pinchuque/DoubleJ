namespace DoubleJ.Oms.Domain.Entities
{
    public class CustomerProductData
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal? Gtin { get; set; }
        public decimal? PricePerPound { get; set; }
        public int? BoxSizeId { get; set; }
        public int? BagSizeId { get; set; }
        public int? BoxQuantity { get; set; }
        public int? PieceQuantity { get; set; }
        public virtual CaseSize BoxSizeEntity { get; set; }
        public virtual CaseSize BagSizeEntity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}