using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BankDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCancelled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimePayed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeDelivered = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.ProductId, x.CartId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplierJoins",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MomentCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplierJoins", x => new { x.ProductId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_ProductSupplierJoins_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplierJoins_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrderJoins",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrderJoins", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductOrderJoins_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrderJoins_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Age", "BankDetails", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), 54, "Capitec: 5492875", "Harald", "Berndt" },
                    { new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"), 32, "Absa: 475693", "Mauro", "Lavista" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "InStock", "Name", "PictureName", "Price" },
                values: new object[,]
                {
                    { new Guid("04a41261-0286-4532-9e78-9d65c77109f2"), 70, "cabbages", "cabbages.jpg", 30m },
                    { new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"), 300, "maize", "maize.jpg", 15m },
                    { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), 300, "tomatoes", "tomatoes.jpg", 15m },
                    { new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), 200, "potatoes", "potatoes.jpg", 10m },
                    { new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"), 200, "carrots", "carrots.jpg", 7m },
                    { new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"), 100, "leeks", "leeks.jpg", 10m },
                    { new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"), 30, "beetroots", "beetroots.jpg", 15m },
                    { new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384"), 250, "onions", "onions.jpg", 17m },
                    { new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"), 150, "artichokes", "artichokes.jpg", 5m }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "SupplierName" },
                values: new object[,]
                {
                    { new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27"), "Johan" },
                    { new Guid("32c81734-a0f9-45d2-b613-7a5304c1fb6f"), "John" },
                    { new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe"), "Johannes" },
                    { new Guid("de5ae53e-886a-4061-8dfa-d5c2b27716ca"), "Juan" },
                    { new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), "Jean" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderStatus", "TimeCancelled", "TimeDelivered", "TimePayed" },
                values: new object[,]
                {
                    { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), "Cancelled", new DateTime(2024, 11, 30, 23, 38, 55, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), "Payed", new DateTime(2023, 5, 2, 23, 59, 23, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 28, 17, 42, 49, 0, DateTimeKind.Unspecified) },
                    { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), "InTransit", new DateTime(2024, 4, 12, 5, 27, 19, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), "Delivered", new DateTime(2022, 6, 26, 19, 1, 34, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 25, 16, 48, 42, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 21, 51, 25, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartId",
                table: "CartProducts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderJoins_OrderId",
                table: "ProductOrderJoins",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplierJoins_SupplierId",
                table: "ProductSupplierJoins",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "ProductOrderJoins");

            migrationBuilder.DropTable(
                name: "ProductSupplierJoins");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
