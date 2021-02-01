using Core.Abstract;
using Core.DataAccess.EntityFrameworkCore.Abstract;
using Core.Spesification;
using DataAccess.Abstract;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new ProductContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new ProductContext();
             context.Remove(entity);
            await context.SaveChangesAsync();

        }

        public async Task<List<TEntity>> GetAll()
        {
            using var context = new ProductContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetListWithSpesificationAsync(ISpesification<TEntity> spesification)
        {
            var query = ApplySpesification(spesification);
            return await query.ToListAsync();
        }
        private IQueryable<TEntity> ApplySpesification(ISpesification<TEntity> spesification)
        {
            using var context = new ProductContext();
            return SpesificationEvaulator<TEntity>.GetQuery(context.Set<TEntity>().AsQueryable(), spesification);
        }
        public async Task<TEntity> GetWithSpesificationAsync(ISpesification<TEntity> spesification)
        {
            var query = ApplySpesification(spesification);
            return await query.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var context = new ProductContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
