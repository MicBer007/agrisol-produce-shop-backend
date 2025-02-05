using shop.api.Dto;
using shop.domain;

namespace shop.api.Mappers
{
    public class OrderProductMapper
    {

        public static OrderProductDto ToDto(OrderProduct OrderProduct)
        {
            if (OrderProduct == null) return null;
            OrderProductDto dto = new()
            {
                Quantity = OrderProduct.Quantity,
                Product = ProductMapper.ToDtoFromType(OrderProduct.Product, typeof(OrderProduct)),
                Order = OrderMapper.ToDtoFromType(OrderProduct.Order, typeof(OrderProduct))
            };
            return dto;
        }

        public static OrderProductDto ToDtoFromType(OrderProduct OrderProduct, Type objectType)
        {
            if (OrderProduct == null) return null;
            OrderProductDto dto = new()
            {
                Quantity = OrderProduct.Quantity
            };
            if (objectType != typeof(Order)) dto.Order = OrderMapper.ToDtoFromType(OrderProduct.Order, typeof(OrderProduct));
            if (objectType != typeof(Product)) dto.Product = ProductMapper.ToDtoFromType(OrderProduct.Product, typeof(OrderProduct));
            return dto;
        }

    }
}
