using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shop.domain;

namespace shop.api.Dto
{
    public class DtoMappingProfile: Profile
    {
        
        public DtoMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductWithoutProductsInOrderDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<ProductInOrder, ProductInOrderDto>().ReverseMap();

            CreateMap<ProductSupplier, ProductSupplierDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ForMember(oDto => oDto.OrderStatus, opt => opt.MapFrom(oS => oS.OrderStatus.ToString()));
            CreateMap<OrderDto, Order>().ForMember(o => o.OrderStatus, opt => opt.MapFrom(oS => (OrderStatus)Enum.Parse(typeof(OrderStatus), oS.OrderStatus)));

            CreateMap<Order, OrderWithoutProductsInOrderDto>().ForMember(oDto => oDto.OrderStatus, opt => opt.MapFrom(oS => oS.OrderStatus.ToString()));
            CreateMap<OrderWithoutProductsInOrderDto, Order>().ForMember(o => o.OrderStatus, opt => opt.MapFrom(oS => (OrderStatus)Enum.Parse(typeof(OrderStatus), oS.OrderStatus)));

        }
    }
}
