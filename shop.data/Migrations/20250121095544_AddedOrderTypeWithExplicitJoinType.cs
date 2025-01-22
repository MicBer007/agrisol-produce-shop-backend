using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderTypeWithExplicitJoinType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimePayed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeDelivered = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.OrderId);
                });

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

            migrationBuilder.InsertData(
                table: "order",
                columns: new[] { "OrderId", "OrderStatus", "TimeCarted", "TimeDelivered", "TimePayed" },
                values: new object[,]
                {
                    { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), "InCart", new DateTime(2024, 11, 30, 23, 38, 55, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), "Payed", new DateTime(2023, 5, 2, 23, 59, 23, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 28, 17, 42, 49, 0, DateTimeKind.Unspecified) },
                    { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), "InCart", new DateTime(2024, 4, 12, 5, 27, 19, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), "Delivered", new DateTime(2022, 6, 26, 19, 1, 34, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 25, 16, 48, 42, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 21, 51, 25, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderJoinTable_ProductId",
                table: "ProductOrderJoinTable",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrderJoinTable");

            migrationBuilder.DropTable(
                name: "order");
        }
    }
}
