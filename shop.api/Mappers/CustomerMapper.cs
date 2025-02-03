using Elfie.Serialization;
using Microsoft.AspNetCore.Localization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using shop.api.Dto;
using shop.domain;

namespace shop.api.Mappers
{
    public static class CustomerMapper
    {

        public static CustomerDto ToDto(Customer Customer)
        {
            if (Customer == null) return null;
            CustomerDto dto = new()
            {
                CustomerId = Customer.CustomerId,
                Cart = CartMapper.ToDtoFromType(Customer.Cart, typeof(Customer)),
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
            if (Customer == null) return null;
            CustomerDto dto = new()
            {
                CustomerId = Customer.CustomerId,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                Age = Customer.Age,
                BankDetails = Customer.BankDetails
            };
            if (objectType != typeof(Cart)) dto.Cart = CartMapper.ToDtoFromType(Customer.Cart, typeof(Customer));
            if (objectType != typeof(Order)) dto.Orders = Customer.Orders.Select(o => OrderMapper.ToDtoFromType(o, typeof(Customer))).ToList();
            return dto;
        }

        public static Customer ToDomain(CustomerDto Customer)
        {
            if (Customer == null) return null;
            List<Order> Orders = Customer.Orders.Select(OrderMapper.ToDomain).ToList();
            Cart Cart = CartMapper.ToDomain(Customer.Cart);
            Guid CustomerId = Customer.CustomerId == null ? Guid.NewGuid() : (Guid)Customer.CustomerId;
            Guid CartId = Customer.Cart.CartId == null ? Guid.NewGuid() : (Guid)Customer.Cart.CartId;
            Customer model = new()
            {
                CustomerId = CustomerId,
                Cart = Cart,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                BankDetails = Customer.BankDetails,
                Age = Customer.Age,
                Orders = Orders
            };
            return model;
        }

    }
}