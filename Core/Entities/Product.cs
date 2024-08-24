namespace Core.Entities
{
    public class Product : BaseEntity
    {
        //we no longer need to specify id cause its getting it from BaseEntity
        public string? Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public ProductType? ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand? ProductBrand { get; set; }
        public int  ProductBrandId { get; set; }
    }
}
