using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class CutSheetDetailMap : EntityTypeConfiguration<CutSheetDetail>
    {
        public CutSheetDetailMap()
        {
            ToTable("dbo.CutSheetDetail");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ColdWeightDeatailId).HasColumnName("ColdWeightDeatailId").IsRequired();
            Property(x => x.CustomerLocationId).HasColumnName("CustomerLocationId").IsRequired();
            Property(x => x.TargetRoastWeight).HasColumnName("TargetRoastWeight").IsRequired();
            Property(x => x.SteackThickness).HasColumnName("SteackThickness").IsRequired();
            Property(x => x.SteackPerPackage).HasColumnName("SteackPerPackage").IsRequired();
            //Property(x => x.RoundTip).HasColumnName("RoundTip").IsRequired();
            Property(x => x.TopRound).HasColumnName("TopRound").IsRequired();
            Property(x => x.BottomRound).HasColumnName("BottomRound").IsRequired();
            Property(x => x.Rump).HasColumnName("Rump").IsRequired();
            Property(x => x.PikesPeak).HasColumnName("PikesPeak").IsRequired();
            Property(x => x.Sirloin).HasColumnName("Sirloin").IsRequired();
            Property(x => x.TriTip).HasColumnName("TriTip").IsRequired();
            Property(x => x.Bavatte).HasColumnName("Bavatte").IsRequired();
            Property(x => x.SkirtSteak).HasColumnName("SkirtSteak").IsRequired();
            Property(x => x.Loin).HasColumnName("Loin").IsRequired();
            Property(x => x.Flank).HasColumnName("Flank").IsRequired();
            Property(x => x.Brisket).HasColumnName("Brisket").IsRequired();
            Property(x => x.Rib).HasColumnName("Rib").IsRequired();
            Property(x => x.ShortRib).HasColumnName("ShortRib").IsRequired();
            Property(x => x.SoupBones).HasColumnName("SoupBones").IsRequired();
            Property(x => x.Chuck).HasColumnName("Chuck").IsRequired();
            Property(x => x.FlatironSteaks).HasColumnName("FlatironSteaks").IsRequired();
            Property(x => x.Arm).HasColumnName("Arm").IsRequired();
            Property(x => x.Pot).HasColumnName("Pot").IsRequired();
            Property(x => x.StewMeat).HasColumnName("StewMeat").IsRequired();
            Property(x => x.Grind).HasColumnName("Grind").IsRequired();
            Property(x => x.Patties).HasColumnName("Patties").IsRequired();
            Property(x => x.TotalLbs).HasColumnName("TotalLbs").IsRequired();
            Property(x => x.PattiesPerPackage).HasColumnName("PattiesPerPackage").IsRequired();
            Property(x => x.TotalPackage).HasColumnName("TotalPackage").IsRequired();
            Property(x => x.OrganMeat).HasColumnName("OrganMeat").IsRequired();
            Property(x => x.SpecialInstruction).HasColumnName("SpecialInstruction").IsRequired();

            HasRequired(a => a.SteakType).WithMany(b => b.CutSheetDetail).HasForeignKey(c => c.RoundTip);

        }
    }
}
