using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBookingShared.Migrations
{
    /// <inheritdoc />
    public partial class AddIconColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconColor",
                table: "Category",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconColor",
                table: "Category");
        }
    }
}
