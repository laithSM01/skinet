namespace API.Dtos
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        /*
         * AddressDto we need to map into the Address inside the order Aggregate
         * in mapping profiles.cs
         */
        public AddressDto ShipToAddress { get; set; }
    }
}
