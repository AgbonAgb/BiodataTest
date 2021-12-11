using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class skillupdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d67daa10-ad27-459c-a2ab-f407d231d0fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "56983c54-d0b4-4617-a5eb-d722d755c5ac");

            migrationBuilder.AddColumn<string>(
                name: "CareerName",
                table: "skills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "skills",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d08c1594-4bf0-4677-b8cf-db32b25df5f9", "60358152-14cc-4657-99cb-aea4ee48e77e", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2cd77f28-8a0b-474b-8e75-9711fd56af52", 0, "9e3ca5bb-6bc1-4727-80c7-f5bcf31476b9", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "e56567b9-7131-4047-b013-3b0d82eb0014", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08c1594-4bf0-4677-b8cf-db32b25df5f9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2cd77f28-8a0b-474b-8e75-9711fd56af52");

            migrationBuilder.DropColumn(
                name: "CareerName",
                table: "skills");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "skills");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d67daa10-ad27-459c-a2ab-f407d231d0fa", "e44848b4-d7a0-42be-89a5-d0917d7a7c39", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "56983c54-d0b4-4617-a5eb-d722d755c5ac", 0, "b3874822-9317-4120-a8d7-96493181fdd9", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "3e321ec8-0d91-4f25-b2a8-7950b927b513", false, "Agbon" });
        }
    }
}
