using FluentValidation;
using Rms.Admin.Models.Templates;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Templates
{
    public class ProductTemplateValidator : AbstractValidator<ProductTemplateModel>
    {
        public ProductTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Product.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Product.ViewPath.Required"));
        }
    }
}