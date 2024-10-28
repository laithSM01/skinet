using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    /*
     * this is going to act as snapshot of our product at the time it was placed
     * product name might change product image might change
     * but we dont want to change it inside order ( no need for relation between our order and productItem)
     * we gonna store the values as it was when it was ordered into our DB
     */
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemId, string productName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        //we need constructor to pass in the properties for this
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }

    }
}
