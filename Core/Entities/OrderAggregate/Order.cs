using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    /*
     * Aggregate all the classes
     * BaseEntity: have own table, and id
     * we wont relate order to identities
     */
    public class Order : BaseEntity
    {
        public Order() { }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyeremail, Address shipToAddress, DeliveryMethod deliveryMethod, decimal subtotal)
        {
            Buyeremail = buyeremail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
        }


        //this is what we will use to retrieve list of orders
        public string Buyeremail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderSatus Status { get; set; }
        [NotMapped]
        public string PaymentIntentId { get; set; }
        /*
         * AutoMapper gonna look inside our classes
         * if he sees something called getWhatever
         * then its also gonna run and get Total and populate that into Total
         * it has to be named what we called our total 
         * and the word get infront of the property
         */
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }

    }
}
