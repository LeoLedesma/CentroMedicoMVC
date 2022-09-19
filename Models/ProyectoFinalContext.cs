using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Design;
using CentroMedico___Proyecto_Final.Migrations;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class ProyectoFinalContext : DbContext
    {
        public ProyectoFinalContext()
        {
        }

        public ProyectoFinalContext(DbContextOptions<ProyectoFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CentroMedico> CentroMedicos { get; set; }
        public virtual DbSet<DiasDeAtencion> DiasDeAtencions { get; set; }
        public virtual DbSet<EspecialidadesCentro> EspecialidadesCentros { get; set; }
        public virtual DbSet<EspecialidadesProfesional> EspecialidadesProfesionales { get; set; }
        public virtual DbSet<HorarioDeAtencion> HorarioDeAtencions { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Profesional> Profesionales { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<RolUsuario> RolesUsuarios { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.;Database=ProyectoFinal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CentroMedico>(entity =>
            {
                entity.ToTable("centroMedico");

                entity.Property(e => e.CentroMedicoId).HasColumnName("CentroMedicoID");

                entity.Property(e => e.DiasDeAtencionId).HasColumnName("DiasDeAtencionID");

                entity.Property(e => e.DuracionTurno).HasColumnName("duracionTurno");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.DiasDeAtencion)
                    .WithMany(p => p.CentroMedicos)
                    .HasForeignKey(d => d.DiasDeAtencionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__centroMed__idDia__3C69FB99");
            });

            modelBuilder.Entity<DiasDeAtencion>(entity =>
            {
                entity.ToTable("diasDeAtencion");

                entity.Property(e => e.DiasDeAtencionId).HasColumnName("DiasDeAtencionID");

                entity.Property(e => e.DomingoId).HasColumnName("DomingoID");

                entity.Property(e => e.JuevesId).HasColumnName("JuevesID");

                entity.Property(e => e.LunesId).HasColumnName("LunesID");

                entity.Property(e => e.MartesId).HasColumnName("MartesID");

                entity.Property(e => e.MiercolesId).HasColumnName("MiercolesID");

                entity.Property(e => e.SabadoId).HasColumnName("SabadoID");

                entity.Property(e => e.ViernesId).HasColumnName("ViernesID");

                entity.HasOne(d => d.Domingo)
                    .WithMany(p => p.DiasDeAtencionDomingos)
                    .HasForeignKey(d => d.DomingoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diasDeAte__idDom__31EC6D26");

                entity.HasOne(d => d.Jueves)
                    .WithMany(p => p.DiasDeAtencionJueves)
                    .HasForeignKey(d => d.JuevesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diasDeAte__idJue__32E0915F");

                entity.HasOne(d => d.Lunes)
                    .WithMany(p => p.DiasDeAtencionLunes)
                    .HasForeignKey(d => d.LunesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diasDeAte__idLun__33D4B598");

                entity.HasOne(d => d.Martes)
                    .WithMany(p => p.DiasDeAtencionMartes)
                    .HasForeignKey(d => d.MartesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diasDeAte__idMar__34C8D9D1");

                entity.HasOne(d => d.Miercoles)
                    .WithMany(p => p.DiasDeAtencionMiercoles)
                    .HasForeignKey(d => d.MiercolesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diasDeAte__idMie__35BCFE0A");

                entity.HasOne(d => d.Sabado)
                    .WithMany(p => p.DiasDeAtencionSabados)
                    .HasForeignKey(d => d.SabadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diasDeAte__idSab__36B12243");

                entity.HasOne(d => d.Viernes)
                    .WithMany(p => p.DiasDeAtencionViernes)
                    .HasForeignKey(d => d.ViernesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diasDeAte__idVie__37A5467C");
            });

            modelBuilder.Entity<EspecialidadesCentro>(entity =>
            {
                entity.HasKey(e => e.EspecialidadId)
                    .HasName("PK__especial__3213E83FD8EB4316");

                entity.ToTable("especialidadesCentro");

                entity.Property(e => e.EspecialidadId).HasColumnName("EspecialidadID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<EspecialidadesProfesional>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("especialidadesProfesionales");

                entity.Property(e => e.EspecialidadId).HasColumnName("EspecialidadID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ProfesionalId).HasColumnName("ProfesionalID");

                entity.HasOne(d => d.Especialidad)
                    .WithMany()
                    .HasForeignKey(d => d.EspecialidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_especialidadesProfesionales_especialidadesCentro");

                entity.HasOne(d => d.Profesional)
                    .WithMany()
                    .HasForeignKey(d => d.ProfesionalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__especiali__idPro__398D8EEE");
            });

            modelBuilder.Entity<HorarioDeAtencion>(entity =>
            {
                entity.ToTable("horarioDeAtencion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Atiende).HasColumnName("atiende");

                entity.Property(e => e.Desde)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("desde");

                entity.Property(e => e.EsPorDefecto).HasColumnName("esPorDefecto");

                entity.Property(e => e.Hasta)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("hasta");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("pacientes");

                entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("documento");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Nacionalidad).HasColumnName("nacionalidad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroAfiliado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numeroAfiliado");

                entity.Property(e => e.ObraSocial)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("obraSocial");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.TelefonoContacto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefonoContacto");
            });

            modelBuilder.Entity<Profesional>(entity =>
            {
                entity.HasKey(e => e.ProfesionalId)
                    .HasName("PK__profesio__3213E83FD1E933DA");

                entity.ToTable("profesionales");

                entity.Property(e => e.ProfesionalId).HasColumnName("ProfesionalID");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.DiasDeAtencionId).HasColumnName("DiasDeAtencionID");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("documento");


                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("matricula");

                entity.Property(e => e.Nacionalidad).HasColumnName("nacionalidad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.DiasDeAtencion)
                    .WithMany(p => p.Profesionales)
                    .HasForeignKey(d => d.DiasDeAtencionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__profesion__idDia__32E0915F");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.RolId).HasColumnName("RolID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<RolUsuario>(entity => {

                entity.HasKey(bc => new { bc.UsuarioId, bc.RolesId });
                entity.HasOne(bc => bc.Usuario)
                    .WithMany(b => b.RolUsuarios)
                    .HasForeignKey(bc => bc.UsuarioId);

                modelBuilder.Entity<RolUsuario>()
                    .HasOne(bc => bc.Rol)
                    .WithMany(c => c.RolUsuarios)
                    .HasForeignKey(bc => bc.RolesId);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.ToTable("turnos");

                entity.Property(e => e.TurnoId).HasColumnName("TurnoID");

                entity.Property(e => e.EspecialidadId).HasColumnName("EspecialidadID");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.PacienteAsistio).HasColumnName("pacienteAsistio");

                entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

                entity.Property(e => e.ProfesionalId).HasColumnName("ProfesionalID");

                entity.HasOne(d => d.Especialidad)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.EspecialidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__turnos__idEspeci__3B75D760");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.PacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__turnos__idPacien__3C69FB99");

                entity.HasOne(d => d.Profesional)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.ProfesionalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__turnos__idProfes__3D5E1FD2");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuariosId);

                entity.Property(e => e.UsuariosId).HasColumnName("UsuariosID");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreUsuario");

                entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

                entity.Property(e => e.ProfesionalId).HasColumnName("ProfesionalID");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PacienteId)
                    .HasConstraintName("FK_Usuarios_pacientes");

                entity.HasOne(d => d.Profesional)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.ProfesionalId).HasConstraintName("FK_Usuarios_profesionales");
                
                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
