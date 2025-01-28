namespace shop.api.Dto
{
    public class ProductSupplierJoinDto
    {
        public ProductDto Product { get; set; }
        public SupplierDto Supplier { get; set; }
        public DateTime MomentCreated { get; set; }
    }
}
