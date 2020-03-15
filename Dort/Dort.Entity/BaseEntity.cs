using Dort.Entity.Attributes;

namespace Dort.Entity
{
    public interface IBaseEntity<IdType>
    {
        [DapperKey]
        IdType Id { get; set; }
    }
}
