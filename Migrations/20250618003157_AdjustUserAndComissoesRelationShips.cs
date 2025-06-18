using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContabilidadeBeatyBeach.Migrations
{
    /// <inheritdoc />
    public partial class AdjustUserAndComissoesRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comissoes_Usuarios_UsuariosId",
                table: "Comissoes");

            migrationBuilder.DropIndex(
                name: "IX_Comissoes_UsuariosId",
                table: "Comissoes");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Comissoes");

            migrationBuilder.CreateIndex(
                name: "IX_Comissoes_UserId",
                table: "Comissoes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comissoes_Usuarios_UserId",
                table: "Comissoes",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comissoes_Usuarios_UserId",
                table: "Comissoes");

            migrationBuilder.DropIndex(
                name: "IX_Comissoes_UserId",
                table: "Comissoes");

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Comissoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comissoes_UsuariosId",
                table: "Comissoes",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comissoes_Usuarios_UsuariosId",
                table: "Comissoes",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
