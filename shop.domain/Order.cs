using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Product> Products { get; set; } = new();
    }
}
