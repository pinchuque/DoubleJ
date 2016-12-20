using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using DoubleJ.Oms.Model.Entities;
using DoubleJ.Oms.Model.Mappings;

namespace DoubleJ.Oms.Model
{
    public class OmsContext : DbContext, IOmsContext
    {
        public IDbSet<ColdWeightEntry> ColdWeightEntry { get; set; } 
        public IDbSet<ColdWeightEntryDetail> ColdWeightEntryDetail { get; set; } 
        public IDbSet<Customer> Customer { get; set; } 
        public IDbSet<CustomerLocation> CustomerLocation { get; set; } 
        public IDbSet<CustomerProductCode> CustomerProductCode { get; set; } 
        public IDbSet<Label> Label { get; set; } 
        public IDbSet<LabelType> LabelType { get; set; } 
        public IDbSet<LogoType> LogoType { get; set; } 
        public IDbSet<Order> Order { get; set; } 
        public IDbSet<OrderDetail> OrderDetail { get; set; } 
        public IDbSet<Offal> Offals { get; set; } 
        public IDbSet<OrderCombo> OrderCombos { get; set; } 
        public IDbSet<OrderOffal> OrderOffals { get; set; } 
        public IDbSet<PrimalCut> PrimalCut { get; set; } 
        public IDbSet<Product> Product { get; set; } 
        public IDbSet<QualityGrade> QualityGrade { get; set; } 
        public IDbSet<Region> Region { get; set; } 
        public IDbSet<Scale> Scale { get; set; } 
        public IDbSet<SiteNavigation> SiteNavigation { get; set; } 
        public IDbSet<Species> Species { get; set; } 
        public IDbSet<Status> Status { get; set; } 
        public IDbSet<SubPrimalCut> SubPrimalCut { get; set; } 
        public IDbSet<TrimCut> TrimCut { get; set; } 
        public IDbSet<User> User { get; set; } 
        public IDbSet<UserType> UserType { get; set; } 
        public IDbSet<CurrentLocationType> CurrentLocationType { get; set; } 

        static OmsContext()
        {
            Database.SetInitializer(new OmsDbContextInitializer());
        }

        public OmsContext()
            : base("Name=OmsContext")
        {
        }

        public OmsContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ColdWeightEntryConfiguration());
            modelBuilder.Configurations.Add(new ColdWeightEntryDetailConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new CustomerLocationConfiguration());
            modelBuilder.Configurations.Add(new CustomerProductCodeConfiguration());
            modelBuilder.Configurations.Add(new LabelConfiguration());
            modelBuilder.Configurations.Add(new LabelTypeConfiguration());
            modelBuilder.Configurations.Add(new LogoTypeConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new OrderOffalConfiguration());
            modelBuilder.Configurations.Add(new OffalConfiguration());
            modelBuilder.Configurations.Add(new OrderComboConfiguration());
            modelBuilder.Configurations.Add(new PrimalCutConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new QualityGradeConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new ScaleConfiguration());
            modelBuilder.Configurations.Add(new SiteNavigationConfiguration());
            modelBuilder.Configurations.Add(new SpeciesConfiguration());
            modelBuilder.Configurations.Add(new StatusConfiguration());
            modelBuilder.Configurations.Add(new SubPrimalCutConfiguration());
            modelBuilder.Configurations.Add(new TrimCutConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
			modelBuilder.Configurations.Add(new RefrigerationConfiguration());
            modelBuilder.Configurations.Add(new CurrentLocationTypeConfiguration());
        }

        public virtual IEnumerable<Product> ProductGetBySearchCriteria(string name, string upc, string description, int? speciesId, int? qualityGradeId, string customerProductCode, int? primalCutId, int? subPrimalCutId, int? trimCutId)
        {
            const string query = "ProductGetBySearchCriteria @Name, @Upc, @Description, @SpeciesId, @QualityGradeId, @CustomerProductCode, @PrimalCutId, @SubPrimalCutId, @TrimCutId";
            var parameters = new object[]
                {
                    new SqlParameter("@Name", (object)name ?? DBNull.Value),
                    new SqlParameter("@Upc", (object)upc ?? DBNull.Value),
                    new SqlParameter("@Description", (object)description ?? DBNull.Value),
                    new SqlParameter("@SpeciesId", speciesId.HasValue ? (object)speciesId.Value : DBNull.Value),
                    new SqlParameter("@QualityGradeId", qualityGradeId.HasValue ? (object)qualityGradeId.Value : DBNull.Value),
                    new SqlParameter("@CustomerProductCode", (object)customerProductCode ?? DBNull.Value),
                    new SqlParameter("@PrimalCutId", primalCutId.HasValue ? (object)primalCutId.Value : DBNull.Value),
                    new SqlParameter("@SubPrimalCutId", subPrimalCutId.HasValue ? (object)subPrimalCutId.Value : DBNull.Value),
                    new SqlParameter("@TrimCutId", trimCutId.HasValue ? (object)trimCutId.Value : DBNull.Value)
                };

            var result = ((IObjectContextAdapter) this).ObjectContext.ExecuteStoreQuery<Product>(query, parameters);
            return result;
        }
    }
}