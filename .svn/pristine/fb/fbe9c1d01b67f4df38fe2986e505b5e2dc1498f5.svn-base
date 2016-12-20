using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class OrderComboMap : EntityTypeConfiguration<OrderCombo>
    {
        public OrderComboMap()
        {
            ToTable("dbo.OrderCombo");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
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