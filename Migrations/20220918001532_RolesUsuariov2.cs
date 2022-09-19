using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroMedico___Proyecto_Final.Migrations
{
    public partial class RolesUsuariov2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles_Usuarios");

            migrationBuilder.CreateTable(
                name: "RolesUsuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuarios", x => new { x.UsuarioId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuarios_RolesId",
                table: "RolesUsuarios",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesUsuarios");

            migrationBuilder.CreateTable(
                name: "Roles_Usuarios",
                columns: table => new
                {
                    RolesUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolesID = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles_Usuarios", x => x.RolesUsuarioId);
                    table.ForeignKey(
                        name: "FK_Roles_Usuarios_Roles",
                        column: x => x.RolesID,
                        principalTable: "Roles",
                        principalColumn: "RolID");
                    table.ForeignKey(
                        name: "FK_Roles_Usuarios_Usuarios",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_Usuarios_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Usuarios_RolesID",
                table: "Roles_Usuarios",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Usuarios_UsuarioID",
                table: "Roles_Usuarios",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Usuarios_UsuariosId",
                table: "Roles_Usuarios",
                column: "UsuariosId");
        }
    }
}
