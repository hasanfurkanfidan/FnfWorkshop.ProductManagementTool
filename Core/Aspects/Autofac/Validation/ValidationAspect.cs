using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        Type _Validator;
        public ValidationAspect(Type Validator)
        {
            if (!typeof(IValidator).IsAssignableFrom(Validator))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }
            _Validator = Validator;
        }
        protected override async Task OnBefore(IInvocation invocation)
        {
            var validator =(IValidator<object>)Activator.CreateInstance(_Validator);
            var entityType = _Validator.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                await ValidationTool.ValidateAsync<object>(validator, entity);
            }


        }
    }
}
