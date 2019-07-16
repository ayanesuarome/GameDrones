using System.Collections.Generic;
using GameDrone.Core;
using GameDrones.Domain.Matches;

namespace GameDrones.Domain.Players
{
    /// <summary>
    /// Entity Player definition.
    /// </summary>
    public class Player : Entity, IAuditable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of won matches.
        /// </summary>
        public ICollection<Match> WonMatches { get; protected set; } = new HashSet<Match>();

        /// <summary>
        /// Gets or sets the collection of lost matches.
        /// </summary>
        public ICollection<Match> LostMatches { get; protected set; } = new HashSet<Match>();

        #endregion
    }
}