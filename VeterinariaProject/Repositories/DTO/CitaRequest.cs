using System;

namespace VeterinariaProject.Repositories.DTO
{
    public class CitaRequest
    {
       
        public DateTime? FechaCita { get; set; }
        public string NombreDueño { get; set; }
        public int? IdMascotaFk { get; set; }
    }
    
}
