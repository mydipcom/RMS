using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Rms.Core.Infrastructure;
using Rms.Services.Localization;
using Rms.Web.Models.Industry;

namespace Rms.Web.Validators.Industry
{
    public class IndustryValidator : AbstractValidator<IndustryModel>
    {
        public IndustryValidator()
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Industry.Fields.Name.Required"));
            RuleFor(x => x.DisplayOrder)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Industry.Fields.DisplayOrder.Required"));
        }
    }
}