﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shop.data;

#nullable disable

namespace shop.data.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20250115130318_primaryKeysNowHaveDefaults")]
    partial class primaryKeysNowHaveDefaults
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("shop.domain.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BankDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("customer", (string)null);

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"),
                            Age = 54,
                            BankDetails = "Capitec:5492875",
                            FirstName = "Harald",
                            LastName = "Berndt"
                        },
                        new
                        {
                            CustomerId = new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"),
                            Age = 32,
                            BankDetails = "Absa:475693",
                            FirstName = "Mauro",
                            LastName = "Lavista"
                        });
                });

            modelBuilder.Entity("shop.domain.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("InStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"),
                            InStock = 15,
                            Name = "tomatoes",
                            PictureName = "tomatoes.jpg",
                            Price = 300m
                        },
                        new
                        {
                            ProductId = new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"),
                            InStock = 10,
                            Name = "potatoes",
                            PictureName = "potatoes.jpg",
                            Price = 200m
                        },
                        new
                        {
                            ProductId = new Guid("04a41261-0286-4532-9e78-9d65c77109f2"),
                            InStock = 30,
                            Name = "cabbages",
                            PictureName = "cabbages.jpg",
                            Price = 70m
                        },
                        new
                        {
                            ProductId = new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"),
                            InStock = 10,
                            Name = "leeks",
                            PictureName = "leeks.jpg",
                            Price = 100m
                        },
                        new
                        {
                            ProductId = new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"),
                            InStock = 7,
                            Name = "carrots",
                            PictureName = "carrots.jpg",
                            Price = 200m
                        },
                        new
                        {
                            ProductId = new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"),
                            InStock = 5,
                            Name = "artichokes",
                            PictureName = "artichokes.jpg",
                            Price = 150m
                        },
                        new
                        {
                            ProductId = new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"),
                            InStock = 15,
                            Name = "beetroots",
                            PictureName = "beetroots.jpg",
                            Price = 30m
                        },
                        new
                        {
                            ProductId = new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384"),
                            InStock = 17,
                            Name = "onions",
                            PictureName = "onions.jpg",
                            Price = 250m
                        },
                        new
                        {
                            ProductId = new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"),
                            InStock = 15,
                            Name = "maize",
                            PictureName = "maize.jpg",
                            Price = 300m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
