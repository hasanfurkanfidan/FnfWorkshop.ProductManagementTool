using CQRS.Query;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class GetProductListWithCategoryValidate:AbstractValidator<GetProductsWithCategoryQuery>
    {
        public GetProductListWithCategoryValidate()
        {
            RuleFor(p => p.ApplicationId).ExclusiveBetween(1, int.MaxValue).WithMessage("AppId essential");
            RuleFor(p => p.CategoryName).Equal("dadas");
       }
    }
}
