using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContabilidadeBeatyBeach.Migrations
{
    /// <inheritdoc />
    public partial class AddSalarioTotalinResumoMensalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SalarioTotal",
                table: "ResumoMensal",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalarioTotal",
                table: "ResumoMensal");
        }
    }
}
