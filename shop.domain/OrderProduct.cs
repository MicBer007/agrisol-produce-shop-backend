namespace shop.domain
{
    public class OrderProduct
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
