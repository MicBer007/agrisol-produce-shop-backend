namespace shop.domain
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string PictureName { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = [];
        public List<ProductSupplierJoin> ProductSupplierJoins { get; set; } = [];
    }

}
