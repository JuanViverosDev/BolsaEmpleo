using BolsaEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BolsaEmpleo.Infrastructure.Context
{
    public class BolsaEmpleoDbContext : DbContext
    {
        #region Ciudadanos Domain
        
        public DbSet<Ciudadano> Ciudadanos { get; set; }
        
        #endregion Ciudadanos Domain

        #region Vacantes Domain
        
        public DbSet<Vacante> Vacantes { get; set; }
        
        #endregion Vacantes Domain

        public BolsaEmpleoDbContext()
        {
        }

        public BolsaEmpleoDbContext(DbContextOptions<BolsaEmpleoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            base.OnModelCreating(modelBuilder);
        }
    }
}