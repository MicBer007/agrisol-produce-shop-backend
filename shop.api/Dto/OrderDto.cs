using shop.domain;

namespace shop.api.Dto
{
    public class OrderDto
    {
        public Guid? OrderId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? TimeCarted { get; set; }
        public DateTime? TimePayed { get; set; }
        public DateTime? TimeDelivered { get; set; }
     //   public Guid CustomerId { get; set; }
       // public List<int> Amounts { get; set; } = [];
        public List<ProductInOrderDto> ProductsInOrder { get; set; } = new List<ProductInOrderDto>();
    }
}
