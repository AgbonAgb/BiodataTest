using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class AddtoCart34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCartItem_shoppingCartItem_ShoppingCartItemId1",
                table: "shoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCartItem_ShoppingCartItemId1",
                table: "shoppingCartItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75cb79ca-2091-4e70-b2b8-65ef220ce4e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39f4f51b-7406-4a1d-8366-db667b0e73ef");

            migrationBuilder.DropColumn(
                name: "ShoppingCartItemId1",
                table: "shoppingCartItem");

            migrationBuilder.AlterColumn<string>(
                name: "EmployerId",
                table: "shoppingCartItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CareerName",
                table: "shoppingCartItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "shoppingCartItem",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployerId",
                table: "applications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ShoppingCartItemViewModel",
                columns: table => new
                {
                    EmployerId = table.Column<string>(nullable: false),
                    ShoppingCartTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItemViewModel", x => x.EmployerId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e287017c-df8a-422b-b516-19aa7dc16537", "e29d6337-0ff3-4b08-814d-5486da328874", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "49730400-1fc7-43f9-a342-2465caa80b82", 0, "830addb6-d4eb-4b57-95e4-60eee435234a", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "4a9309a1-c651-4f43-b271-6ab0fb3d4696", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItemViewModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e287017c-df8a-422b-b516-19aa7dc16537");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49730400-1fc7-43f9-a342-2465caa80b82");

            migrationBuilder.DropColumn(
                name: "CareerName",
                table: "shoppingCartItem");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "shoppingCartItem");

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "shoppingCartItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartItemId1",
                table: "shoppingCartItem",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75cb79ca-2091-4e70-b2b8-65ef220ce4e0", "4fd10a8e-dfc5-4e43-8064-19116e57cfe9", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "39f4f51b-7406-4a1d-8366-db667b0e73ef", 0, "2743f89c-78fb-46b4-989c-c92e212bd382", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "38f5e38d-ed95-4f84-8e80-a5728fa17d85", false, "Agbon" });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCartItem_ShoppingCartItemId1",
                table: "shoppingCartItem",
                column: "ShoppingCartItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCartItem_shoppingCartItem_ShoppingCartItemId1",
                table: "shoppingCartItem",
                column: "ShoppingCartItemId1",
                principalTable: "shoppingCartItem",
                principalColumn: "ShoppingCartItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
