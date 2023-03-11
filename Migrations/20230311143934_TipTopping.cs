using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeneaSite.Migrations
{
    public partial class TipTopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipToppingID",
                table: "Cafea",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipTopping",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireTopping = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipTopping", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipToppingID",
                table: "Cafea",
                column: "TipToppingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafea_TipTopping_TipToppingID",
                table: "Cafea",
                column: "TipToppingID",
                principalTable: "TipTopping",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafea_TipTopping_TipToppingID",
                table: "Cafea");

            migrationBuilder.DropTable(
                name: "TipTopping");

            migrationBuilder.DropIndex(
                name: "IX_Cafea_TipToppingID",
                table: "Cafea");

            migrationBuilder.DropColumn(
                name: "TipToppingID",
                table: "Cafea");
        }
    }
}
