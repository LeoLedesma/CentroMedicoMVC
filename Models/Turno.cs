using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class Turno
    {
        public int TurnoId { get; set; }
        public DateTime Fecha { get; set; }
        public int PacienteId { get; set; }
        public int ProfesionalId { get; set; }
        public int EspecialidadId { get; set; }
        public bool PacienteAsistio { get; set; }

        public virtual EspecialidadesCentro Especialidad { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Profesional Profesional { get; set; }
    }
}
