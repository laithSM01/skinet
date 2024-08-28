using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T> //there will be BaseSpecification to implement these interfaces
    {
        //generic expressions
        Expression<Func<T, bool>> Criteria { get; } 
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending {  get; }
        int Take {  get; } // take certain amount of records or products ex the first 5 
        int Skip { get; } // skip certain amount of records or products
        bool IsPagingEnabled { get; } 

    }
}
