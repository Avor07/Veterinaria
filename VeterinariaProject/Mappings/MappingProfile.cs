using AutoMapper;
using VeterinariaProject.Models;
using VeterinariaProject.Repositories.DTO;

namespace VeterinariaProject.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<CitasV, Cita>();
            CreateMap<Cita, CitasV>();

            CreateMap<CitaRequest,Cita>();
            CreateMap<Cita,CitaRequest>();
        }
    }
}
