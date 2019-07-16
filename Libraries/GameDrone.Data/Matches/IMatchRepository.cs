using System.Collections.Generic;
using GameDrones.Domain.Matches;

namespace GameDrones.Data.Matches
{
    /// <summary>
    /// Repository definition for macthes.
    /// </summary>
    public interface IMatchRepository : ICreateUpdate<Match>, IRead<Match>
    {
        /// <summary>
        /// Finds all matches.
        /// </summary>
        IList<Match> FindAllMatches();
    }
}