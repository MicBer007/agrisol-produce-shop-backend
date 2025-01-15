using shop.domain;

namespace shop.api.Dto
{
    public class CustomerDto
    {
        public Guid? CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string BankDetails { get; set; }

    }

}
