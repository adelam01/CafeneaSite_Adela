using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeneaSite.Migrations
{
    public partial class all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membru",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membru", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipAroma",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireAroma = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAroma", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipBoabe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireBoabe = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipBoabe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipCafea",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipCafea", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipLapte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireLapte = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipLapte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipTopping",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireTopping = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipTopping", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cafea",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireCafea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipCafeaID = table.Column<int>(type: "int", nullable: true),
                    TipBoabeID = table.Column<int>(type: "int", nullable: true),
                    TipLapteID = table.Column<int>(type: "int", nullable: true),
                    TipAromaID = table.Column<int>(type: "int", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafea", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cafea_TipAroma_TipAromaID",
                        column: x => x.TipAromaID,
                        principalTable: "TipAroma",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cafea_TipBoabe_TipBoabeID",
                        column: x => x.TipBoabeID,
                        principalTable: "TipBoabe",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cafea_TipCafea_TipCafeaID",
                        column: x => x.TipCafeaID,
                        principalTable: "TipCafea",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cafea_TipLapte_TipLapteID",
                        column: x => x.TipLapteID,
                        principalTable: "TipLapte",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CafeaTipuriTopping",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CafeaID = table.Column<int>(type: "int", nullable: false),
                    TipToppingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CafeaTipuriTopping", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CafeaTipuriTopping_Cafea_CafeaID",
                        column: x => x.CafeaID,
                        principalTable: "Cafea",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CafeaTipuriTopping_TipTopping_TipToppingID",
                        column: x => x.TipToppingID,
                        principalTable: "TipTopping",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipAromaID",
                table: "Cafea",
                column: "TipAromaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipBoabeID",
                table: "Cafea",
                column: "TipBoabeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipCafeaID",
                table: "Cafea",
                column: "TipCafeaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipLapteID",
                table: "Cafea",
                column: "TipLapteID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaTipuriTopping_CafeaID",
                table: "CafeaTipuriTopping",
                column: "CafeaID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaTipuriTopping_TipToppingID",
                table: "CafeaTipuriTopping",
                column: "TipToppingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CafeaTipuriTopping");

            migrationBuilder.DropTable(
                name: "Membru");

            migrationBuilder.DropTable(
                name: "Cafea");

            migrationBuilder.DropTable(
                name: "TipTopping");

            migrationBuilder.DropTable(
                name: "TipAroma");

            migrationBuilder.DropTable(
                name: "TipBoabe");

            migrationBuilder.DropTable(
                name: "TipCafea");

            migrationBuilder.DropTable(
                name: "TipLapte");
        }
    }
}
