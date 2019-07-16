using System.Collections.Generic;
using System.Linq;
using GameDrones.Data.Players;
using GameDrones.Domain.Players;

namespace GameDrones.Service.Players
{
    /// <summary>
    /// Service implementation to access players.
    /// </summary>
    public class PlayerService : IPlayerService
    {
        #region Fields

        private readonly IPlayerRepository _playerRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerService"/> class.
        /// </summary>
        /// <param name="playerRepository">Player repository instance</param>
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public IList<Player> FindAllPlayers()
        {
            var query = _playerRepository.FindAllPlayers();

            return query.ToList();
        }

        /// <inheritdoc />
        public void InsertPlayer(Player player)
        {
            _playerRepository.Save(player);
        }

        /// <inheritdoc />
        public Player GetPlayerById(int id)
        {
            var player = _playerRepository.GetById(id);

            return player;
        }

        /// <inheritdoc />
        public Player GetPlayerByName(string name)
        {
            var player = _playerRepository.GetPlayerByName(name);

            return player;
        }

        #endregion
    }
}