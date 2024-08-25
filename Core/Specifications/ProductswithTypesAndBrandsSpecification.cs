using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductswithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductswithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        //Expression<Func<Product, bool>> criteria will be replaced with x => x.Id == id, and id is the one you type in
        public ProductswithTypesAndBrandsSpecification(int id) : base(productWithTheId => productWithTheId.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
