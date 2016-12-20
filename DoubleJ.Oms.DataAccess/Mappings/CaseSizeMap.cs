using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class CaseSizeMap : EntityTypeConfiguration<CaseSize>
    {
        public CaseSizeMap()
        {
            ToTable("dbo.CaseSize");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreateDateTime).HasColumnName("CreateDateTime").IsRequired();
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
            Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            Property(x => x.TareWeight).HasColumnName("TareWeight").IsRequired();
            Property(x => x.CaseTypeId).HasColumnName("CaseTypeId").IsRequired();
            HasRequired(x => x.CustomerType).WithMany(x => x.CaseSizes).HasForeignKey(x => x.CustomerTypeId);
            HasRequired(x => x.CaseType).WithMany(x => x.CaseSizes).HasForeignKey(x => x.CaseTypeId);
        }
    }
}