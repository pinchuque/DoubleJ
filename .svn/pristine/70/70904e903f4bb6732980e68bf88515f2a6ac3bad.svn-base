using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class BoxSizeMap : EntityTypeConfiguration<BoxSize>
    {
        public BoxSizeMap()
        {
            ToTable("dbo.BoxSize");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired();
            Property(x => x.TareWeight).HasColumnName("TareWeight").IsRequired();
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
            Property(x => x.CreateUserId).HasColumnName("CreateUserId").IsRequired();
            Property(x => x.CreateDateTime).HasColumnName("CreateDateTime").IsRequired();
            Property(x => x.UpdateUserId).HasColumnName("UpdateUserId").IsOptional();
            Property(x => x.UpdateDateTime).HasColumnName("UpdateDateTime").IsOptional();
        }
    }
}