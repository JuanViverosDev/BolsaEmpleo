using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaEmpleo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailcolumntociudadanosentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Ciudadanos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Ciudadanos");
        }
    }
}
