using Elfie.Serialization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using shop.api.Dto;
using shop.domain;

namespace shop.api.Mappers
{
    public static class CustomerMapper
    {

        public static CustomerDto ToDto(Customer Customer)
        {
            CustomerDto dto = new()
            {
                CustomerId = Customer.CustomerId,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                Age = Customer.Age,
                BankDetails = Customer.BankDetails,
                Orders = Customer.Orders.Select(o => OrderMapper.ToDtoFromType(o, Customer.GetType())).ToList()
            };
            return dto;
        }

        public static CustomerDto ToDtoFromType(Customer Customer, Type objectType)
        {
            CustomerDto dto = new()
            {
                CustomerId = Customer.CustomerId,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                Age = Customer.Age,
                BankDetails = Customer.BankDetails
            };
            if (objectType != typeof(Order)) dto.Orders = Customer.Orders.Select(o => OrderMapper.ToDtoFromType(o, typeof(Customer))).ToList();
            return dto;
        }

        public static Customer ToDomain(CustomerDto Customer)
        {
            List<Order> orders = Customer.Orders.Select(OrderMapper.ToDomain).ToList();
            Guid CustomerId = Customer.CustomerId == null ? Guid.NewGuid() : (Guid)Customer.CustomerId;
            Customer model = new()
            {
                CustomerId = CustomerId,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                BankDetails = Customer.BankDetails,
                Age = Customer.Age,
                Orders = orders
            };
            return model;
        }

    }
}