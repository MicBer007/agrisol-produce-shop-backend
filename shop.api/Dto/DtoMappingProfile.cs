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
        }
    }
}
