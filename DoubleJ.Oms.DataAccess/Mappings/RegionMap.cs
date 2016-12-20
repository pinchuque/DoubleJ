using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class RegionMap : EntityTypeConfiguration<Region>
    {
        public RegionMap()
        {
            ToTable("dbo.Region");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(20);
            Property(x => x.SortOrder).HasColumnName("SortOrder").IsRequired();
        }
    }
}