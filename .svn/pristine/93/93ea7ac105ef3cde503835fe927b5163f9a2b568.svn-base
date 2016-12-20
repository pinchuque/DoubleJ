
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class OrganMeatValueMap : EntityTypeConfiguration<OrganMeatValue>
    {
        public OrganMeatValueMap()
        {
            ToTable("dbo.OrganMeatValue");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CutSheetDetailId).HasColumnName("CutSheetDetailId").IsRequired();
            Property(x => x.OrganMeatTypeId).HasColumnName("OrganMeatTypeId").IsRequired();

            HasRequired(a => a.CutSheetDetail).WithMany(b => b.OrganMeatValue).HasForeignKey(c => c.CutSheetDetailId);
            HasRequired(a => a.OrganMeatType).WithMany(b => b.OrganMeatValue).HasForeignKey(c => c.OrganMeatTypeId);
        }

    }
}