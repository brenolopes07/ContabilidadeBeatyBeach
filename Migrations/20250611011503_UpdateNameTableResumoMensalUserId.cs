using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContabilidadeBeatyBeach.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameTableResumoMensalUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "usuarioId",
            table: "ResumoMensal",
            newName: "UserId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "UserId",
            table: "ResumoMensal",
            newName: "usuarioId");
        }
    }
}
