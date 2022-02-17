using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8097865f-ff6a-4c59-8d94-a989f9393245");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b46e86-82a2-44a9-af36-1003050bb242");

            migrationBuilder.AlterColumn<string>(
                name: "skillDescription",
                table: "skills",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9464e92-4754-43bc-949e-899a341467d6", "cdda7286-aab2-4fa7-ba8c-246132b2f93e", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fcfd500f-42ae-4251-b941-753b8bd15abc", 0, "eab640f8-f63e-4762-9fca-273b4d3eb5f3", null, false, null, null, false, null, null, null, null, null, false, "cf82b646-28e5-42f9-aba8-685c698ca440", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9464e92-4754-43bc-949e-899a341467d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fcfd500f-42ae-4251-b941-753b8bd15abc");

            migrationBuilder.AlterColumn<string>(
                name: "skillDescription",
                table: "skills",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8097865f-ff6a-4c59-8d94-a989f9393245", "7ad3ca32-d26d-41a3-acfd-19d56f53ed87", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75b46e86-82a2-44a9-af36-1003050bb242", 0, "b6006828-9566-49e2-8081-242460e6b95a", null, false, null, null, false, null, null, null, null, null, false, "1ed7d6ac-ddef-421d-95e0-ca6366cf7428", false, null });
        }
    }
}
