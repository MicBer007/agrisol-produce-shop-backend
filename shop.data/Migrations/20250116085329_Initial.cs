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
                name: "customer",
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
                    table.PrimaryKey("PK_customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "product",
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
                    table.PrimaryKey("PK_product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                table: "customer",
                columns: new[] { "CustomerId", "Age", "BankDetails", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), 54, "Capitec:5492875", "Harald", "Berndt" },
                    { new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"), 32, "Absa:475693", "Mauro", "Lavista" }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "ProductId", "InStock", "Name", "PictureName", "Price" },
                values: new object[,]
                {
                    { new Guid("04a41261-0286-4532-9e78-9d65c77109f2"), 30, "cabbages", "cabbages.jpg", 70m },
                    { new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"), 15, "maize", "maize.jpg", 300m },
                    { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), 15, "tomatoes", "tomatoes.jpg", 300m },
                    { new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), 10, "potatoes", "potatoes.jpg", 200m },
                    { new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"), 7, "carrots", "carrots.jpg", 200m },
                    { new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"), 10, "leeks", "leeks.jpg", 100m },
                    { new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"), 15, "beetroots", "beetroots.jpg", 30m },
                    { new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384"), 17, "onions", "onions.jpg", 250m },
                    { new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"), 5, "artichokes", "artichokes.jpg", 150m }
                });

            migrationBuilder.InsertData(
                table: "transaction",
                columns: new[] { "TransactionId", "CustomerId", "TransactionName", "TransactionValue" },
                values: new object[] { new Guid("10987938-d34c-4809-ab86-9ba1671ad36f"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), "Tomatoes", 140m });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_CustomerId",
                table: "transaction",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
