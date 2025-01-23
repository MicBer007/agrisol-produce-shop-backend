using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedExplicitRelationshipMappingBetweenProductAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrderJoins",
                table: "ProductOrderJoins");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrderJoins_ProductId",
                table: "ProductOrderJoins");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ProductOrderJoins",
                newName: "Quantity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrderJoins",
                table: "ProductOrderJoins",
                columns: new[] { "ProductId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderJoins_OrderId",
                table: "ProductOrderJoins",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrderJoins",
                table: "ProductOrderJoins");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrderJoins_OrderId",
                table: "ProductOrderJoins");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductOrderJoins",
                newName: "Amount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrderJoins",
                table: "ProductOrderJoins",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderJoins_ProductId",
                table: "ProductOrderJoins",
                column: "ProductId");
        }
    }
}
