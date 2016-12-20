using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class OrderOffalConfiguration : EntityTypeConfiguration<OrderOffal>
    {
        public OrderOffalConfiguration()
        {
            ToTable("dbo.OrderOffal");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
            Property(x => x.OffalId).HasColumnName("OffalId").IsRequired();
            Property(x => x.CustomerLocationId).HasColumnName("CustomerLocationId").IsRequired();
            Property(x => x.Quantity).HasColumnName("Quantity").IsRequired();
            Property(x => x.Weight).HasColumnName("Weight").IsRequired().HasPrecision(18, 2);

            HasRequired(a => a.Order).WithMany(b => b.OrderOffals).HasForeignKey(c => c.OrderId);
            HasRequired(a => a.Offal).WithMany(b => b.OrderOffals).HasForeignKey(c => c.OffalId);
            HasRequired(a => a.CustomerLocation).WithMany(b => b.OrderOffals).HasForeignKey(c => c.CustomerLocationId);
        }
    }
}