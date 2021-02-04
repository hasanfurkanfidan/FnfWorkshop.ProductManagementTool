using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spesification
{
    public class BaseSpesification<T> : ISpesification<T>
    {
        public BaseSpesification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }


        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }
    }
}
