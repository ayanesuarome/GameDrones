using FluentValidation;
using GameDrones.Web.Models;

namespace GameDrones.Web.Validators
{
    /// <summary>
    /// Model validator for the model <see cref="GameStatisticsModel"/>.
    /// </summary>
    public class GameStatisticsModelValidator : BaseValidator<GameStatisticsModel>
    {
        public GameStatisticsModelValidator()
        {
            RuleFor(x => x.WinnerName)
                .NotEmpty().WithMessage("The WinnerName is required");
            RuleFor(x => x.LoserName)
                .NotEmpty().WithMessage("The LoserName is required");
        }
    }
}
