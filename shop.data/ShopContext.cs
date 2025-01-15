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

        //Please try to implement support for EFPowerTools to see the nice diagrams

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Product[] Products = new Product[]
            {
                new Product {ProductId = new Guid("1ccfbdc0-73af-4fff-ac5e-be8ed0627e18"), Name = "Potatoes", InStock = 300, Price = 13, PictureName = "null"},
                new Product {ProductId = new Guid("4d5e5b05-5274-4097-9e35-1495f8da90c7"), Name = "Tomatoes", InStock = 200, Price = 10, PictureName = "null"},
                new Product {ProductId = new Guid("6b525f5a-0863-4100-ac83-803e52060177"), Name = "Maize", InStock = 300, Price = 15, PictureName = "null"},
                new Product {ProductId = new Guid("6cc84e23-38bd-44f1-bdc7-e256ad0662f3"), Name = "Cabbages", InStock = 70, Price = 20, PictureName = "null"},
                new Product {ProductId = new Guid("7cc84e23-38bd-44f1-bdc7-e256ad0662f3"), Name = "Eggplants", InStock = 100, Price = 15, PictureName = "null"},
            };
            modelBuilder.Entity<Product>(pBuilder => pBuilder.ToTable("product"));
            modelBuilder.Entity<Product>().HasData(Products);
            Customer[] Customers = new Customer[]
            {
                new Customer {CustomerId = new Guid("4f3c769f-4770-4d99-97a5-3f6bd6a6f8c9"), FirstName = "Harold", LastName = "Hutchinson", Age = 31, BankDetails = "Capitec"},
                new Customer {CustomerId = new Guid("5020a15e-5dc9-4b11-adb5-fef33a5ef012"), FirstName = "Jonny", LastName = "Williams", Age = 45, BankDetails = "Standard Bank"},
                new Customer {CustomerId = new Guid("9e7069da-4e8f-4316-84f1-a6094e6284cc"), FirstName = "Steve", LastName = "Ridge", Age = 24, BankDetails = "FNB"},
                new Customer {CustomerId = new Guid("ade07982-1b61-4262-9079-9a8265f49539"), FirstName = "Richard", LastName = "Bird", Age = 50, BankDetails = "Capitec"},
            };
            modelBuilder.Entity<Customer>(cBuilder => cBuilder.ToTable("customer"));
            modelBuilder.Entity<Customer>().HasData(Customers);
        }

    }
}
