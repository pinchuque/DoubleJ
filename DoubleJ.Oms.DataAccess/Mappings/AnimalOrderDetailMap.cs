using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.DataAccess.Mappings
{
    public class AnimalOrderDetailMap : EntityTypeConfiguration<AnimalOrderDetail>
    {
        public AnimalOrderDetailMap()
        {
            ToTable("dbo.AnimalOrderDetail");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ColdWeightDetailId).HasColumnName("ColdWeightDetailId").IsRequired();
            Property(x => x.OrderDetailId).HasColumnName("OrderDetailId").IsRequired();

            HasRequired(a => a.ColdWeightEntryDetail).WithMany(b => b.AnimalOrderDetails).HasForeignKey(c => c.ColdWeightDetailId);
            HasRequired(a => a.OrderDetail).WithMany(b => b.AnimalOrderDetails).HasForeignKey(c => c.OrderDetailId);
        }
    }
}
