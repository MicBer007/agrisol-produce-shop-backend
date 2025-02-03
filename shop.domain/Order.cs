namespace shop.domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime? TimeCancelled { get; set; }
        public DateTime? TimePayed { get; set; }
        public DateTime? TimeDelivered { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = [];
    }
}
