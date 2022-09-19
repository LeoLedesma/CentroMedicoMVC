using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroMedico___Proyecto_Final.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "especialidadesCentro",
                columns: table => new
                {
                    EspecialidadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__especial__3213E83FD8EB4316", x => x.EspecialidadID);
                });

            migrationBuilder.CreateTable(
                name: "horarioDeAtencion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    atiende = table.Column<bool>(type: "bit", nullable: false),
                    esPorDefecto = table.Column<bool>(type: "bit", nullable: false),
                    desde = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    hasta = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarioDeAtencion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    PacienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    apellido = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    genero = table.Column<int>(type: "int", nullable: false),
                    nacionalidad = table.Column<int>(type: "int", nullable: false),
                    documento = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    telefonoContacto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    obraSocial = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    numeroAfiliado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.PacienteID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "diasDeAtencion",
                columns: table => new
                {
                    DiasDeAtencionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LunesID = table.Column<int>(type: "int", nullable: false),
                    MartesID = table.Column<int>(type: "int", nullable: false),
                    MiercolesID = table.Column<int>(type: "int", nullable: false),
                    JuevesID = table.Column<int>(type: "int", nullable: false),
                    ViernesID = table.Column<int>(type: "int", nullable: false),
                    SabadoID = table.Column<int>(type: "int", nullable: false),
                    DomingoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diasDeAtencion", x => x.DiasDeAtencionID);
                    table.ForeignKey(
                        name: "FK__diasDeAte__idDom__31EC6D26",
                        column: x => x.DomingoID,
                        principalTable: "horarioDeAtencion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__diasDeAte__idJue__32E0915F",
                        column: x => x.JuevesID,
                        principalTable: "horarioDeAtencion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__diasDeAte__idLun__33D4B598",
                        column: x => x.LunesID,
                        principalTable: "horarioDeAtencion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__diasDeAte__idMar__34C8D9D1",
                        column: x => x.MartesID,
                        principalTable: "horarioDeAtencion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__diasDeAte__idMie__35BCFE0A",
                        column: x => x.MiercolesID,
                        principalTable: "horarioDeAtencion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__diasDeAte__idSab__36B12243",
                        column: x => x.SabadoID,
                        principalTable: "horarioDeAtencion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__diasDeAte__idVie__37A5467C",
                        column: x => x.ViernesID,
                        principalTable: "horarioDeAtencion",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "centroMedico",
                columns: table => new
                {
                    CentroMedicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    duracionTurno = table.Column<int>(type: "int", nullable: false),
                    DiasDeAtencionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centroMedico", x => x.CentroMedicoID);
                    table.ForeignKey(
                        name: "FK__centroMed__idDia__3C69FB99",
                        column: x => x.DiasDeAtencionID,
                        principalTable: "diasDeAtencion",
                        principalColumn: "DiasDeAtencionID");
                });

            migrationBuilder.CreateTable(
                name: "profesionales",
                columns: table => new
                {
                    ProfesionalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    apellido = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    genero = table.Column<int>(type: "int", nullable: false),
                    nacionalidad = table.Column<int>(type: "int", nullable: false),
                    documento = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    matricula = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DiasDeAtencionID = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__profesio__3213E83FD1E933DA", x => x.ProfesionalID);
                    table.ForeignKey(
                        name: "FK__profesion__idDia__32E0915F",
                        column: x => x.DiasDeAtencionID,
                        principalTable: "diasDeAtencion",
                        principalColumn: "DiasDeAtencionID");
                });

            migrationBuilder.CreateTable(
                name: "especialidadesProfesionales",
                columns: table => new
                {
                    EspecialidadID = table.Column<int>(type: "int", nullable: false),
                    ProfesionalID = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__especiali__idPro__398D8EEE",
                        column: x => x.ProfesionalID,
                        principalTable: "profesionales",
                        principalColumn: "ProfesionalID");
                    table.ForeignKey(
                        name: "FK_especialidadesProfesionales_especialidadesCentro",
                        column: x => x.EspecialidadID,
                        principalTable: "especialidadesCentro",
                        principalColumn: "EspecialidadID");
                });

            migrationBuilder.CreateTable(
                name: "turnos",
                columns: table => new
                {
                    TurnoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    ProfesionalID = table.Column<int>(type: "int", nullable: false),
                    EspecialidadID = table.Column<int>(type: "int", nullable: false),
                    pacienteAsistio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turnos", x => x.TurnoID);
                    table.ForeignKey(
                        name: "FK__turnos__idEspeci__3B75D760",
                        column: x => x.EspecialidadID,
                        principalTable: "especialidadesCentro",
                        principalColumn: "EspecialidadID");
                    table.ForeignKey(
                        name: "FK__turnos__idPacien__3C69FB99",
                        column: x => x.PacienteID,
                        principalTable: "pacientes",
                        principalColumn: "PacienteID");
                    table.ForeignKey(
                        name: "FK__turnos__idProfes__3D5E1FD2",
                        column: x => x.ProfesionalID,
                        principalTable: "profesionales",
                        principalColumn: "ProfesionalID");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuariosID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    contrasenia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: true),
                    ProfesionalID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuariosID);
                    table.ForeignKey(
                        name: "FK_Usuarios_pacientes",
                        column: x => x.PacienteID,
                        principalTable: "pacientes",
                        principalColumn: "PacienteID");
                    table.ForeignKey(
                        name: "FK_Usuarios_profesionales",
                        column: x => x.ProfesionalID,
                        principalTable: "profesionales",
                        principalColumn: "ProfesionalID");
                });

            migrationBuilder.CreateTable(
                name: "Roles_Usuarios",
                columns: table => new
                {
                    RolesUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    RolesID = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "UsuariosID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_centroMedico_DiasDeAtencionID",
                table: "centroMedico",
                column: "DiasDeAtencionID");

            migrationBuilder.CreateIndex(
                name: "IX_diasDeAtencion_DomingoID",
                table: "diasDeAtencion",
                column: "DomingoID");

            migrationBuilder.CreateIndex(
                name: "IX_diasDeAtencion_JuevesID",
                table: "diasDeAtencion",
                column: "JuevesID");

            migrationBuilder.CreateIndex(
                name: "IX_diasDeAtencion_LunesID",
                table: "diasDeAtencion",
                column: "LunesID");

            migrationBuilder.CreateIndex(
                name: "IX_diasDeAtencion_MartesID",
                table: "diasDeAtencion",
                column: "MartesID");

            migrationBuilder.CreateIndex(
                name: "IX_diasDeAtencion_MiercolesID",
                table: "diasDeAtencion",
                column: "MiercolesID");

            migrationBuilder.CreateIndex(
                name: "IX_diasDeAtencion_SabadoID",
                table: "diasDeAtencion",
                column: "SabadoID");

            migrationBuilder.CreateIndex(
                name: "IX_diasDeAtencion_ViernesID",
                table: "diasDeAtencion",
                column: "ViernesID");

            migrationBuilder.CreateIndex(
                name: "IX_especialidadesProfesionales_EspecialidadID",
                table: "especialidadesProfesionales",
                column: "EspecialidadID");

            migrationBuilder.CreateIndex(
                name: "IX_especialidadesProfesionales_ProfesionalID",
                table: "especialidadesProfesionales",
                column: "ProfesionalID");

            migrationBuilder.CreateIndex(
                name: "IX_profesionales_DiasDeAtencionID",
                table: "profesionales",
                column: "DiasDeAtencionID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Usuarios_RolesID",
                table: "Roles_Usuarios",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Usuarios_UsuarioID",
                table: "Roles_Usuarios",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_turnos_EspecialidadID",
                table: "turnos",
                column: "EspecialidadID");

            migrationBuilder.CreateIndex(
                name: "IX_turnos_PacienteID",
                table: "turnos",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_turnos_ProfesionalID",
                table: "turnos",
                column: "ProfesionalID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PacienteID",
                table: "Usuarios",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ProfesionalID",
                table: "Usuarios",
                column: "ProfesionalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "centroMedico");

            migrationBuilder.DropTable(
                name: "especialidadesProfesionales");

            migrationBuilder.DropTable(
                name: "Roles_Usuarios");

            migrationBuilder.DropTable(
                name: "turnos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "especialidadesCentro");

            migrationBuilder.DropTable(
                name: "pacientes");

            migrationBuilder.DropTable(
                name: "profesionales");

            migrationBuilder.DropTable(
                name: "diasDeAtencion");

            migrationBuilder.DropTable(
                name: "horarioDeAtencion");
        }
    }
}
