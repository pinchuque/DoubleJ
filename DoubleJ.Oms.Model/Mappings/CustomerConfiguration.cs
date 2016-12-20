using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("dbo.Customer");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.PONumber).HasColumnName("PONumber").IsOptional().HasMaxLength(50);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            Property(x => x.DistributedBy).HasColumnName("DistributedBy").IsOptional().HasMaxLength(30);
            Property(x => x.LogoTypeId).HasColumnName("LogoTypeId").IsRequired();
            Property(x => x.LogoFileName).HasColumnName("LogoFileName").IsOptional().HasMaxLength(200);
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
            Property(x => x.LegacyCustomerId).HasColumnName("LegacyCustomerId").IsOptional();
            Property(x => x.BagLabel).HasColumnName("BagLabel").IsRequired();
            Property(x => x.BoxLabel).HasColumnName("BoxLabel").IsRequired();
            Property(x => x.BestBeforeDate).HasColumnName("BestBeforeDate").IsRequired();

            HasRequired(a => a.User).WithMany(b => b.Customer).HasForeignKey(c => c.UserId);
            HasRequired(a => a.LogoType).WithMany(b => b.Customer).HasForeignKey(c => c.LogoTypeId);
        }
    }
}