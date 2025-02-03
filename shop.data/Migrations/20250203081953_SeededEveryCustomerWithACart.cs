using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class SeededEveryCustomerWithACart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "CustomerId" },
                values: new object[] { new Guid("82d5d779-dc12-49b9-8cfa-fb285a2cde7c"), new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: new Guid("82d5d779-dc12-49b9-8cfa-fb285a2cde7c"));
        }
    }
}
