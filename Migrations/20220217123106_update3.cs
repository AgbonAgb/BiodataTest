using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "194ce1ca-0aff-414b-9413-fea5352172fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e032c5ba-96dd-4b73-b9ac-b35bf8f7577c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8097865f-ff6a-4c59-8d94-a989f9393245", "7ad3ca32-d26d-41a3-acfd-19d56f53ed87", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75b46e86-82a2-44a9-af36-1003050bb242", 0, "b6006828-9566-49e2-8081-242460e6b95a", null, false, null, null, false, null, null, null, null, null, false, "1ed7d6ac-ddef-421d-95e0-ca6366cf7428", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8097865f-ff6a-4c59-8d94-a989f9393245");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b46e86-82a2-44a9-af36-1003050bb242");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "194ce1ca-0aff-414b-9413-fea5352172fd", "9263cd97-597c-4fb8-8dd3-34c9ac2fd051", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e032c5ba-96dd-4b73-b9ac-b35bf8f7577c", 0, "d2e55a62-a094-4ef0-8acb-35e809a3b7bb", null, false, null, null, false, null, null, null, null, null, false, "bdc89d65-0e23-472f-866e-11714e299cad", false, null });
        }
    }
}
