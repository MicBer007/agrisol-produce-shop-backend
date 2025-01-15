using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.domain
{
    public class Customer
    {
        public Guid? CustomerId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        public String BankDetails { get; set; }
    }

}
