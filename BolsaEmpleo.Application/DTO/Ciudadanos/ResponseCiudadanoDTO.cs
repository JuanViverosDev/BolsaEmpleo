using BolsaEmpleo.Domain.Entities;

namespace BolsaEmpleo.Application.DTO.Ciudadanos;

public class ResponseCiudadanoDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Apellido { get; set; } = string.Empty;
    public string TipoDocumento { get; set; } = string.Empty;
    public string NumDocumento { get; set; } = string.Empty;
    public DateTime? FechaNacimiento { get; set; } = DateTime.UtcNow;
    public string? Profesion { get; set; } = string.Empty;
    public float? AspiracionSalarial { get; set; } = 0;
    public IEnumerable<Vacante>? Vacantes { get; set; } = Array.Empty<Vacante>().ToList();
}