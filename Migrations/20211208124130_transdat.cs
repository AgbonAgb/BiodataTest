using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class transdat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17ab7eb6-cebe-4a71-a7a2-864616fa196e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e706a219-cd52-42c8-a8b2-49ed4b334a91");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransDate",
                table: "ApplicationViewModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TransDate",
                table: "applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad8395c3-481e-4711-adce-c86c7f571c42", "a9c33c8f-2ea3-474b-9024-8d76f332bef7", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a198ee3-e3b7-42b8-9125-f97bedd946c1", 0, "8067c09f-6655-4579-9caf-24a586aa8279", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "8e7de0cc-94b7-4e7b-b2ce-9711f0d7d6e9", false, "Agbon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad8395c3-481e-4711-adce-c86c7f571c42");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a198ee3-e3b7-42b8-9125-f97bedd946c1");

            migrationBuilder.DropColumn(
                name: "TransDate",
                table: "ApplicationViewModel");

            migrationBuilder.DropColumn(
                name: "TransDate",
                table: "applications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17ab7eb6-cebe-4a71-a7a2-864616fa196e", "07bc07f0-0eb7-43da-af02-f97caf121d6c", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e706a219-cd52-42c8-a8b2-49ed4b334a91", 0, "5507f563-ec37-485e-9949-5c3929d6f034", "agbonwinn@yahoo.com", false, "Agbon", "Godwin", false, null, null, null, "AQAAAAEAACcQAAAAEDeN6XPtWjB/59XyTXCdDACLuvRzqVCFvgkRF8CzJ0Cl3HEKB+d94afT2mksWCNMsQ==", null, false, "473748e5-0e93-42fb-bc7b-225eea687724", false, "Agbon" });
        }
    }
}
