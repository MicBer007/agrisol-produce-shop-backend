using AutoMapper;
using shop.domain;

namespace shop.api.Dto
{
    public class DtoMappingProfile: Profile
    {
        
        public DtoMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Supplier, SupplierDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ForMember(oDto => oDto.OrderStatus, opt => opt.MapFrom(oS => oS.OrderStatus.ToString()));
            CreateMap<OrderDto, Order>().ForMember(o => o.OrderStatus, opt => opt.MapFrom(oS => (OrderStatus)Enum.Parse(typeof(OrderStatus), oS.OrderStatus)));
        
        }
    }
}
