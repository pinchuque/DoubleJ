﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.DataAccess.Mappings
{
    internal class UserTypeMap : EntityTypeConfiguration<UserType>
    {
        public UserTypeMap()
        {
            ToTable("dbo.UserType");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
        }
    }
}