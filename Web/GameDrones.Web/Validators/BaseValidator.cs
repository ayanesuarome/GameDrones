using FluentValidation;
using GameDrones.Web.Models;

namespace GameDrones.Web.Validators
{
    /// <summary>
    /// Base class for all validators of the application.
    /// </summary>
    /// <typeparam name="TModel">Type of the model to validate</typeparam>
    public class BaseValidator<TModel> : AbstractValidator<TModel>
        where TModel : BaseModel
    {
    }
}
