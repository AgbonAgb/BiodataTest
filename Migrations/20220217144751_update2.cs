using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9464e92-4754-43bc-949e-899a341467d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fcfd500f-42ae-4251-b941-753b8bd15abc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e38e612f-a5bd-4dfb-b504-8489e0c45dd9", "289500cc-0018-446d-9ca0-9720fe20595f", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9076a433-93dd-4a37-9871-091eda84556e", 0, "8c4b7989-4218-41f4-9aa5-02847dd6294f", null, false, null, null, false, null, null, null, null, null, false, "2b889e45-9451-4470-9b55-0baed5ca288a", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e38e612f-a5bd-4dfb-b504-8489e0c45dd9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9076a433-93dd-4a37-9871-091eda84556e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9464e92-4754-43bc-949e-899a341467d6", "cdda7286-aab2-4fa7-ba8c-246132b2f93e", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fcfd500f-42ae-4251-b941-753b8bd15abc", 0, "eab640f8-f63e-4762-9fca-273b4d3eb5f3", null, false, null, null, false, null, null, null, null, null, false, "cf82b646-28e5-42f9-aba8-685c698ca440", false, null });
        }
    }
}
