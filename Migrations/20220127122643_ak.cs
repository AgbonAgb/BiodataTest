using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class ak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3ebf78c-5252-4356-aa67-87d3125cdcbe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cafc075-2f11-4e85-8362-5e4f7b235c0c");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "RegisterUser");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingitemQty",
                table: "ShoppingCartItemViewModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransRef",
                table: "shoppingCartItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "RegisterUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "RegisterUser",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerId = table.Column<string>(nullable: true),
                    TransRef = table.Column<string>(nullable: true),
                    CybRef = table.Column<string>(nullable: true),
                    TransDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26d7c5e3-055d-425d-acd2-2ae5c0e78115", "c31a842a-cba3-4981-87fb-8d6a34e08b35", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "34623216-99d0-4570-93b9-05c9336067d7", 0, "57c1b04d-0893-4405-984f-3b1bd8550438", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "76cfdb80-1162-4be9-9dcb-2fbc0380736d", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26d7c5e3-055d-425d-acd2-2ae5c0e78115");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34623216-99d0-4570-93b9-05c9336067d7");

            migrationBuilder.DropColumn(
                name: "ShoppingitemQty",
                table: "ShoppingCartItemViewModel");

            migrationBuilder.DropColumn(
                name: "TransRef",
                table: "shoppingCartItem");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "RegisterUser");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "RegisterUser");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "RegisterUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3ebf78c-5252-4356-aa67-87d3125cdcbe", "b588cf58-7840-4f25-afbd-f4b7da1987fd", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7cafc075-2f11-4e85-8362-5e4f7b235c0c", 0, "f32c46b2-357b-4f48-8ab1-f08ab0600f71", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "8ff0d265-c8ee-41ff-810f-6ef8dc6ed408", false, "Agbon" });
        }
    }
}
