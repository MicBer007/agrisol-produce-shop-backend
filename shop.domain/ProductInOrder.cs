namespace shop.domain
{
    public class ProductInOrder
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
