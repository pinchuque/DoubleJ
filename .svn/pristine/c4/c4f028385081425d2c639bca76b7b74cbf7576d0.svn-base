using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class ColdWeightEntryMap : EntityTypeConfiguration<ColdWeightEntry>
    {
        public ColdWeightEntryMap()
        {
            ToTable("dbo.ColdWeight");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.TotalWeight).HasColumnName("TotalWeight").IsRequired();
            Property(x => x.TotalCount).HasColumnName("TotalCount").IsRequired();
            Property(x => x.TrackAnimalId).HasColumnName("TrackAnimalId").IsRequired();

            HasRequired(a => a.Order).WithMany(b => b.ColdWeightEntries).HasForeignKey(c => c.OrderId);
        }
    }
}