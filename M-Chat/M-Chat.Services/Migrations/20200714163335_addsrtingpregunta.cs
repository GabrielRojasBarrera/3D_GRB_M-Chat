using Microsoft.EntityFrameworkCore.Migrations;

namespace M_Chat.Services.Migrations
{
    public partial class addsrtingpregunta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Respuesta",
                table: "Preguntas");

            migrationBuilder.DropColumn(
                name: "Descripccion",
                table: "Cuestionario");

            migrationBuilder.AddColumn<string>(
                name: "Pregunta",
                table: "Preguntas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pregunta",
                table: "Preguntas");

            migrationBuilder.AddColumn<string>(
                name: "Respuesta",
                table: "Preguntas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripccion",
                table: "Cuestionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
