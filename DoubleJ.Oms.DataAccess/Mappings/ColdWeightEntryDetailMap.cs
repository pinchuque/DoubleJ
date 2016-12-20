﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class ColdWeightEntryDetailMap : EntityTypeConfiguration<ColdWeightEntryDetail>
    {
        public ColdWeightEntryDetailMap()
        {
            ToTable("dbo.ColdWeightDetail");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ColdWeightId).HasColumnName("ColdWeightId").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.FirstSideWeight).HasColumnName("FirstSideWeight").IsRequired();
            Property(x => x.SecondSideWeight).HasColumnName("SecondSideWeight").IsOptional();
            Property(x => x.ThirdSideWeight).HasColumnName("ThirdSideWeight").IsOptional();
            Property(x => x.FourthSideWeight).HasColumnName("FourthSideWeight").IsOptional();
            Property(x => x.HotWeight).HasColumnName("HotWeight").IsRequired();
            Property(x => x.ColdWeight).HasColumnName("ColdWeight").IsRequired();
            Property(x => x.AnimalNumber).HasColumnName("AnimalNumber").IsOptional();
            Property(x => x.EarTag).HasColumnName("EarTag").IsOptional();
            Property(x => x.IsOrganic).HasColumnName("IsOrganic").IsRequired();
            Property(x => x.AnimalLabelId).HasColumnName("AnimalLabelId").IsRequired();
            Property(x => x.QualityGradeId).HasColumnName("QualityGradeId").IsOptional();
            Property(x => x.TrackAnimalId).HasColumnName("TrackAnimalId").IsRequired();

            HasRequired(a => a.ColdWeightEntry).WithMany(b => b.ColdWeightEntryDetails).HasForeignKey(c => c.ColdWeightId);
            HasRequired(a => a.AnimalLabel).WithMany(b => b.ColdWeightEntryDetails).HasForeignKey(c => c.AnimalLabelId);
            HasOptional(a => a.QualityGrade).WithMany(b => b.ColdWeightEntries).HasForeignKey(c => c.QualityGradeId);
        }
    }
}