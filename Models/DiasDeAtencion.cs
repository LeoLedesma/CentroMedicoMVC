using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class DiasDeAtencion
    {
        public DiasDeAtencion()
        {
            CentroMedicos = new HashSet<CentroMedico>();
            Profesionales = new HashSet<Profesional>();
        }

        public int DiasDeAtencionId { get; set; }
        public int LunesId { get; set; }
        public int MartesId { get; set; }
        public int MiercolesId { get; set; }
        public int JuevesId { get; set; }
        public int ViernesId { get; set; }
        public int SabadoId { get; set; }
        public int DomingoId { get; set; }

        public virtual HorarioDeAtencion Domingo { get; set; }
        public virtual HorarioDeAtencion Jueves { get; set; }
        public virtual HorarioDeAtencion Lunes { get; set; }
        public virtual HorarioDeAtencion Martes { get; set; }
        public virtual HorarioDeAtencion Miercoles { get; set; }
        public virtual HorarioDeAtencion Sabado { get; set; }
        public virtual HorarioDeAtencion Viernes { get; set; }
        public virtual ICollection<CentroMedico> CentroMedicos { get; set; }
        public virtual ICollection<Profesional> Profesionales { get; set; }
    }
}
