using System.Collections.Generic;
using System.Linq;
using GameDrones.Core;
using GameDrones.Data.Players;
using GameDrones.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace GameDrones.Data.Tests.ClassFixtures
{
    /// <summary>
    /// Creates a <see cref="GameDroneContext"/> test context and share it among all the tests per class which
    /// inherits this one, and have it cleaned up after all the tests in the class have finished.
    /// </summary>
    public class GameDroneContextFixture : Disposable
    {
        #region Fields

        private Mock<IDbContext> _dbContextMock;
        private Mock<ILogger<PlayerRepository>> _loggerMock;

        #endregion

        #region Setup and Cleanup

        /// <summary>
        /// Initializes a new instance of the <see cref="GameDroneContextFixture"/> class.
        /// </summary>
        public GameDroneContextFixture()
        {
            _dbContextMock = new Mock<IDbContext>();
            _loggerMock = new Mock<ILogger<PlayerRepository>>();
        }

        #region IDisposable Support

        protected override void DisposeCore()
        {
            _dbContextMock = null;
            _loggerMock = null;
        }

        #endregion

        #endregion

        #region Methods

        public Mock<IDbContext> DbContextMock => _dbContextMock;
        public Mock<ILogger<PlayerRepository>> LoggerMock => _loggerMock;

        /// <summary>
        /// Gets the queryable db set by mocking a number of properties of DbSet that are used by Entity Framework.
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="sourceList">The list of entities simulating the data set</param>
        /// <returns>The <see cref="DbSet{TEntity}"/></returns>
        public DbSet<TEntity> GetQueryableMockDbSet<TEntity>(List<TEntity> sourceList)
            where TEntity : class, IEntity
        {
            var queryable = sourceList.AsQueryable();

            var mockSet = new Mock<DbSet<TEntity>>();
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mockSet.Object;
        }

        #endregion
    }
}