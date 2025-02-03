using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCartAndCartProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "CustomerId" },
                values: new object[] { new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d") });

            migrationBuilder.InsertData(
                table: "CartProducts",
                columns: new[] { "CartId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), 100 },
                    { new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), 300 },
                    { new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"), 40 },
                    { new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384"), 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProducts",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d") });

            migrationBuilder.DeleteData(
                table: "CartProducts",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e") });

            migrationBuilder.DeleteData(
                table: "CartProducts",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d") });

            migrationBuilder.DeleteData(
                table: "CartProducts",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"), new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384") });

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: new Guid("abbf2d1a-2b6d-4186-82a3-d0ae39900333"));
        }
    }
}
