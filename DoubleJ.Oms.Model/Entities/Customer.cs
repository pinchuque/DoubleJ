using System;
using System.Collections.Generic;
using DoubleJ.Oms.Model.Definitions;

namespace DoubleJ.Oms.Model.Entities
{
    public class Customer : EntityBase
    {
        public Customer()
        {
            LogoTypeId = OmsLogoType.None;
            IsActive = true;
            CustomerLocation = new List<CustomerLocation>();
            CustomerProductCode = new List<CustomerProductCode>();
            Order = new List<Order>();
        }

        public string Name { get; set; }
        public string PONumber { get; set; }
        public int UserId { get; set; }
        public string DistributedBy { get; set; }
        public OmsLogoType LogoTypeId { get; set; }
        public string LogoFileName { get; set; }
        public bool IsActive { get; set; }
        public int? LegacyCustomerId { get; set; }
        public string BagLabel { get; set; }
        public string BoxLabel { get; set; }
        public DateTime BestBeforeDate { get; set; }
        
        public virtual ICollection<CustomerLocation> CustomerLocation { get; set; }
        public virtual ICollection<CustomerProductCode> CustomerProductCode { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        
        public virtual User User { get; set; }
        public virtual LogoType LogoType { get; set; }
    }
}