using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration()
        {
            ToTable("dbo.OrderDetail");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
            Property(x => x.ProductId).HasColumnName("ProductId").IsRequired();
            Property(x => x.CustomerLocationId).HasColumnName("CustomerLocationId").IsRequired();
            Property(x => x.BoxQuantity).HasColumnName("BoxQuantity").IsRequired();
            Property(x => x.BoxSize).HasColumnName("BoxSize").IsRequired().HasMaxLength(50);
            Property(x => x.BoxTare).HasColumnName("BoxTare").IsRequired().HasPrecision(18, 2);
            Property(x => x.BagTare).HasColumnName("BagTare").IsRequired().HasPrecision(18, 2);
            Property(x => x.BoxBagQuantity).HasColumnName("BoxBagQuantity").IsRequired();
            Property(x => x.BagPieceQuantity).HasColumnName("BagPieceQuantity").IsOptional();
            Property(x => x.PieceQuantity).HasColumnName("PieceQuantity").IsOptional();

            HasRequired(a => a.Order).WithMany(b => b.OrderDetail).HasForeignKey(c => c.OrderId);
            HasRequired(a => a.Product).WithMany(b => b.OrderDetail).HasForeignKey(c => c.ProductId);
            HasRequired(a => a.CustomerLocation).WithMany(b => b.OrderDetail).HasForeignKey(c => c.CustomerLocationId);
        }
    }
}