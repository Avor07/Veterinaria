using System;
using System.Collections.Generic;

#nullable disable

namespace VeterinariaProject.Models
{
    public partial class Cita
    {
        public int IdCita { get; set; }
        public DateTime? FechaCita { get; set; }
        public string NombreDueño { get; set; }
        public int? IdMascotaFk { get; set; }

        public virtual Mascota IdMascotaFkNavigation { get; set; }
    }
}
