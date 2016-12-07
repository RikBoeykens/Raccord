using System;

namespace Raccord.Domain.Model
{
    /// Abstract base entity
    public abstract class Entity
    {
        /// ID of the abstract entity
        public long ID { get; set; }
    }
}
