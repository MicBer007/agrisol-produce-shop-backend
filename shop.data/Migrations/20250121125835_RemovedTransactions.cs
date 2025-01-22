using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_customer_CustomerId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderJoinTable_order_OrderId",
                table: "ProductOrderJoinTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderJoinTable_product_ProductId",
                table: "ProductOrderJoinTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductSuppliersJoinTable_productSuppliers_ProductSupplierId",
                table: "ProductProductSuppliersJoinTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductSuppliersJoinTable_product_ProductId",
                table: "ProductProductSuppliersJoinTable");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productSuppliers",
                table: "productSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.RenameTable(
                name: "productSuppliers",
                newName: "ProductSuppliers");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_order_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSuppliers",
                table: "ProductSuppliers",
                column: "ProductSupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderJoinTable_Orders_OrderId",
                table: "ProductOrderJoinTable",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderJoinTable_Products_ProductId",
                table: "ProductOrderJoinTable",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductSuppliersJoinTable_ProductSuppliers_ProductSupplierId",
                table: "ProductProductSuppliersJoinTable",
                column: "ProductSupplierId",
                principalTable: "ProductSuppliers",
                principalColumn: "ProductSupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductSuppliersJoinTable_Products_ProductId",
                table: "ProductProductSuppliersJoinTable",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderJoinTable_Orders_OrderId",
                table: "ProductOrderJoinTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderJoinTable_Products_ProductId",
                table: "ProductOrderJoinTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductSuppliersJoinTable_ProductSuppliers_ProductSupplierId",
                table: "ProductProductSuppliersJoinTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductSuppliersJoinTable_Products_ProductId",
                table: "ProductProductSuppliersJoinTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSuppliers",
                table: "ProductSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "ProductSuppliers",
                newName: "productSuppliers");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "customer");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "order",
                newName: "IX_order_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productSuppliers",
                table: "productSuppliers",
                column: "ProductSupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "CustomerId");

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_transaction_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "transaction",
                columns: new[] { "TransactionId", "CustomerId", "TransactionName", "TransactionValue" },
                values: new object[] { new Guid("10987938-d34c-4809-ab86-9ba1671ad36f"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), "Tomatoes", 140m });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_CustomerId",
                table: "transaction",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer_CustomerId",
                table: "order",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderJoinTable_order_OrderId",
                table: "ProductOrderJoinTable",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderJoinTable_product_ProductId",
                table: "ProductOrderJoinTable",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductSuppliersJoinTable_productSuppliers_ProductSupplierId",
                table: "ProductProductSuppliersJoinTable",
                column: "ProductSupplierId",
                principalTable: "productSuppliers",
                principalColumn: "ProductSupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductSuppliersJoinTable_product_ProductId",
                table: "ProductProductSuppliersJoinTable",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
