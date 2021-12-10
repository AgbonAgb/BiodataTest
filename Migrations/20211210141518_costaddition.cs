using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class costaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb40425d-e91b-47ec-bb10-e65db17b0319");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8277c8b1-9a35-463b-b9e1-22dc06615743");

            migrationBuilder.CreateTable(
                name: "yearsExperienceCost",
                columns: table => new
                {
                    CostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearsLowerBound = table.Column<int>(nullable: false),
                    YearsHigherBound = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    CareerID = table.Column<int>(nullable: false),
                    CareerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yearsExperienceCost", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "YearsExperienceCostViewModel",
                columns: table => new
                {
                    CostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearsLowerBound = table.Column<int>(nullable: false),
                    YearsHigherBound = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    CareerID = table.Column<int>(nullable: false),
                    CareerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearsExperienceCostViewModel", x => x.CostId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1acf2cc6-9291-4fdc-b37d-2bc9b59f42e9", "b771559c-9cce-44f8-be6a-21ba7b60cfc3", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9be873be-211c-4e80-9722-bca480a66266", 0, "595c61b5-23ab-4a33-ad31-cfd0d2522cbf", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "f700f93f-0d98-4c0c-9221-14839c563237", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "yearsExperienceCost");

            migrationBuilder.DropTable(
                name: "YearsExperienceCostViewModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1acf2cc6-9291-4fdc-b37d-2bc9b59f42e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9be873be-211c-4e80-9722-bca480a66266");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb40425d-e91b-47ec-bb10-e65db17b0319", "5e83fb0b-e724-4080-b1d9-7b88f85561e1", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8277c8b1-9a35-463b-b9e1-22dc06615743", 0, "5f43fd5a-c453-4024-8020-6de211c69b00", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "dfe0b50b-351b-4422-99e5-0affecfa4297", false, "Agbon" });
        }
    }
}
