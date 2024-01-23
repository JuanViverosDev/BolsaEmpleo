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
        }
        
        [HttpPost]
        public async Task<IActionResult> CrearCiudadano()
        {
            var response =  _ciudadanoService.GetUsers();
            return Ok(response);
        }
    }
}