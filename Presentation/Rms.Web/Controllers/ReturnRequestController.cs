using System;
using System.Web.Mvc;
using Rms.Core;
using Rms.Core.Domain.Localization;
 
using Rms.Services.Customers;
using Rms.Services.Directory;
using Rms.Services.Localization;
using Rms.Services.Messages;
 
using Rms.Services.Seo;
using Rms.Web.Framework.Security;
 

namespace Rms.Web.Controllers
{
    public partial class ReturnRequestController : BasePublicController
    {
		#region Fields

       
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly ICurrencyService _currencyService;
    
        private readonly ILocalizationService _localizationService;
        private readonly ICustomerService _customerService;
        private readonly IWorkflowMessageService _workflowMessageService;

        private readonly LocalizationSettings _localizationSettings;
 
        #endregion

		#region Constructors

        public ReturnRequestController( 
            IWorkContext workContext, IStoreContext storeContext,
            ICurrencyService currencyService, 
            ILocalizationService localizationService,
            ICustomerService customerService,
            IWorkflowMessageService workflowMessageService,
            LocalizationSettings localizationSettings )
        {
          
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._currencyService = currencyService;
       
          
            this._localizationService = localizationService;
            this._customerService = customerService;
            this._workflowMessageService = workflowMessageService;

            this._localizationSettings = localizationSettings;
           
        }

        #endregion

       
        #region Methods
 
        #endregion
    }
}
