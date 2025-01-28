using shop.domain;

namespace shop.api.Dto
{
    public class OrderProductDto
    {
        public ProductDto Product { get; set; }
        public OrderDto Order { get; set; }
        public int Quantity { get; set; }
    }
}
