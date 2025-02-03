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

        public static OrderProduct ToDomain(OrderProductDto OrderProduct)
        {
            if (OrderProduct == null) return null;
            OrderProduct model = new()
            {
                ProductId = (Guid) OrderProduct.Product.ProductId,
                Product = ProductMapper.ToDomain(OrderProduct.Product),
                OrderId = (Guid) OrderProduct.Order.OrderId,
                Order = OrderMapper.ToDomain(OrderProduct.Order),
                Quantity = OrderProduct.Quantity
            };
            return model;
        }

    }
}
