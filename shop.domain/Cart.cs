using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.domain
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public Guid CustomerId {  get; set; }
        public Customer Customer { get; set; }
        public List<CartProduct> CartProducts { get; set; } = [];

    }
}
