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

    }
}
