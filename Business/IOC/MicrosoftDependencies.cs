using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IOC
{
    public static class MicrosoftDependencies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMetaDataService, MetaDataManager>();
            services.AddScoped<IVariantPictureRepository, VariantPictureRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IVariationRepository, VariationRepository>();
            services.AddScoped<IVariationTypeRepository, VariationTypeRepository>();
            services.AddScoped<IVariantPictureRepository, VariantPictureRepository>();



        }
    }
}
