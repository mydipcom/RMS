using FluentValidation;
using Rms.Admin.Models.Templates;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Templates
{
    public class ManufacturerTemplateValidator : AbstractValidator<ManufacturerTemplateModel>
    {
        public ManufacturerTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Manufacturer.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Manufacturer.ViewPath.Required"));
        }
    }
}