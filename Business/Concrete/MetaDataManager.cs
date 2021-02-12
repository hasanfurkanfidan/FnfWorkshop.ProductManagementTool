using Business.Abstract;
using Business.Constants;
using Business.VariationListDto;
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
        
        public MetaDataManager(IProductRepository productRepository,IVariationRepository variationRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _variationRepository = variationRepository;
                 
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

        public async Task<IDataResult<VariationsWithCategoryInfoDto>> GetProductVariantsFromCategory(string categoryName,int applicationId)
        {
            var category = await _categoryRepository.GetWithSpesificationAsync(new BaseSpesification<Category>(p => p.Name == categoryName));
            var products = await _productRepository.GetListWithSpesificationAsync(new BaseSpesification<Product>(p => p.CategoryId == category.Id));

            var list = new List<VariationsWithCategoryInfoDto>();
            foreach (var item in products)
            {
                var model = new VariationsWithCategoryInfoDto();

            }

            return new SuccessDataResult<VariationsWithCategoryInfoDto>
            {
                Data = new VariationsWithCategoryInfoDto
                {

                },
                Success = true,
                Message = ""
            };
        }

      
    }
}
