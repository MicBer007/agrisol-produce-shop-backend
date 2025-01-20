using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.domain
{
    public class ProductSupplier
    {
        public Guid? ProductSupplierId { get; set; }
        public string ProductSupplierName { get; set; }
        public List<Product> Products { get; set; } = new();

    }
}
