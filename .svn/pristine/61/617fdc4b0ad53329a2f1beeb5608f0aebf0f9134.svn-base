using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class OrderComboConfiguration : EntityTypeConfiguration<OrderCombo>
    {
        public OrderComboConfiguration()
        {
            ToTable("dbo.OrderCombo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
            Property(x => x.ProductId).HasColumnName("ProductId").IsRequired();
            Property(x => x.CustomerLocationId).HasColumnName("CustomerLocationId").IsRequired();
            Property(x => x.Quantity).HasColumnName("Quantity").IsRequired();
            Property(x => x.Weight).HasColumnName("Weight").IsRequired().HasPrecision(18, 2);

            HasRequired(a => a.Order).WithMany(b => b.OrderCombos).HasForeignKey(c => c.OrderId);
            HasRequired(a => a.Product).WithMany(b => b.OrderCombos).HasForeignKey(c => c.ProductId);
            HasRequired(a => a.CustomerLocation).WithMany(b => b.OrderCombos).HasForeignKey(c => c.CustomerLocationId);
        }
    }
}