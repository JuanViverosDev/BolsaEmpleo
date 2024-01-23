using BolsaEmpleo.Application.Base;
using BolsaEmpleo.Application.Common.Interfaces;
using BolsaEmpleo.Domain.Entities;
using BolsaEmpleo.Infrastructure.Context;

namespace BolsaEmpleo.Infrastructure.Persistence.Auth
{
    public class CiudadanoRepository : RepositoryBase<Ciudadano, BolsaEmpleoDbContext>, ICiudadanoRepository
    {
        public CiudadanoRepository(BolsaEmpleoDbContext db) : base(db)
        {
        }
    }
}