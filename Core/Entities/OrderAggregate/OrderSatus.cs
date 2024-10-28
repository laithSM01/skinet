using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    /*
     * its not a class its an enum
     * this is gonna track status our orders in 
     * 3 status
     */
    public enum OrderSatus
    {
        //add additional attributes so you can return the text of the status here
        [EnumMember(Value ="Pending")]
        Pending,
        [EnumMember(Value = "Payment Recieved")]
        PaymentRecieved,
        [EnumMember(Value = "Payment Failed")]
        PaymentFailed

        //in real applications you will have more fields such as shipped, complete
    }
}
