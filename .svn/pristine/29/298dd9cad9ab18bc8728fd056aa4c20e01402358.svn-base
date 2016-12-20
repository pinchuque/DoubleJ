using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("dbo.Product");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Upc).HasColumnName("UPC").IsRequired().HasMaxLength(12);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(30);
            Property(x => x.GermanDescription).HasColumnName("GermanDescription").IsOptional().HasMaxLength(30);
            Property(x => x.FrenchDescription).HasColumnName("FrenchDescription").IsOptional().HasMaxLength(30);
            Property(x => x.ItalianDescription).HasColumnName("ItalianDescription").IsOptional().HasMaxLength(30);
            Property(x => x.SwedishDescription).HasColumnName("SwedishDescription").IsOptional().HasMaxLength(30);
            Property(x => x.PrimalCutId).HasColumnName("PrimalCutId").IsRequired();
            Property(x => x.SubPrimalCutId).HasColumnName("SubPrimalCutId").IsOptional();
            Property(x => x.TrimCutId).HasColumnName("TrimCutId").IsOptional();
            Property(x => x.SpeciesId).HasColumnName("SpeciesId").IsOptional();
            Property(x => x.QualityGradeId).HasColumnName("QualityGradeId").IsOptional();
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();

            HasRequired(a => a.PrimalCut).WithMany(b => b.Product).HasForeignKey(c => c.PrimalCutId); 
            HasOptional(a => a.SubPrimalCut).WithMany(b => b.Product).HasForeignKey(c => c.SubPrimalCutId); 
            HasOptional(a => a.TrimCut).WithMany(b => b.Product).HasForeignKey(c => c.TrimCutId); 
            HasOptional(a => a.Species).WithMany(b => b.Product).HasForeignKey(c => c.SpeciesId); 
            HasOptional(a => a.QualityGrade).WithMany(b => b.Product).HasForeignKey(c => c.QualityGradeId); 
        }
    }
}