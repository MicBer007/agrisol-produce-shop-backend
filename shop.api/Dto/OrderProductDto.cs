using shop.domain;

namespace shop.api.Dto
{
    public class OrderProductDto
    {
        public ProductWithoutOrderProductsDto Product { get; set; }
        public OrderWithoutOrderProductsDto Order { get; set; }
        public int Quantity { get; set; }
    }
}
