namespace shop.api.Dto
{
    public class OrderWithoutOrderProductsDto
    {
        public Guid? OrderId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? TimeCarted { get; set; }
        public DateTime? TimePayed { get; set; }
        public DateTime? TimeDelivered { get; set; }
        public Guid CustomerId { get; set; }
    }
}
