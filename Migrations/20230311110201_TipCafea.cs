using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeneaSite.Migrations
{
    public partial class TipCafea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipCafea",
                table: "Cafea");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Cafea",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "TipCafeaID",
                table: "Cafea",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipCafea",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipCafea", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipCafeaID",
                table: "Cafea",
                column: "TipCafeaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafea_TipCafea_TipCafeaID",
                table: "Cafea",
                column: "TipCafeaID",
                principalTable: "TipCafea",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafea_TipCafea_TipCafeaID",
                table: "Cafea");

            migrationBuilder.DropTable(
                name: "TipCafea");

            migrationBuilder.DropIndex(
                name: "IX_Cafea_TipCafeaID",
                table: "Cafea");

            migrationBuilder.DropColumn(
                name: "TipCafeaID",
                table: "Cafea");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Cafea",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<string>(
                name: "TipCafea",
                table: "Cafea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
