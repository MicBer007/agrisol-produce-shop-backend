using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class FixedPriceStockMixupOnProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("04a41261-0286-4532-9e78-9d65c77109f2"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 70, 30m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 300, 15m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 300, 15m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 200, 10m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 200, 7m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 100, 10m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 30, 15m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 250, 17m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 150, 5m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("04a41261-0286-4532-9e78-9d65c77109f2"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 30, 70m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 15, 300m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 15, 300m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 10, 200m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 7, 200m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 10, 100m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 15, 30m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 17, 250m });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ProductId",
                keyValue: new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"),
                columns: new[] { "InStock", "Price" },
                values: new object[] { 5, 150m });
        }
    }
}
