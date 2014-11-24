using FluentValidation;
using Rms.Admin.Models.Stores;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Stores
{
    public class StoreValidator : AbstractValidator<StoreModel>
    {
        public StoreValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Name.Required"));
            RuleFor(x => x.Url).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Url.Required"));
        }
    }
}