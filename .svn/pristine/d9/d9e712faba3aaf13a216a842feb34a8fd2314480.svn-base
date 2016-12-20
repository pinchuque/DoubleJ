using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Model.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Service.Interfaces;

namespace DoubleJ.Oms.Service.Services.Internal
{
    public class ProductSearchService : IProductSearchService
    {
        private readonly IProductRepository _productRepository;

        public ProductSearchService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductSearchResultItem> Search(ProductSearchViewModel viewModel)
        {
            return _productRepository.GetBySearchCriteria(viewModel.Name, viewModel.Upc, viewModel.Description,
                                                          viewModel.SpeciesId, viewModel.QualityGradeId,
                                                          viewModel.CustomerProductCode, viewModel.PrimalCutId,
                                                          viewModel.SubPrimalCutId, viewModel.TrimCutId)
                                     .Select(MapToResultItem)
                                     .ToList();
        }

        private static ProductSearchResultItem MapToResultItem(Product product)
        {
            return new ProductSearchResultItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Upc = product.Upc
                };
        }
    }
}