using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data
{
    public class ShopContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> ProductOrderJoins { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSupplierJoin> ProductSupplierJoins { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public ShopContext() { }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
        }

    }
}
