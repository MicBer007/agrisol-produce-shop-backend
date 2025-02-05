using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DataConfig
{
    public class OrderProductConfig: IEntityTypeConfiguration<OrderProduct>
    {

        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            OrderProduct[] orderProducts =
            {
                new OrderProduct() {ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), OrderId = new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), Quantity = 30},
                new OrderProduct() {ProductId = new Guid("571CFFB5-45CF-4130-9FE8-DB271CF7769E"), OrderId = new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), Quantity = 70},
                new OrderProduct() {ProductId = new Guid("3E7F899D-867C-4698-B853-6C66C0F413FB"), OrderId = new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), Quantity = 1},
                new OrderProduct() {ProductId = new Guid("8BF98D1E-78A2-44A5-BA3D-7E0E40079384"), OrderId = new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), Quantity = 100},
                new OrderProduct() {ProductId = new Guid("885F5A71-8458-4C41-B437-A2B07153BF5D"), OrderId = new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), Quantity = 20},
                new OrderProduct() {ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), OrderId = new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), Quantity = 60},
                new OrderProduct() {ProductId = new Guid("6089C0D4-A700-48FB-BDDD-E63E60C6C4FC"), OrderId = new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), Quantity = 50},
                new OrderProduct() {ProductId = new Guid("95CDCF59-5D79-4FED-B5E5-771F9E7A2F30"), OrderId = new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), Quantity = 10},
                new OrderProduct() {ProductId = new Guid("57AC950F-8CA5-45D8-90C6-A9136752E844"), OrderId = new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), Quantity = 60},
                new OrderProduct() {ProductId = new Guid("571CFFB5-45CF-4130-9FE8-DB271CF7769E"), OrderId = new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), Quantity = 350},
                new OrderProduct() {ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), OrderId = new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), Quantity = 250},
                new OrderProduct() {ProductId = new Guid("6089C0D4-A700-48FB-BDDD-E63E60C6C4FC"), OrderId = new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), Quantity = 200},
                new OrderProduct() {ProductId = new Guid("571CFFB5-45CF-4130-9FE8-DB271CF7769E"), OrderId = new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), Quantity = 5},
                new OrderProduct() {ProductId = new Guid("04A41261-0286-4532-9E78-9D65C77109F2"), OrderId = new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), Quantity = 30},
                new OrderProduct() {ProductId = new Guid("6089C0D4-A700-48FB-BDDD-E63E60C6C4FC"), OrderId = new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), Quantity = 10},
                new OrderProduct() {ProductId = new Guid("885F5A71-8458-4C41-B437-A2B07153BF5D"), OrderId = new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), Quantity = 300},
                new OrderProduct() {ProductId = new Guid("3E7F899D-867C-4698-B853-6C66C0F413FB"), OrderId = new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), Quantity = 100},
                new OrderProduct() {ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), OrderId = new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), Quantity = 40},
                new OrderProduct() {ProductId = new Guid("57AC950F-8CA5-45D8-90C6-A9136752E844"), OrderId = new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), Quantity = 10},
            };
            builder.HasData(orderProducts);
            builder.HasKey(oP => new { oP.ProductId, oP.OrderId });
            builder.HasOne(oP => oP.Order).WithMany(o => o.OrderProducts).HasForeignKey(oP => oP.OrderId);
            builder.HasOne(oP => oP.Product).WithMany(p => p.OrderProducts).HasForeignKey(oP => oP.ProductId);
        }
    }
}
