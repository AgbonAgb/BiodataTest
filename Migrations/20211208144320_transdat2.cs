using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class transdat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad8395c3-481e-4711-adce-c86c7f571c42");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a198ee3-e3b7-42b8-9125-f97bedd946c1");

            migrationBuilder.AddColumn<string>(
                name: "CareerName",
                table: "ApplicationViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "ApplicationViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CareerName",
                table: "applications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "applications",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb40425d-e91b-47ec-bb10-e65db17b0319", "5e83fb0b-e724-4080-b1d9-7b88f85561e1", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8277c8b1-9a35-463b-b9e1-22dc06615743", 0, "5f43fd5a-c453-4024-8020-6de211c69b00", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "dfe0b50b-351b-4422-99e5-0affecfa4297", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb40425d-e91b-47ec-bb10-e65db17b0319");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8277c8b1-9a35-463b-b9e1-22dc06615743");

            migrationBuilder.DropColumn(
                name: "CareerName",
                table: "ApplicationViewModel");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "ApplicationViewModel");

            migrationBuilder.DropColumn(
                name: "CareerName",
                table: "applications");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "applications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad8395c3-481e-4711-adce-c86c7f571c42", "a9c33c8f-2ea3-474b-9024-8d76f332bef7", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a198ee3-e3b7-42b8-9125-f97bedd946c1", 0, "8067c09f-6655-4579-9caf-24a586aa8279", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "8e7de0cc-94b7-4e7b-b2ce-9711f0d7d6e9", false, "Agbon" });
        }
    }
}
