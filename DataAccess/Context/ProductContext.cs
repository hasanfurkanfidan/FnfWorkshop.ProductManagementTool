using Enities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ProductContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ProductManagementTool.mssql.somee.com;Database=ProductManagementTool;user id=hasanfurkanfidan_SQLLogin_1;password=b9w53l2io7");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<VariationType> VariationTypes { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}
