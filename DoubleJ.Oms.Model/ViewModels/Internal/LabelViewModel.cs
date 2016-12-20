using System.ComponentModel.DataAnnotations;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class LabelViewModel
    {
        [Display(Name="Order")]
        public int? OrderId { get; set; }

        [Display(Name="Owner")]
        public string CustomerName { get; set; }

        [Display(Name="Ship To Locations")]
        public int CustomerLocationsTotal { get; set; }

        [Display(Name="Total Pieces")]
        public int? PieceTotal { get; set; }

        [Display(Name="Total Bags")]
        public int? BagTotal { get; set; }

        [Display(Name="Total Boxes")]
        public int? BoxTotal { get; set; }    

        [Display(Name = "Special Instructions")]
        public string SpecialInstructions { get; set; }

        [Display(Name = "Owner Comments")]
        public string CustomerComments { get; set; }
    }
}
