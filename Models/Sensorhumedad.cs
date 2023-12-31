using System;
using System.Collections.Generic;

namespace GardenAppV1.Models
{
    public partial class Sensorhumedad
    {
        public int IdHumedad { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? ValorHumedad { get; set; }
        public int? IdJardin { get; set; }

        public virtual Jardin? oJardin { get; set; }
    }
}
