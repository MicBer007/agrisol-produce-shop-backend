namespace shop.api.Dto
{
    public class AddProductToCartRequestDto
    {
        public required Guid CartId { get; set; }
        public required Guid ProductId { get; set; }
        public required int Quantity { get; set; }
    }
}
