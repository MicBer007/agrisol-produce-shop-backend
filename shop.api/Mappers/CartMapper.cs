using shop.api.Dto;
using shop.domain;
using static NuGet.Packaging.PackagingConstants;

namespace shop.api.Mappers
{
    public class CartMapper
    {

        public static CartDto ToDto(Cart Cart)
        {
            if (Cart == null) return null;
            CartDto dto = new()
            {
                CartId = Cart.CartId,
                Customer = CustomerMapper.ToDtoFromType(Cart.Customer, typeof(Cart)),
                CartProducts = Cart.CartProducts.Select(cP => CartProductMapper.ToDtoFromType(cP, typeof(Cart))).ToList()
            };
            return dto;
        }

        public static CartDto ToDtoFromType(Cart Cart, Type objectType)
        {
            if (Cart == null) return null;
            CartDto dto = new()
            {
                CartId = Cart.CartId,
                
            };
            if (objectType != typeof(Customer)) dto.Customer = CustomerMapper.ToDtoFromType(Cart.Customer, typeof(Cart));
            if (objectType != typeof (CartProduct)) dto.CartProducts = Cart.CartProducts.Select(cP => CartProductMapper.ToDtoFromType(cP, typeof (Cart))).ToList();
            return dto;
        }

    }
}
