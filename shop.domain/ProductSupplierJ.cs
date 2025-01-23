namespace shop.domain
{
    public class ProductSupplierJ
    {
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime MomentCreated { get; set; }
    }
}
