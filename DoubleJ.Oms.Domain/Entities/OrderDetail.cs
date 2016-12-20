using System.Collections.Generic;
using DoubleJ.Oms.Domain.Definitions;


namespace DoubleJ.Oms.Domain.Entities
{
    public class OrderDetail : EntityBase
    {
        public OrderDetail()
        {
            Label = new List<Label>();
            AnimalOrderDetails = new List<AnimalOrderDetail>();
        }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerLocationId { get; set; }
        public int BoxQuantity { get; set; }
        public int PieceQuantity { get; set; }
        public OmsSideType? SideTypeId { get; set; }
     
        public virtual ICollection<Label> Label { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual CustomerLocation CustomerLocation { get; set; }
        public virtual SideType SideType { get; set; }
        public virtual ICollection<AnimalOrderDetail> AnimalOrderDetails { get; set; }
    }
}