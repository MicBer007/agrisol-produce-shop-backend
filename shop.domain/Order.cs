namespace shop.domain
{
    public class Order
    {
        public Guid? OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime? TimeCarted { get; set; }
        public DateTime? TimePayed { get; set; }
        public DateTime? TimeDelivered { get; set; }
        public Guid CustomerId { get; set; }
        public List<ProductInOrder> ProductsInOrder { get; set; } = new List<ProductInOrder>();
    }
}
