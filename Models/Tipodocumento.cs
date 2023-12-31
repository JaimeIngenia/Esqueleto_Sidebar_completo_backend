using System;
using System.Collections.Generic;

namespace GardenAppV1.Models
{
    public partial class Tipodocumento
    {
        public Tipodocumento()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoDocumento { get; set; }
        public string? TipoDocumento1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
