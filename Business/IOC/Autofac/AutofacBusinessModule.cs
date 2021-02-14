using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Interceptors;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Concrete;
using DataAccess.Abstract;

namespace Business.IOC.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MetaDataManager>().As<IMetaDataService>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<StockRepository>().As<IStockRepository>();
            builder.RegisterType<VariationRepository>().As<IVariationRepository>();
            builder.RegisterType<VariantPictureRepository>().As<IVariantPictureRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions() {
                Selector =new AspectInterceptorSelector()
            }).SingleInstance();
                
        }
    }
}
