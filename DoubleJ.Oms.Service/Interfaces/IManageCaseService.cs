using System.Collections.Generic;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IManageCaseService
    {
        IEnumerable<CaseType> GetTypes();
        IEnumerable<CustomerType> GeCustomerTypes();
    }
}