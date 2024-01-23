using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaEmpleo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudadanos_Vacantes_VacanteId",
                table: "Ciudadanos");

            migrationBuilder.DropIndex(
                name: "IX_Ciudadanos_VacanteId",
                table: "Ciudadanos");

            migrationBuilder.DropColumn(
                name: "VacanteId",
                table: "Ciudadanos");

            migrationBuilder.DropColumn(
                name: "VacantesId",
                table: "Ciudadanos");

            migrationBuilder.CreateTable(
                name: "CiudadanoVacante",
                columns: table => new
                {
                    CiudadanosId = table.Column<int>(type: "integer", nullable: false),
                    VacantesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiudadanoVacante", x => new { x.CiudadanosId, x.VacantesId });
                    table.ForeignKey(
                        name: "FK_CiudadanoVacante_Ciudadanos_CiudadanosId",
                        column: x => x.CiudadanosId,
                        principalTable: "Ciudadanos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CiudadanoVacante_Vacantes_VacantesId",
                        column: x => x.VacantesId,
                        principalTable: "Vacantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CiudadanoVacante_VacantesId",
                table: "CiudadanoVacante",
                column: "VacantesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CiudadanoVacante");

            migrationBuilder.AddColumn<int>(
                name: "VacanteId",
                table: "Ciudadanos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "VacantesId",
                table: "Ciudadanos",
                type: "integer[]",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudadanos_VacanteId",
                table: "Ciudadanos",
                column: "VacanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudadanos_Vacantes_VacanteId",
                table: "Ciudadanos",
                column: "VacanteId",
                principalTable: "Vacantes",
                principalColumn: "Id");
        }
    }
}
