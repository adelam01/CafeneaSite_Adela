using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeneaSite.Migrations
{
    public partial class TipLapte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipLapteID",
                table: "Cafea",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipLapte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireLapte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipLapte", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipLapteID",
                table: "Cafea",
                column: "TipLapteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafea_TipLapte_TipLapteID",
                table: "Cafea",
                column: "TipLapteID",
                principalTable: "TipLapte",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafea_TipLapte_TipLapteID",
                table: "Cafea");

            migrationBuilder.DropTable(
                name: "TipLapte");

            migrationBuilder.DropIndex(
                name: "IX_Cafea_TipLapteID",
                table: "Cafea");

            migrationBuilder.DropColumn(
                name: "TipLapteID",
                table: "Cafea");
        }
    }
}
