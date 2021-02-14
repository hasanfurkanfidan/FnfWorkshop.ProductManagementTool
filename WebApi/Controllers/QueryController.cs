using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Enities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IMetaDataService _metaDataService;
        public QueryController(IMetaDataService metaDataService)
        {
            _metaDataService = metaDataService;
        }
        [HttpPost]
       
        public async Task<IActionResult>AddProduct(Product product)
        {
           var jsonData = JsonConvert.SerializeObject(product);
           var classData =  JsonConvert.DeserializeObject<Product>(jsonData);
           var result =  await _metaDataService.AddProductAsync(product);
            return Ok(result.Message);
        }
        [HttpGet("getproducts")]      
        [CacheAspect(40)]

        public async Task<IActionResult>GetProducts(int applicationId,string categoryName)
        {
            var data = await _metaDataService.GetProductVariantsFromCategory(categoryName, applicationId);
            return Ok(data);
        }
    }
}
