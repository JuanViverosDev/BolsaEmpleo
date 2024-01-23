using BolsaEmpleo.Application.DTO.Ciudadanos;
using BolsaEmpleo.Application.DTO.Vacantes;
using BolsaEmpleo.Application.Service.Ciudadanos.Interfaces;
using BolsaEmpleo.Application.Service.Vacantes.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BolsaEmpleo.Web.Controllers.Vacantes
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacantesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVacanteService _vacanteService;

        public VacantesController(
            IVacanteService vacanteService,
            IHttpContextAccessor httpContextAccessor)
        {
            _vacanteService = vacanteService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> CrearVacante(CreateVacanteDTO vacante)
        {
            try
            {
                var response = await _vacanteService.CreateVacante(vacante);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarVacante(CreateVacanteDTO vacante)
        {
            try
            {
                var response = await _vacanteService.UpdateVacante(vacante);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarVacante(int id)
        {
            try
            {
                var response = await _vacanteService.DeleteVacante(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerVacante(CreateVacanteDTO vacante)
        {
            try
            {
                var response = await _vacanteService.GetVacante(vacante);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetVacantes()
        {
            try
            {
                var response = await _vacanteService.GetVacantes();
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("aplicar/{idCiudadano}/{idVacante}")]
        public async Task<IActionResult> AplicarVacante(int idCiudadano, int idVacante)
        {
            try
            {
                var response = await _vacanteService.AplicarVacante(idCiudadano, idVacante);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("desertar/{idCiudadano}/{idVacante}")]
        public async Task<IActionResult> DesertarVacante(int idCiudadano, int idVacante)
        {
            try
            {
                var response = await _vacanteService.DesertarVacante(idCiudadano, idVacante);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}