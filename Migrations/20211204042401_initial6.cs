using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09c2a4a7-84a8-478c-afea-d1fd3efed644");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a517bb0-b290-4f4e-9a20-76ae0799edff");

            migrationBuilder.AddColumn<int>(
                name: "BioDataViewModelStaffId",
                table: "staffcost",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "available",
                table: "bioData",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BioDataViewModel",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNumber = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Referer = table.Column<string>(nullable: true),
                    RefererId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    DeptId = table.Column<int>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    approved = table.Column<bool>(nullable: false),
                    available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioDataViewModel", x => x.StaffId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e864fc0d-60d5-4297-a574-33ae9031fe42", "b34d3636-1ed3-417a-9955-de71254e6d82", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "51ca0669-b09c-4739-914e-c1691ef191e6", 0, "8b35447f-7de3-44ab-a8cf-71064c91988e", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "38259781-a3c2-40ad-b2c5-8b82d11b9d9c", false, "Agbon" });

            migrationBuilder.CreateIndex(
                name: "IX_staffcost_BioDataViewModelStaffId",
                table: "staffcost",
                column: "BioDataViewModelStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_staffcost_BioDataViewModel_BioDataViewModelStaffId",
                table: "staffcost",
                column: "BioDataViewModelStaffId",
                principalTable: "BioDataViewModel",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_staffcost_BioDataViewModel_BioDataViewModelStaffId",
                table: "staffcost");

            migrationBuilder.DropTable(
                name: "BioDataViewModel");

            migrationBuilder.DropIndex(
                name: "IX_staffcost_BioDataViewModelStaffId",
                table: "staffcost");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e864fc0d-60d5-4297-a574-33ae9031fe42");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51ca0669-b09c-4739-914e-c1691ef191e6");

            migrationBuilder.DropColumn(
                name: "BioDataViewModelStaffId",
                table: "staffcost");

            migrationBuilder.DropColumn(
                name: "available",
                table: "bioData");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09c2a4a7-84a8-478c-afea-d1fd3efed644", "440979c4-76c9-4351-911c-4064d7d6c86c", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8a517bb0-b290-4f4e-9a20-76ae0799edff", 0, "4918abfa-9859-4a54-a85f-2db267b2a36b", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "78b8e0cb-f629-402c-9d52-9ea6ce185397", false, "Agbon" });
        }
    }
}
