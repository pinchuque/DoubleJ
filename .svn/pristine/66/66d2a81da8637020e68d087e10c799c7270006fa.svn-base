using System.Collections.Generic;


namespace DoubleJ.Oms.Domain.Entities
{
    public class CustomerLocation : EntityBase
    {
        public CustomerLocation()
        {
            OrderDetail = new List<OrderDetail>();
            OrderCombos = new List<OrderCombo>();
            OrderOffals = new List<OrderOffal>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool IsShipTo { get; set; }
        public bool IsBillTo { get; set; }
        public string Email { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<OrderCombo> OrderCombos { get; set; }
        public virtual ICollection<OrderOffal> OrderOffals { get; set; }

        public virtual Customer Customer { get; set; }
    }
}