using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroMedico___Proyecto_Final.Migrations
{
    public partial class RolesUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Usuarios_Usuarios",
                table: "Roles_Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Roles_Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Usuarios_UsuariosId",
                table: "Roles_Usuarios",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Usuarios_Usuarios",
                table: "Roles_Usuarios",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuariosID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Usuarios_Usuarios_UsuariosId",
                table: "Roles_Usuarios",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "UsuariosID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Usuarios_Usuarios",
                table: "Roles_Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Usuarios_Usuarios_UsuariosId",
                table: "Roles_Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Usuarios_UsuariosId",
                table: "Roles_Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Roles_Usuarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Usuarios_Usuarios",
                table: "Roles_Usuarios",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuariosID");
        }
    }
}
