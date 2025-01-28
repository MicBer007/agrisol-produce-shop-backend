namespace shop.domain
{
    public class ProductSupplierJoin
    {
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime MomentCreated { get; set; }
    }
}
