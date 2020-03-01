using System.ComponentModel.DataAnnotations;

namespace Dort.Entity
{
    public interface IBaseEntity<IdType>
    {
        IdType Id { get; set; }
    }
}
