using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class initial006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4368bc32-af54-47db-9cab-7cbea46fd3b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "950e19c7-ecb2-4bfb-a326-1e3629ecc77c");

            migrationBuilder.AddColumn<string>(
                name: "CvPath",
                table: "BioDataViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CvPath",
                table: "bioData",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0056d303-0e23-484e-800f-71db599981b3", "af9d396b-35e7-4300-9c25-5a1272dfb3ec", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "691b5543-7bf1-4949-9433-63c7941342cd", 0, "d7172ce4-5ee6-4d1e-b12b-27ba110c66e9", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "64acecb9-5c1a-4d9b-8ba7-94f64bc1d2f4", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0056d303-0e23-484e-800f-71db599981b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "691b5543-7bf1-4949-9433-63c7941342cd");

            migrationBuilder.DropColumn(
                name: "CvPath",
                table: "BioDataViewModel");

            migrationBuilder.DropColumn(
                name: "CvPath",
                table: "bioData");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4368bc32-af54-47db-9cab-7cbea46fd3b3", "291fb55d-9052-45db-98ec-6055a77d1829", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "950e19c7-ecb2-4bfb-a326-1e3629ecc77c", 0, "1087a5bc-bc3e-4a54-bf70-55e530ac5e64", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "b12e394a-f9da-45c6-9911-3f15c742be52", false, "Agbon" });
        }
    }
}
