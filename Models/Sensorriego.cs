using System;
using System.Collections.Generic;

namespace GardenAppV1.Models
{
    public partial class Sensorriego
    {
        public int IdRiego { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? FinalicedAt { get; set; }
        public int? ValorEncendido { get; set; }
        public int? ValorApagado { get; set; }
        public int? TiempoRiego { get; set; }
        public int? IdJardin { get; set; }

        public virtual Jardin? oJardin { get; set; }
    }
}
