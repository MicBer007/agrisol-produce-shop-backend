using shop.domain;

namespace shop.api.Dto
{
    public class ProductInOrderDto
    {
        public ProductWithoutProductsInOrderDto Product { get; set; }
       
        public OrderWithoutProductsInOrderDto Order { get; set; }
        public int Quantity { get; set; }
    }
}
