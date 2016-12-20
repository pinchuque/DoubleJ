using System.Collections.Generic;

using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IColdWeightEntryService
    {
        ColdWeightEntryModel Get(int orderId);
        ColdWeightCutSheetViewModel GetCutSheetViewModel(int orderId);
        ColdWeightEntryDetailItem GetColdWeightEntryDetail(int orderId);
        ColdWeightEntryModel GetColdWeightEntryPreferences(int? orderId);
        IEnumerable<ColdWeightEntryDetailItem> GetItems(int orderId);
        IEnumerable<ColdWeightEntryDetailItem> AddDetail(List<ColdWeightEntryDetailItem> arrayItems, ColdWeightEntryDetailItem item);
        bool RemoveDetail(ColdWeightEntryDetailItem coldWeightEntryDetailItem);
        bool RemoveAllDetails(int coldWeightId);
        void Update(ColdWeightEntryModel coldWeightEntryItem);

        void Save(IEnumerable<ColdWeightEntryDetailItem> newarray, int OrderId, TrackAnimal trackAnimal);
        bool CheckIfAnimalNumberAlreadyExists(string valueToCheck);
        bool CheckIfEarTagAlreadyExists(string valueToCheck);
    }
}
