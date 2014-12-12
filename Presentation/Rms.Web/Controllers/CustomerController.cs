using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Rms.Core;
using Rms.Core.Domain.Common;
using Rms.Core.Domain.Customers;
using Rms.Core.Domain.Forums;
using Rms.Core.Domain.Localization;
using Rms.Core.Domain.Media;
using Rms.Services.Authentication;
using Rms.Services.Authentication.External;
 
using Rms.Services.Common;
using Rms.Services.Customers;
using Rms.Services.Directory;
using Rms.Services.Forums;
using Rms.Services.Helpers;
using Rms.Services.Localization;
using Rms.Services.Logging;
using Rms.Services.Media;
using Rms.Services.Messages;
using Rms.Services.Stores;
using Rms.Web.Framework.Security;
using Rms.Web.Framework.UI.Captcha;
using Rms.Web.Models.Common;
using Rms.Web.Models.Customer;

namespace Rms.Web.Controllers
{
    public partial class CustomerController : BasePublicController
    {
        #region Fields

        private readonly IAuthenticationService _authenticationService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly DateTimeSettings _dateTimeSettings;

        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly ICustomerService _customerService;
        private readonly ICustomerAttributeParser _customerAttributeParser;
        private readonly ICustomerAttributeService _customerAttributeService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ICustomerRegistrationService _customerRegistrationService;

        private readonly CustomerSettings _customerSettings;
        private readonly AddressSettings _addressSettings;
        private readonly ForumSettings _forumSettings;

        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;

        private readonly ICurrencyService _currencyService;

        private readonly IPictureService _pictureService;
        private readonly IForumService _forumService;

        private readonly IOpenAuthenticationService _openAuthenticationService;

        private readonly IDownloadService _downloadService;
        private readonly IWebHelper _webHelper;
        private readonly ICustomerActivityService _customerActivityService;

        private readonly MediaSettings _mediaSettings;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;
        private readonly CaptchaSettings _captchaSettings;
        private readonly ExternalAuthenticationSettings _externalAuthenticationSettings;

        #endregion

        #region Ctor

        public CustomerController(IAuthenticationService authenticationService,
            IDateTimeHelper dateTimeHelper,
            DateTimeSettings dateTimeSettings,

            ILocalizationService localizationService,
            IWorkContext workContext,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            ICustomerService customerService,
            ICustomerAttributeParser customerAttributeParser,
            ICustomerAttributeService customerAttributeService,
            IGenericAttributeService genericAttributeService,
            ICustomerRegistrationService customerRegistrationService,

            CustomerSettings customerSettings, AddressSettings addressSettings, ForumSettings forumSettings,

            ICountryService countryService, IStateProvinceService stateProvinceService,

            ICurrencyService currencyService,
            IPictureService pictureService, INewsLetterSubscriptionService newsLetterSubscriptionService,
            IForumService forumService,
            IOpenAuthenticationService openAuthenticationService,

            IDownloadService downloadService, IWebHelper webHelper,
            ICustomerActivityService customerActivityService, MediaSettings mediaSettings,
            IWorkflowMessageService workflowMessageService, LocalizationSettings localizationSettings,
            CaptchaSettings captchaSettings, ExternalAuthenticationSettings externalAuthenticationSettings)
        {
            this._authenticationService = authenticationService;
            this._dateTimeHelper = dateTimeHelper;
            this._dateTimeSettings = dateTimeSettings;

            this._localizationService = localizationService;
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._storeMappingService = storeMappingService;
            this._customerService = customerService;
            this._customerAttributeParser = customerAttributeParser;
            this._customerAttributeService = customerAttributeService;
            this._genericAttributeService = genericAttributeService;
            this._customerRegistrationService = customerRegistrationService;


            this._customerSettings = customerSettings;
            this._addressSettings = addressSettings;
            this._forumSettings = forumSettings;

            this._countryService = countryService;
            this._stateProvinceService = stateProvinceService;

            this._currencyService = currencyService;

            this._pictureService = pictureService;
            this._forumService = forumService;

            this._openAuthenticationService = openAuthenticationService;

            this._downloadService = downloadService;
            this._webHelper = webHelper;
            this._customerActivityService = customerActivityService;

            this._mediaSettings = mediaSettings;
            this._workflowMessageService = workflowMessageService;
            this._localizationSettings = localizationSettings;
            this._captchaSettings = captchaSettings;
            this._externalAuthenticationSettings = externalAuthenticationSettings;
        }

