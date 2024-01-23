using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaEmpleo.Domain.Entities.Base;

public abstract class DomainObject : DomainBaseObject
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public override bool Equals(object obj)
    {
        var item = obj as DomainObject;
        if (item == null)
        {
            return false;
        }
        return this.Id.Equals(item.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}