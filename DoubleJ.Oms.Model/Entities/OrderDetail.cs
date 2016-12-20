using System.Collections.Generic;

namespace DoubleJ.Oms.Model.Entities
{
    public class OrderDetail : EntityBase
    {
        public OrderDetail()
        {
            Label = new List<Label>();
        }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerLocationId { get; set; }
        public int BoxQuantity { get; set; }
        public string BoxSize { get; set; }
        public decimal BoxTare { get; set; }
        public decimal BagTare { get; set; }
        public int BoxBagQuantity { get; set; }
        public int? BagPieceQuantity { get; set; }
        public int? PieceQuantity { get; set; }

        public virtual ICollection<Label> Label { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual CustomerLocation CustomerLocation { get; set; }
    }
}