using shop.domain;

namespace shop.api.Dto
{
    public class ProductSupplierDto
    {
        public Guid? ProductSupplierId { get; set; }
        public string ProductSupplierName { get; set; }
        public List<Product> Products { get; set; }

    }
}
