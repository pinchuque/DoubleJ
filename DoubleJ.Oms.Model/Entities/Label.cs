using System;
using DoubleJ.Oms.Model.Definitions;

namespace DoubleJ.Oms.Model.Entities
{
    public class Label : EntityBase
    {
        public Label()
        {
            IsPrinted = false;
            CreatedDate = DateTime.Now;
        }

        public OmsLabelType TypeId { get; set; }
        public OmsCurrentLocation? CurrentLocationId { get; set; }
        public int OrderDetailId { get; set; }
        public string ItemCode { get; set; }
        public string LotNumber { get; set; }
        public string Description { get; set; }
        public double PoundWeight { get; set; }
        public double KilogramWeight { get; set; }
        public string ProcessDate { get; set; }
        public string SlaughterDate { get; set; }
        public DateTime BestBeforeDate { get; set; }
        public string SpeciesBugPath { get; set; }
        public string LogoPath { get; set; }
        public string BornIn { get; set; }
        public string RaisedIn { get; set; }
        public string ProductOf { get; set; }
        public string DistributedBy { get; set; }
        public string GermanDescription { get; set; }
        public string FrenchDescription { get; set; }
        public string ItalianDescription { get; set; }
        public string SwedishDescription { get; set; }
        public bool IsPrinted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LabelFile { get; set; }

        public string Primal { get; set; }
        public string SubPrimal { get; set; }
        public string Trim { get; set; }
        public string GradeName { get; set; }
        public string SerialNumber { get; set; }
        public string Organic { get; set; }
        public string CustomerProductCode { get; set; }
        public string Customer { get; set; }

        public string PackedFor { get; set; }
        public string Refrigeration { get; set; }
        public string CustomerProductDescription { get; set; }
        public string VarCustomerJobValue { get; set; }

        public virtual LabelType LabelType { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        public virtual CurrentLocationType CurrentLocation { get; set; }
    }
}