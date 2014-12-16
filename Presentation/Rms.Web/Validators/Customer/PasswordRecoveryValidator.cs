using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Rms.Core.Infrastructure;
using Rms.Services.Localization;
using Rms.Web.Models.Customer;

namespace Rms.Web.Validators.Customer
{
    public class PasswordRecoveryValidator : AbstractValidator<PasswordRecoveryModel>
    {
        public PasswordRecoveryValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.PasswordRecovery.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}