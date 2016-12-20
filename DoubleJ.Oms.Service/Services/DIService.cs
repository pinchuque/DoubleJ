using DoubleJ.Oms.DataAccess;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.Repositories;
using DoubleJ.Oms.Service.Interfaces;
using DoubleJ.Oms.Service.Interfaces.Web;
using DoubleJ.Oms.Service.Services.Internal;
using DoubleJ.Oms.Service.Services.Web;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;

namespace DoubleJ.Oms.Service.Services
{

    public static class DIService
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>(params IParameter[] parameters)
        {
            return _ninjectKernel.Get<T>(parameters);
        }

        public static void RegisterServicesWeb(IKernel kernel)
        {
            kernel.Bind<IOmsContext>().To<OmsContext>().InScope(x => x.Request);
            RegisterServices(kernel);
        }

        public static void RegisterServicesDesktop(IKernel kernel)
        {
            kernel.Bind<IOmsContext>().To<OmsContext>().InScope(x => x.Request);
            RegisterServices(kernel);
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind<IColdWeightEntryRepository>().To<ColdWeightEntryRepository>();
            kernel.Bind<IColdWeightEntryDetailRepository>().To<ColdWeightEntryDetailRepository>();
            kernel.Bind<ICustomerLocationRepository>().To<CustomerLocationRepository>();
            kernel.Bind<ICustomerProductDataRepository>().To<CustomerProductDataRepository>();
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<ILabelRepository>().To<LabelRepository>();
            kernel.Bind<ILogoTypeRepository>().To<LogoTypeRepository>();
            kernel.Bind<IOrderDetailRepository>().To<OrderDetailRepository>();
            kernel.Bind<IOffalRepository>().To<OffalRepository>();
            kernel.Bind<IOrderOffalRepository>().To<OrderOffalRepository>();
            kernel.Bind<IOrderComboRepository>().To<OrderComboRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IPrimalCutRepository>().To<PrimalCutRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IQualityGradeRepository>().To<QualityGradeRepository>();
            kernel.Bind<IRegionRepository>().To<RegionRepository>();
            kernel.Bind<IScaleRepository>().To<ScaleRepository>();
            kernel.Bind<ISiteNavigationRepository>().To<SiteNavigationRepository>();
            kernel.Bind<ISpeciesRepository>().To<SpeciesRepository>();
            kernel.Bind<IStatusRepository>().To<StatusRepository>();
            //kernel.Bind<ISubPrimalCutRepository>().To<SubPrimalCutRepository>();
            kernel.Bind<ITrimCutRepository>().To<TrimCutRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
			kernel.Bind<IRefrigerationRepository>().To<RefrigerationRepository>();
            kernel.Bind<ICutSheetDetailRepository>().To<CutSheetDetailRepository>();
            kernel.Bind<ISteakTypeRepository>().To<SteakTypeRepository>();
            kernel.Bind<IChuckTypeRepository>().To<ChuckTypeRepository>();
            kernel.Bind<IRibTypeRepository>().To<RibTypeRepository>();
            kernel.Bind<IPackageSizeRepository>().To<PackageSizeRepository>();
            kernel.Bind<IOrganMeatTypeRepository>().To<OrganMeatTypeRepository>();
            kernel.Bind<IAnimalOrderDetailRepository>().To<AnimalOrderDetailRepository>();
            kernel.Bind<ICaseTypeRepository>().To<CaseTypeRepository>();
            kernel.Bind<ICaseSizeRepository>().To<CaseSizeRepository>();
            kernel.Bind<IAnimalLabelRepository>().To<AnimalLabelRepository>();
            kernel.Bind<ICustomerTypeRepository>().To<CustomerTypeRepository>();

            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IColdWeightEntryService>().To<ColdWeightEntryService>();
            kernel.Bind<ILabelService>().To<LabelService>();
            kernel.Bind<ILabelCreateService>().To<Device.LabelCreateService>();
            kernel.Bind<ILookupService>().To<LookupService>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IOrderDetailService>().To<OrderDetailService>();
            kernel.Bind<IOrderSearchService>().To<OrderSearchService>();
            kernel.Bind<ISiteNavigationService>().To<SiteNavigationService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IScaleService>().To<Device.ScaleService>();
            kernel.Bind<IProductSearchService>().To<ProductSearchService>();
            kernel.Bind<IBoxSizeRepository>().To<BoxSizeRepository>();
            kernel.Bind<IBagSizeRepository>().To<BagSizeRepository>();
            kernel.Bind<IOrderReportService>().To<OrderReportService>();
            kernel.Bind<IManageCaseService>().To<ManageCaseService>();
        }        
    }
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            DIService.RegisterServicesDesktop(KernelInstance);
        }
    }
}
