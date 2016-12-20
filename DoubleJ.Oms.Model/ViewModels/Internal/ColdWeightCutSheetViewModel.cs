using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class ColdWeightCutSheetViewModel
    {
        [Display(Name = "Order Number")]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Owner")]
        public string CustomerName { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Display(Name = "Requested Process Date")]
        public DateTime RequestedProcessDate { get; set; }

        [Display(Name = "Expected Head Number")]
        public int ExpectedHeadNumber { get; set; }
    }
}
