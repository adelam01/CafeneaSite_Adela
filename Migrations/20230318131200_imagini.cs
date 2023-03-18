using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeneaSite.Migrations
{
    public partial class imagini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagine",
                table: "TipTopping",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagine",
                table: "TipLapte",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagine",
                table: "TipCafea",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagine",
                table: "TipBoabe",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagine",
                table: "TipTopping");

            migrationBuilder.DropColumn(
                name: "Imagine",
                table: "TipLapte");

            migrationBuilder.DropColumn(
                name: "Imagine",
                table: "TipCafea");

            migrationBuilder.DropColumn(
                name: "Imagine",
                table: "TipBoabe");
        }
    }
}
