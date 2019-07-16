namespace GameDrones.Web.Models
{
    /// <summary>
    /// Model for a game statistics.
    /// </summary>
    public class GameStatisticsModel : BaseModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the winner player name.
        /// </summary>
        public string WinnerName { get; set; }
        
        /// <summary>
        /// Gets or sets the loser player name.
        /// </summary>
        public string LoserName { get; set; }

        #endregion
    }
}