using AutoMapper;
using BolsaEmpleo.Application.Common.Interfaces;
using BolsaEmpleo.Application.DTO.Ciudadanos;
using BolsaEmpleo.Application.Service.Ciudadanos.Interfaces;
using BolsaEmpleo.Domain.Entities;

namespace BolsaEmpleo.Application.Service.Ciudadanos.Implementation;

public class CiudadanoService : ICiudadanoService
{
    private readonly IMapper _mapper;
    private readonly ICiudadanoRepository _ciudadanoRepository;

    public CiudadanoService(ICiudadanoRepository ciudadanoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _ciudadanoRepository = ciudadanoRepository;
    }
    
    public async Task<ResponseCiudadanoDTO> CreateCiudadano(CreateCiudadanoDTO ciudadano)
    {
        var ciudadanoEntity = _mapper.Map<Ciudadano>(ciudadano);
        await _ciudadanoRepository.AddAsync(ciudadanoEntity);
        return _mapper.Map<ResponseCiudadanoDTO>(ciudadanoEntity);
    }
    
    public async Task<CreateCiudadanoDTO> UpdateCiudadano(CreateCiudadanoDTO ciudadano)
    {
        var ciudadanoEntity = _mapper.Map<Ciudadano>(ciudadano);
        await _ciudadanoRepository.UpdateAsync(ciudadanoEntity);
        return _mapper.Map<CreateCiudadanoDTO>(ciudadanoEntity);
    }
    
    public async Task<CreateCiudadanoDTO> DeleteCiudadano(int id)
    {
        var ciudadanoEntity = await _ciudadanoRepository.FindOneAsync(c => c.Id == id);
        ciudadanoEntity.IsDeleted = true;
        await _ciudadanoRepository.UpdateAsync(ciudadanoEntity);
        return _mapper.Map<CreateCiudadanoDTO>(ciudadanoEntity);
    }
    
    public async Task<ResponseCiudadanoDTO> GetCiudadano(int id)
    {
        var ciudadanoEntity = await _ciudadanoRepository.FindOneAsync(c => c.Id == id && !c.IsDeleted, c => c.Vacantes);
        return _mapper.Map<ResponseCiudadanoDTO>(ciudadanoEntity);
    }
    
    public async Task<IEnumerable<ResponseCiudadanoDTO>> GetCiudadanos()
    {
        var ciudadanos = await _ciudadanoRepository.FindAsync(c => c.Id > 0 && !c.IsDeleted);
        return _mapper.Map<IEnumerable<ResponseCiudadanoDTO>>(ciudadanos);
    }
}