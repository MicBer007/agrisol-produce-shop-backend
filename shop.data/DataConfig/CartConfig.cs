using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using shop.domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace shop.data.DataConfig
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            Cart[] carts =
            {
                new(){ CartId = new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), CustomerId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), CartProducts = []},
                new(){ CartId = new Guid("82d5d779-dc12-49b9-8cfa-fb285a2cde7c"), CustomerId = new Guid("95CDCF59-5D79-4FED-B5E5-771F9E7A2F30"), CartProducts = []}
            };
            builder.HasData(carts);
        }
    }
}
