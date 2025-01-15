using shop.domain;

namespace shop.api.Dto
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string BankDetails { get; set; }

        public CustomerDto()
        {

        }
        public CustomerDto(Customer customer)
        {
            CustomerId = customer.CustomerId;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Age = customer.Age;
            BankDetails = customer.BankDetails;
        }
        public Customer ToDomain()
        {
            return new Customer
            {
                CustomerId = CustomerId,
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                BankDetails = BankDetails
            };
        }

        public void FromDomain(Customer customer)
        {

            CustomerId = customer.CustomerId;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Age = customer.Age;
            BankDetails = customer.BankDetails;
        }

    }

}
