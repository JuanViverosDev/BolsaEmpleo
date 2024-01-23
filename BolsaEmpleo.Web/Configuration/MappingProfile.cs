using AutoMapper;
using BolsaEmpleo.Application.DTO.Ciudadanos;
using BolsaEmpleo.Domain.Entities;

namespace BolsaEmpleo.Web.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCiudadanoDTO, Ciudadano>().ReverseMap();
        CreateMap<Ciudadano, ResponseCiudadanoDTO>().ReverseMap();
    }
}