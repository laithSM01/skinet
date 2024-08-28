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
        public ProductswithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(productObj =>
            (string.IsNullOrEmpty(productParams.Search) || productObj.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || productObj.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || productObj.ProductTypeId == productParams.TypeId) 
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
               productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort)
                {
                    case "priceAsc":
                            AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                       AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        //Expression<Func<Product, bool>> criteria will be replaced with x => x.Id == id, and id is the one you type in
        public ProductswithTypesAndBrandsSpecification(int id) : base(productWithTheId => productWithTheId.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
