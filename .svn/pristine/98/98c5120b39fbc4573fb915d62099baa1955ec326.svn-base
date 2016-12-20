using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("dbo.User");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TypeId).HasColumnName("TypeId").IsRequired();
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(200);
            Property(x => x.Password).HasColumnName("Password").IsRequired().HasMaxLength(100);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(100);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(100);
            Property(x => x.Phone).HasColumnName("Phone").IsOptional().HasMaxLength(20);
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
            Property(x => x.CustomerId).HasColumnName("CustomerId").IsOptional();

            HasRequired(a => a.UserType).WithMany(b => b.User).HasForeignKey(c => c.TypeId); 
        }
    }
}