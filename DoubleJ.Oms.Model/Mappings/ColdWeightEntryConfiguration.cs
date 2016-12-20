using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class ColdWeightEntryConfiguration : EntityTypeConfiguration<ColdWeightEntry>
    {
        public ColdWeightEntryConfiguration()
        {
            ToTable("dbo.ColdWeight");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.QualityGradeId).HasColumnName("QualityGradeId").IsOptional();
            Property(x => x.TotalWeight).HasColumnName("TotalWeight").IsRequired();
            Property(x => x.TotalCount).HasColumnName("TotalCount").IsRequired();


            HasRequired(a => a.Order).WithMany(b => b.ColdWeightEntries).HasForeignKey(c => c.OrderId);
            HasOptional(a => a.QualityGrade).WithMany(b => b.ColdWeightEntries).HasForeignKey(c => c.QualityGradeId); 
        }
    }

}
