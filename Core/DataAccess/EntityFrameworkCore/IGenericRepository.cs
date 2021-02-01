using Core.Spesification;
using Enities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericRepository<TEntity>where TEntity:class,IEntity,new()
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetListWithSpesificationAsync(ISpesification<TEntity> spesification);
        Task<TEntity> GetWithSpesificationAsync(ISpesification<TEntity> spesification);

    }
}
