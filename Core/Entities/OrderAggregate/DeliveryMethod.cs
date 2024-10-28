using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    /*
     * no need for constructor
     * user will select a delivery method and use delivery method id
     * to decide which delivery method is going to be in our order
     */
    public class DeliveryMethod : BaseEntity
    {
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public  string Description { get; set; }
        public decimal Price { get; set; }
    }
}
