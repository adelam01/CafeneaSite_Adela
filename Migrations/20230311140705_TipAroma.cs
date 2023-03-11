using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeneaSite.Migrations
{
    public partial class TipAroma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipAromaID",
                table: "Cafea",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipAroma",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireAroma = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAroma", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipAromaID",
                table: "Cafea",
                column: "TipAromaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafea_TipAroma_TipAromaID",
                table: "Cafea",
                column: "TipAromaID",
                principalTable: "TipAroma",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafea_TipAroma_TipAromaID",
                table: "Cafea");

            migrationBuilder.DropTable(
                name: "TipAroma");

            migrationBuilder.DropIndex(
                name: "IX_Cafea_TipAromaID",
                table: "Cafea");

            migrationBuilder.DropColumn(
                name: "TipAromaID",
                table: "Cafea");
        }
    }
}
