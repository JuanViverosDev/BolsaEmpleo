using BolsaEmpleo.Application.DTO.Ciudadanos;
using BolsaEmpleo.Application.DTO.Vacantes;

namespace BolsaEmpleo.Application.Service.Vacantes.Interfaces;

public interface IVacanteService
{
    Task<ResponseVacanteDTO> CreateVacante(CreateVacanteDTO vacante);
    Task<ResponseVacanteDTO> UpdateVacante(CreateVacanteDTO vacante);
    Task<ResponseVacanteDTO> DeleteVacante(int id);
    Task<ResponseVacanteDTO> GetVacante(CreateVacanteDTO vacante);
    Task<IEnumerable<ResponseVacanteDTO>> GetVacantes();
    Task<bool> AplicarVacante(int idCiudadano, int idVacante);
    Task<bool> DesertarVacante(int idCiudadano, int idVacante);
}