namespace DoubleJ.Oms.Model.Entities
{
    public class CustomerProductCode
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}