using System;
using System.Collections.Generic;

namespace CentroMedico___Proyecto_Final.Models
{
    public partial class RolUsuario
    {
        public int UsuarioId { get; set; }
        public int RolesId { get; set; }

        public Rol Rol { get; set; }
        public Usuario Usuario { get; set; }

        
    }
}
