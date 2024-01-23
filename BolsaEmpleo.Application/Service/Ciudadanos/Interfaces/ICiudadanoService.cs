using BolsaEmpleo.Application.DTO.Ciudadanos;

namespace BolsaEmpleo.Application.Service.Ciudadanos.Interfaces;

public interface ICiudadanoService
{
    public Task<ResponseCiudadanoDTO> CreateCiudadano(CreateCiudadanoDTO ciudadano);

    public Task<CreateCiudadanoDTO> UpdateCiudadano(CreateCiudadanoDTO ciudadano);
    
    public Task<CreateCiudadanoDTO> DeleteCiudadano(int id);

    public Task<ResponseCiudadanoDTO> GetCiudadano(int id);

    public Task<IEnumerable<ResponseCiudadanoDTO>> GetCiudadanos();
}