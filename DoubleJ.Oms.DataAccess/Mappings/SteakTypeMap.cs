﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class SteakTypeMap : EntityTypeConfiguration<SteakType>
    {
        public SteakTypeMap()
        {
            ToTable("dbo.SteakType");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName("Name").IsOptional();
        }

    }
}
