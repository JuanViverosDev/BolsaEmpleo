using BolsaEmpleo.Application.Base;
using BolsaEmpleo.Application.Common.Interfaces;
using BolsaEmpleo.Domain.Entities;
using BolsaEmpleo.Infrastructure.Context;

namespace BolsaEmpleo.Infrastructure.Persistence.Auth
{
    public class VacanteRepository : RepositoryBase<Vacante, BolsaEmpleoDbContext>, IVacanteRepository
    {
        public VacanteRepository(BolsaEmpleoDbContext db) : base(db)
        {
        }
    }
}