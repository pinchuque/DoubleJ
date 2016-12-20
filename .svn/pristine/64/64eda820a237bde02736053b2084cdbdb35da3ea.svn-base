using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DoubleJ.Oms.Model.Entities;

namespace DoubleJ.Oms.Model
{
    public interface IOmsContext : IDisposable
    {
        IDbSet<ColdWeightEntry> ColdWeightEntry { get; set; } 
        IDbSet<ColdWeightEntryDetail> ColdWeightEntryDetail { get; set; } 
        IDbSet<Customer> Customer { get; set; }
        IDbSet<CustomerLocation> CustomerLocation { get; set; }
        IDbSet<CustomerProductCode> CustomerProductCode { get; set; }
        IDbSet<Label> Label { get; set; }
        IDbSet<LabelType> LabelType { get; set; }
        IDbSet<LogoType> LogoType { get; set; }
        IDbSet<Order> Order { get; set; }
        IDbSet<OrderDetail> OrderDetail { get; set; }
        IDbSet<PrimalCut> PrimalCut { get; set; }
        IDbSet<Product> Product { get; set; }
        IDbSet<QualityGrade> QualityGrade { get; set; }
        IDbSet<Region> Region { get; set; }
        IDbSet<Scale> Scale { get; set; }
        IDbSet<SiteNavigation> SiteNavigation { get; set; }
        IDbSet<Species> Species { get; set; }
        IDbSet<Status> Status { get; set; }
        IDbSet<SubPrimalCut> SubPrimalCut { get; set; }
        IDbSet<TrimCut> TrimCut { get; set; }
        IDbSet<User> User { get; set; }
        IDbSet<UserType> UserType { get; set; }

        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        IEnumerable<Product> ProductGetBySearchCriteria(string name, string upc, string description, int? speciesId, int? qualityGradeId, string customerProductCode, int? primalCutId, int? subPrimalCutId, int? trimCutId);
    }
}