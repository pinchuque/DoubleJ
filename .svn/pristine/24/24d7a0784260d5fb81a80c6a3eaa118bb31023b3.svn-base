using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class AnimalLabelMap : EntityTypeConfiguration<AnimalLabel>
    {
        public AnimalLabelMap()
        {
            ToTable("dbo.AnimalLabel");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IsOrganic).HasColumnName("IsOrganic").IsRequired();
            Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            Property(x => x.SpeciesId).HasColumnName("SpeciesId").IsRequired();
            HasRequired(x => x.Species).WithMany(x => x.AnimalLabels).HasForeignKey(x => x.SpeciesId);
        }
    }
}