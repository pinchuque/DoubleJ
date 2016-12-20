using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class CustomerLocationConfiguration : EntityTypeConfiguration<CustomerLocation>
    {
        public CustomerLocationConfiguration()
        {
            ToTable("dbo.CustomerLocation");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CustomerId).HasColumnName("CustomerId").IsRequired();
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            Property(x => x.Address1).HasColumnName("Address1").IsRequired().HasMaxLength(100);
            Property(x => x.Address2).HasColumnName("Address2").IsOptional().HasMaxLength(100);
            Property(x => x.City).HasColumnName("City").IsRequired().HasMaxLength(50);
            Property(x => x.StateCode).HasColumnName("StateCode").IsRequired().HasMaxLength(2);
            Property(x => x.ZipCode).HasColumnName("ZipCode").IsRequired().HasMaxLength(10);
            Property(x => x.Phone).HasColumnName("Phone").IsRequired().HasMaxLength(20);
            Property(x => x.Fax).HasColumnName("Fax").IsOptional().HasMaxLength(20);
            Property(x => x.IsShipTo).HasColumnName("IsShipTo").IsRequired();
            Property(x => x.IsBillTo).HasColumnName("IsBillTo").IsRequired();

            HasRequired(a => a.Customer).WithMany(b => b.CustomerLocation).HasForeignKey(c => c.CustomerId); 
        }
    }
}