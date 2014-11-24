using FluentValidation;
using Rms.Admin.Models.Directory;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Directory
{
    public class StateProvinceValidator : AbstractValidator<StateProvinceModel>
    {
        public StateProvinceValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.Fields.Name.Required"));
        }
    }
}