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
            ProductSupplierJoin[] Joins = [];
            
            builder.Property(pPS => pPS.MomentCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasData(Joins);
            builder.HasKey(pS => new { pS.ProductId, pS.SupplierId });
            builder.HasOne(pS => pS.Product).WithMany(p => p.ProductSupplierJoins).HasForeignKey(oP => oP.ProductId);
            builder.HasOne(pS => pS.Supplier).WithMany(s => s.ProductSupplierJoins).HasForeignKey(pS => pS.SupplierId);
        }
    }
}
