using shop.domain;

namespace shop.api.Dto
{
    public class CartProductDto
    {
        public ProductDto? Product { get; set; }
        public CartDto? Cart { get; set; }
        public int Quantity { get; set; }
    }
}
