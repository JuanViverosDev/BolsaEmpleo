using AutoMapper;
using BolsaEmpleo.Application.Common.Interfaces;
using BolsaEmpleo.Application.DTO.Vacantes;
using BolsaEmpleo.Application.Service.Vacantes.Interfaces;
using BolsaEmpleo.Domain.Entities;

namespace BolsaEmpleo.Application.Service.Vacantes.Implementation;

public class VacanteService : IVacanteService
{
    private readonly IMapper _mapper;
    private readonly ICiudadanoRepository _ciudadanoRepository;
    private readonly IVacanteRepository _vacanteRepository;

    public VacanteService(ICiudadanoRepository ciudadanoRepository, IMapper mapper,
        IVacanteRepository vacanteRepository)
    {
        _ciudadanoRepository = ciudadanoRepository;
        _vacanteRepository = vacanteRepository;
        _mapper = mapper;
    }

    public async Task<ResponseVacanteDTO> CreateVacante(CreateVacanteDTO vacante)
    {
        var vacanteEntity = _mapper.Map<Vacante>(vacante);
        await _vacanteRepository.AddAsync(vacanteEntity);
        return _mapper.Map<ResponseVacanteDTO>(vacanteEntity);
    }

    public async Task<ResponseVacanteDTO> UpdateVacante(CreateVacanteDTO vacante)
    {
        var vacanteEntity = _mapper.Map<Vacante>(vacante);
        await _vacanteRepository.UpdateAsync(vacanteEntity);
        return _mapper.Map<ResponseVacanteDTO>(vacanteEntity);
    }

    public async Task<ResponseVacanteDTO> DeleteVacante(int id)
    {
        var vacanteEntity = await _vacanteRepository.FindOneAsync(v => v.Id == id);
        vacanteEntity.IsDeleted = true;
        await _vacanteRepository.UpdateAsync(vacanteEntity);
        return _mapper.Map<ResponseVacanteDTO>(vacanteEntity);
    }

    public async Task<ResponseVacanteDTO> GetVacante(CreateVacanteDTO vacante)
    {
        var vacanteEntity = _mapper.Map<Vacante>(vacante);
        var vacanteResult = await _vacanteRepository.FindOneAsync(v => v.Id == vacanteEntity.Id && !v.IsDeleted,
            v => v.Ciudadanos);
        return _mapper.Map<ResponseVacanteDTO>(vacanteResult);
    }

    public async Task<IEnumerable<ResponseVacanteDTO>> GetVacantes()
    {
        var vacantes = await _vacanteRepository.FindAsync(v => v.Id > 0 && !v.IsDeleted);
        return _mapper.Map<IEnumerable<ResponseVacanteDTO>>(vacantes);
    }

    public async Task<bool> AplicarVacante(int idCiudadano, int idVacante)
    {
        var ciudadano = await _ciudadanoRepository.FindOneAsync(c => c.Id == idCiudadano);
        var vacante = await _vacanteRepository.FindOneAsync(v => v.Id == idVacante);
        if (ciudadano == null || vacante == null) return false;
        vacante.Ciudadanos.Add(ciudadano);
        await _vacanteRepository.UpdateAsync(vacante);
        return true;
    }

    public async Task<bool> DesertarVacante(int idCiudadano, int idVacante)
    {
        var ciudadano = await _ciudadanoRepository.FindOneAsync(c => c.Id == idCiudadano);
        var vacante = await _vacanteRepository.FindOneAsync(v => v.Id == idVacante, v => v.Ciudadanos);
        if (ciudadano == null || vacante == null) return false;
        vacante.Ciudadanos.Remove(ciudadano);
        await _vacanteRepository.UpdateAsync(vacante);
        await _ciudadanoRepository.UpdateAsync(ciudadano);
        return true;
    }
}