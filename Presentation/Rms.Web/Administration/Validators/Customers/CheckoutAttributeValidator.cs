using FluentValidation;
using Rms.Admin.Models.Customers;
using Rms.Services.Localization;

namespace Rms.Admin.Validators.Customers
{
    public class CustomerAttributeValidator : AbstractValidator<CustomerAttributeModel>
    {
        public CustomerAttributeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerAttributes.Fields.Name.Required"));
        }
    }
}