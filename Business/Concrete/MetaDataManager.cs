using Business.Abstract;
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
            return new SuccessResult("Product Added");
        }

        public async Task<IResult> CheckProductNameExistAsync(string productName)
        {
            var product = await _productRepository.GetListWithSpesificationAsync(new BaseSpesification<Product> { Criteria = p => p.Name == productName });
            var result = product.Any();
            if (result)
            {
                return new ErrorResult("Product Name already exist.");
            }
            return new SuccessResult();
        }
    }
}
