// <auto-generated />
using System;
using CentroMedico___Proyecto_Final.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CentroMedico___Proyecto_Final.Migrations
{
    [DbContext(typeof(ProyectoFinalContext))]
    [Migration("20220917204640_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.CentroMedico", b =>
                {
                    b.Property<int>("CentroMedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CentroMedicoID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CentroMedicoId"), 1L, 1);

                    b.Property<int>("DiasDeAtencionId")
                        .HasColumnType("int")
                        .HasColumnName("DiasDeAtencionID");

                    b.Property<int>("DuracionTurno")
                        .HasColumnType("int")
                        .HasColumnName("duracionTurno");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("CentroMedicoId");

                    b.HasIndex("DiasDeAtencionId");

                    b.ToTable("centroMedico", (string)null);
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.DiasDeAtencion", b =>
                {
                    b.Property<int>("DiasDeAtencionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DiasDeAtencionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiasDeAtencionId"), 1L, 1);

                    b.Property<int>("DomingoId")
                        .HasColumnType("int")
                        .HasColumnName("DomingoID");

                    b.Property<int>("JuevesId")
                        .HasColumnType("int")
                        .HasColumnName("JuevesID");

                    b.Property<int>("LunesId")
                        .HasColumnType("int")
                        .HasColumnName("LunesID");

                    b.Property<int>("MartesId")
                        .HasColumnType("int")
                        .HasColumnName("MartesID");

                    b.Property<int>("MiercolesId")
                        .HasColumnType("int")
                        .HasColumnName("MiercolesID");

                    b.Property<int>("SabadoId")
                        .HasColumnType("int")
                        .HasColumnName("SabadoID");

                    b.Property<int>("ViernesId")
                        .HasColumnType("int")
                        .HasColumnName("ViernesID");

                    b.HasKey("DiasDeAtencionId");

                    b.HasIndex("DomingoId");

                    b.HasIndex("JuevesId");

                    b.HasIndex("LunesId");

                    b.HasIndex("MartesId");

                    b.HasIndex("MiercolesId");

                    b.HasIndex("SabadoId");

                    b.HasIndex("ViernesId");

                    b.ToTable("diasDeAtencion", (string)null);
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.EspecialidadesCentro", b =>
                {
                    b.Property<int>("EspecialidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EspecialidadID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecialidadId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("nombre");

                    b.HasKey("EspecialidadId")
                        .HasName("PK__especial__3213E83FD8EB4316");

                    b.ToTable("especialidadesCentro", (string)null);
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.EspecialidadesProfesionale", b =>
                {
                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int")
                        .HasColumnName("EspecialidadID");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<int>("ProfesionalId")
                        .HasColumnType("int")
                        .HasColumnName("ProfesionalID");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex("ProfesionalId");

                    b.ToTable("especialidadesProfesionales", (string)null);
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.HorarioDeAtencion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Atiende")
                        .HasColumnType("bit")
                        .HasColumnName("atiende");

                    b.Property<string>("Desde")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("desde");

                    b.Property<bool>("EsPorDefecto")
                        .HasColumnType("bit")
                        .HasColumnName("esPorDefecto");

                    b.Property<string>("Hasta")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("hasta");

                    b.HasKey("Id");

                    b.ToTable("horarioDeAtencion", (string)null);
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PacienteID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("apellido");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("documento");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date")
                        .HasColumnName("fechaNacimiento");

                    b.Property<int>("Genero")
                        .HasColumnType("int")
                        .HasColumnName("genero");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<int>("Nacionalidad")
                        .HasColumnType("int")
                        .HasColumnName("nacionalidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("nombre");

                    b.Property<string>("NumeroAfiliado")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("numeroAfiliado");

                    b.Property<string>("ObraSocial")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("obraSocial");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefono");

                    b.Property<string>("TelefonoContacto")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefonoContacto");

                    b.HasKey("PacienteId");

                    b.ToTable("pacientes", (string)null);
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Profesionale", b =>
                {
                    b.Property<int>("ProfesionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfesionalID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfesionalId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("apellido");

                    b.Property<int>("DiasDeAtencionId")
                        .HasColumnType("int")
                        .HasColumnName("DiasDeAtencionID");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("documento");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date")
                        .HasColumnName("fechaNacimiento");

                    b.Property<int>("Genero")
                        .HasColumnType("int")
                        .HasColumnName("genero");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("matricula");

                    b.Property<int>("Nacionalidad")
                        .HasColumnType("int")
                        .HasColumnName("nacionalidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefono");

                    b.HasKey("ProfesionalId")
                        .HasName("PK__profesio__3213E83FD1E933DA");

                    b.HasIndex("DiasDeAtencionId");

                    b.ToTable("profesionales", (string)null);
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Role", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RolID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.RolesUsuario", b =>
                {
                    b.Property<int>("RolesUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolesUsuarioId"), 1L, 1);

                    b.Property<int>("RolesId")
                        .HasColumnType("int")
                        .HasColumnName("RolesID");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("RolesUsuarioId");

                    b.HasIndex("RolesId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Roles_Usuarios", (string)null);
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Turno", b =>
                {
                    b.Property<int>("TurnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TurnoID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurnoId"), 1L, 1);

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int")
                        .HasColumnName("EspecialidadID");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha");

                    b.Property<bool>("PacienteAsistio")
                        .HasColumnType("bit")
                        .HasColumnName("pacienteAsistio");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int")
                        .HasColumnName("PacienteID");

                    b.Property<int>("ProfesionalId")
                        .HasColumnType("int")
                        .HasColumnName("ProfesionalID");

                    b.HasKey("TurnoId");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("ProfesionalId");

                    b.ToTable("turnos", (string)null);
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Usuario", b =>
                {
                    b.Property<int>("UsuariosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuariosID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuariosId"), 1L, 1);

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("contrasenia");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombreUsuario");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int")
                        .HasColumnName("PacienteID");

                    b.Property<int?>("ProfesionalId")
                        .HasColumnType("int")
                        .HasColumnName("ProfesionalID");

                    b.HasKey("UsuariosId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("ProfesionalId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.CentroMedico", b =>
                {
                    b.HasOne("CentroMedico___Proyecto_Final.Models.DiasDeAtencion", "DiasDeAtencion")
                        .WithMany("CentroMedicos")
                        .HasForeignKey("DiasDeAtencionId")
                        .IsRequired()
                        .HasConstraintName("FK__centroMed__idDia__3C69FB99");

                    b.Navigation("DiasDeAtencion");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.DiasDeAtencion", b =>
                {
                    b.HasOne("CentroMedico___Proyecto_Final.Models.HorarioDeAtencion", "Domingo")
                        .WithMany("DiasDeAtencionDomingos")
                        .HasForeignKey("DomingoId")
                        .IsRequired()
                        .HasConstraintName("FK__diasDeAte__idDom__31EC6D26");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.HorarioDeAtencion", "Jueves")
                        .WithMany("DiasDeAtencionJueves")
                        .HasForeignKey("JuevesId")
                        .IsRequired()
                        .HasConstraintName("FK__diasDeAte__idJue__32E0915F");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.HorarioDeAtencion", "Lunes")
                        .WithMany("DiasDeAtencionLunes")
                        .HasForeignKey("LunesId")
                        .IsRequired()
                        .HasConstraintName("FK__diasDeAte__idLun__33D4B598");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.HorarioDeAtencion", "Martes")
                        .WithMany("DiasDeAtencionMartes")
                        .HasForeignKey("MartesId")
                        .IsRequired()
                        .HasConstraintName("FK__diasDeAte__idMar__34C8D9D1");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.HorarioDeAtencion", "Miercoles")
                        .WithMany("DiasDeAtencionMiercoles")
                        .HasForeignKey("MiercolesId")
                        .IsRequired()
                        .HasConstraintName("FK__diasDeAte__idMie__35BCFE0A");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.HorarioDeAtencion", "Sabado")
                        .WithMany("DiasDeAtencionSabados")
                        .HasForeignKey("SabadoId")
                        .IsRequired()
                        .HasConstraintName("FK__diasDeAte__idSab__36B12243");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.HorarioDeAtencion", "Viernes")
                        .WithMany("DiasDeAtencionViernes")
                        .HasForeignKey("ViernesId")
                        .IsRequired()
                        .HasConstraintName("FK__diasDeAte__idVie__37A5467C");

                    b.Navigation("Domingo");

                    b.Navigation("Jueves");

                    b.Navigation("Lunes");

                    b.Navigation("Martes");

                    b.Navigation("Miercoles");

                    b.Navigation("Sabado");

                    b.Navigation("Viernes");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.EspecialidadesProfesionale", b =>
                {
                    b.HasOne("CentroMedico___Proyecto_Final.Models.EspecialidadesCentro", "Especialidad")
                        .WithMany()
                        .HasForeignKey("EspecialidadId")
                        .IsRequired()
                        .HasConstraintName("FK_especialidadesProfesionales_especialidadesCentro");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.Profesionale", "Profesional")
                        .WithMany()
                        .HasForeignKey("ProfesionalId")
                        .IsRequired()
                        .HasConstraintName("FK__especiali__idPro__398D8EEE");

                    b.Navigation("Especialidad");

                    b.Navigation("Profesional");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Profesionale", b =>
                {
                    b.HasOne("CentroMedico___Proyecto_Final.Models.DiasDeAtencion", "DiasDeAtencion")
                        .WithMany("Profesionales")
                        .HasForeignKey("DiasDeAtencionId")
                        .IsRequired()
                        .HasConstraintName("FK__profesion__idDia__32E0915F");

                    b.Navigation("DiasDeAtencion");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.RolesUsuario", b =>
                {
                    b.HasOne("CentroMedico___Proyecto_Final.Models.Role", "Roles")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("RolesId")
                        .IsRequired()
                        .HasConstraintName("FK_Roles_Usuarios_Roles");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.Usuario", "Usuario")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("UsuarioId")
                        .IsRequired()
                        .HasConstraintName("FK_Roles_Usuarios_Usuarios");

                    b.Navigation("Roles");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Turno", b =>
                {
                    b.HasOne("CentroMedico___Proyecto_Final.Models.EspecialidadesCentro", "Especialidad")
                        .WithMany("Turnos")
                        .HasForeignKey("EspecialidadId")
                        .IsRequired()
                        .HasConstraintName("FK__turnos__idEspeci__3B75D760");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.Paciente", "Paciente")
                        .WithMany("Turnos")
                        .HasForeignKey("PacienteId")
                        .IsRequired()
                        .HasConstraintName("FK__turnos__idPacien__3C69FB99");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.Profesionale", "Profesional")
                        .WithMany("Turnos")
                        .HasForeignKey("ProfesionalId")
                        .IsRequired()
                        .HasConstraintName("FK__turnos__idProfes__3D5E1FD2");

                    b.Navigation("Especialidad");

                    b.Navigation("Paciente");

                    b.Navigation("Profesional");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Usuario", b =>
                {
                    b.HasOne("CentroMedico___Proyecto_Final.Models.Paciente", "Paciente")
                        .WithMany("Usuarios")
                        .HasForeignKey("PacienteId")
                        .HasConstraintName("FK_Usuarios_pacientes");

                    b.HasOne("CentroMedico___Proyecto_Final.Models.Profesionale", "Profesional")
                        .WithMany("Usuarios")
                        .HasForeignKey("ProfesionalId")
                        .HasConstraintName("FK_Usuarios_profesionales");

                    b.Navigation("Paciente");

                    b.Navigation("Profesional");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.DiasDeAtencion", b =>
                {
                    b.Navigation("CentroMedicos");

                    b.Navigation("Profesionales");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.EspecialidadesCentro", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.HorarioDeAtencion", b =>
                {
                    b.Navigation("DiasDeAtencionDomingos");

                    b.Navigation("DiasDeAtencionJueves");

                    b.Navigation("DiasDeAtencionLunes");

                    b.Navigation("DiasDeAtencionMartes");

                    b.Navigation("DiasDeAtencionMiercoles");

                    b.Navigation("DiasDeAtencionSabados");

                    b.Navigation("DiasDeAtencionViernes");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Paciente", b =>
                {
                    b.Navigation("Turnos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Profesionale", b =>
                {
                    b.Navigation("Turnos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Role", b =>
                {
                    b.Navigation("RolesUsuarios");
                });

            modelBuilder.Entity("CentroMedico___Proyecto_Final.Models.Usuario", b =>
                {
                    b.Navigation("RolesUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
