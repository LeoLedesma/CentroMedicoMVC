using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class HorarioDeAtencion
    {
        public HorarioDeAtencion()
        {
            DiasDeAtencionDomingos = new HashSet<DiasDeAtencion>();
            DiasDeAtencionJueves = new HashSet<DiasDeAtencion>();
            DiasDeAtencionLunes = new HashSet<DiasDeAtencion>();
            DiasDeAtencionMartes = new HashSet<DiasDeAtencion>();
            DiasDeAtencionMiercoles = new HashSet<DiasDeAtencion>();
            DiasDeAtencionSabados = new HashSet<DiasDeAtencion>();
            DiasDeAtencionViernes = new HashSet<DiasDeAtencion>();
        }

        public int Id { get; set; }
        public bool Atiende { get; set; }
        public bool EsPorDefecto { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }

        public virtual ICollection<DiasDeAtencion> DiasDeAtencionDomingos { get; set; }
        public virtual ICollection<DiasDeAtencion> DiasDeAtencionJueves { get; set; }
        public virtual ICollection<DiasDeAtencion> DiasDeAtencionLunes { get; set; }
        public virtual ICollection<DiasDeAtencion> DiasDeAtencionMartes { get; set; }
        public virtual ICollection<DiasDeAtencion> DiasDeAtencionMiercoles { get; set; }
        public virtual ICollection<DiasDeAtencion> DiasDeAtencionSabados { get; set; }
        public virtual ICollection<DiasDeAtencion> DiasDeAtencionViernes { get; set; }
    }
}
