using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Model.Annotations;
using DoubleJ.Oms.Model.Models;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class CutSheetDetailViewModel
    {

        public CutSheetDetailViewModel()
        {
            TopRoundButtonList = new List<SelectListItem>();
            RoundTipRadioButtonList = new List<SelectListItem>();        
            RumpRadioButtonsList = new List<SelectListItem>();
            BottomRoundRadioButtonsList = new List<SelectListItem>(); 
            PikesPeakRadioButtonsList = new List<SelectListItem>();
            SirloinRadioButtonsList = new List<SelectListItem>();
            TriTipRadioButtonsList = new List<SelectListItem>();
            BavatteRadioButtonsList = new List<SelectListItem>();
            SkirtSteakRadioButtonsList =  new List<SelectListItem>();
            LoinRadioButtonsList = new List<SelectListItem>();
            FlankRadioButtonsList = new List<SelectListItem>();
            BrisketRadioButtonsList = new List<SelectListItem>();
            RibRadioButtonsList = new List<SelectListItem>();
            ChuckRadioButtonsList = new List<SelectListItem>();
            ArmRadioButtonsList = new List<SelectListItem>();
            PotRadioButtonsList = new List<SelectListItem>();
            GrindRadioButtonsList = new List<SelectListItem>();
            StewMeatRadioButtonsList = new List<SelectListItem>();
            PattiesRadioButtonsList = new List<SelectListItem>();
            OrganMeatTypeList = new List<SelectListItem>();
            OrganMeatSelected = new List<int>();
            
        }
        [DisplayName("Owner:")]
        public string CustomerName { get; set; }
        public int ColdWeightId { get; set; }
        public string CustomerPhone { get; set; }
        [DisplayName("Customer:")]
        public string CustomerLocationName { get; set; }
        public string CustomerLocationPhone { get; set; }
         [DisplayName("TarGet Roast Weight (lbs)")]
        public decimal TarGetRoastWeight { get; set; }
         [DisplayName("Steack Thickness (inches)")]
        public decimal SteackThickness { get; set; }
        [DisplayName("Steacks Per Package")]
        public int SteackPerPackage { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Round Tip:")]
        [Required]
        public int RoundTip { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Top Round:")]
        [Required]
        public int TopRound { get; set; }
        [DisplayName("Bottom Round:")]
        [UIHint("RadioButtonList")]
        public int BottomRound { get; set; }
        [DisplayName("Rump:")]
        [UIHint("RadioButtonList")]
        public int Rump { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Pikes Peak:")]
        public int PikesPeak { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Sirloin:")]
        public int Sirloin { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Tri-Tip:")]
        public int TriTip { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Bavatte:")]
        public int Bavatte { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Skirt Steak:")]
        public int SkirtSteak { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Loin:")]
        public int Loin { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Flank:")]
        public int Flank { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Brisket:")]
        public int Brisket { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Rib:")]
        public int Rib { get; set; }
        //[DisplayName("Short Rib:")]
        public bool ShortRib { get; set; }
        //[DisplayName("Soup Bones:")]
        public bool SoupBones { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Chuck:")]
        public int Chuck { get; set; }
        //[DisplayName("Flatiron Steaks:")]
        public bool FlatironSteaks { get; set; }
        [DisplayName("Arm:")]
        [UIHint("RadioButtonList")]
        public int Arm { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Pot:")]
        public int Pot { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Stew Meat:")]
        public int StewMeat { get; set; }
        [DisplayName("Grind:")]
        [UIHint("RadioButtonList")]
        public int Grind { get; set; }
        [UIHint("RadioButtonList")]
        [DisplayName("Patties:")]
        public int Patties { get; set; }
        [DisplayName("Total Lbs:")]
        public decimal TotalLbs { get; set; }
        [DisplayName("Patties Per Package:")]
        public int PattiesPerPackage { get; set; }
        [DisplayName("Total Packages:")]
        public string TotalPackage { get; set; }
        [DisplayName("Organ Meat:")]
        public int OrganMeat { get; set; }
        [DisplayName("Special Instructions:")]
        [DataType(DataType.MultilineText)]
        public string SpecialInstruction { get; set; }


        public List<SelectListItem> TopRoundButtonList { get; set; }
        [Required]
        [NotNull]
        public List<SelectListItem> RoundTipRadioButtonList { get; set; }
        public List<SelectListItem> RumpRadioButtonsList { get; set; }
        public List<SelectListItem> BottomRoundRadioButtonsList { get; set; }
        public List<SelectListItem> PikesPeakRadioButtonsList { get; set; }
        public List<SelectListItem> SirloinRadioButtonsList { get; set; }
        public List<SelectListItem> TriTipRadioButtonsList { get; set; }
        public List<SelectListItem> BavatteRadioButtonsList { get; set; }
        public List<SelectListItem> SkirtSteakRadioButtonsList { get; set; }
        public List<SelectListItem> LoinRadioButtonsList { get; set; }
        public List<SelectListItem> FlankRadioButtonsList { get; set; }
        public List<SelectListItem> BrisketRadioButtonsList { get; set; }
        public List<SelectListItem> RibRadioButtonsList { get; set; }
        public List<SelectListItem> ChuckRadioButtonsList { get; set; }
        public List<SelectListItem> ArmRadioButtonsList { get; set; }
        public List<SelectListItem> PotRadioButtonsList { get; set; }
        public List<SelectListItem> GrindRadioButtonsList { get; set; }
        public List<SelectListItem> StewMeatRadioButtonsList { get; set; }
        public List<SelectListItem> PattiesRadioButtonsList { get; set; }
        public List<SelectListItem> OrganMeatTypeList { get; set; }
        public List<int> OrganMeatSelected { get; set; }

        [DisplayName("Short Rib")]
        public OmsCutSheetDDL ShortRibDDL { get; set; }
        [DisplayName("Soup Bones")]
        public OmsCutSheetDDL SoupBonesDDL { get; set; }
        [DisplayName("Flatrion Steaks")]
        public OmsCutSheetDDL FlatrionSteaksDDL { get; set; }
    }

    public class CutSheetColdWeight
    {
        public string  Name { get; set; }
        public int ColdWeightId { get; set; }
        public string SelectedCustomerLocationId { get; set; }
    }
}
