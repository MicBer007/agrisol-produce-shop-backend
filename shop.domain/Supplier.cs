namespace shop.domain
{
    public class Supplier
    {
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public List<Product> Products { get; set; } = new();

    }
}
