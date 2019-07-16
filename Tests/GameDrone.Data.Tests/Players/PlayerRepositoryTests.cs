using System.Collections.Generic;
using GameDrones.Data.Players;
using GameDrones.Data.Tests.ClassFixtures;
using GameDrones.Domain.Players;
using Xunit;

namespace GameDrones.Data.Tests.Players
{
    /// <summary>
    /// Test class to test the <see cref="PlayerRepositoryTests"/> implementations.
    /// It uses shared object instance across tests in a single class.
    /// Further information at <see cref="GameDroneContextFixture"/>
    /// </summary>
    public class PlayerRepositoryTests : IClassFixture<GameDroneContextFixture>
    {
        #region Fields

        private readonly GameDroneContextFixture _fixture;
        private readonly IPlayerRepository _playerRepository;

        #endregion

        #region Setup and Cleanup

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerRepositoryTests"/> class.
        /// </summary>
        /// <param name="fixture">Fixture instance</param>
        public PlayerRepositoryTests(GameDroneContextFixture fixture)
        {
            _fixture = fixture;
            
            _playerRepository = new PlayerRepository(
                _fixture.DbContextMock.Object,
                _fixture.LoggerMock.Object);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Tests that <see cref="IPlayerRepository.GetById(int)"/>
        /// returns null value when there is no any <see cref="Player"/>.
        /// </summary>
        [Fact]
        public void GetAccountTypeByAccountTypeValueReturnsNullWhenNoValuesFound()
        {
            var context = new GameDroneContext("connection")
            {
                Players = _fixture.GetQueryableMockDbSet(new List<Player>())
            };

            _fixture.DbContextMock.Setup(m => m.Set<Player>()).Returns(context.Players);
            var result = _playerRepository.GetById(15);

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that <see cref="IPlayerRepository.GetPlayerByName(string)"/>
        /// returns null value when there is no any <see cref="Player"/> that matches the criteria.
        /// </summary>
        [Fact]
        public void GetAccountTypeByAccountTypeValueReturnsNullWhenNotFindingAnyMatching()
        {
            var players = new List<Player>
            {
                new Player { Name = "TEST" }
            };

            var context = new GameDroneContext("connection")
            {
                Players = _fixture.GetQueryableMockDbSet(players)
            };

            _fixture.DbContextMock.Setup(m => m.Set<Player>()).Returns(context.Players);
            var result = _playerRepository.GetPlayerByName("OTHER");

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that <see cref="IPlayerRepository.GetPlayerByName(string)"/>
        /// returns a valid and an existing one <see cref="Player"/> 
        /// by the provided <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name to look for</param>
        [Theory]
        [MemberData(nameof(GetPlayerNames))]
        public void GetAccountTypeByAccountTypeValueReturnsAValidAccountType(string name)
        {
            var players = new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Name = "NameOne",
                },
                new Player
                {
                    Id = 2,
                    Name = "NameTwo"
                },
                new Player
                {
                    Id = 3,
                    Name = "NameThree"
                }
            };

            var context = new GameDroneContext("connection")
            {
                Players = _fixture.GetQueryableMockDbSet(players)
            };

            _fixture.DbContextMock.Setup(m => m.Set<Player>()).Returns(context.Players);
            var player = _playerRepository.GetPlayerByName(name);

            Assert.NotNull(player);
            Assert.Equal(name, player.Name);
            Assert.IsAssignableFrom<Player>(player);
        }

        public static IEnumerable<object[]> GetPlayerNames()
        {
            yield return new object[] { "NameOne" };
            yield return new object[] { "NameTwo" };
            yield return new object[] { "NameThree" };
        }

        #endregion
    }
}
