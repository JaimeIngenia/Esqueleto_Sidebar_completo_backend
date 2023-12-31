using System;
using System.Collections.Generic;

namespace GardenAppV1.Models
{
    public partial class Sensortemperatura
    {
        public int IdTemperatura { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? ValorTemperatura { get; set; }
        public int? IdJardin { get; set; }

        public virtual Jardin? oJardin { get; set; }
    }
}
