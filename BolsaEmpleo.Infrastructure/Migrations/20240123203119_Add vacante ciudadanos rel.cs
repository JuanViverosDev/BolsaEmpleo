using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaEmpleo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addvacanteciudadanosrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacantes_Ciudadanos_CiudadanoId",
                table: "Vacantes");

            migrationBuilder.DropIndex(
                name: "IX_Vacantes_CiudadanoId",
                table: "Vacantes");

            migrationBuilder.DropColumn(
                name: "CiudadanoId",
                table: "Vacantes");

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
                name: "CiudadanoId",
                table: "Vacantes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacantes_CiudadanoId",
                table: "Vacantes",
                column: "CiudadanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacantes_Ciudadanos_CiudadanoId",
                table: "Vacantes",
                column: "CiudadanoId",
                principalTable: "Ciudadanos",
                principalColumn: "Id");
        }
    }
}
