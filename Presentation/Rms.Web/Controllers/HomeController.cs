using System.Web.Mvc;
using Rms.Web.Framework.Security;

namespace Rms.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        [NopHttpsRequirement(SslRequirement.No)]
        public ActionResult Index()
        { 
            return View();
        }
    }
}
