using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataRelationshipsForOrderClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProductOrderJoinTable",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrderJoinTable", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductOrderJoinTable_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrderJoinTable_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "order",
                keyColumn: "OrderId",
                keyValue: new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"),
                column: "CustomerId",
                value: new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"));

            migrationBuilder.UpdateData(
                table: "order",
                keyColumn: "OrderId",
                keyValue: new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"),
                column: "CustomerId",
                value: new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"));

            migrationBuilder.UpdateData(
                table: "order",
                keyColumn: "OrderId",
                keyValue: new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"),
                column: "CustomerId",
                value: new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"));

            migrationBuilder.UpdateData(
                table: "order",
                keyColumn: "OrderId",
                keyValue: new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"),
                column: "CustomerId",
                value: new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"));

            migrationBuilder.CreateIndex(
                name: "IX_order_CustomerId",
                table: "order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderJoinTable_ProductId",
                table: "ProductOrderJoinTable",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer_CustomerId",
                table: "order",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_customer_CustomerId",
                table: "order");

            migrationBuilder.DropTable(
                name: "ProductOrderJoinTable");

            migrationBuilder.DropIndex(
                name: "IX_order_CustomerId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "order");
        }
    }
}
