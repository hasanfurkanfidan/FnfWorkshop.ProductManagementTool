using Business.VariationListDto;
using Core.Utilities.Result;
using CQRS.Query;
using Enities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMetaDataService
    {
        Task<IDataResult<List< VariationsWithCategoryInfoDto>>> GetProductVariantsFromCategory(GetProductsWithCategoryQuery query);
        Task<IResult> AddProductAsync(Product product);
        Task<IResult> CheckProductNameExistAsync(string productName);
    }
}
