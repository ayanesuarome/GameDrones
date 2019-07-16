using GameDrones.Service.Matches;
using GameDrones.Service.Players;
using Microsoft.AspNetCore.Mvc;

namespace GameDrones.Web.Controllers
{
    /// <summary>
    /// Controller for players.
    /// </summary>
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        #region Fields

        private readonly IPlayerService _playerService;
        private readonly IMatchService _matchService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayersController"/>.
        /// </summary>
        /// <param name="playerService">Player service instance</param>
        /// <param name="matchService">Match service instance</param>
        public PlayersController(
            IPlayerService playerService,
            IMatchService matchService)
        {
            _playerService = playerService;
            _matchService = matchService;
        }

        #endregion

        #region Methods

        #endregion
    }
}
