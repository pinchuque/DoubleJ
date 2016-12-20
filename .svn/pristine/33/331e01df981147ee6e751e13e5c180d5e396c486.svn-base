using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model.Mappings
{
    internal class SiteNavigationConfiguration : EntityTypeConfiguration<SiteNavigation>
    {
        public SiteNavigationConfiguration()
        {
            ToTable("dbo.SiteNavigation");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.Url).HasColumnName("Url").IsOptional().HasMaxLength(200);
            Property(x => x.SortOrder).HasColumnName("SortOrder").IsRequired();
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
        }
    }
}