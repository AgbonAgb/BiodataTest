using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class applica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f23e4a0-dace-4126-a1e0-0d62966f5a80");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd05091-6694-42cf-8f47-48378eb6f36c");

            migrationBuilder.AddColumn<int>(
                name: "yearsExpe",
                table: "ApplicationViewModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "yearsExpe",
                table: "applications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17ab7eb6-cebe-4a71-a7a2-864616fa196e", "07bc07f0-0eb7-43da-af02-f97caf121d6c", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e706a219-cd52-42c8-a8b2-49ed4b334a91", 0, "5507f563-ec37-485e-9949-5c3929d6f034", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "473748e5-0e93-42fb-bc7b-225eea687724", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17ab7eb6-cebe-4a71-a7a2-864616fa196e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e706a219-cd52-42c8-a8b2-49ed4b334a91");

            migrationBuilder.DropColumn(
                name: "yearsExpe",
                table: "ApplicationViewModel");

            migrationBuilder.DropColumn(
                name: "yearsExpe",
                table: "applications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f23e4a0-dace-4126-a1e0-0d62966f5a80", "eff5531d-8ed8-43a1-9a89-35167400b0d3", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bfd05091-6694-42cf-8f47-48378eb6f36c", 0, "4e8568fd-1aea-4e5d-b0a5-2890e0d15e9a", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "572a192a-0882-4f39-a976-d66a5fcb8e23", false, "Agbon" });
        }
    }
}
