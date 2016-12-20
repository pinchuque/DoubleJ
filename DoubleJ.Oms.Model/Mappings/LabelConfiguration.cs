using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class LabelConfiguration : EntityTypeConfiguration<Label>
    {
        public LabelConfiguration()
        {
            ToTable("dbo.Label");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TypeId).HasColumnName("TypeId").IsRequired();
            Property(x => x.CurrentLocationId).HasColumnName("CurrentLocationId").IsOptional();
            Property(x => x.OrderDetailId).HasColumnName("OrderDetailId").IsRequired();
            Property(x => x.ItemCode).HasColumnName("ItemCode").IsRequired().HasMaxLength(15);
            Property(x => x.LotNumber).HasColumnName("LotNumber").IsRequired().HasMaxLength(15);
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(30);
            Property(x => x.PoundWeight).HasColumnName("PoundWeight").IsRequired();
            Property(x => x.KilogramWeight).HasColumnName("KilogramWeight").IsRequired();
            Property(x => x.ProcessDate).HasColumnName("ProcessDate").IsRequired().HasMaxLength(10);
            Property(x => x.SlaughterDate).HasColumnName("SlaughterDate").IsRequired().HasMaxLength(10);
            Property(x => x.BestBeforeDate).HasColumnName("BestBeforeDate").IsRequired();
            Property(x => x.SpeciesBugPath).HasColumnName("SpeciesBugPath").IsOptional().HasMaxLength(100);
            Property(x => x.LogoPath).HasColumnName("LogoPath").IsOptional().HasMaxLength(100);
            Property(x => x.BornIn).HasColumnName("BornIn").IsOptional().HasMaxLength(50);
            Property(x => x.RaisedIn).HasColumnName("RaisedIn").IsOptional().HasMaxLength(20);
            Property(x => x.ProductOf).HasColumnName("ProductOf").IsOptional().HasMaxLength(20);
            Property(x => x.DistributedBy).HasColumnName("DistributedBy").IsOptional().HasMaxLength(30);
            Property(x => x.GermanDescription).HasColumnName("GermanDescription").IsOptional().HasMaxLength(30);
            Property(x => x.FrenchDescription).HasColumnName("FrenchDescription").IsOptional().HasMaxLength(30);
            Property(x => x.ItalianDescription).HasColumnName("ItalianDescription").IsOptional().HasMaxLength(30);
            Property(x => x.SwedishDescription).HasColumnName("SwedishDescription").IsOptional().HasMaxLength(30);
            Property(x => x.IsPrinted).HasColumnName("IsPrinted").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.LabelFile).HasColumnName("LabelFile").IsRequired();
            Property(x => x.Primal).HasColumnName("Primal").IsOptional().HasMaxLength(20);
            Property(x => x.SubPrimal).HasColumnName("SubPrimal").IsOptional().HasMaxLength(20);
            Property(x => x.Trim).HasColumnName("Trim").IsOptional().HasMaxLength(20);
            Property(x => x.GradeName).HasColumnName("GradeName").IsOptional().HasMaxLength(20);
            Property(x => x.SerialNumber).HasColumnName("SerialNumber").IsOptional().HasMaxLength(20);
            Property(x => x.Organic).HasColumnName("Organic").IsOptional().HasMaxLength(100);
            Property(x => x.CustomerProductCode).HasColumnName("CustomerProductCode").IsOptional().HasMaxLength(30);
            Property(x => x.Customer).HasColumnName("Customer").IsOptional().HasMaxLength(25);
            Property(x => x.CustomerProductDescription).HasColumnName("VarCustomerProductValue").IsOptional().HasMaxLength(20);
            Property(x => x.PackedFor).HasColumnName("PackedFor").IsRequired().HasMaxLength(50);
            Property(x => x.Refrigeration).HasColumnName("Refrigeration").IsOptional().HasMaxLength(50);

            HasRequired(a => a.LabelType).WithMany(b => b.Label).HasForeignKey(c => c.TypeId); 
            HasRequired(a => a.OrderDetail).WithMany(b => b.Label).HasForeignKey(c => c.OrderDetailId); 
            HasRequired(a => a.CurrentLocation).WithMany(b => b.Label).HasForeignKey(c => c.CurrentLocationId); 
        }
    }
}