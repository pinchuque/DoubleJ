using System.Collections.Generic;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Service.Interfaces.Web;

namespace DoubleJ.Oms.Service.Services.Web
{
    public class LookupService : ILookupService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogoTypeRepository _logoTypeRepository;
        private readonly IPrimalCutRepository _primalCutRepository;
        private readonly IQualityGradeRepository _qualityGradeRepository;
        private readonly IRefrigerationRepository _refrigerationRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly ISpeciesRepository _speciesRepository;
        private readonly IStatusRepository _statusRepository;
        //private readonly ISubPrimalCutRepository _subPrimalCutRepository;
        private readonly ITrimCutRepository _trimCutRepository;

        public LookupService(
            ICustomerRepository customerRepository, 
            ILogoTypeRepository logoTypeRepository,
            IPrimalCutRepository primalCutRepository, 
            IQualityGradeRepository qualityGradeRepository,
            IRegionRepository regionRepository, 
            ISpeciesRepository speciesRepository,
            IStatusRepository statusRepository, 
            //ISubPrimalCutRepository subPrimalCutRepository,
            ITrimCutRepository trimCutRepository, 
            IRefrigerationRepository refrigerationRepository)
        {
            _customerRepository = customerRepository;
            _logoTypeRepository = logoTypeRepository;
            _primalCutRepository = primalCutRepository;
            _qualityGradeRepository = qualityGradeRepository;
            _regionRepository = regionRepository;
            _speciesRepository = speciesRepository;
            _statusRepository = statusRepository;
            //_subPrimalCutRepository = subPrimalCutRepository;
            _trimCutRepository = trimCutRepository;
            _refrigerationRepository = refrigerationRepository;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetAllActive();
        }

        public IEnumerable<Customer> GetCustomers(string name)
        {
            return _customerRepository.GetActiveByName(name);
        }

        public IEnumerable<LogoType> GetLogoTypes()
        {
            return _logoTypeRepository.GetAll();
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _statusRepository.GetAll();
        }

        public IEnumerable<PrimalCut> GetPrimalCuts()
        {
            return _primalCutRepository.GetAll();
        }

        public IEnumerable<QualityGrade> GetQualityGrades()
        {
            return _qualityGradeRepository.GetAll();
        }

        public IEnumerable<Region> GetRegions()
        {
            return _regionRepository.GetAll();
        }

        public IEnumerable<Species> GetSpecies()
        {
            return _speciesRepository.GetAll();
        }

        //public IEnumerable<SubPrimalCut> GetSubPrimalCuts()
        //{
        //    return _subPrimalCutRepository.GetAll();
        //}

        public IEnumerable<TrimCut> GetTrimCuts()
        {
            return _trimCutRepository.GetAll();
        }

        public IEnumerable<Refrigeration> GetRefrigerations()
        {
            return _refrigerationRepository.GetAll();
        }
    }
}