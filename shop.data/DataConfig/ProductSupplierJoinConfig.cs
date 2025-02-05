using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using shop.domain;
using System.Reflection.Emit;

namespace shop.data.DataConfig
{
    public class ProductSpplierJoinConfig : IEntityTypeConfiguration<ProductSupplierJoin>
    {
        public void Configure(EntityTypeBuilder<ProductSupplierJoin> builder)
        {
            ProductSupplierJoin[] Joins =
            {
                new ProductSupplierJoin() { SupplierId = new Guid("ECA7177E-B329-4B1B-89CC-1F6ED6445FBE"), ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("1EBD7129-AEF3-4F96-8DF9-4C035D214F27"), ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("DE5AE53E-886A-4061-8DFA-D5C2B27716CA"), ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("ECA7177E-B329-4B1B-89CC-1F6ED6445FBE"), ProductId = new Guid("3E7F899D-867C-4698-B853-6C66C0F413FB"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("5F2601E2-2F25-4312-A61E-DAA5BE44A3FE"), ProductId = new Guid("3E7F899D-867C-4698-B853-6C66C0F413FB"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("DE5AE53E-886A-4061-8DFA-D5C2B27716CA"), ProductId = new Guid("95CDCF59-5D79-4FED-B5E5-771F9E7A2F30"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("1EBD7129-AEF3-4F96-8DF9-4C035D214F27"), ProductId = new Guid("8BF98D1E-78A2-44A5-BA3D-7E0E40079384"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("5F2601E2-2F25-4312-A61E-DAA5BE44A3FE"), ProductId = new Guid("04A41261-0286-4532-9E78-9D65C77109F2"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("ECA7177E-B329-4B1B-89CC-1F6ED6445FBE"), ProductId = new Guid("04A41261-0286-4532-9E78-9D65C77109F2"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("5F2601E2-2F25-4312-A61E-DAA5BE44A3FE"), ProductId = new Guid("885F5A71-8458-4C41-B437-A2B07153BF5D"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("1EBD7129-AEF3-4F96-8DF9-4C035D214F27"), ProductId = new Guid("885F5A71-8458-4C41-B437-A2B07153BF5D"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("ECA7177E-B329-4B1B-89CC-1F6ED6445FBE"), ProductId = new Guid("57AC950F-8CA5-45D8-90C6-A9136752E844"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("32C81734-A0F9-45D2-B613-7A5304C1FB6F"), ProductId = new Guid("57AC950F-8CA5-45D8-90C6-A9136752E844"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("1EBD7129-AEF3-4F96-8DF9-4C035D214F27"), ProductId = new Guid("571CFFB5-45CF-4130-9FE8-DB271CF7769E"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("ECA7177E-B329-4B1B-89CC-1F6ED6445FBE"), ProductId = new Guid("571CFFB5-45CF-4130-9FE8-DB271CF7769E"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("32C81734-A0F9-45D2-B613-7A5304C1FB6F"), ProductId = new Guid("6089C0D4-A700-48FB-BDDD-E63E60C6C4FC"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
                new ProductSupplierJoin() { SupplierId = new Guid("ECA7177E-B329-4B1B-89CC-1F6ED6445FBE"), ProductId = new Guid("6089C0D4-A700-48FB-BDDD-E63E60C6C4FC"), MomentCreated = new DateTime(2025, 2, 5, 10, 0, 0)},
            };
            
            builder.Property(pPS => pPS.MomentCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasData(Joins);
            builder.HasKey(pS => new { pS.ProductId, pS.SupplierId });
            builder.HasOne(pS => pS.Product).WithMany(p => p.ProductSupplierJoins).HasForeignKey(oP => oP.ProductId);
            builder.HasOne(pS => pS.Supplier).WithMany(s => s.ProductSupplierJoins).HasForeignKey(pS => pS.SupplierId);
        }
    }
}
