using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class CustomerProductCodeConfiguration : EntityTypeConfiguration<CustomerProductCode>
    {
        public CustomerProductCodeConfiguration()
        {
            ToTable("dbo.CustomerProductCode");
            HasKey(x => new { x.CustomerId, x.ProductId });

            Property(x => x.CustomerId).HasColumnName("CustomerId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ProductId).HasColumnName("ProductId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ProductCode).HasColumnName("ProductCode").IsOptional().HasMaxLength(15);
            Property(x => x.ProductDescription).HasColumnName("ProductDescription").IsOptional().HasMaxLength(20);

            HasRequired(a => a.Customer).WithMany(b => b.CustomerProductCode).HasForeignKey(c => c.CustomerId);
            HasRequired(a => a.Product).WithMany(b => b.CustomerProductCode).HasForeignKey(c => c.ProductId);
        }
    }
}