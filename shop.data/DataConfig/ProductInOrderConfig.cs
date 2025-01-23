using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop.domain;

namespace shop.data.DataConfig
{
    public class ProductInOrderConfig : IEntityTypeConfiguration<ProductInOrder>
    {
        public void Configure(EntityTypeBuilder<ProductInOrder> builder)
        {
            builder.ToTable("ProductInOrder");
            builder.HasKey(k => new { k.ProductId, k.OrderId });
            
            builder.HasOne(pio => pio.Product)
                .WithMany(p => p.ProductInOrders)
                .HasForeignKey(pio => pio.ProductId);   
           
            builder.HasOne(pio => pio.Order)
                .WithMany(o => o.ProductsInOrder)
                .HasForeignKey(pio => pio.OrderId);
        }
    }
}
