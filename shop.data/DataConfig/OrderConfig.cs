using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using shop.domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace shop.data.DataConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> oBuilder)
        {
            Order[] orders =
            {
                new Order { OrderId = new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), OrderStatus = OrderStatus.InCart, TimeCarted=new DateTime(2024, 4, 12, 5, 27, 19), TimePayed = null, TimeDelivered = null, CustomerId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D")},
                new Order { OrderId = new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), OrderStatus = OrderStatus.Payed, TimeCarted=new DateTime(2023, 5, 2, 23, 59, 23), TimePayed = new DateTime(2024, 2, 28, 17, 42, 49), TimeDelivered = null, CustomerId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D")},
                new Order { OrderId = new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), OrderStatus = OrderStatus.Delivered, TimeCarted=new DateTime(2022, 6, 26, 19, 1, 34), TimePayed = new DateTime(2024, 5, 25, 21, 51, 25), TimeDelivered = new DateTime(2024, 8, 25, 16, 48, 42), CustomerId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D")},
                new Order { OrderId = new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), OrderStatus = OrderStatus.InCart, TimeCarted=new DateTime(2024, 11, 30, 23, 38, 55), TimePayed = null, TimeDelivered = null, CustomerId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D")}
            };
            oBuilder.Property(o => o.OrderId).ValueGeneratedOnAdd();
            oBuilder.Property(o => o.OrderStatus).HasConversion(new EnumToStringConverter<OrderStatus>());
            oBuilder.HasData(orders);
        }
    }
}
