using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class career2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b030f1e6-dd26-4145-aae2-02300f633d00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66679a0-448b-4e9c-ad77-6afc8daef850");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "careers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CareerViewModel",
                columns: table => new
                {
                    CareerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareerName = table.Column<string>(nullable: true),
                    CareerDesc = table.Column<string>(nullable: true),
                    CareerImageUrl = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    skills = table.Column<string>(nullable: true),
                    skillId = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerViewModel", x => x.CareerID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da7095b6-9943-462b-ace0-c70115fbffc0", "f22c4612-bea1-491b-8a8f-2eb7a22bf832", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8fdd8b51-b8de-418d-abde-bda3ef145afe", 0, "5fe5e44d-5733-446a-9476-624b60517228", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "8fee93b0-6e19-40f1-b270-de059e87e124", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerViewModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da7095b6-9943-462b-ace0-c70115fbffc0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8fdd8b51-b8de-418d-abde-bda3ef145afe");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "careers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b030f1e6-dd26-4145-aae2-02300f633d00", "f1d6ee5d-f0a6-4917-b4c5-1bcf52820e45", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f66679a0-448b-4e9c-ad77-6afc8daef850", 0, "5aa80d56-f6b0-450c-bf6c-8d251b4756d2", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "2b741c62-9a15-43a3-83f1-22607dbb7f28", false, "Agbon" });
        }
    }
}
