using Business.Abstract;
using Business.Constants;
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
        
        public MetaDataManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
            var products = await _productRepository.GetListWithSpesificationAsync(new BaseSpesification<Product> { Criteria = p => p.Name == productName });
            if (products.Count>0)
            {
                return new ErrorResult(Messages.ProductExist);
            }
            return new SuccessResult();
        }
    }
}
