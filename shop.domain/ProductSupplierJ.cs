namespace shop.domain
{
    public class ProductSupplierJ
    {
        public Guid ProductId { get; set; }
        public Guid ProductSupplierId { get; set; }
        public DateTime MomentCreated { get; set; }
    }
}
