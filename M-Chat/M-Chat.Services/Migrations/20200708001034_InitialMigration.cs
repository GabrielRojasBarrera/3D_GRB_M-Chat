using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace M_Chat.Services.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centro_Educativo",
                columns: table => new
                {
                    CentroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_CentroEducativo = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Nivel_Educativo = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Representante = table.Column<string>(nullable: false),
                    Clave = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centro_Educativo", x => x.CentroId);
                });

            migrationBuilder.CreateTable(
                name: "Cuestionario",
                columns: table => new
                {
                    CuestionarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripccion = table.Column<string>(nullable: false),
                    Fecha_aplicacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuestionario", x => x.CuestionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    TutorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Curp = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.TutorId);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    PreguntaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Respuesta = table.Column<string>(nullable: false),
                    CuestionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.PreguntaId);
                    table.ForeignKey(
                        name: "FK_Preguntas_Cuestionario_CuestionarioId",
                        column: x => x.CuestionarioId,
                        principalTable: "Cuestionario",
                        principalColumn: "CuestionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Infante",
                columns: table => new
                {
                    InfanteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Fecha_Nacimiento_Infante = table.Column<DateTime>(nullable: false),
                    Genero_Infante = table.Column<string>(nullable: false),
                    Curp = table.Column<string>(nullable: false),
                    TutorId = table.Column<int>(nullable: false),
                    CentroId = table.Column<int>(nullable: false),
                    Centro_EducativoCentroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infante", x => x.InfanteId);
                    table.ForeignKey(
                        name: "FK_Infante_Centro_Educativo_Centro_EducativoCentroId",
                        column: x => x.Centro_EducativoCentroId,
                        principalTable: "Centro_Educativo",
                        principalColumn: "CentroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Infante_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutor",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    RespuestaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Respuesta = table.Column<bool>(nullable: false),
                    PreguntaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.RespuestaId);
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    DiagnosticoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resultado = table.Column<string>(nullable: false),
                    InfanteId = table.Column<int>(nullable: false),
                    CuestionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.DiagnosticoId);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Cuestionario_CuestionarioId",
                        column: x => x.CuestionarioId,
                        principalTable: "Cuestionario",
                        principalColumn: "CuestionarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Infante_InfanteId",
                        column: x => x.InfanteId,
                        principalTable: "Infante",
                        principalColumn: "InfanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_CuestionarioId",
                table: "Diagnostico",
                column: "CuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_InfanteId",
                table: "Diagnostico",
                column: "InfanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Infante_Centro_EducativoCentroId",
                table: "Infante",
                column: "Centro_EducativoCentroId");

            migrationBuilder.CreateIndex(
                name: "IX_Infante_TutorId",
                table: "Infante",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_CuestionarioId",
                table: "Preguntas",
                column: "CuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Infante");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "Centro_Educativo");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropTable(
                name: "Cuestionario");
        }
    }
}
