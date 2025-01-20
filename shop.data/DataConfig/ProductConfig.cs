using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop.domain;

namespace shop.data.DataConfig
{
    public class ProductConfig: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> pBuilder)
        {
            Product[] Products = {
                new Product {ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), Name = "tomatoes", Price = 15, InStock = 300, PictureName = "tomatoes.jpg"},
                new Product {ProductId = new Guid("571CFFB5-45CF-4130-9FE8-DB271CF7769E"), Name = "potatoes", Price = 10, InStock = 200, PictureName = "potatoes.jpg"},
                new Product {ProductId = new Guid("04A41261-0286-4532-9E78-9D65C77109F2"), Name = "cabbages", Price = 30, InStock = 70, PictureName = "cabbages.jpg"},
                new Product {ProductId = new Guid("6089C0D4-A700-48FB-BDDD-E63E60C6C4FC"), Name = "leeks", Price = 10, InStock = 100, PictureName = "leeks.jpg"},
                new Product {ProductId = new Guid("57AC950F-8CA5-45D8-90C6-A9136752E844"), Name = "carrots", Price = 7, InStock = 200, PictureName = "carrots.jpg"},
                new Product {ProductId = new Guid("95CDCF59-5D79-4FED-B5E5-771F9E7A2F30"), Name = "artichokes", Price = 5, InStock = 150, PictureName = "artichokes.jpg"},
                new Product {ProductId = new Guid("885F5A71-8458-4C41-B437-A2B07153BF5D"), Name = "beetroots", Price = 15, InStock = 30, PictureName = "beetroots.jpg"},
                new Product {ProductId = new Guid("8BF98D1E-78A2-44A5-BA3D-7E0E40079384"), Name = "onions", Price = 17, InStock = 250, PictureName = "onions.jpg"},
                new Product {ProductId = new Guid("3E7F899D-867C-4698-B853-6C66C0F413FB"), Name = "maize", Price = 15, InStock = 300, PictureName = "maize.jpg"}
            };
            pBuilder.Property(p => p.ProductId).ValueGeneratedOnAdd();
            pBuilder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            pBuilder.HasData(Products);
            pBuilder.ToTable("product");
        }
    }
}
