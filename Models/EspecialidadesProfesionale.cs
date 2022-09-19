using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class EspecialidadesProfesional
    {
        public int EspecialidadId { get; set; }
        public int ProfesionalId { get; set; }
        public bool IsActive { get; set; }

        public virtual EspecialidadesCentro Especialidad { get; set; }
        public virtual Profesional Profesional { get; set; }
    }
}
