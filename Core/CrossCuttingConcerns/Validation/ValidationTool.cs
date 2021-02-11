using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static async Task ValidateAsync<T>(AbstractValidator<T> validator,T entity)
        {
            var result =await validator.ValidateAsync(entity);
        }
    }
}
