using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Rms.Core.Infrastructure;
using Rms.Web.Framework;
using Rms.Web.Framework.Controllers;
using Rms.Web.Framework.Security;
using Rms.Web.Framework.Seo;
using Rms.Web.Models.Common;

namespace Rms.Web.Controllers
{
    public abstract partial class BasePublicController : BaseController
    {
        protected virtual ActionResult InvokeHttp404()
        {
            // Call target Controller and pass the routeData.
            IController errorController = EngineContext.Current.Resolve<Rms.Web.Controllers.CommonController>();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Common");
            routeData.Values.Add("action", "PageNotFound");

            errorController.Execute(new RequestContext(this.HttpContext, routeData));

            return new EmptyResult();
        }


        protected virtual JsonResult Success()
        {
            return Json(new UIResponse(true));
        }


        protected virtual JsonResult Fail(IList<string> msgs)
        {
            return Json(new UIResponse(false, msgs));
        }
    }
}
