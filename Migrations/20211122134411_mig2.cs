using Microsoft.EntityFrameworkCore.Migrations;

namespace BiodataTest.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Referer",
                table: "BioDataViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referer",
                table: "bioData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Referer",
                table: "BioDataViewModel");

            migrationBuilder.DropColumn(
                name: "Referer",
                table: "bioData");
        }
    }
}
