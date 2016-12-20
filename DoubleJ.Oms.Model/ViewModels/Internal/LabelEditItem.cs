using System;
using System.ComponentModel.DataAnnotations;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class LabelEditItem
    {
        public int LabelId { get; set; }

        [Display(Name = "Type")]
        public OmsLabelType LabelType { get; set; }

        [Display(Name = "Printed")]
        public DateTime PrintedDate { get; set; }

        [Display(Name = "Weight")]
        public double PoundWeight { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Display(Name = "Ship To")]
        public string LocationName { get; set; }
    }
}