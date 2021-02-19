using Business.Abstract;
using Business.Constants;
using Business.Validations;
using Business.VariationListDto;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Spesification;
using Core.Utilities.BusinessRule;
using Core.Utilities.Result;
using CQRS.Query;
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
        public MetaDataManager(IProductRepository productRepository, IStockRepository stockRepository, IVariantPictureRepository variantPictureRepository, IVariationRepository variationRepository, ICategoryRepository categoryRepository)
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
            if (result != null)
            {
                return result;
            }
            await _productRepository.AddAsync(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> CheckProductNameExistAsync(string productName)
        {
            var products = await _productRepository.GetListWithSpesificationAsync(new BaseSpesification<Product>(p => p.Name == productName));
            if (products.Count > 0)
            {
                return new ErrorResult(Messages.ProductExist);
            }
            return new SuccessResult();
        }
      
        //[LogAspect(typeof(DatabaseLogger))]
        [CacheAspect(40)]
        [ValidationAspect(typeof(GetProductListWithCategoryValidate))]

        public async Task<IDataResult<List<VariationsWithCategoryInfoDto>>> GetProductVariantsFromCategory(GetProductsWithCategoryQuery query)
        {
            var products = new List<Product>();
            var category = await _categoryRepository.GetWithSpesificationAsync(new BaseSpesification<Category>(p => p.Name == query.CategoryName));
            if (category != null)
            {
                products = await _productRepository.GetListWithSpesificationAsync(new BaseSpesification<Product>(p => p.CategoryId == category.Id));

            }

            var list = new List<VariationsWithCategoryInfoDto>();
            if (products.Count > 0)
            {
                foreach (var item in products)
                {
                    var model = new VariationsWithCategoryInfoDto();
                    var variant = await _variationRepository.GetWithSpesificationAsync(new BaseSpesification<Variation>(p => p.ProductId == item.Id && p.IsActive == true));

                    model.ProductName = item.Name;
                    model.TotalData = products.Count();
                    if (variant != null)
                    {
                        var stocks = await _stockRepository.GetListWithSpesificationAsync(new BaseSpesification<Stock>(p => p.ProductId == item.Id && p.VariationId == variant.Id));
                        if (stocks.Count > 0)
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
            return new SuccessDataResult<List<VariationsWithCategoryInfoDto>>
            {
                Data = list,
                Message = Messages.ProductListWithCategory,
                Success = true
            };
        }


    }
}
