using Business.Abstract;
using Business.Constants;
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
        private readonly IMetaDataService _metaDataService;
        public MetaDataTest(IMetaDataService metaDataService)
        {
            _metaDataService = metaDataService;
        }
        [Fact]
        public async Task AddProductTest()
        {
            var service = new Mock<IMetaDataService>();
            //Arrange
            var product = new Product
            {
                ApplicationId = 1,
                CategoryId = 1,
                Name = "Product1",

            };
            //Act
            var result = await service.Setup(p => p.AddProductAsync(product).Result);
            //Assert
            Assert.Equal(Messages.ProductAdded, result.Message);
        }
    }
}
