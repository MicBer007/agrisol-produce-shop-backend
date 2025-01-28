using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop.domain;

namespace shop.data.DataConfig
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            Supplier[] ProductSuppliers = {
                new Supplier {SupplierId = new Guid("de5ae53e-886a-4061-8dfa-d5c2b27716ca"), SupplierName = "Juan"},
                new Supplier {SupplierId = new Guid("32c81734-a0f9-45d2-b613-7a5304c1fb6f"), SupplierName = "John"},
                new Supplier {SupplierId = new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe"), SupplierName = "Johannes"},
                new Supplier {SupplierId = new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), SupplierName = "Jean"},
                new Supplier {SupplierId = new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27"), SupplierName = "Johan"}
            };
            builder.HasData(ProductSuppliers);
        }
    }
}
