using System.Collections.Generic;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface IColdWeightEntryDetailRepository : IGenericRepository<ColdWeightEntryDetail>
    {
        bool CheckIfAnimalNumberAlreadyExists(string valueToCheck);
        bool CheckIfEarTagAlreadyExists(string valueToCheck);
        bool RemoveAllDetails(int id);
        Dictionary<OmsSideType, int?> GetSideWeigths(int coldWeightDetailId);
    }
}
