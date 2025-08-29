namespace Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        // stripe related properties: 
        public int? DeliveryMethodId { get; set; } // this is gonna be optional: they won't have the chance to select method until checkout
        public string? ClientSecret { get; set; } // will be used from stripe so the user can confirm the payment intent 
        public string? PaymentIntentId { get; set; } // will use this one to be able to update payment intent
        public decimal ShippingPrice { get; set; }
    }
}
