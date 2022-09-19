using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class Profesional
    {
        public Profesional()
        {
            Turnos = new HashSet<Turno>();
            Usuarios = new HashSet<Usuario>();
        }

        public int ProfesionalId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Genero { get; set; }
        public int Nacionalidad { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Matricula { get; set; }
        public int DiasDeAtencionId { get; set; }
        public bool IsActive { get; set; }

        public virtual DiasDeAtencion DiasDeAtencion { get; set; }
        public virtual ICollection<Turno> Turnos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
