using System;

namespace GameDrones.Domain
{
    /// <summary>
    /// Base definition for an entity.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the entity ID.
        /// </summary>
        int Id { get; set; }
    }
}
