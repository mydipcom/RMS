using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rms.Web.Framework;

namespace Rms.Web.Models.Customer
{
    public class LoginModel
    {
          [NopResourceDisplayName("Account.Login.Fields.UserName")]
        public string UserName { get; set; }

         [NopResourceDisplayName("Account.Login.Fields.Password")]
        public string Password { get; set; }

          [NopResourceDisplayName("Account.Login.Fields.RememberMe")]
        public bool RememberMe { get; set; }
    }
}