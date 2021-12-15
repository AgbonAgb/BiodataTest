using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class AddtoCart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13b3e90a-52f6-49b8-abe7-542328579e8f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a6ea28d-ecec-417c-afb6-b9b8ba78ed47");

            migrationBuilder.CreateTable(
                name: "shoppingCartItem",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    CareerID = table.Column<int>(nullable: false),
                    EmployerId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    transDate = table.Column<DateTime>(nullable: false),
                    ShoppingCartTotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    finalize = table.Column<bool>(nullable: false),
                    ShoppingCartItemId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCartItem", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_shoppingCartItem_shoppingCartItem_ShoppingCartItemId1",
                        column: x => x.ShoppingCartItemId1,
                        principalTable: "shoppingCartItem",
                        principalColumn: "ShoppingCartItemId",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppingCartItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75cb79ca-2091-4e70-b2b8-65ef220ce4e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39f4f51b-7406-4a1d-8366-db667b0e73ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13b3e90a-52f6-49b8-abe7-542328579e8f", "a609b91c-11f5-42ef-9175-1678d1efaf57", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5a6ea28d-ecec-417c-afb6-b9b8ba78ed47", 0, "46b5c41a-4a9f-4c71-bc6b-f1836a6f70b3", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "099da01f-5d9d-4655-954b-c58474987070", false, "Agbon" });
        }
    }
}
