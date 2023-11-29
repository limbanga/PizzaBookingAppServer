using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBookingShared.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Product_ProductId",
                table: "OrderLine");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Product_ProductId",
                table: "OrderLine",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Product_ProductId",
                table: "OrderLine");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Product_ProductId",
                table: "OrderLine",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
