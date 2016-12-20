using System;
using System.Collections.Generic;
using DoubleJ.Oms.Model.Definitions;

namespace DoubleJ.Oms.Model.Entities
{
    public class Order : EntityBase
    {
        public Order()
        {
            CreatedDate = DateTime.Now;
            LogoTypeId = OmsLogoType.None;
            OrderDetail = new List<OrderDetail>();
            OrderCombos = new List<OrderCombo>();
            OrderOffals = new List<OrderOffal>();
            ColdWeightEntries = new List<ColdWeightEntry>();
        }

        public int CustomerId { get; set; }
        public OmsStatus StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RequestedProcessDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public DateTime? SlaughterDate { get; set; }
        public DateTime? ProcessDate { get; set; }
        public int ExpectedHeadNumber { get; set; }
        public int? ReceivedHeadNumber { get; set; }
        public int? SlaughteredHeadNumber { get; set; }
        public OmsLogoType LogoTypeId { get; set; }
        public int? BornRegionId { get; set; }
        public int? RaisedRegionId { get; set; }
        public int? SlaughteredRegionId { get; set; }
        public int? ProductOfRegionId { get; set; }
        public string SpecialInstructions { get; set; }
        public string CustomerComments { get; set; }
        public bool ComboCompleted { get; set; }
        public int? RefrigerationId { get; set; }
        public DateTime BestBeforeDate { get; set; }
        public string LotNumber { get; set; }
        public string AdditionalInfoOnLabel { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<OrderCombo> OrderCombos { get; set; }
        public virtual ICollection<OrderOffal> OrderOffals { get; set; }
        public virtual ICollection<ColdWeightEntry> ColdWeightEntries { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual LogoType LogoType { get; set; }

        public virtual Region BornRegion { get; set; }
        public virtual Region RaisedRegion { get; set; }
        public virtual Region SlaughteredRegion { get; set; }
        public virtual Region ProductOfRegion { get; set; }
        public virtual Refrigeration Refrigeration { get; set; }
    }
}