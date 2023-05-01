using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeterinariaProject.Repositories.DTO;
using VeterinariaProject.Repositories.Interfaces;

namespace VeterinariaProject.Controllers
{
    [Route("api/[controller]")] //Enrutamiento prefijo nombre del  controlador
    [ApiController] // 
    public class VeterinariaController : ControllerBase
    {
        private readonly Iveterinaria _veterinaria;
        public VeterinariaController(Iveterinaria veterinaria)
        {
            _veterinaria = veterinaria;
        }

        [HttpGet("api/Veterinaria/ObtenerCitas")]
        public async Task<ActionResult<RespuestaGenerica>> ObtenerCitas() 
        {
            try 
            {

                var datos = await _veterinaria.ObtenerCitas();
                return new RespuestaGenerica
                {

                    data = datos,
                    status = 200,
                    title = "OK ",
                    codRespuesta = "01"

                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica 
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codRespuesta = "01"

                }
                );
            }


        }

        [HttpGet("api/Veterinaria/ObtenerCitasPorId/{idCita}")]
        public async Task<ActionResult<RespuestaGenerica>> ObtenerCitasPorId(int idCita)
        {
            try
            {

                var datos = await _veterinaria.ObtenerCitasPorId(idCita);
                return new RespuestaGenerica
                {

                    data = datos,
                    status = 200,
                    title = "OK ",
                    codRespuesta = "01"

                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codRespuesta = "01"

                }
                );
            }


        }

        [HttpPost("api/Veterinaria/AgregarCita")]
        public async Task<ActionResult<RespuestaGenerica>> AgregarCita(CitaRequest request)
        {
            try
            {

                var datos = await _veterinaria.AgregarCita(request);
                return new RespuestaGenerica
                {

                    data = datos,
                    status = 200,
                    title = "OK ",
                    codRespuesta = "01"

                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codRespuesta = "01"

                }
                );
            }


        }

       [HttpPut("api/Veterinaria/ActualizarCita/{idCita}")]
        public async Task<ActionResult<RespuestaGenerica>> ActualizarCita(int idCita,CitaRequest request)
        {
            try
            {

                var datos = await _veterinaria.ActualizarCita(idCita,request);
                return new RespuestaGenerica
                {

                    data = datos,
                    status = 200,
                    title = "OK ",
                    codRespuesta = "01"

                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codRespuesta = "01"

                }
                );
            }


        }



    }
}
