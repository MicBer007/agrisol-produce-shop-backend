using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class AddedJoinTableForProductProductSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductSupplier");

            migrationBuilder.CreateTable(
                name: "ProductProductSuppliersJoinTable",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductSuppliersJoinTable", x => new { x.ProductId, x.ProductSupplierId });
                    table.ForeignKey(
                        name: "FK_ProductProductSuppliersJoinTable_productSuppliers_ProductSupplierId",
                        column: x => x.ProductSupplierId,
                        principalTable: "productSuppliers",
                        principalColumn: "ProductSupplierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductSuppliersJoinTable_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductSuppliersJoinTable_ProductSupplierId",
                table: "ProductProductSuppliersJoinTable",
                column: "ProductSupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductSuppliersJoinTable");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductSupplier_SuppliersProductSupplierId",
                table: "ProductProductSupplier",
                column: "SuppliersProductSupplierId");
        }
    }
}
