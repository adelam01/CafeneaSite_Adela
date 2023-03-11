using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeneaSite.Migrations
{
    public partial class TipBoabe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafea_TipCafea_TipCafeaID",
                table: "Cafea");

            migrationBuilder.AlterColumn<int>(
                name: "TipCafeaID",
                table: "Cafea",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TipBoabeID",
                table: "Cafea",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipBoabe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireBoabe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipBoabe", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipBoabeID",
                table: "Cafea",
                column: "TipBoabeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafea_TipBoabe_TipBoabeID",
                table: "Cafea",
                column: "TipBoabeID",
                principalTable: "TipBoabe",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafea_TipCafea_TipCafeaID",
                table: "Cafea",
                column: "TipCafeaID",
                principalTable: "TipCafea",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafea_TipBoabe_TipBoabeID",
                table: "Cafea");

            migrationBuilder.DropForeignKey(
                name: "FK_Cafea_TipCafea_TipCafeaID",
                table: "Cafea");

            migrationBuilder.DropTable(
                name: "TipBoabe");

            migrationBuilder.DropIndex(
                name: "IX_Cafea_TipBoabeID",
                table: "Cafea");

            migrationBuilder.DropColumn(
                name: "TipBoabeID",
                table: "Cafea");

            migrationBuilder.AlterColumn<int>(
                name: "TipCafeaID",
                table: "Cafea",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cafea_TipCafea_TipCafeaID",
                table: "Cafea",
                column: "TipCafeaID",
                principalTable: "TipCafea",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