        #endregion




        [NopHttpsRequirement(SslRequirement.Yes)]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _customerRegistrationService.ValidateCustomer(model.UserName, model.Password);
                switch (loginResult)
                {
                    case CustomerLoginResults.Successful:
                    {
                        var customer = _customerService.GetCustomerByUsername(model.UserName);


                        //sign in new customer
                        _authenticationService.SignIn(customer, model.RememberMe);

                        //activity log
                        _customerActivityService.InsertActivity("PublicStore.Login",
                            _localizationService.GetResource("ActivityLog.PublicStore.Login"), customer);

                        if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                            return Redirect(returnUrl);
                        else
                            return RedirectToRoute("HomePage");
                    }
                    case CustomerLoginResults.CustomerNotExist:
                        ModelState.AddModelError("",
                            _localizationService.GetResource("Account.Login.WrongCredentials.CustomerNotExist"));
                        break;
                    case CustomerLoginResults.Deleted:
                        ModelState.AddModelError("",
                            _localizationService.GetResource("Account.Login.WrongCredentials.Deleted"));
                        break;
                    case CustomerLoginResults.NotActive:
                        ModelState.AddModelError("",
                            _localizationService.GetResource("Account.Login.WrongCredentials.NotActive"));
                        break;
                    case CustomerLoginResults.NotRegistered:
                        ModelState.AddModelError("",
                            _localizationService.GetResource("Account.Login.WrongCredentials.NotRegistered"));
                        break;
                    case CustomerLoginResults.WrongPassword:
                    default:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials"));
                        break;
                }
            }

            return View(model);
        }


        public ActionResult Logout(string returnUrl)
        {
            _authenticationService.SignOut();
            if (!String.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            return RedirectToRoute("HomePage");
        }


        [NopHttpsRequirement(SslRequirement.Yes)]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (_workContext.CurrentCustomer.IsRegistered())
            {
                //Already registered customer. 
                _authenticationService.SignOut();

                //Save a new record
                _workContext.CurrentCustomer = _customerService.InsertGuestCustomer();
            }
            var customer = _workContext.CurrentCustomer;
            if (ModelState.IsValid)
            {
                bool isApproved = _customerSettings.UserRegistrationType == UserRegistrationType.Standard;
                var registrationRequest = new CustomerRegistrationRequest(customer, model.Email, model.Username,
                    model.Password,
                    _customerSettings.DefaultPasswordFormat, isApproved);
                var registrationResult = _customerRegistrationService.RegisterCustomer(registrationRequest);
                if (registrationResult.Success)
                {
                    customer.Mobile = model.Mobile;
                    _customerService.UpdateCustomer(customer);
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in registrationResult.Errors)
                        ModelState.AddModelError("", error);
                }
            }
            return View(model);
        }

        public ActionResult PasswordRecovery()
        {
            var model=new PasswordRecoveryModel();
            return View(model);
        }


        [HttpPost]
        public ActionResult PasswordRecovery(PasswordRecoveryModel model)
        { 
            if (ModelState.IsValid)
            {
                var customer = _customerService.GetCustomerByEmail(model.Email);
                if (customer != null && customer.Active && !customer.Deleted)
                {
                    _workflowMessageService.SendCustomerPasswordRecoveryMessage(customer,
                        _workContext.WorkingLanguage.Id);

                    model.Result = _localizationService.GetResource("Account.PasswordRecovery.EmailHasBeenSent");
                }
                else
                    model.Result = _localizationService.GetResource("Account.PasswordRecovery.EmailNotFound");

                return View(model);
            }
            return View(model);
        }

        public ActionResult Profile()
        {
            var customer = _workContext.CurrentCustomer;
            var profile = new CustomerProfileModel();
            profile.Email = customer.Email;
            profile.FullName = customer.GetFullName();
            return View(profile);
        }



        public ActionResult CustomerManager()
        {
            return View();
        }


        public ActionResult CustomerList(DataTableParameter param)
        {
            var tabrow = new List<CustomerModel>();


            for (int i = 0; i < 100; i++)
            {
                tabrow.Add(new CustomerModel()
                {
                    Id = i,
                    Name = "Alvis" + i,
                    Age = i
                });
            }


            return Json(new
            {
                param.draw,
                data = tabrow.Skip(param.start).Take(param.length),
                recordsTotal = 100,
                recordsFiltered = 100
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
