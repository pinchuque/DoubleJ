using System;
using System.Collections.Generic;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Service.Interfaces;

namespace DoubleJ.Oms.Service.Services.Internal
{
    public class ManageCaseService : IManageCaseService
    {
        private readonly ICaseTypeRepository _caseTypeRepository;
        public ManageCaseService(ICaseTypeRepository caseTypeRepository, ICustomerTypeRepository customerTypeRepository)
        {
            _caseTypeRepository = caseTypeRepository;
        }

        public IEnumerable<CaseType> GetTypes()
        {
            return _caseTypeRepository.GetAll();
        }

        public IEnumerable<CustomerType> GeCustomerTypes()
        {
            throw new NotImplementedException();
        }
    }
}