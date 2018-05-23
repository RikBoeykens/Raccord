using System;

namespace Raccord.Domain.Model
{
    /// Abstract base entity
    public abstract class Entity<T>
    {
        /// ID of the abstract entity
        public T ID { get; set; }
    }
}
