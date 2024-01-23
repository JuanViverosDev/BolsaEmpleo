namespace BolsaEmpleo.Application.DTO.Ciudadanos;

public class CreateCiudadanoDTO
{
    public string Nombre { get; set; } = string.Empty;
    public string? Apellido { get; set; } = string.Empty;
    public string TipoDocumento { get; set; } = string.Empty;
    public string NumDocumento { get; set; } = string.Empty;
    public DateTime? FechaNacimiento { get; set; } = DateTime.UtcNow;
    public string? Profesion { get; set; } = string.Empty;
    public float? AspiracionSalarial { get; set; } = 0;
}