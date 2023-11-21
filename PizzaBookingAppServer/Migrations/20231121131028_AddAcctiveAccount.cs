using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBookingShared.Migrations
{
    /// <inheritdoc />
    public partial class AddAcctiveAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addresss",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LoginFailedCount",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Addresss",
                table: "User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LoginFailedCount",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
