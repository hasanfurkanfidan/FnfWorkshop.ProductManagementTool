using Business.VariationListDto;
using Core.Utilities.Result;
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
        Task<IDataResult<List< VariationsWithCategoryInfoDto>>> GetProductVariantsFromCategory(string categoryName, int applicationId);
        Task<IResult> AddProductAsync(Product product);
        Task<IResult> CheckProductNameExistAsync(string productName);
    }
}
