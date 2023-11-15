using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBookingShared.Migrations
{
    /// <inheritdoc />
    public partial class AddStateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Order");
        }
    }
}
