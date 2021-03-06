﻿using System.Web.Routing;
using Rms.Web.Framework.Localization;
using Rms.Web.Framework.Mvc.Routes;
using Rms.Web.Framework.Seo;

namespace Rms.Web.Infrastructure
{
    public partial class GenericUrlRouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {

            //the last route. it's used when none of registered routes could be used for the current request
            //but it this case we cannot process non-registered routes (/controller/action)
            //routes.MapLocalizedRoute(
            //    "PageNotFound-Wildchar",
            //    "{*url}",
            //    new { controller = "Common", action = "PageNotFound" },
            //    new[] { "Rms.Web.Controllers" });
        }

        public int Priority
        {
            get
            {
                //it should be the last route
                //we do not set it to -int.MaxValue so it could be overriden (if required)
                return -1000000;
            }
        }
    }
}
