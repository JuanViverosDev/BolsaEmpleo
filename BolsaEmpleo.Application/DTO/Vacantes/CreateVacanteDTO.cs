namespace BolsaEmpleo.Application.DTO.Ciudadanos;

public class CreateVacanteDTO
{
    public int? Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public string? Descripcion { get; set; } = string.Empty;
    public string? Empresa { get; set; } = string.Empty;
    public float? Salario { get; set; } = 0;a
}