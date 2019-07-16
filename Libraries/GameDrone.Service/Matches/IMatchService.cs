using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameDrones.Domain.Matches;

namespace GameDrones.Service.Matches
{
    /// <summary>
    /// Service definition to access matches.
    /// </summary>
    public interface IMatchService
    {
        /// <summary>
        /// Finds all matches.
        /// </summary>
        IList<Match> FindAllMatches();

        /// <summary>
        /// Inserts a new match.
        /// </summary>
        /// <param name="match">The match to insert</param>
        /// <exception cref="ArgumentNullException">If the <paramref name="match"/> is null</exception>
        void InsertMatch(Match match);

        /// <summary>
        /// Inserts a new match asynchronously.
        /// </summary>
        /// <param name="match">The match to insert</param>
        /// <exception cref="ArgumentNullException">If the <paramref name="match"/> is null</exception>
        Task InsertMatchAsync(Match match);

        /// <summary>
        /// Gets a match by ID.
        /// </summary>
        /// <param name="id">ID of the match to get</param>
        /// <returns>The match found by the provided ID; null otherwise</returns>
        Match GetMatchById(int id);
    }
}
