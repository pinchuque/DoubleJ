using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Domain.Entities
{
    public class CutSheetDetail : EntityBase
    {

        public CutSheetDetail()
        {
            OrganMeatValue = new List<OrganMeatValue>();
        }


        public int ColdWeightDeatailId { get; set; }
        public int CustomerLocationId { get; set; }
        public decimal TargetRoastWeight { get; set; }
        public decimal SteackThickness { get; set; }
        public int SteackPerPackage { get; set; }
        //public int  { get; set; }
        public int TopRound { get; set; }
        public int BottomRound { get; set; }
        public int Rump { get; set; }
        public int PikesPeak { get; set; }
        public int Sirloin { get; set; }
        public int TriTip { get; set; }
        public int Bavatte { get; set; }
        public int SkirtSteak { get; set; }
        public int Loin { get; set; }
        public int Flank { get; set; }
        public int Brisket { get; set; }
        public int Rib { get; set; }
        public bool ShortRib { get; set; }
        public bool SoupBones { get; set; }
        public int Chuck { get; set; }
        public bool FlatironSteaks { get; set; }
        public int Arm { get; set; }
        public int Pot { get; set; }
        public int StewMeat { get; set; }
        public int Grind { get; set; }
        public int Patties { get; set; }
        public decimal TotalLbs { get; set; }
        public int PattiesPerPackage { get; set; }
        public string TotalPackage { get; set; }
        public int OrganMeat { get; set; }
        public string SpecialInstruction { get; set; }

        public OmsSteakType RoundTip { get; set; }

        public virtual SteakType SteakType { get; set; }

        public virtual ICollection<OrganMeatValue> OrganMeatValue { get; set; }
    }
}
