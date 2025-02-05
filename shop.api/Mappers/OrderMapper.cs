using shop.api.Dto;
using shop.domain;
using static NuGet.Packaging.PackagingConstants;

namespace shop.api.Mappers
{
    public class OrderMapper
    {

        public static OrderDto ToDto(Order Order)
        {
            if (Order == null) return null;
            OrderDto dto = new()
            {
                OrderId = Order.OrderId,
                CustomerId = Order.CustomerId,
                OrderStatus = Order.OrderStatus.ToString(),
                TimeCancelled = Order.TimeCancelled,
                TimePayed = Order.TimePayed,
                TimeDelivered = Order.TimeDelivered,
                OrderProducts = Order.OrderProducts.Select(o => OrderProductMapper.ToDtoFromType(o, Order.GetType())).ToList()
            };
            return dto;
        }

        public static OrderDto ToDtoFromType(Order Order, Type objectType)
        {
            if (Order == null) return null;
            OrderDto dto = new()
            {
                OrderId = Order.OrderId,
                CustomerId = Order.CustomerId,
                OrderStatus = Order.OrderStatus.ToString(),
                TimeCancelled = Order.TimeCancelled,
                TimePayed = Order.TimePayed,
                TimeDelivered = Order.TimeDelivered
            };
            if (objectType != typeof (OrderProduct)) dto.OrderProducts = Order.OrderProducts.Select(oP => OrderProductMapper.ToDtoFromType(oP, typeof (Order))).ToList();
            return dto;
        }

        public static Order ToDomain(OrderDto Order)
        {
            Guid OrderId = Order.OrderId == null ? Guid.NewGuid() : (Guid) Order.OrderId;
            Order model = new()
            {
                OrderId = OrderId,
                OrderStatus = (OrderStatus) Enum.Parse(typeof(OrderStatus), Order.OrderStatus),
                TimeCancelled = Order.TimeCancelled,
                TimePayed = Order.TimePayed,
                TimeDelivered = Order.TimeDelivered,
                OrderProducts = []
            };
            return model;
        }

    }
}
