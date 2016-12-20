using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class ColdWeightEntryDetailConfiguration : EntityTypeConfiguration<ColdWeightEntryDetail>
    {
        public ColdWeightEntryDetailConfiguration()
        {
            ToTable("dbo.ColdWeightDetail");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ColdWeightId).HasColumnName("ColdWeightId").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.Weight).HasColumnName("Weight").IsRequired();


            HasRequired(a => a.ColdWeight).WithMany(b => b.ColdWeightEntryDetails).HasForeignKey(c => c.ColdWeightId);
        }
    }
}
