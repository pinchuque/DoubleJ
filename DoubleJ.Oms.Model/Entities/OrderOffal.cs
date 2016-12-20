namespace DoubleJ.Oms.Model.Entities
{
    public class OrderOffal : EntityBase
    {
        public int OrderId { get; set; }
        public int OffalId { get; set; }
        public int CustomerLocationId { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }

        public virtual Order Order { get; set; }
        public virtual Offal Offal { get; set; }
        public virtual CustomerLocation CustomerLocation { get; set; }
    }
}