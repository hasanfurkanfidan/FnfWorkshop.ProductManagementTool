using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Enities.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class MetaDataTest
    {
        private IProductRepository _productRepository { get; set; }
        private IMetaDataService _metaDataService { get; set; }
        public MetaDataTest()
        {
            this._productRepository = new ProductRepository();
            this._metaDataService = new MetaDataManager(_productRepository);
        }
        [Fact]
       
        public async Task AddProductTest()
        {
            var product = new Product
            {
                ApplicationId = 1,
                CategoryId = 1,
                Name = "Product1",
            };
            var actualData =await _metaDataService.AddProductAsync(product);
            Assert.Equal(Messages.ProductAdded,actualData.Message);
        }
    }
}
