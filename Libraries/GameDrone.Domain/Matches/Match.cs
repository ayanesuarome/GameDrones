using GameDrone.Core;
using GameDrones.Domain.Players;

namespace GameDrones.Domain.Matches
{
    /// <summary>
    /// Entity Match definition.
    /// </summary>
    public class Match : Entity, IAuditable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the winner ID.
        /// </summary>
        public int WinnerId { get; set; }

        /// <summary>
        /// Gets or sets the loser ID.
        /// </summary>
        public int LoserId { get; set; }

        /// <summary>
        /// Gets or sets the winner.
        /// </summary>
        public Player Winner { get; set; }

        /// <summary>
        /// Gets or sets the loser.
        /// </summary>
        public Player Loser { get; set; }

        #endregion
    }
}