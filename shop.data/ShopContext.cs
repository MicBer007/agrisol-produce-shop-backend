using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data
{
    public class ShopContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<ProductProductSupplier> ProductProductSuppliersJoinTable { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrderJoinTable { get; set; }

        public ShopContext() { }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
            modelBuilder.Entity<ProductProductSupplier>().Property(pPS => pPS.MomentCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Product>().HasMany(p => p.Suppliers).WithMany(pS => pS.Products).UsingEntity<ProductProductSupplier>();
            modelBuilder.Entity<Order>().HasMany(o => o.Products).WithMany(p => p.Orders).UsingEntity<ProductOrder>();
        }

    }
}
