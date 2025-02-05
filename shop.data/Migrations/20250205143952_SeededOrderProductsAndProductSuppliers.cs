using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class SeededOrderProductsAndProductSuppliers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductOrderJoins",
                columns: new[] { "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("04a41261-0286-4532-9e78-9d65c77109f2"), 30 },
                    { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"), 100 },
                    { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"), 1 },
                    { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), 60 },
                    { new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), 250 },
                    { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), 40 },
                    { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), 30 },
                    { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), 350 },
                    { new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), 5 },
                    { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), 70 },
                    { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"), 60 },
                    { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"), 10 },
                    { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"), 50 },
                    { new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"), 200 },
                    { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"), 10 },
                    { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"), 300 },
                    { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"), 20 },
                    { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384"), 100 },
                    { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"), 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductSupplierJoins",
                columns: new[] { "ProductId", "SupplierId", "MomentCreated" },
                values: new object[,]
                {
                    { new Guid("04a41261-0286-4532-9e78-9d65c77109f2"), new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("04a41261-0286-4532-9e78-9d65c77109f2"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"), new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), new Guid("de5ae53e-886a-4061-8dfa-d5c2b27716ca"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"), new Guid("32c81734-a0f9-45d2-b613-7a5304c1fb6f"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"), new Guid("32c81734-a0f9-45d2-b613-7a5304c1fb6f"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"), new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"), new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384"), new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"), new Guid("de5ae53e-886a-4061-8dfa-d5c2b27716ca"), new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("04a41261-0286-4532-9e78-9d65c77109f2") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("46e4fa2d-96bc-4c80-8ece-1a20cd7402b4"), new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("7213d1a4-0da4-4d88-82eb-379cf1f4b03c"), new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("ed5287a9-7240-4485-9f5f-392cd52f6ea7"), new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384") });

            migrationBuilder.DeleteData(
                table: "ProductOrderJoins",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("22ed9b30-1d3c-4b96-ab3a-56f40608f2be"), new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("04a41261-0286-4532-9e78-9d65c77109f2"), new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("04a41261-0286-4532-9e78-9d65c77109f2"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"), new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("3e7f899d-867c-4698-b853-6c66c0f413fb"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), new Guid("de5ae53e-886a-4061-8dfa-d5c2b27716ca") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("4c004c7a-aa08-4714-9f2a-153dce79154d"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("571cffb5-45cf-4130-9fe8-db271cf7769e"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"), new Guid("32c81734-a0f9-45d2-b613-7a5304c1fb6f") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("57ac950f-8ca5-45d8-90c6-a9136752e844"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"), new Guid("32c81734-a0f9-45d2-b613-7a5304c1fb6f") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("6089c0d4-a700-48fb-bddd-e63e60c6c4fc"), new Guid("eca7177e-b329-4b1b-89cc-1f6ed6445fbe") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"), new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("885f5a71-8458-4c41-b437-a2b07153bf5d"), new Guid("5f2601e2-2f25-4312-a61e-daa5be44a3fe") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("8bf98d1e-78a2-44a5-ba3d-7e0e40079384"), new Guid("1ebd7129-aef3-4f96-8df9-4c035d214f27") });

            migrationBuilder.DeleteData(
                table: "ProductSupplierJoins",
                keyColumns: new[] { "ProductId", "SupplierId" },
                keyValues: new object[] { new Guid("95cdcf59-5d79-4fed-b5e5-771f9e7a2f30"), new Guid("de5ae53e-886a-4061-8dfa-d5c2b27716ca") });
        }
    }
}
