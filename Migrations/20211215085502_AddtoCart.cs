using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class AddtoCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08c1594-4bf0-4677-b8cf-db32b25df5f9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2cd77f28-8a0b-474b-8e75-9711fd56af52");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "yearsExperienceCost",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "skillCode",
                table: "ApplicationViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skillDescription",
                table: "ApplicationViewModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "skillId",
                table: "ApplicationViewModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b425be6f-9e8a-495c-9abc-a1b3df4a08a1", "c90bef8e-7698-41a1-bd8d-e1cafac12ba0", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d21121f3-73a5-4cc4-80dd-1aa4a62db8eb", 0, "bcfa11d1-4064-408f-8d95-b35d75bceae4", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "9d5b4176-ca9d-4623-84da-5f72f55914f8", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b425be6f-9e8a-495c-9abc-a1b3df4a08a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d21121f3-73a5-4cc4-80dd-1aa4a62db8eb");

            migrationBuilder.DropColumn(
                name: "skillCode",
                table: "ApplicationViewModel");

            migrationBuilder.DropColumn(
                name: "skillDescription",
                table: "ApplicationViewModel");

            migrationBuilder.DropColumn(
                name: "skillId",
                table: "ApplicationViewModel");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "yearsExperienceCost",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d08c1594-4bf0-4677-b8cf-db32b25df5f9", "60358152-14cc-4657-99cb-aea4ee48e77e", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2cd77f28-8a0b-474b-8e75-9711fd56af52", 0, "9e3ca5bb-6bc1-4727-80c7-f5bcf31476b9", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "e56567b9-7131-4047-b013-3b0d82eb0014", false, "Agbon" });
        }
    }
}
