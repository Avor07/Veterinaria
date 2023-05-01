using System;
using System.Threading.Tasks;
using VeterinariaProject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VeterinariaProject.Repositories.Interfaces;
using VeterinariaProject.Repositories.DTO;
using System.Collections.Generic;
using AutoMapper;

namespace VeterinariaProject.Repositories.Logic
{
    public class VeterinariaLogic:Iveterinaria
    {
        private readonly IMapper _mapper;
        private readonly VeterinariaContext _context;
        public VeterinariaLogic(VeterinariaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<object> ObtenerCitas()
        {
            try
            {
                var datos = await (from C in _context.Cita
                                   select C).ToListAsync();
                return datos;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        


        }
        public async Task<object> ObtenerCitasPorId(int idCita)
        {
            List<CitasV> datos = new List<CitasV>();
            try
            {
                datos = await (from C in _context.Cita.Where(x => x.IdCita == idCita)
                               join M in _context.Mascota on C.IdMascotaFk equals M.IdMascota
                                      select new CitasV
                                      {
                                          IdCita = C.IdCita,
                                          FechaCita=C.FechaCita,
                                          NombreDueño=C.NombreDueño,
                                          IdMascotaFk=C.IdMascotaFk,
                                          NombreMascota=M.Nombre

                                      }).ToListAsync();
                return datos;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        


        }

        public async Task<object> AgregarCita(CitaRequest request)
        {
            try
            {
                // Se mapea el objeto request(Animal) a un objeto de la clase Animales para poder insertar los datos
                var datos = _mapper.Map<Cita>(request);

                //Se insertan los datos y se guardan los cambios
                _context.Cita.Add(datos);
                await _context.SaveChangesAsync();

                //Se consulta el ultimo elemento de la tabla Animales y se extrae el idAnimal
                int idCita = await (from C in _context.Cita.OrderBy(x => x.IdCita)
                                    select C.IdCita).LastAsync();
                return new
                {
                    resultado = true,
                    idCita= idCita,

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        public async Task<object> ActualizarCita(int idCita,CitaRequest request)
        {
            try
            {
                // Se mapea el objeto request(Animal) a un objeto de la clase Animales para poder insertar los datos
                var EntidadDatosActualizados = _mapper.Map<Cita>(request);

                var EntidadActualizar = await _context.Cita.FirstOrDefaultAsync(x => x.IdCita== idCita);
                if (EntidadActualizar != null)
                {
                    EntidadActualizar.NombreDueño= EntidadDatosActualizados.NombreDueño;
                    EntidadActualizar.FechaCita = EntidadDatosActualizados.FechaCita;
                    EntidadActualizar.IdMascotaFk = EntidadDatosActualizados.IdMascotaFk;

                    _context.Cita.Update(EntidadActualizar).Property(x => x.IdCita).IsModified = false;
                    await _context.SaveChangesAsync();
                }

                //Se consulta el ultimo elemento de la tabla Animales y se extrae el idAnimal
                var cita = await (from C in _context.Cita.Where(x => x.IdCita == idCita)
                                    select new
                                    {
                                        idCita= C.IdCita,
                                        nombreDueño = C.NombreDueño,
                                        fecha = C.FechaCita,
                                        mascota = C.IdMascotaFk,
                                      
                                    }).ToListAsync();

                return new { resultado = "Datos actualizados correctamente", Cita = cita};
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }


    }
}
