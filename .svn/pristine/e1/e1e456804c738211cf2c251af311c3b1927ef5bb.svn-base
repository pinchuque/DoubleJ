using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class PrimalCutMap : EntityTypeConfiguration<PrimalCut>
    {
        public PrimalCutMap()
        {
            ToTable("dbo.PrimalCut");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.SortOrder).HasColumnName("SortOrder").IsRequired();
            Property(x => x.TextColor).HasColumnName("TextColor").IsOptional().HasMaxLength(50);
            Property(x => x.BackgroundColor).HasColumnName("BackgroundColor").IsOptional().HasMaxLength(50);
            Property(x => x.BackgroundSort).HasColumnName("BackgroundSort").IsRequired();
        }
    }
}