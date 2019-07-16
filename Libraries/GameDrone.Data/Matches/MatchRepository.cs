using System.Collections.Generic;
using System.Linq;
using GameDrones.Domain.Matches;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameDrones.Data.Matches
{
    /// <summary>
    /// Repository implementation to access to matches.
    /// </summary>
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Object context instance</param>
        /// <param name="logger">Logger instance</param>
        public MatchRepository(IDbContext dbContext, ILogger<MatchRepository> logger)
            : base(dbContext, logger)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public IList<Match> FindAllMatches()
        {
            var query = Entities
                .Include(x => x.Winner)
                .Include(x => x.Loser);

            return query.ToList();
        }

        #endregion
    }
}