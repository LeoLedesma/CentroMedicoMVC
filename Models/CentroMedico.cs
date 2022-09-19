using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class CentroMedico
    {
        public int CentroMedicoId { get; set; }
        public string Nombre { get; set; }
        public int DuracionTurno { get; set; }
        public int DiasDeAtencionId { get; set; }

        public virtual DiasDeAtencion DiasDeAtencion { get; set; }
    }
}
