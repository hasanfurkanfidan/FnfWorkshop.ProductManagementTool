using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Enities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {


        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>();
            var manager = new MetaDataManager(new ProductRepository());
           var result =  await manager.AddProductAsync(new Product
            {
                Name = "Product1",
                CategoryId = 3,
                ApplicationId = 1,

            });
            Console.WriteLine(result.Message);
            Console.Read();
        }


        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddDbContext<ProductContext>();
                    services.AddScoped<IProductRepository, ProductRepository>();
                });
        }
       

    }
}
