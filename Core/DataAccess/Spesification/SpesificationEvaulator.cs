using Enities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spesification
{
    public class SpesificationEvaulator<TEntity> where TEntity:class,IEntity,new()
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpesification<TEntity> spesification)
        {
            var query = inputQuery;
            if (spesification.Criteria != null)
            {
                query = query.Where(spesification.Criteria);
            }
            query = spesification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
