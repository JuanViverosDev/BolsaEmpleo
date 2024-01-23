using BolsaEmpleo.Domain.Entities.Base;

namespace BolsaEmpleo.Domain.Entities
{
    public class Ciudadano : DomainObject
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Apellido { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string NumDocumento { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; } = DateTime.UtcNow;
        public string? Profesion { get; set; } = string.Empty;
        public float? AspiracionSalarial { get; set; } = 0;
        public virtual ICollection<Vacante> Vacantes { get; set; } =
            Array.Empty<Vacante>().ToList();
    }
}