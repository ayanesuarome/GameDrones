using System.Collections.Generic;
using System.Linq;
using GameDrones.Domain.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameDrones.Data.Players
{
    /// <summary>
    /// Repository implementation to access to players.
    /// </summary>
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Object context instance</param>
        /// <param name="logger">Logger instance</param>
        public PlayerRepository(IDbContext dbContext, ILogger<PlayerRepository> logger)
            : base(dbContext, logger)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public IList<Player> FindAllPlayers()
        {
            var query = Entities;

            return query.ToList();
        }


        /// <inheritdoc />
        public Player GetPlayerByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            var player = Entities
                .Include(x => x.WonMatches)
                .Include(x => x.LostMatches)
                .FirstOrDefault(x => x.Name.Equals(name));

            return player;
        }

        #endregion
    }
}