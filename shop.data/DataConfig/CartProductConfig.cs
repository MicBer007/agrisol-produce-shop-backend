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
    public class CartProductConfig: IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            CartProduct[] cartProducts =
            {
                new CartProduct { CartId = new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), Quantity = 100},
                new CartProduct { CartId = new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), ProductId = new Guid("8BF98D1E-78A2-44A5-BA3D-7E0E40079384"), Quantity = 30},
                new CartProduct { CartId = new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), ProductId = new Guid("885F5A71-8458-4C41-B437-A2B07153BF5D"), Quantity = 40},
                new CartProduct { CartId = new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), ProductId = new Guid("571CFFB5-45CF-4130-9FE8-DB271CF7769E"), Quantity = 300}
            };
            builder.HasData(cartProducts);
            builder.HasKey(cP => new { cP.ProductId, cP.CartId });
            builder.HasOne(cP => cP.Cart).WithMany(c => c.CartProducts).HasForeignKey(cP => cP.CartId);
            builder.HasOne(cP => cP.Product).WithMany(p => p.CartProducts).HasForeignKey(cP => cP.ProductId);
        }
    }
}
