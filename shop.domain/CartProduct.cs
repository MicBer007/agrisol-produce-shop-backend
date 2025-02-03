using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.domain
{
    public class CartProduct
    {
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }

    }
}
