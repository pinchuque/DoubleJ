﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class SpeciesMap : EntityTypeConfiguration<Species>
    {
        public SpeciesMap()
        {
            ToTable("dbo.Species");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.SortOrder).HasColumnName("SortOrder").IsOptional();
            Property(x => x.BaseSpecies).HasColumnName("Species").IsOptional();
        }
    }
}