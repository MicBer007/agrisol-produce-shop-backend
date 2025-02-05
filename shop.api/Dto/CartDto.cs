using shop.domain;

namespace shop.api.Dto
{
    public class CartDto
    {
        public Guid? CartId { get; set; }
        public CustomerDto? Customer { get; set; }
        public List<CartProductDto> CartProducts { get; set; } = [];

    }
}
