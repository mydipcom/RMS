using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;
using Rms.Web.Validators.Customer;

namespace Rms.Web.Models.Customer
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Account.ChangePassword.Fields.OldPassword.Required")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Account.ChangePassword.Fields.NewPassword.Required")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Account.ChangePassword.Fields.ConfirmNewPassword.Required")]
        [Compare("NewPassword", ErrorMessage = "Account.ChangePassword.Fields.NewPassword.EnteredPasswordsDoNotMatch")]
        public string ConfirmNewPassword { get; set; }

    }
}