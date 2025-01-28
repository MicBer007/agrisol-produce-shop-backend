namespace shop.domain
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string BankDetails { get; set; }
        public List<Order> Orders { get; set; } = [];
    }

}
