using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Order");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CustomerId).HasColumnName("CustomerId").IsRequired();
            Property(x => x.POCustomer).HasColumnName("POCustomer").IsOptional().HasMaxLength(50);
            Property(x => x.StatusId).HasColumnName("StatusId").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.RequestedProcessDate).HasColumnName("RequestedProcessDate").IsRequired();
            Property(x => x.ReceiveDate).HasColumnName("ReceiveDate").IsOptional();
            Property(x => x.SlaughterDate).HasColumnName("SlaughterDate").IsOptional();
            Property(x => x.ProcessDate).HasColumnName("ProcessDate").IsOptional();
            Property(x => x.ExpectedHeadNumber).HasColumnName("ExpectedHeadNumber").IsRequired();
            Property(x => x.ReceivedHeadNumber).HasColumnName("ReceivedHeadNumber").IsOptional();
            Property(x => x.SlaughteredHeadNumber).HasColumnName("SlaughteredHeadNumber").IsOptional();
            Property(x => x.BornRegionId).HasColumnName("BornRegionId").IsOptional();
            Property(x => x.RaisedRegionId).HasColumnName("RaisedRegionId").IsOptional();
            Property(x => x.SlaughteredRegionId).HasColumnName("SlaughteredRegionId").IsOptional();
            Property(x => x.ProductOfRegionId).HasColumnName("ProductOfRegionId").IsOptional();
            Property(x => x.SpecialInstructions).HasColumnName("SpecialInstructions").IsOptional().HasMaxLength(500);
            Property(x => x.CustomerComments).HasColumnName("CustomerComments").IsOptional().HasMaxLength(500);
            Property(x => x.ComboCompleted).HasColumnName("ComboCompleted").IsRequired();
            Property(x => x.RefrigerationId).HasColumnName("RefrigerationId").IsOptional();
            Property(x => x.BestBeforeDate).HasColumnName("BestBeforeDate").IsOptional();
            Property(x => x.LotNumber).HasColumnName("LotNumber").IsOptional().HasMaxLength(15);
            Property(x => x.AdditionalInfoOnLabel).HasColumnName("AdditionalInfoOnLabel").IsOptional().HasMaxLength(20);
            Property(x => x.BagEnable).HasColumnName("BagEnable").IsRequired();

            HasRequired(a => a.Customer)
                .WithMany(b => b.Order)
                .HasForeignKey(c => c.CustomerId)
                .WillCascadeOnDelete(false);
            HasRequired(a => a.Status).WithMany(b => b.Order).HasForeignKey(c => c.StatusId);
            HasOptional(a => a.BornRegion).WithMany(b => b.OrderBornRegion).HasForeignKey(c => c.BornRegionId);
            HasOptional(a => a.RaisedRegion).WithMany(b => b.OrderRaisedRegion).HasForeignKey(c => c.RaisedRegionId);
            HasOptional(a => a.SlaughteredRegion)
                .WithMany(b => b.OrderSlaughteredRegion)
                .HasForeignKey(c => c.SlaughteredRegionId);
            HasOptional(a => a.ProductOfRegion)
                .WithMany(b => b.OrderProductOfRegion)
                .HasForeignKey(c => c.ProductOfRegionId);
        }
    }
}