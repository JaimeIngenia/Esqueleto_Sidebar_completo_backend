using System;
using System.Collections.Generic;

namespace GardenAppV1.Models
{
    public partial class Jardin
    {
        public Jardin()
        {
            Sensorhumedads = new HashSet<Sensorhumedad>();
            Sensorriegos = new HashSet<Sensorriego>();
            Sensortemperaturas = new HashSet<Sensortemperatura>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdJardin { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? ValorSensor { get; set; }
        public int? SensorId { get; set; }

        public virtual ICollection<Sensorhumedad> Sensorhumedads { get; set; }
        public virtual ICollection<Sensorriego> Sensorriegos { get; set; }
        public virtual ICollection<Sensortemperatura> Sensortemperaturas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
