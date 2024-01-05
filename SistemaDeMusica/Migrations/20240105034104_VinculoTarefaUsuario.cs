using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeMusica.Migrations
{
    public partial class VinculoTarefaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Musicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_UsuarioId",
                table: "Musicas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Usuarios_UsuarioId",
                table: "Musicas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Usuarios_UsuarioId",
                table: "Musicas");

            migrationBuilder.DropIndex(
                name: "IX_Musicas_UsuarioId",
                table: "Musicas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Musicas");
        }
    }
}
