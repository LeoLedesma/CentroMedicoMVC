using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            RolUsuarios = new HashSet<RolUsuario>();
        }

        public int UsuariosId { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Email { get; set; }
        public int? PacienteId { get; set; }
        public int? ProfesionalId { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Profesional Profesional { get; set; }
        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
