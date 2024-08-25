using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        /*
         * this method will take include just like product repo did,
         * Aggregate them and pass them into query 
         * which will be Iquerable, 
         * and pass to list or method so it can query to Db and return result which it contains
         */

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                //ex products: get me a product where the product is what ever we specified as this criteria
                query = query.Where(spec.Criteria);//p => p.ProductTypeId == id this what will be replaced inside brackets 
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
