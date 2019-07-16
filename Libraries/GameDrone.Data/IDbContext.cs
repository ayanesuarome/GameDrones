using System;
using System.Threading.Tasks;
using GameDrones.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameDrones.Data
{
    /// <summary>
    /// DbContext definition. For further information <see cref="DbContext"/> class.
    /// </summary>
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Provides access to database related information and operations for this context.
        /// </summary>
        DatabaseFacade Database { get; }

        /// <summary>
        /// Returns a Microsoft.EntityFrameworkCore.DbSet instance for access to entities of the given
        ///  type in the context and the underlying store.
        /// </summary>
        /// <typeparam name="TEntity">The type entity for which a set should be returned</typeparam>
        /// <returns>A set for the given entity type</returns>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class, IEntity;

        /// <summary>
        /// Gets a System.Data.Entity.Infrastructure.DbEntityEntry object for the given
        /// entity providing access to information about the entity and the ability to perform
        /// actions on the entity.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The type of the entity</returns>
        EntityEntry Entry(object entity);

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database.
        /// This can include state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign 
        /// key property included in the entity class (often referred to as independent associations)
        /// </returns>
        int SaveChanges();

        /// <summary>
        /// Saves all changes made in this context to the underlying database asynchronously.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database.
        /// This can include state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign 
        /// key property included in the entity class (often referred to as independent associations)
        /// </returns>
        Task<int> SaveChangesAsync();
    }
}
