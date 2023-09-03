using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prj_JACV_Ejercicio_6.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analistas",
                columns: table => new
                {
                    ID_Analista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analistas", x => x.ID_Analista);
                });

            migrationBuilder.CreateTable(
                name: "AreasDesempeno",
                columns: table => new
                {
                    ID_Area_Desempeno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor_Puntuacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDesempeno", x => x.ID_Area_Desempeno);
                });

            migrationBuilder.CreateTable(
                name: "Talentos",
                columns: table => new
                {
                    ID_Talento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTalento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Area = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talentos", x => x.ID_Talento);
                    table.ForeignKey(
                        name: "FK_Talentos_AreasDesempeno_ID_Area",
                        column: x => x.ID_Area,
                        principalTable: "AreasDesempeno",
                        principalColumn: "ID_Area_Desempeno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puntos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Analista = table.Column<int>(type: "int", nullable: false),
                    ID_Talento = table.Column<int>(type: "int", nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puntos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Puntos_Analistas_ID_Analista",
                        column: x => x.ID_Analista,
                        principalTable: "Analistas",
                        principalColumn: "ID_Analista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Puntos_Talentos_ID_Talento",
                        column: x => x.ID_Talento,
                        principalTable: "Talentos",
                        principalColumn: "ID_Talento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puntos_ID_Analista",
                table: "Puntos",
                column: "ID_Analista");

            migrationBuilder.CreateIndex(
                name: "IX_Puntos_ID_Talento",
                table: "Puntos",
                column: "ID_Talento");

            migrationBuilder.CreateIndex(
                name: "IX_Talentos_ID_Area",
                table: "Talentos",
                column: "ID_Area");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puntos");

            migrationBuilder.DropTable(
                name: "Analistas");

            migrationBuilder.DropTable(
                name: "Talentos");

            migrationBuilder.DropTable(
                name: "AreasDesempeno");
        }
    }
}
