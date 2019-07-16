using System.Collections.Generic;
using System.Linq;
using GameDrones.Core;
using GameDrones.Domain.Matches;
using GameDrones.Domain.Players;
using GameDrones.Tests.AutoFixture;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GameDrones.Data.Tests
{
    /// <summary>
    /// Test class to test the <see cref="ContextTests"/> connection and access.
    /// </summary>
    public class ContextTests : Disposable
    {
        #region Fields

        private GameDroneContext _gameDroneContext;
        private const string ConnectionString = "data source=DESKTOP-4S89ACT;initial catalog=GameDrones;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        #endregion

        #region Setup and Cleanup

        /// <summary>
        /// Initializes a new instance of the class <see cref="ContextTests"/> class.
        /// </summary>
        public ContextTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameDroneContext>()
                .UseSqlServer(ConnectionString);

            _gameDroneContext = new GameDroneContext(optionsBuilder.Options);
        }

        #endregion

        #region IDisposable Support

        protected override void DisposeCore()
        {
            _gameDroneContext.Dispose();
        }

        #endregion

        #region Test Methods

        /// <summary>
        /// Tests that the <see cref="GameDroneContext"/> can query the data base.
        /// </summary>
        [Fact]
        public void CanQueryDataBase()
        {
            using (var ctx = Build())
            {
                var query = ctx.Players;
                var sql = query.ToList();

                Assert.NotNull(sql);
            }
        }

        /// <summary>
        /// Tests that the <see cref="GameDroneContext"/> can use transaction.
        /// </summary>
        [Fact]
        public void CanUseTransactions()
        {
            using (var ctx = Build())
            using (ctx.Database.BeginTransaction())
            {
                var player = new Player
                {
                    Name = "Name"
                };

                ctx.Add(player);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Tests that entity framework can compile queries using the <see cref="GameDroneContext"/>.
        /// </summary>
        [Fact]
        public void CanCompileQueries()
        {
            var query = EF.CompileQuery<GameDroneContext, IEnumerable<Player>>(ctx => ctx.Players.OrderBy(x => x.Name));

            using (var ctx = Build())
            {
                var players = query(ctx).ToList();

                Assert.NotEmpty(players);
            }
        }

        /// <summary>
        /// Tests that the <see cref="GameDroneContext"/> can validate the context operation
        /// and throwns the <see cref="DbUpdateException"/>.
        /// </summary>
        [Fact]
        public void CanValidateTheDbOperation()
        {
            using (var ctx = Build())
            {
                var player = new Player
                {
                    Id = 10000,
                    Name = "Name"
                };

                ctx.Add(player);

                Assert.Throws<DbUpdateException>(() => ctx.SaveChanges());
            }
        }

        /// <summary>
        /// Tests that the <see cref="GameDroneContext"/> can use Linq and Sql operations.
        /// </summary>
        /// <param name="player">The player</param>
        [Theory, AutoMoqData]
        public void CanUseLinqAndSql(Player player)
        {
            using (var ctx = Build())
            {
                player.Id = 0;

                ctx.Add(player);
                ctx.SaveChanges();

                var players = ctx
                    .Players
                    .FromSql("SELECT * FROM Player")
                    .Where(x => x.Name.Contains("Name"))
                    .ToList();

                Assert.NotEmpty(players);
            }
        }

        /// <summary>
        /// Tests that the <see cref="GameDroneContext"/> can use the eager load.
        /// </summary>
        [Fact]
        public void CanEagerLoad()
        {
            using (var ctx = Build())
            {
                var existPlayer =
                    ctx.Players.FirstOrDefault(x => x.Name.Contains("Winner") || x.Name.Contains("Loser"));

                if (existPlayer == null)
                {
                    var players = new List<Player>
                    {
                        new Player
                        {
                            Name = "Winner"
                        },
                        new Player
                        {
                            Name = "Loser"
                        }
                    };

                    ctx.Players.AddRange(players);
                    ctx.SaveChanges();

                    var match = new Match
                    {
                        WinnerId = players[0].Id,
                        LoserId = players[1].Id
                    };

                    ctx.Matches.Add(match);
                    ctx.SaveChanges();
                }

                var matchesWithWinner = ctx
                    .Matches
                    .Include(x => x.Winner)
                    .Include(x => x.Loser)
                    .ToList();

                Assert.NotEmpty(matchesWithWinner);
                Assert.All(matchesWithWinner, x => Assert.NotNull(x.Winner));
                Assert.All(matchesWithWinner, x => Assert.NotNull(x.Loser));
            }
        }

        [Fact]
        public void CanUseLike()
        {
            using (var ctx = Build())
            {
                var existPlayer =
                    ctx.Players.FirstOrDefault(x => x.Name.Contains("Winner"));

                if (existPlayer == null)
                {
                    var player = new Player
                    {
                        Name = "Winner"
                    };

                    ctx.Add(player);
                    ctx.SaveChanges();
                }

                var projects = ctx.Players.Where(x => EF.Functions.Like(x.Name, "%win%")).ToList();

                Assert.NotEmpty(projects);
            }
        }

        public GameDroneContext Build()
        {
            return _gameDroneContext;
        }

        #endregion
    }
}
