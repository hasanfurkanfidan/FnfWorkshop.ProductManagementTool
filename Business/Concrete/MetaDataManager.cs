using Business.Abstract;
using Business.Constants;
using Business.VariationListDto;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Spesification;
using Core.Utilities.BusinessRule;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Enities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MetaDataManager : IMetaDataService
    {
        private readonly IProductRepository _productRepository;
        private readonly IVariationRepository _variationRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IVariantPictureRepository _variantPictureRepository;
        private readonly IStockRepository _stockRepository;
        public MetaDataManager(IProductRepository productRepository,IStockRepository stockRepository,IVariantPictureRepository variantPictureRepository,IVariationRepository variationRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _variantPictureRepository = variantPictureRepository;
            _categoryRepository = categoryRepository;
            _variationRepository = variationRepository;
            _stockRepository = stockRepository;     
        }
        public async Task<IResult> AddProductAsync(Product product)
        {
            var result = BusinessRules.Run(await CheckProductNameExistAsync(product.Name));
            if (result!=null)
            {
                return result;
            }
            await _productRepository.AddAsync(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> CheckProductNameExistAsync(string productName)
        {
            var products = await _productRepository.GetListWithSpesificationAsync(new BaseSpesification<Product>(p => p.Name == productName));
            if (products.Count>0)
            {
                return new ErrorResult(Messages.ProductExist);
            }
            return new SuccessResult();
        }
        [CacheAspect(40)]
        [LogAspect(typeof(DatabaseLogger))]
        public async Task<IDataResult<List<VariationsWithCategoryInfoDto>>> GetProductVariantsFromCategory(string categoryName,int applicationId)
        {
            var category = await _categoryRepository.GetWithSpesificationAsync(new BaseSpesification<Category>(p => p.Name == categoryName));
            var products = await _productRepository.GetListWithSpesificationAsync(new BaseSpesification<Product>(p => p.CategoryId == category.Id));

            var list = new List<VariationsWithCategoryInfoDto>();
            foreach (var item in products)
            {
                var model = new VariationsWithCategoryInfoDto();
                var variants = await _variationRepository.GetListWithSpesificationAsync(new BaseSpesification<Variation>(p => p.ProductId == item.Id&&p.IsActive==true));
                foreach (var variant in variants)
                {
                    model.ProductName = item.Name;
                    model.TotalData = variants.Count();
                    var stocks = await _stockRepository.GetListWithSpesificationAsync(new BaseSpesification<Stock>(p => p.ProductId == item.Id && p.VariationId == variant.Id));
                    if (stocks.Count>0)
                    {
                       
                        model.Price = stocks.FirstOrDefault().Price;
                        list.Add(model);
                    }
                    else
                    {
                        return new ErrorDataResult<List<VariationsWithCategoryInfoDto>>
                        {
                            Data = null,
                            Success = false,
                            Message = Messages.ProductNotExist
                        };
                    }
                 
                }
            }
            return new SuccessDataResult<List<VariationsWithCategoryInfoDto>>
            {
                Data = list,
                Message = Messages.ProductListWithCategory,
                Success = true
            };
        }

      
    }
}
