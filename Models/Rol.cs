using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class Rol
    {
        public Rol()
        {   
        }

        public int RolId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
