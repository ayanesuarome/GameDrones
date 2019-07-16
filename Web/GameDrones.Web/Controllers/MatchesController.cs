using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDrones.Domain.Matches;
using GameDrones.Domain.Players;
using GameDrones.Service.Matches;
using GameDrones.Service.Players;
using GameDrones.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameDrones.Web.Controllers
{
    /// <summary>
    /// Controller for matches.
    /// </summary>
    [Route("api/[controller]")]
    public class MatchesController : Controller
    {
        #region Fields

        private readonly IPlayerService _playerService;
        private readonly IMatchService _matchService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchesController"/>.
        /// </summary>
        /// <param name="playerService">Player service instance</param>
        /// <param name="matchService">Match service instance</param>
        public MatchesController(
            IPlayerService playerService,
            IMatchService matchService)
        {
            _playerService = playerService;
            _matchService = matchService;
        }

        #endregion

        #region Methods

        [HttpGet("[action]")]
        public async Task<IEnumerable<GameStatisticsModel>> GamesWonByPlayer(string name)
        {
            //if (string.IsNullOrEmpty(name)) return new EmptyResult();

            var matches = _matchService.FindAllMatches().Where(x => x.Winner.Name.Contains(name)).ToList();

            if (!matches.Any()) return null;

            return matches.Select(match => new GameStatisticsModel
            {
                WinnerName = match.Winner.Name,
                LoserName = match.Loser.Name
            });
        }

        [HttpGet("[action]")]
        public object GamesWonByPlayerSyncfusion(string name)
        {
            if (string.IsNullOrEmpty(name)) return new BadRequestResult();

            var matches = _matchService.FindAllMatches().Where(x => x.Winner.Name.Contains(name)).ToList();

            if (!matches.Any()) return new EmptyResult();

            IEnumerable result = matches.Select(match => new GameStatisticsModel
            {
                WinnerName = match.Winner.Name,
                LoserName = match.Loser.Name
            });

            var count = matches.Count;

            return Json(new { Items = result, Count = count });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMatch([FromBody] GameStatisticsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var winner = GetOrInsertPlayer(model.WinnerName);
            var loser = GetOrInsertPlayer(model.LoserName);

            var match = new Match
            {
                Winner = winner,
                Loser = loser
            };

            await _matchService.InsertMatchAsync(match);

            return Ok();
        }

        [NonAction]
        private Player GetOrInsertPlayer(string name)
        {
            var player = _playerService.GetPlayerByName(name);

            if (player != null) return player;

            player = new Player
            {
                Name = name
            };

            _playerService.InsertPlayer(player);

            return player;
        }

        #endregion
    }
}
