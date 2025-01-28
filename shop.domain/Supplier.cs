namespace shop.domain
{
    public class Supplier
    {
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public List<ProductSupplierJoin> ProductSupplierJoins { get; set; } = [];

    }
}
