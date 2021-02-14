using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using CQRS.Query;
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
        [HttpGet("getproducts")]
        [CacheAspect(duration:40)]
        public async Task<IActionResult>GetProducts(GetProductsWithCategoryQuery query)
        {
            var data = await _metaDataService.GetProductVariantsFromCategory(query.CategoryName, query.ApplicationId);
            return Ok(data);
        }
    }
}
