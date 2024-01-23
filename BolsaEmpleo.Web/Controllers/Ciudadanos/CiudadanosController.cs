using BolsaEmpleo.Application.DTO.Ciudadanos;
using BolsaEmpleo.Application.Service.Ciudadanos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BolsaEmpleo.Web.Controllers.Ciudadanos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadanosController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICiudadanoService _ciudadanoService;

        public CiudadanosController(
            ICiudadanoService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _ciudadanoService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCiudadano(CreateCiudadanoDTO ciudadano)
        {
            var response = await _ciudadanoService.CreateCiudadano(ciudadano);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCiudadano(CreateCiudadanoDTO ciudadano)
        {
            var response = await _ciudadanoService.UpdateCiudadano(ciudadano);
            return Ok(response);
        }
        
        [HttpDelete]
        public async Task<IActionResult> EliminarCiudadano(int id)
        {
            var response = await _ciudadanoService.DeleteCiudadano(id);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCiudadano(int id)
        {
            var response = await _ciudadanoService.GetCiudadano(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCiudadanos()
        {
            var response = await _ciudadanoService.GetCiudadanos();
            return Ok(response);
        }
    }
}