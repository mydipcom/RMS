using FluentValidation;
using Rms.Admin.Models.Affiliates;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Affiliates
{
    public class AffiliateValidator : AbstractValidator<AffiliateModel>
    {
        public AffiliateValidator(ILocalizationService localizationService)
        {
        }
    }
}