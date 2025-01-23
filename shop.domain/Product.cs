namespace shop.domain
{
    public class Product
    {
        public Guid? ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string PictureName { get; set; }
        public List<ProductSupplier> Suppliers { get; set; } = new List<ProductSupplier>();
        public List<ProductInOrder> ProductInOrders { get; set; } = new List<ProductInOrder>();
    }

}
