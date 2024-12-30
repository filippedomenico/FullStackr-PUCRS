using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthPass.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Passaporte = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Vacina",
                columns: table => new
                {
                    VacinaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DosesNecessarias = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoVacina = table.Column<int>(type: "int", nullable: false),
                    Disponivel = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacina", x => x.VacinaId);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioVacina",
                columns: table => new
                {
                    UsuarioVacinaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VacinaId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioVacina", x => x.UsuarioVacinaId);
                    table.ForeignKey(
                        name: "FK_UsuarioVacina_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioVacina_Vacina_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacina",
                        principalColumn: "VacinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDoseVacina",
                columns: table => new
                {
                    UsuarioDoseVacinaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsuarioVacinaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataVacinacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataPrevisaoDose = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDoseVacina", x => x.UsuarioDoseVacinaId);
                    table.ForeignKey(
                        name: "FK_UsuarioDoseVacina_UsuarioVacina_UsuarioDoseVacinaId",
                        column: x => x.UsuarioDoseVacinaId,
                        principalTable: "UsuarioVacina",
                        principalColumn: "UsuarioVacinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVacina_UsuarioId",
                table: "UsuarioVacina",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVacina_VacinaId",
                table: "UsuarioVacina",
                column: "VacinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioDoseVacina");

            migrationBuilder.DropTable(
                name: "UsuarioVacina");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Vacina");
        }
    }
}
