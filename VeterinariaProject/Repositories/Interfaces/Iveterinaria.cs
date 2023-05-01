using System.Threading.Tasks;
using VeterinariaProject.Repositories.DTO;

namespace VeterinariaProject.Repositories.Interfaces
{
    public interface Iveterinaria
    {
        Task <object>ActualizarCita(int idCita, CitaRequest request);
        Task <object>AgregarCita(CitaRequest request);
        Task<object> ObtenerCitas();
        Task<object> ObtenerCitasPorId(int idCita);
    }
}
