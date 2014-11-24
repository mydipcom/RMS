using FluentValidation;
using Rms.Admin.Models.Templates;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Templates
{
    public class CategoryTemplateValidator : AbstractValidator<CategoryTemplateModel>
    {
        public CategoryTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Category.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Category.ViewPath.Required"));
        }
    }
}