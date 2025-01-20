using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.domain
{
    public class ProductProductSupplier
    {
        public Guid ProductId { get; set; }
        public Guid ProductSupplierId { get; set; }
    }
}
