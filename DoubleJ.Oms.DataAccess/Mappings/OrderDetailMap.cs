using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetail");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
            Property(x => x.ProductId).HasColumnName("ProductId").IsRequired();
            Property(x => x.CustomerLocationId).HasColumnName("CustomerLocationId").IsRequired();
            Property(x => x.BoxQuantity).HasColumnName("BoxQuantity").IsRequired();
            Property(x => x.PieceQuantity).HasColumnName("PieceQuantity");
            Property(x => x.SideTypeId).HasColumnName("SideTypeId").IsOptional();
            
            HasRequired(a => a.Order).WithMany(b => b.OrderDetail).HasForeignKey(c => c.OrderId);
            HasRequired(a => a.Product).WithMany(b => b.OrderDetail).HasForeignKey(c => c.ProductId);
            HasRequired(a => a.CustomerLocation).WithMany(b => b.OrderDetail).HasForeignKey(c => c.CustomerLocationId);
            HasRequired(a => a.SideType).WithMany(b => b.OrderDetail).HasForeignKey(c => c.SideTypeId);
        }
    }
}