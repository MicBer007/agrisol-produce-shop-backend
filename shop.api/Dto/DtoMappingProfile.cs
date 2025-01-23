using AutoMapper;
using shop.domain;

namespace shop.api.Dto
{
    public class DtoMappingProfile: Profile
    {
        
        public DtoMappingProfile()
        {
            CreateMap<Product, ProductDto>().MaxDepth(5).ReverseMap();

            CreateMap<Customer, CustomerDto>().MaxDepth(1);//.ReverseMap();

            CreateMap<Supplier, SupplierDto>().MaxDepth(5).ReverseMap();

            CreateMap<Order, OrderDto>().MaxDepth(5).ForMember(oDto => oDto.OrderStatus, opt => opt.MapFrom(oS => oS.OrderStatus.ToString()));
            CreateMap<OrderDto, Order>().MaxDepth(5).ForMember(o => o.OrderStatus, opt => opt.MapFrom(oS => (OrderStatus)Enum.Parse(typeof(OrderStatus), oS.OrderStatus)));
        
        }
    }
}
