using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(){} //this constructor is to get list without parameters in the specification Class

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        //Include will do the include() in regular  repo c:
        public List<Expression<Func<T, object>>> Includes { get; } = 
            new List<Expression<Func<T, object>>>();

        //method allow us to add include statement to our include list
        //protected: access this class it self, or any child class

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include); 
        }
    }
}
