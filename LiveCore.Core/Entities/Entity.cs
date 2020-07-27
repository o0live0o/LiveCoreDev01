
using LiveCore.Core.interfaces;

namespace LiveCore.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}