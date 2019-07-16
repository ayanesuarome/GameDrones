using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDrones.Data.Matches;
using GameDrones.Domain.Matches;

namespace GameDrones.Service.Matches
{
    /// <summary>
    /// Service implementation to access matches.
    /// </summary>
    public class MatchService : IMatchService
    {
        #region Fields

        private readonly IMatchRepository _matchRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchService"/> class.
        /// </summary>
        /// <param name="matchRepository">Match repository instance</param>
        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public IList<Match> FindAllMatches()
        {
            var query = _matchRepository.FindAllMatches();

            return query.ToList();
        }

        /// <inheritdoc />
        public void InsertMatch(Match match)
        {
            _matchRepository.Save(match);
        }

        /// <inheritdoc />
        public async Task InsertMatchAsync(Match match)
        {
            await _matchRepository.SaveAsync(match);
        }

        /// <inheritdoc />
        public Match GetMatchById(int id)
        {
            var match = _matchRepository.GetById(id);

            return match;
        }

        #endregion
    }
}