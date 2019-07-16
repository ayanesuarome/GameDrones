using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDrones.Core;
using GameDrones.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameDrones.Data
{
    /// <summary>
    /// Base repository implementation that all repositories must inherit.
    /// </summary>
    public abstract class Repository<TEntity>
        : ICreateUpdate<TEntity>, IRead<TEntity>, IRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region Fields

        protected readonly IDbContext DbContext;
        private readonly ILogger _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new inctance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">Object context instance</param>
        /// <param name="logger">Logger instance</param>
        protected Repository(IDbContext dbContext, ILogger logger)
        {
            DbContext = dbContext;
            _logger = logger;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public virtual void Save(TEntity entity)
        {
            _logger.LogInformation($"Start inserting entity {entity.GetType()}");
            Validate.IsNotNull(entity, nameof(entity));
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
            _logger.LogInformation($"End inserting entity {entity.GetType()}");
        }

        public virtual async Task SaveAsync(TEntity entity)
        {
            _logger.LogInformation($"Start inserting entity {entity.GetType()}");
            Validate.IsNotNull(entity, nameof(entity));
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();
            _logger.LogInformation($"End inserting entity {entity.GetType()}");
        }

        /// <inheritdoc />
        public virtual void SaveAll(IEnumerable<TEntity> entities)
        {
            Validate.IsNotNull(entities, nameof(entities));
            foreach (var entity in entities)
            {
                Save(entity);
            }
        }

        /// <inheritdoc />
        public virtual void Update(TEntity entity)
        {
            _logger.LogInformation($"Start updating entity {entity.GetType()}");
            Validate.IsNotNull(entity, nameof(entity));
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
            _logger.LogInformation($"End updating entity {entity.GetType()}");
        }

        /// <inheritdoc />
        public virtual TEntity GetById(int entityId)
        {
            if (entityId <= 0)
            {
                return null;
            }
            
            var entity = DbContext.Set<TEntity>().Find(entityId);
            return entity;
        }

        /// <inheritdoc />
        public virtual IQueryable<TEntity> Entities => DbContext.Set<TEntity>();

        #endregion
    }
}
