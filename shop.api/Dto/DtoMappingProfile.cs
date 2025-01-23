using AutoMapper;
using shop.domain;

namespace shop.api.Dto
{
    public class DtoMappingProfile: Profile
    {
        
        public DtoMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductWithoutOrderProductsDto>().ReverseMap();
            //
            CreateMap<Order, OrderDto>().ForMember(oDto => oDto.OrderStatus, opt => opt.MapFrom(oS => oS.OrderStatus.ToString()));
            CreateMap<OrderDto, Order>().ForMember(o => o.OrderStatus, opt => opt.MapFrom(oS => (OrderStatus)Enum.Parse(typeof(OrderStatus), oS.OrderStatus)));

            CreateMap<Order, OrderWithoutOrderProductsDto>().ForMember(oDto => oDto.OrderStatus, opt => opt.MapFrom(oS => oS.OrderStatus.ToString()));
            CreateMap<OrderWithoutOrderProductsDto, Order>().ForMember(o => o.OrderStatus, opt => opt.MapFrom(oS => (OrderStatus)Enum.Parse(typeof(OrderStatus), oS.OrderStatus)));

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<OrderProduct, OrderProductDto>();
            CreateMap<OrderProductDto, OrderProduct>().ForMember(oP => oP.ProductId, action => action.MapFrom(oPD => oPD.Product.ProductId)).ForMember(oP => oP.ProductId, action => action.MapFrom(oPD => oPD.Product.ProductId));

            CreateMap<Supplier, SupplierDto>().ReverseMap();
        
        }
    }
}
