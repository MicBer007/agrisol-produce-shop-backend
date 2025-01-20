using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop.domain;

namespace shop.data.DataConfig
{
    public class ProductSupplierConfig : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            ProductSupplier[] ProductSuppliers = {
                new ProductSupplier {ProductSupplierId = new Guid("de5ae53e-886a-4061-8dfa-d5c2b27716ca"), ProductSupplierName = "Juan"},
                new ProductSupplier {ProductSupplierId = new Guid("32c81734-a0f9-45d2-b613-7a5304c1fb6f"), ProductSupplierName = "John"},
                new ProductSupplier {ProductSupplierId = new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe"), ProductSupplierName = "Johannes"},
                new ProductSupplier {ProductSupplierId = new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), ProductSupplierName = "Jean"},
                new ProductSupplier {ProductSupplierId = new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27"), ProductSupplierName = "Johan"}
            };
            builder.Property(pS => pS.ProductSupplierId).ValueGeneratedOnAdd();
            builder.HasData(ProductSuppliers);
            builder.ToTable("productSuppliers");
        }
    }
}
