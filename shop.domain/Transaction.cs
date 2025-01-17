using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.domain
{
    public class Transaction
    {
        public Guid? TransactionId { get; set; }
        public string TransactionName { get; set; }
        public decimal TransactionValue { get; set; }
        public required Guid CustomerId { get; set; }

    }
}
