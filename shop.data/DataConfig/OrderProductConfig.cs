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
            builder.HasKey(oP => new { oP.ProductId, oP.OrderId });
            builder.HasOne(oP => oP.Order).WithMany(o => o.OrderProducts).HasForeignKey(oP => oP.OrderId);
            builder.HasOne(oP => oP.Product).WithMany(p => p.OrderProducts).HasForeignKey(oP => oP.ProductId);
        }
    }
}
