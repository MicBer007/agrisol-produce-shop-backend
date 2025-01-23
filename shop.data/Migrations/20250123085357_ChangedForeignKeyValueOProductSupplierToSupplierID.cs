using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedForeignKeyValueOProductSupplierToSupplierID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplierJoins_Suppliers_SuppliersSupplierId",
                table: "ProductSupplierJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSupplierJoins",
                table: "ProductSupplierJoins");

            migrationBuilder.DropIndex(
                name: "IX_ProductSupplierJoins_SuppliersSupplierId",
                table: "ProductSupplierJoins");

            migrationBuilder.DropColumn(
                name: "SuppliersSupplierId",
                table: "ProductSupplierJoins");

            migrationBuilder.RenameColumn(
                name: "ProductSupplierId",
                table: "ProductSupplierJoins",
                newName: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSupplierJoins",
                table: "ProductSupplierJoins",
                columns: new[] { "ProductId", "SupplierId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplierJoins_SupplierId",
                table: "ProductSupplierJoins",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplierJoins_Suppliers_SupplierId",
                table: "ProductSupplierJoins",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplierJoins_Suppliers_SupplierId",
                table: "ProductSupplierJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSupplierJoins",
                table: "ProductSupplierJoins");

            migrationBuilder.DropIndex(
                name: "IX_ProductSupplierJoins_SupplierId",
                table: "ProductSupplierJoins");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "ProductSupplierJoins",
                newName: "ProductSupplierId");

            migrationBuilder.AddColumn<Guid>(
                name: "SuppliersSupplierId",
                table: "ProductSupplierJoins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSupplierJoins",
                table: "ProductSupplierJoins",
                columns: new[] { "ProductId", "SuppliersSupplierId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplierJoins_SuppliersSupplierId",
                table: "ProductSupplierJoins",
                column: "SuppliersSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplierJoins_Suppliers_SuppliersSupplierId",
                table: "ProductSupplierJoins",
                column: "SuppliersSupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
