using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,ICoreModule[]coreModules)
        {
            foreach (var modude in coreModules)
            {
                modude.Load(services);
            }
            return ServiceTool.Create(services);
        }

    }
}
