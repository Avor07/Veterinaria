using System;
using System.Collections.Generic;

#nullable disable

namespace VeterinariaProject.Models
{
    public partial class Mascota
    {
        public Mascota()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdMascota { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
