using FluentValidation;
using Rms.Admin.Models.Customers;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Customers
{
    public class CustomerAttributeValueValidator : AbstractValidator<CustomerAttributeValueModel>
    {
        public CustomerAttributeValueValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerAttributes.Values.Fields.Name.Required"));
        }
    }
}