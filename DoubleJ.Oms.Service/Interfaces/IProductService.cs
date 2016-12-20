using System.Collections.Generic;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Model.Models;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IProductService
    {
        ProductViewModel Get();
        void Add(ProductViewModel model);
        ProductViewModel Get(int id);
        ProductDataViewModel GetAllCustomerData(int id);
        void Edit(ProductViewModel model);
        void Edit(int productId, ProductCodeItem model);
        void EditCustomerData(int productId, IEnumerable<ProductCodeItem> items);
        NutritionInfoViewModel GetNutritionInfo(int productId);
        void EditNutritionInfo(NutritionInfoViewModel model);
        IEnumerable<ProductCodeItem> GetCustomerItems(int productId);
        IEnumerable<ProductTypeItem> GetBoxTypes(OmsCustomerType? customerTypeId, bool isBoth);
        IEnumerable<ProductTypeItem> GetBagTypes(OmsCustomerType? customerTypeId, bool isBoth);
    }
}