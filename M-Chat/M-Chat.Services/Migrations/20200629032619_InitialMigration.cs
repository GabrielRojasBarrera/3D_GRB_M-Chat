using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace M_Chat.Services.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centro_Educativos",
                columns: table => new
                {
                    ClaveId = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Nivel_Educativo = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Representante = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centro_Educativos", x => x.ClaveId);
                });

            migrationBuilder.CreateTable(
                name: "Cuestionarios",
                columns: table => new
                {
                    Id_Cuestionario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripccion = table.Column<string>(nullable: false),
                    Fecha_aplicacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuestionarios", x => x.Id_Cuestionario);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    EmailId = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Curp = table.Column<string>(nullable: false),
                    Nacionalidad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    Id_Pregunta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta = table.Column<string>(nullable: false),
                    CuestionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.Id_Pregunta);
                    table.ForeignKey(
                        name: "FK_Preguntas_Cuestionarios_CuestionarioId",
                        column: x => x.CuestionarioId,
                        principalTable: "Cuestionarios",
                        principalColumn: "Id_Cuestionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Infantes",
                columns: table => new
                {
                    CurpId = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Fecha_Nacimiento_Infante = table.Column<DateTime>(nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    TutorId = table.Column<string>(nullable: true),
                    ClaveId = table.Column<string>(nullable: true),
                    Centro_educativoClaveId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infantes", x => x.CurpId);
                    table.ForeignKey(
                        name: "FK_Infantes_Centro_Educativos_Centro_educativoClaveId",
                        column: x => x.Centro_educativoClaveId,
                        principalTable: "Centro_Educativos",
                        principalColumn: "ClaveId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Infantes_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    Id_Respuesta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Respuesta = table.Column<bool>(nullable: false),
                    TutorId = table.Column<string>(nullable: true),
                    PreguntaId = table.Column<string>(nullable: true),
                    PreguntasId_Pregunta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.Id_Respuesta);
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_PreguntasId_Pregunta",
                        column: x => x.PreguntasId_Pregunta,
                        principalTable: "Preguntas",
                        principalColumn: "Id_Pregunta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respuestas_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    Id_Diagnostico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resultado = table.Column<string>(nullable: false),
                    InfanteId = table.Column<string>(nullable: true),
                    RespuestaId = table.Column<int>(nullable: false),
                    RespuestasId_Respuesta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.Id_Diagnostico);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Infantes_InfanteId",
                        column: x => x.InfanteId,
                        principalTable: "Infantes",
                        principalColumn: "CurpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Respuestas_RespuestasId_Respuesta",
                        column: x => x.RespuestasId_Respuesta,
                        principalTable: "Respuestas",
                        principalColumn: "Id_Respuesta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_InfanteId",
                table: "Diagnosticos",
                column: "InfanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_RespuestasId_Respuesta",
                table: "Diagnosticos",
                column: "RespuestasId_Respuesta");

            migrationBuilder.CreateIndex(
                name: "IX_Infantes_Centro_educativoClaveId",
                table: "Infantes",
                column: "Centro_educativoClaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Infantes_TutorId",
                table: "Infantes",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_CuestionarioId",
                table: "Preguntas",
                column: "CuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PreguntasId_Pregunta",
                table: "Respuestas",
                column: "PreguntasId_Pregunta");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_TutorId",
                table: "Respuestas",
                column: "TutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Infantes");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Centro_Educativos");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropTable(
                name: "Cuestionarios");
        }
    }
}
