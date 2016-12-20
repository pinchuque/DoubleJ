namespace DoubleJ.Oms.Domain.Entities
{
    public class OrderCombo : EntityBase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerLocationId { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual CustomerLocation CustomerLocation { get; set; }
    }
}