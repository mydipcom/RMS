using FluentValidation;
using Rms.Admin.Models.Topics;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Topics
{
    public class TopicValidator : AbstractValidator<TopicModel>
    {
        public TopicValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SystemName).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Topics.Fields.SystemName.Required"));
        }
    }
}