using System;
using System.Collections.Generic;
using GameDrones.Domain.Players;

namespace GameDrones.Data.Players
{
    /// <summary>
    /// Repository definition for players.
    /// </summary>
    public interface IPlayerRepository : ICreateUpdate<Player>, IRead<Player>
    {
        /// <summary>
        /// Finds all players.
        /// </summary>
        IList<Player> FindAllPlayers();

        /// <summary>
        /// Gets a player by the provided name.
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <returns>The player</returns>
        Player GetPlayerByName(string name);
    }
}