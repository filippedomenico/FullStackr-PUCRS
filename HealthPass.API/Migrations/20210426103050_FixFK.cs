using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthPass.API.Migrations
{
    public partial class FixFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioDoseVacina_UsuarioVacina_UsuarioDoseVacinaId",
                table: "UsuarioDoseVacina");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDoseVacina_UsuarioVacinaId",
                table: "UsuarioDoseVacina",
                column: "UsuarioVacinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioDoseVacina_UsuarioVacina_UsuarioVacinaId",
                table: "UsuarioDoseVacina",
                column: "UsuarioVacinaId",
                principalTable: "UsuarioVacina",
                principalColumn: "UsuarioVacinaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioDoseVacina_UsuarioVacina_UsuarioVacinaId",
                table: "UsuarioDoseVacina");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioDoseVacina_UsuarioVacinaId",
                table: "UsuarioDoseVacina");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioDoseVacina_UsuarioVacina_UsuarioDoseVacinaId",
                table: "UsuarioDoseVacina",
                column: "UsuarioDoseVacinaId",
                principalTable: "UsuarioVacina",
                principalColumn: "UsuarioVacinaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
