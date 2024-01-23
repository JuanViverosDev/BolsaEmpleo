namespace BolsaEmpleo.Domain.Entities.Base;

public class DomainBaseObject
{
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Modified { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public string? CreatedBy { get; set; }
}