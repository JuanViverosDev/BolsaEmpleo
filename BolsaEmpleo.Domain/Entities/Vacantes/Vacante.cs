using BolsaEmpleo.Domain.Entities.Base;

namespace BolsaEmpleo.Domain.Entities
{
    public class Vacante : DomainObject
    {
        public string Codigo { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string? Descripcion { get; set; } = string.Empty;
        public string? Empresa { get; set; } = string.Empty;
        public float? Salario { get; set; } = 0;
        public virtual ICollection<Ciudadano> Ciudadanos { get; set; } =
            Array.Empty<Ciudadano>().ToList();
    }
}