using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class BagSizeMap : EntityTypeConfiguration<BagSize>
    {
        public BagSizeMap()
        {
            ToTable("dbo.BagSize");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired();
            Property(x => x.TareWeight).HasColumnName("TareWeight").IsRequired();
        }
    }
}
