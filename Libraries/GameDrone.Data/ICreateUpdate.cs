using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameDrones.Domain;

namespace GameDrones.Data
{
    /// <summary>
    /// Base interface for creating and updating entities.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity</typeparam>
    public interface ICreateUpdate<in TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Saves a new entity.
        /// </summary>
        /// <param name="entity">The entity to save</param>
        /// <exception cref="ArgumentNullException">If the <paramref name="entity"/> is null</exception>
        void Save(TEntity entity);

        /// <summary>
        /// Saves a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to save</param>
        /// <exception cref="ArgumentNullException">If the <paramref name="entity"/> is null</exception>
        Task SaveAsync(TEntity entity);

        /// <summary>
        /// Save all new entities.
        /// </summary>
        /// <param name="entities">The entities to be saved</param>
        /// <exception cref="ArgumentNullException">If the provided list of <paramref name="entities"/> is <c>null</c></exception>
        void SaveAll(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <exception cref="ArgumentNullException">If the <paramref name="entity"/> is null</exception>
        void Update(TEntity entity);
    }
}
