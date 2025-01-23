using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data
{
    public class ShopContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductSupplierJ> ProductSupplierJoins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrderJ> ProductOrderJoins { get; set; }

        public ShopContext() { }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
            modelBuilder.Entity<ProductSupplierJ>().Property(pPS => pPS.MomentCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Product>().HasMany(p => p.Suppliers).WithMany(pS => pS.Products).UsingEntity<ProductSupplierJ>();
            modelBuilder.Entity<Order>().HasMany(o => o.Products).WithMany(p => p.Orders).UsingEntity<ProductOrderJ>();
        }

    }
}
