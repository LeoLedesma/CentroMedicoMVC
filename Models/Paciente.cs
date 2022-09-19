using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Turnos = new HashSet<Turno>();
            Usuarios = new HashSet<Usuario>();
        }

        public int PacienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Genero { get; set; }
        public int Nacionalidad { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string TelefonoContacto { get; set; }
        public string ObraSocial { get; set; }
        public string NumeroAfiliado { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
