using BolsaEmpleo.Application.Common.Interfaces;
using BolsaEmpleo.Application.DTO.Ciudadanos;
using BolsaEmpleo.Application.Service.Ciudadanos.Interfaces;
using BolsaEmpleo.Domain.Entities;

namespace BolsaEmpleo.Application.Service.Ciudadanos.Implementation;

public class CiudadanoService : ICiudadanoService
{
    private readonly ICiudadanoRepository _ciudadanoRepository;

    public CiudadanoService(ICiudadanoRepository ciudadanoRepository)
    {
        _ciudadanoRepository = ciudadanoRepository;
    }

    public async Task<CreateCiudadanoDTO> CreateCiudadano(CreateCiudadanoDTO ciudadano)
    {
        var ciudadanoEntity = new Ciudadano()
        {
            Nombre = ciudadano.Nombre,
            Apellido = ciudadano.Apellido,
            TipoDocumento = ciudadano.TipoDocumento,
            NumDocumento = ciudadano.NumDocumento,
            FechaNacimiento = ciudadano.FechaNacimiento,
            Profesion = ciudadano.Profesion,
            AspiracionSalarial = ciudadano.AspiracionSalarial
        };

        var ciudadanoCreated = await _ciudadanoRepository.AddAsync(ciudadanoEntity);

        var ciudadanoCreatedDTO = new CreateCiudadanoDTO
        {
            Nombre = ciudadanoCreated.Nombre,
            Apellido = ciudadanoCreated.Apellido,
            TipoDocumento = ciudadanoCreated.TipoDocumento,
            NumDocumento = ciudadanoCreated.NumDocumento,
            FechaNacimiento = ciudadanoCreated.FechaNacimiento,
            Profesion = ciudadanoCreated.Profesion,
            AspiracionSalarial = ciudadanoCreated.AspiracionSalarial
        };

        return ciudadanoCreatedDTO;
    }

    // public async Task<CreateCiudadanoDTO> UpdateCiudadano(CreateCiudadanoDTO ciudadano)
    // {
    //     var ciudadanoEntity = new Ciudadano
    //     {
    //         Nombre = ciudadano.Nombre,
    //         Apellido = ciudadano.Apellido,
    //         TipoDocumento = ciudadano.TipoDocumento,
    //         NumDocumento = ciudadano.NumDocumento,
    //         FechaNacimiento = ciudadano.FechaNacimiento,
    //         Profesion = ciudadano.Profesion,
    //         AspiracionSalarial = ciudadano.AspiracionSalarial
    //     };
    //     
    //     var ciudadanoUpdated = await _ciudadanoRepository.UpdateAsync(ciudadanoEntity);
    //
    //     var ciudadanoUpdatedDTO = new CreateCiudadanoDTO
    //     {
    //         Nombre = ciudadanoUpdated.Nombre,
    //         Apellido = ciudadanoUpdated.Apellido,
    //         TipoDocumento = ciudadanoUpdated.TipoDocumento,
    //         NumDocumento = ciudadanoUpdated.NumDocumento,
    //         FechaNacimiento = ciudadanoUpdated.FechaNacimiento,
    //         Profesion = ciudadanoUpdated.Profesion,
    //         AspiracionSalarial = ciudad
    //     };
    //
    //     return ciudadanoUpdatedDTO;
    // }

    // public async Task<CreateCiudadanoDTO> DeleteCiudadano(int id)
    // {
    //     
    //     var ciudadanoToDelete = await _ciudadanoRepository.FindAsync(id);
    //
    //     var ciudadanoDeletedDTO = new CreateCiudadanoDTO
    //     {
    //         Nombre = ciudadanoDeleted.Nombre,
    //         Apellido = ciudadanoDeleted.Apellido,
    //         TipoDocumento = ciudadanoDeleted.TipoDocumento,
    //         NumDocumento = ciudadanoDeleted.NumDocumento,
    //         FechaNacimiento = ciudadanoDeleted.FechaNacimiento,
    //         Profesion = ciudadanoDeleted.Profesion,
    //         AspiracionSalarial = ciudadanoDeleted.AspiracionSalarial
    //     };
    //
    //     return ciudadanoDeletedDTO;
    // }

    public async Task<CreateCiudadanoDTO> GetCiudadano(int id)
    {
        var ciudadano = await _ciudadanoRepository.FindAsync(id);

        var ciudadanoDTO = new CreateCiudadanoDTO
        {
            Nombre = ciudadano.Nombre,
            Apellido = ciudadano.Apellido,
            TipoDocumento = ciudadano.TipoDocumento,
            NumDocumento = ciudadano.NumDocumento,
            FechaNacimiento = ciudadano.FechaNacimiento,
            Profesion = ciudadano.Profesion,
            AspiracionSalarial = ciudadano.AspiracionSalarial
        };

        return ciudadanoDTO;
    }

    public async Task<IEnumerable<ResponseCiudadanoDTO>> GetCiudadanos()
    {
        var ciudadanos = await _ciudadanoRepository.FindAsync(ciudadano => !ciudadano.IsDeleted);

        var ciudadanosDTO = ciudadanos.Select(ciudadano => new ResponseCiudadanoDTO
        {
            Nombre = ciudadano.Nombre,
            Apellido = ciudadano.Apellido,
            TipoDocumento = ciudadano.TipoDocumento,
            NumDocumento = ciudadano.NumDocumento,
            FechaNacimiento = ciudadano.FechaNacimiento,
            Profesion = ciudadano.Profesion,
            AspiracionSalarial = ciudadano.AspiracionSalarial
        });

        return ciudadanosDTO;
    }
}