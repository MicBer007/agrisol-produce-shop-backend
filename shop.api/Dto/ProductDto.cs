namespace shop.api.Dto
{
    public class ProductDto
    {
        public Guid? ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string PictureName { get; set; }
        public List<ProductSupplierJoinDto> ProductSupplierJoins { get; set; } = [];
        public List<OrderProductDto> OrderProducts { get; set; } = [];
        public List<CartProductDto> CartProducts { get; set; } = [];

    }

}
