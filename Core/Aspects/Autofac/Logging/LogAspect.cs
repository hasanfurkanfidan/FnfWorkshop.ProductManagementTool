using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType!=typeof(LoggerServiceBase))
            {
                throw new Exception(AspectMessages.LoggerType);
            }
            _loggerServiceBase =(LoggerServiceBase) Activator.CreateInstance(loggerService);
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = invocation.Arguments.Select(x => new LogParameter { Value = x, Type = x.GetType().Name, }).ToList();
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                ApplicationId =Convert.ToInt32(logParameters.Where(p=>p.Name == "applicationId").FirstOrDefault().Value),
                LogParameters = logParameters,
                
            };
            return logDetail;
        } 
    }
}
