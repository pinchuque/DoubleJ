using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class ScaleMap : EntityTypeConfiguration<Scale>
    {
        public ScaleMap()
        {
            ToTable("dbo.Scale");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IpAddress).HasColumnName("IpAddress").IsRequired().HasMaxLength(15);
            Property(x => x.IpPort).HasColumnName("IpPort").IsRequired();
            Property(x => x.TimeoutSeconds).HasColumnName("TimeoutSeconds").IsRequired();
        }
    }
}