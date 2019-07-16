using GameDrones.Domain;

namespace GameDrones.Data
{
    /// <summary>
    /// Base repository definition that all repositories must inherit.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
    }
}
