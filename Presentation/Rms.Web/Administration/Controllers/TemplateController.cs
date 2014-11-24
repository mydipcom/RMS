using System;
using System.Linq;
using System.Web.Mvc;
using Rms.Admin.Models.Templates;
 
using Rms.Services.Localization;
using Rms.Services.Security;
using Rms.Web.Framework.Kendoui;
using Rms.Web.Framework.Mvc;

namespace Rms.Admin.Controllers
{
    public partial class TemplateController : BaseAdminController
    {
        #region Fields

        
        private readonly IPermissionService _permissionService;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Constructors

        public TemplateController( 
            IPermissionService permissionService,
            ILocalizationService localizationService)
        { 
            this._permissionService = permissionService;
            this._localizationService = localizationService;
        }

        #endregion

 

 

 
    }
}
