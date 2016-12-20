using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class AddCustomerViewModel
    {
        public AddCustomerViewModel()
        {
            BagLabel = "bag.lbl";
            BoxLabel = "box.lbl";

            BestBeforeDays = 0;
            Location = new CustomerLocationViewModel();
            CustomerType = OmsCustomerType.Fabrication;
            UseLogoOnLabels = OmsLogoType.None;
        }

        [DisplayName("Owner Name")]
        [Required]
        public string CustomerName { get; set; }

        [DisplayName("Is Archived")]
        [Required]
        public bool IsArchived { get; set; }

        [DisplayName("Owner Type")]
        [Required]
        public OmsCustomerType CustomerType { get; set; }

        [DisplayName("Order Contact Email")]
        public string OrderContactEmail { get; set; }

        [DisplayName("Portal Password")]
        public string PortalPassword { get; set; }

        [DisplayName("Order Contact Phone")]
        public string OrderContactPhone { get; set; }

        [DisplayName("Label' distributed by'")]
        public string LabelDistributedBy { get; set; }

        [DisplayName("Owner Logo FileName")]
        public string CustomerLogo { get; set; }

        [DisplayName("Owner Logo FileName")]
        public string LogoFileName { get; set; }

        [DisplayName("Use Logo On Labels")]
        [Required]
        [EnumDataType(typeof(OmsLogoType))]
        public OmsLogoType UseLogoOnLabels { get; set; }

        [DisplayName("Bag Label")]
        [Required]
        public string BagLabel { get; set; }

        [DisplayName("Box Label")]
        [Required]
        public string BoxLabel { get; set; }

        [DisplayName("Tray Label")]
        [Required]
        public string TrayLabel { get; set; }


        [DisplayName("Order Contact First Name")]
        public string OrderContactFirstName { get; set; }

        [DisplayName("Order Contact Last Name")]
        public string OrderContactLastName { get; set; }

        [DisplayName("Owner P.O.#")]
        public string CustomerPo { get; set; }

        public CustomerLocationViewModel Location { get; set; }

        [DisplayName("# Days (Best Before Date)")]
        [Required]
        public int? BestBeforeDays { get; set; }
    }
}
