using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class EspecialidadesCentro
    {
        public EspecialidadesCentro()
        {
            Turnos = new HashSet<Turno>();
        }

        public int EspecialidadId { get; set; }
        public string Nombre { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
