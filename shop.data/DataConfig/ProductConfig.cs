﻿using System;
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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> pBuilder)
        {
            Product[] Products = {
                new Product {ProductId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), Name = "tomatoes", InStock = 15, Price = 300, PictureName = "tomatoes.jpg"},
                new Product {ProductId = new Guid("571CFFB5-45CF-4130-9FE8-DB271CF7769E"), Name = "potatoes", InStock = 10, Price = 200, PictureName = "potatoes.jpg"},
                new Product {ProductId = new Guid("04A41261-0286-4532-9E78-9D65C77109F2"), Name = "cabbages", InStock = 30, Price = 70, PictureName = "cabbages.jpg"},
                new Product {ProductId = new Guid("6089C0D4-A700-48FB-BDDD-E63E60C6C4FC"), Name = "leeks", InStock = 10, Price = 100, PictureName = "leeks.jpg"},
                new Product {ProductId = new Guid("57AC950F-8CA5-45D8-90C6-A9136752E844"), Name = "carrots", InStock = 7, Price = 200, PictureName = "carrots.jpg"},
                new Product {ProductId = new Guid("95CDCF59-5D79-4FED-B5E5-771F9E7A2F30"), Name = "artichokes", InStock = 5, Price = 150, PictureName = "artichokes.jpg"},
                new Product {ProductId = new Guid("885F5A71-8458-4C41-B437-A2B07153BF5D"), Name = "beetroots", InStock = 15, Price = 30, PictureName = "beetroots.jpg"},
                new Product {ProductId = new Guid("8BF98D1E-78A2-44A5-BA3D-7E0E40079384"), Name = "onions", InStock = 17, Price = 250, PictureName = "onions.jpg"},
                new Product {ProductId = new Guid("3E7F899D-867C-4698-B853-6C66C0F413FB"), Name = "maize", InStock = 15, Price = 300, PictureName = "maize.jpg"}
            };
            pBuilder.Property(p => p.ProductId).ValueGeneratedOnAdd();
            pBuilder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            pBuilder.HasData(Products);
            pBuilder.ToTable("product");
        }
    }
}