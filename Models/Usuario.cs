using System;
using System.Collections.Generic;

namespace GardenAppV1.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public int? IdTipoRoles { get; set; }
        public int? IdJardin { get; set; }

        public virtual Jardin? IdJardinNavigation { get; set; }
        public virtual Tipodocumento? IdTipoDocumentoNavigation { get; set; }
        public virtual Tiporole? IdTipoRolesNavigation { get; set; }
    }
}
