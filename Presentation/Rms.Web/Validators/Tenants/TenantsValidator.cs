using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Rms.Core.Infrastructure;
using Rms.Services.Localization;
using Rms.Web.Models.Tenants;

namespace Rms.Web.Validators.Tenants
{
    public class TenantsValidator : AbstractValidator<TenantsModel>
    {
        public TenantsValidator()
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            RuleFor(x => x.TenantName)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Tenants.Fields.TenantName.Required"));
            RuleFor(x => x.MappedDomain)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Tenants.Fields.MappedDomain.Required"));
        }
    }
}