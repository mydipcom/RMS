using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Rms.Web.Framework;
using Rms.Web.Framework.Mvc;
using Rms.Web.Validators.Customer;

namespace Rms.Web.Models.Customer
{
    [Validator(typeof(RegisterValidator))]
    public partial class RegisterModel : BaseNopModel
    {
        public RegisterModel()
        {

        }

        [NopResourceDisplayName("Account.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [NopResourceDisplayName("Account.Fields.Username")]
        [AllowHtml]
        public string Username { get; set; }

        [NopResourceDisplayName("Account.Fields.Mobile")]
        [AllowHtml]
        public string Mobile { get; set; }

        public bool CheckUsernameAvailabilityEnabled { get; set; }

        [DataType(DataType.Password)]
        [NopResourceDisplayName("Account.Fields.Password")]
        [AllowHtml]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [NopResourceDisplayName("Account.Fields.ConfirmPassword")]
        [AllowHtml]
        public string ConfirmPassword { get; set; }

    }
}