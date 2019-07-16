using System.Linq;
using GameDrones.Domain;

namespace GameDrones.Data
{
    /// <summary>
    /// Base interface for seeking entities.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity</typeparam>
    public interface IRead<out TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Access to all entities and the posibility to make custom queries.
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        /// <summary>
        /// Gets an entity by its ID.
        /// </summary>
        /// <param name="entityId">The entity ID</param>
        /// <returns>The entity with the specified ID if it is found; null otherwise</returns>
        TEntity GetById(int entityId);
    }
}
