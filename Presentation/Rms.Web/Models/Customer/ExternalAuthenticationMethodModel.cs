﻿using System.Web.Routing;
using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Customer
{
    public partial class ExternalAuthenticationMethodModel : BaseNopModel
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }
}