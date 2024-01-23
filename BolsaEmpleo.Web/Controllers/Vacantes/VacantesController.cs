using BolsaEmpleo.Application.DTO.Ciudadanos;
using BolsaEmpleo.Application.Service.Ciudadanos.Interfaces;
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
            var response = await _vacanteService.CreateVacante(vacante);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> ActualizarVacante(CreateVacanteDTO vacante)
        {
            var response = await _vacanteService.UpdateVacante(vacante);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarVacante(int id)
        {
            var response = await _vacanteService.DeleteVacante(id);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerVacante(CreateVacanteDTO vacante)
        {
            var response = await _vacanteService.GetVacante(vacante);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetVacantes()
        {
            var response = await _vacanteService.GetVacantes();
            return Ok(response);
        }
    }
}