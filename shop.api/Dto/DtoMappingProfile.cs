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
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<ProductSupplier, ProductSupplierDto>().ReverseMap();
        }
    }
}
