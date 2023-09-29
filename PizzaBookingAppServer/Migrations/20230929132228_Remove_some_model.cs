using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBookingShared.Migrations
{
    /// <inheritdoc />
    public partial class Remove_some_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_LoginStatus_LoginStatusId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeType_TypeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_LoginStatus_LoginStatusId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "HasPermission");

            migrationBuilder.DropTable(
                name: "IncludePermisson");

            migrationBuilder.DropTable(
                name: "LoginStatus");

            migrationBuilder.DropTable(
                name: "EmployeePermission");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropIndex(
                name: "IX_Employee_LoginStatusId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_TypeId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Customer_LoginStatusId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LoginStatusId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LoginStatusId",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginName",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Email",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LoginName",
                table: "Employee",
                column: "LoginName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PhoneNumber",
                table: "Employee",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_Email",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_LoginName",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_PhoneNumber",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LoginStatusId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginStatusId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HasPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    PermissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HasPermission_EmployeePermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "EmployeePermission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HasPermission_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IncludePermisson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: true),
                    PermissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludePermisson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncludePermisson_EmployeePermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "EmployeePermission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IncludePermisson_EmployeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LoginStatusId",
                table: "Employee",
                column: "LoginStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TypeId",
                table: "Employee",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_LoginStatusId",
                table: "Customer",
                column: "LoginStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HasPermission_EmployeeId",
                table: "HasPermission",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HasPermission_PermissionId",
                table: "HasPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludePermisson_EmployeeTypeId",
                table: "IncludePermisson",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludePermisson_PermissionId",
                table: "IncludePermisson",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_LoginStatus_LoginStatusId",
                table: "Customer",
                column: "LoginStatusId",
                principalTable: "LoginStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeType_TypeId",
                table: "Employee",
                column: "TypeId",
                principalTable: "EmployeeType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_LoginStatus_LoginStatusId",
                table: "Employee",
                column: "LoginStatusId",
                principalTable: "LoginStatus",
                principalColumn: "Id");
        }
    }
}
