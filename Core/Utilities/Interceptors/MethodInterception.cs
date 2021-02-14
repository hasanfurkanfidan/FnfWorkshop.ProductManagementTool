using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual async Task OnBeforeAsync(IInvocation invocation)
        {

        }
        protected virtual void OnBefore(IInvocation invocation)
        {

        }

        protected virtual void OnAfter(IInvocation invocation)
        {

        }
        protected virtual void OnException(IInvocation invocation)
        {

        }
        protected virtual void OnSuccess(IInvocation invocation)
        {

        }
        public override async Task InterceptAsync(IInvocation invocation)
        {
            var isSuccess = true;
            await OnBeforeAsync(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBeforeAsync(invocation).Wait();
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
