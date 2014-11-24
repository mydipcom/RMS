using FluentValidation;
using Rms.Admin.Models.Forums;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Forums
{
    public class ForumGroupValidator : AbstractValidator<ForumGroupModel>
    {
        public ForumGroupValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.ForumGroup.Fields.Name.Required"));
        }
    }
}