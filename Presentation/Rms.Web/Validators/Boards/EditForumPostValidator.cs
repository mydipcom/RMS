using FluentValidation;
using Rms.Services.Localization;
using Rms.Web.Models.Boards;

namespace Rms.Web.Validators.Boards
{
    public class EditForumPostValidator : AbstractValidator<EditForumPostModel>
    {
        public EditForumPostValidator(ILocalizationService localizationService)
        {            
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}