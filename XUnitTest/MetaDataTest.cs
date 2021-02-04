using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
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
        private Mock<IProductRepository> mock { get; set; }
        private IMetaDataService _metaDataService { get; set; }
        public MetaDataTest()
        {
            mock = new Mock<IProductRepository>();
            this._metaDataService = new MetaDataManager(mock.Object);
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
            mock.Setup(z => z.AddAsync(product)).Returns(Task.FromResult(Messages.ProductAdded));
            var actualData =await _metaDataService.AddProductAsync(product);
            Assert.Equal(Messages.ProductAdded,actualData.Message);
        }
    }
}
