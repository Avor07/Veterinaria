using System;

namespace VeterinariaProject.Repositories.DTO
{
    public class CitasV
    {
        public int IdCita { get; set; }
        public DateTime? FechaCita { get; set; }
        public string NombreDueño { get; set; }
        public int? IdMascotaFk { get; set; }
        public String NombreMascota { get; set; }
    }
}
