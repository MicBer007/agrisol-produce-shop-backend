using shop.api.Dto;
using shop.domain;

namespace shop.api.Mappers
{
    public class CartProductMapper
    {

        public static CartProductDto ToDto(CartProduct CartProduct)
        {
            if (CartProduct == null) return null;
            CartProductDto dto = new()
            {
                Quantity = CartProduct.Quantity,
                Cart = CartMapper.ToDtoFromType(CartProduct.Cart, typeof(CartProduct)),
                Product = ProductMapper.ToDtoFromType(CartProduct.Product, typeof(CartProduct))
            };
            return dto;
        }

        public static CartProductDto ToDtoFromType(CartProduct CartProduct, Type ObjectType)
        {
            if (CartProduct == null) return null;
            CartProductDto dto = new()
            {
                Quantity = CartProduct.Quantity,
            };
            if (ObjectType != typeof(Cart)) dto.Cart = CartMapper.ToDtoFromType(CartProduct.Cart, typeof(CartProduct));
            if (ObjectType != typeof(Product)) dto.Product = ProductMapper.ToDtoFromType(CartProduct.Product, typeof(CartProduct));
            return dto;
        }

    }
}
