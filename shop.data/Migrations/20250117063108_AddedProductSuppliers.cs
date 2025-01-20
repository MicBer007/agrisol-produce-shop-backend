using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductSuppliers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productSuppliers",
                columns: table => new
                {
                    ProductSupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productSuppliers", x => x.ProductSupplierId);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductSupplier",
                columns: table => new
                {
                    ProductsProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuppliersProductSupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductSupplier", x => new { x.ProductsProductId, x.SuppliersProductSupplierId });
                    table.ForeignKey(
                        name: "FK_ProductProductSupplier_productSuppliers_SuppliersProductSupplierId",
                        column: x => x.SuppliersProductSupplierId,
                        principalTable: "productSuppliers",
                        principalColumn: "ProductSupplierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductSupplier_product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "productSuppliers",
                columns: new[] { "ProductSupplierId", "ProductSupplierName" },
                values: new object[,]
                {
                    { new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27"), "Johan" },
                    { new Guid("32c81734-a0f9-45d2-b613-7a5304c1fb6f"), "John" },
                    { new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe"), "Johannes" },
                    { new Guid("de5ae53e-886a-4061-8dfa-d5c2b27716ca"), "Juan" },
                    { new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), "Jean" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductSupplier_SuppliersProductSupplierId",
                table: "ProductProductSupplier",
                column: "SuppliersProductSupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductSupplier");

            migrationBuilder.DropTable(
                name: "productSuppliers");
        }
    }
}
