using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Domain
{
    public interface IOmsContext : IDisposable
    {
        IDbSet<Offal> Offals { get; set; }
        IDbSet<OrderCombo> OrderCombos { get; set; }
        IDbSet<OrderOffal> OrderOffals { get; set; }
        IDbSet<CurrentLocationType> CurrentLocationType { get; set; }
        IDbSet<ColdWeightEntry> ColdWeightEntry { get; set; }
        IDbSet<ColdWeightEntryDetail> ColdWeightEntryDetail { get; set; }
        IDbSet<Customer> Customer { get; set; }
        IDbSet<CustomerLocation> CustomerLocation { get; set; }
        IDbSet<CustomerProductData> CustomerProductData { get; set; }
        IDbSet<CustomerType> CustomerType { get; set; }
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
        //IDbSet<SubPrimalCut> SubPrimalCut { get; set; }
        IDbSet<TrimCut> TrimCut { get; set; }
        IDbSet<User> User { get; set; }
        IDbSet<UserType> UserType { get; set; }
        IDbSet<BoxSize> BoxSize { get; set; }
        IDbSet<BagSize> BagSize { get; set; }
        IDbSet<CaseType> CaseType { get; set; }
        IDbSet<CaseSize> CaseSize { get; set; }
        IDbSet<AnimalLabel> AnimalLabel { get; set; }
        IDbSet<ChuckType> ChuckType { get; set; }
        IDbSet<CutSheetDetail> CutSheetDetail { get; set; }
        IDbSet<OrganMeatType> OrganMeatType { get; set; }
        IDbSet<PackageSize> PackageSize { get; set; }
        IDbSet<RibType> RibType { get; set; }
        IDbSet<SteakType> SteakType { get; set; }
        IDbSet<OrganMeatValue> OrganMeatValue { get; set; }

        IDbSet<AnimalOrderDetail> AnimalOrderDetail { get; set; }
        
        int SaveChanges();
        void BulkInsert<T>(IEnumerable<T> sd);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
    }
}