using System;
using System.Collections.Generic;
using GameDrones.Domain.Players;

namespace GameDrones.Service.Players
{
    /// <summary>
    /// Service definition to access players.
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Finds all players.
        /// </summary>
        IList<Player> FindAllPlayers();

        /// <summary>
        /// Inserts a new player.
        /// </summary>
        /// <param name="player">The player to insert</param>
        /// <exception cref="ArgumentNullException">If the <paramref name="player"/> is null</exception>
        void InsertPlayer(Player player);

        /// <summary>
        /// Gets a player by ID.
        /// </summary>
        /// <param name="id">ID of the player to get</param>
        /// <returns>The player found by the provided ID; null otherwise</returns>
        Player GetPlayerById(int id);

        /// <summary>
        /// Gets a player by the provided name.
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <returns>The player</returns>
        Player GetPlayerByName(string name);
    }
}
