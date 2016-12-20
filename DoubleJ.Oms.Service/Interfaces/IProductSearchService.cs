using System.Collections.Generic;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IProductSearchService
    {
        List<ProductSearchResultItem> Search(ProductSearchViewModel viewModel);
    }
}