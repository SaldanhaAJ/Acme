using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Acme.Feature.Promotion.Models;
using Acme.Feature.Promotion.Repositories;
using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;


using Epsilon.DataAccess.Implementations.Cache;
using Epsilon.DataAccess.Implementations.Commands;
using Epsilon.DataAccess.Implementations.DomainObjects.Request;
using Epsilon.DataAccess.Implementations.DomainObjects.Response;
using Epsilon.Infrastructure.Implementations.UI.Views;
using Acme.Foundation.Helper;
using Newtonsoft.Json;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



using Sitecore.Analytics;

using Acme.Feature.Promotion.Models;
using Acme.Foundation.Helper;

using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Links;

using Acme.Feature.Promotion;
using Acme.Feature.Promotion.Helpers;
using log4net.Config;

namespace Acme.Feature.Promotion.Controllers
{
//    public class RegisterController : Controller
    //Sitecore.Mvc.Controllers.SitecoreController
    //Sitecore.Mvc.Controllers.SitecoreController
    public class MemberController : BaseController
    {


        #region Sign Up Methods



        public ActionResult SignUp(String ocode, String promo, string partner)
        {

            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {
                    var repository = new SignUpRepository();

                    var signUp = repository.getSignUp(promoSiteSettings);

                    return View(RenderingPath.Member + RenderingViews.SignUp, signUp);

                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();


        }

        #endregion

        #region Enroll Methods


        /// <summary>
        /// Gets the Enroll Form Header Content/View or a standard path
        /// </summary>
        /// <param name="promo"></param>
        /// <param name="partner"></param>
        /// <returns>Enroll Form Header Content/View</returns>
        public ActionResult EnrollFormHeader(String promo, string partner)
        {

            if (!IsDataSourceNull)
            {
//                Item item = Sitecore.Context.Database.GetItem(ID.Parse(DataSource));

                var repository = new EnrollRespository(ContentPath);

                var enrollFormHeader = repository.getEnrollFormHeaderForPartner(partner);

                if (enrollFormHeader != null) return View(RenderingPath.Member +
                     RenderingViews.EnrollFormHeader, enrollFormHeader);
                else return ShowDataSourceIsNullMessage();

            }
            else return ShowDataSourceIsNullMessage();

            /*
            var item = RenderingContext.Current.Rendering.Item;
            
            List<Item> items2;


            // Get all the decendants in a tree
            items2 = item.Axes.GetDescendants().Where(x => x.TemplateName == "Quarterly Promotion Content").ToList();

            String contentPath = item.Paths.ContentPath;



            //para meters 
            var paras = RenderingContext.Current.Rendering.Parameters;
            */           
            /*
            var repository = new EnrollRespository();

            var enrollFormHeader = repository.getEnrollItemForPromoAndPartner(promo, partner);

            if (enrollFormHeader !=null) return View(RenderingPath.Member +
                RenderingViews.EnrollFormHeader, enrollFormHeader);
            else return ShowDataSouceIsNullMessage();

             * 
             */
        }



        [HttpGet]
        public ActionResult EnrollForm(String selection = "", String gtir = "", String oCode = "", String brand = "")
        {

            var repository = new MemberRepository();

            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {
                    var enrollForm = new EnrollForm();

                    enrollForm.OptInOut = new OptInOutModel
                    {
                        CheckedTerms = false,
                        CheckedThirdParties = false
                    };


                    //Identify Type of Promotion

                    //Validate Prouduct Code - for Reg

                    //Determine Source Code to be used based on inputs, type of promotion and additional settings (?)

                    //Verify Source Code

                    //Based on Source Code + other inputs get Offer Code

                    // Get default state and country from promo site settings

                    String defaultCountry = repository.getCountryDefault(promoSiteSettings);
                    String defaultState = repository.getStateDefault(promoSiteSettings, defaultCountry); ;

                    //Based on Current language get the default country code

                    //Load OptIn model based on that 
                    DefaultOptInOutCheckboxesSelection(defaultCountry, enrollForm.OptInOut);


                    //Load the model and send it back to the client


//                    var countryList = new List<SelectListItem> { new SelectListItem() { Value = "something", Text = "something" } };


                    enrollForm.Countries =
                        new SelectList(Countries.GetCountriesFromCacheOrAddToCache(Request, false),
                        "Value", "Text", defaultCountry);
                    enrollForm.States = new SelectList(States.GetStatesByCountryFromCacheOrAddToCache(defaultCountry),
                        "Value", "Text", defaultState);

                    enrollForm.OfferCode = oCode;



                    if (!IsDataItemNull) return View(RenderingPath.Member +
                        RenderingViews.EnrollForm, enrollForm);
                    else return ShowDataSourceIsNullMessage();

                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }


        [HttpPost]
        public ActionResult EnrollForm(EnrollForm enrollForm, String selection = "",
            String gtir = "", String oCode = "", String brand = null)
        //??? Other than the enrollForm modek not data comes in via post - even though the values are in the query string
        {
            String message = String.Empty;

            ViewBag.Country = enrollForm.SelectedCountry;
            ViewBag.Gtir = gtir;

            var repository = new MemberRepository();

            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {
                    if (SiteConfiguration.HasCaptchaSupport(promoSiteSettings))
                    {
                        CaptchaPrevalidate();
                    }


                    CheckboxesPreValidation(enrollForm.SelectedCountry, enrollForm.OptInOut);

                    enrollForm.Countries = new SelectList(Countries.GetCountriesFromCacheOrAddToCache(Request), "Value", "Text",
                    enrollForm.SelectedCountry);

                    enrollForm.States =
                        new SelectList(States.GetStatesByCountryFromCacheOrAddToCache(enrollForm.SelectedCountry), "Value",
                            "Text", enrollForm.SelectedState);

                    if (!ModelState.IsValid)
                    {

                        ModelState.AddModelError("", GetDictionaryText(DictionaryKeys.InvalidLoginCredentials));

                        return View(RenderingPath.Member + RenderingViews.EnrollForm,
                            enrollForm);
                    }
                    else
                    {
                        try
                        {
                            string lang = string.Empty;
                            lang = CurrentLanguage();
                              

                            // Enroll New Member
                            var enrollRequest = new EnrollRequest(enrollForm.FirstName,
                                enrollForm.LastName,
                                enrollForm.Address1,
                                enrollForm.Address2,
                                enrollForm.City,
                                enrollForm.SelectedCountry,
                                enrollForm.SelectedState,
                                enrollForm.ZipCode,
                                enrollForm.SignUpEmailAddress,
                                new CountryCheckBox().GetCheckBoxStatus(enrollForm.SelectedCountry, "OptInOut_CheckedThirdParties", enrollForm.OptInOut.CheckedThirdParties), // CheckNoThirdParty
                                true, //CheckConfirmationEmail
                                enrollForm.OptInOut.ContactByHHonors, //ContactByHHonors Checkbox
                                enrollForm.OfferCode,
                                lang);

                            var enrollResponse = (new EnrollCommand(Request, enrollRequest)).Execute();

                            // Proceed if the enrollment was successful, otherwise redirect to the friendly error page.
                            if (enrollResponse.Success)
                            {
                                return (RedirectToLocal(repository.getConfirmationPath(promoSiteSettings)));
                            }
                            else
                            {
                                return (RedirectToLocal(repository.getErrorPath(promoSiteSettings) + "?message=" + enrollResponse.DetailedError));

                                /*
                                _logWriter.Error(
                           "During an 'Enroll' POST in the Enroll Controller an unhandled exception occurred due to " + enrollResponse.FriendlyError);
                                if (enrollResponse.FriendlyError.Contains("Duplicate Email Address"))
                                {
                                    ModelState["Enroll.SignUpEmailAddress"].Errors.Add(
                                        _translationService.GetSpecificTranslation("enrollForm", "DuplicateEmail"));
                                }
                                else
                                {
                                    result = RedirectToAction("Index", "FriendlyError", new { message = enrollResponse.FriendlyError, gtir, selection, oCode, brand });
                                }
                                 */
                            }


                            // Drop a promotion

                            // Send a promo confirmation email



                        }
                        catch (Exception exception)
                        {
                            message = exception.Message;
                            return (RedirectToLocal(repository.getErrorPath(promoSiteSettings) + "?message=" + message));
                        }
                    }
                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }

        #endregion

        #region Register Methods

        //
        // GET: /Register/

        //private static readonly ILog logger =
        //   LogManager.GetLogger(typeof(RegisterController));


        [HttpGet]
        public ActionResult RegisterForm(String ocode, String promo, string partner)
        {
            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {
                    var repository = new RegisterRepository();
                    var registerForm = repository.getRegisterForm(promoSiteSettings);

                    return View(RenderingPath.Member +
                    RenderingViews.RegisterForm,
                    registerForm);

                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }


        [HttpGet]
        public ActionResult RegisterFormAjax(String ocode, String promo, string partner)
        {
            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {
                    var repository = new RegisterRepository();
                    var registerForm = repository.getRegisterForm(promoSiteSettings);

                    return View(RenderingPath.Member +
                    RenderingViews.RegisterForm,
                    registerForm);

                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }

        [HttpPost]
        public ActionResult RegisterFormAjax(RegisterModel registerViewModel)
        {
            String message = String.Empty;

            if (!IsDataSourceNull)
            {

                if (!ModelState.IsValid)
                {
                    return View(RenderingPath.Member + RenderingViews.Register, registerViewModel);
                }
                else
                {
                    registerViewModel.PromoCode = "Promocode";

                    try
                    {
                        // Step 1: Login.
                        var loginCommand = new WebLoginGetAllDataCommand(Request, registerViewModel.Username,
                            registerViewModel.Password);

                        var loginResponse = loginCommand.Execute();
                        if (loginResponse.Success)
                        {
                            return View(RenderingPath.Member + "_RegisterConfirmation.cshtml");

                        }
                        else
                        {
                            // message = registerViewModel.Password;
                            message = loginResponse.DetailedError;
                            return (RedirectToAction("Index", "FriendlyError", new { message = message }));
                        }
                    }
                    catch (Exception exception)
                    {
                        message = exception.Message;
                        return (RedirectToAction("Index", "FriendlyError", new { message = message }));
                    }

                }

            }
            else return ShowDataSourceIsNullMessage();

        }


        [HttpGet]
        // Was "RegisterFormServer"
        public ActionResult RegisterFormServer(String ocode, String promo, string partner)
        {
            /*            var logger = log4net.LogManager.GetLogger("Sitecore.Diagnostics.Custom");
                        logger.Info("Hello, world. And by world, I mean a text file.");
            */

            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {
                    var repository = new RegisterRepository();
                    var registerForm = repository.getRegisterForm(promoSiteSettings);

                    return View(RenderingPath.Member +
                    RenderingViews.RegisterFormServer,
                    registerForm);

                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }

        [HttpPost]
        public ActionResult RegisterFormServer(RegisterForm registerViewModel, String selection = "",
            String gtir = "", String oCode = "", String brand = null)
        {
            String message = String.Empty;
            var repository = new RegisterRepository();

            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {

                    if (SiteConfiguration.HasCaptchaSupport(promoSiteSettings ))
                    {
                        CaptchaPrevalidate();
                    }



                    if (!ModelState.IsValid)
                    {

                        ModelState.AddModelError("", GetDictionaryText(DictionaryKeys.InvalidLoginCredentials));


                        Sitecore.Security.Domains.Domain domain = Sitecore.Context.Domain;
                        string domainUser = domain.Name + @"\" + "Some UserName";
                        AnalyticsHelper.RegisterGoalOnCurrentPage("Login", "[Login] Username: \"" + domainUser + "\"");
                        //AnalyticsHelper.SetVisitTagsOnLogin(domainUser, false);



                        return View(RenderingPath.Member + RenderingViews.RegisterFormServer, 
                            registerViewModel);
                    }
                    else
                    {

                        try
                        {
                            // Step 1: Login.
                            var loginCommand = new WebLoginGetAllDataCommand(Request, registerViewModel.Username,
                                registerViewModel.Password);

                            var loginResponse = loginCommand.Execute();
                            if (loginResponse.Success)
                            {
                                //return (RedirectToLocal( repository.getConfirmationPath(promoSiteSettings) +  "?promo=HH42016&partner=American Airlines"));
                                return (RedirectToLocal( repository.getConfirmationPath(promoSiteSettings) ));
                            }
                            else
                            {
                                // message = registerViewModel.Password;
                                //message = loginResponse.DetailedError;
                                //return (RedirectToLocal(repository.getErrorPath(promoSiteSettings) + "?message=" + message));

                                ModelState.AddModelError("", GetDictionaryText(DictionaryKeys.InvalidLoginCredentials));

                                return View(RenderingPath.Member + RenderingViews.RegisterFormServer,
                                    registerViewModel);

                            }
                        }
                        catch (Exception exception)
                        {
                            message = exception.Message;
                            return (RedirectToLocal(repository.getErrorPath(promoSiteSettings) + "?message=" + message));
                        }
                   }
                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }

    #region Register FF Number

        [HttpGet]
        // Based on "RegisterFormServer"
        public ActionResult RegisterFormFFNumber(String ocode, String promo, string partner)
        {

            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {
                    var repository = new MemberRepository();
                    var registerFormFFNumber = repository.getRegisterFormFFNumber(promoSiteSettings);

                    return View(RenderingPath.Member +
                    RenderingViews.RegisterFormFFNumber,
                    registerFormFFNumber);

                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }

        [HttpPost]
        public ActionResult RegisterFormFFNumber(RegisterFormFFNumber registerViewModel, String selection = "",
            String gtir = "", String oCode = "", String brand = null)
        {
            String message = String.Empty;
            var repository = new MemberRepository();

            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {

                    if (SiteConfiguration.HasCaptchaSupport(promoSiteSettings))
                    {
                        CaptchaPrevalidate();
                    }

                    if (!ModelState.IsValid)
                    {

                        ModelState.AddModelError("", GetDictionaryText(DictionaryKeys.InvalidLoginCredentials));

                        return View(RenderingPath.Member + RenderingViews.RegisterFormFFNumber,
                            registerViewModel);
                    }
                    else
                    {

                        try
                        {
                            // Step 1: Login.
                            var loginCommand = new WebLoginGetAllDataCommand(Request, registerViewModel.Username,
                                registerViewModel.Password);

                            var loginResponse = loginCommand.Execute();
                            if (loginResponse.Success)
                            {
                                //return (RedirectToLocal( repository.getConfirmationPath(promoSiteSettings) +  "?promo=HH42016&partner=American Airlines"));
                                return (RedirectToLocal(repository.getConfirmationPath(promoSiteSettings)));
                            }
                            else
                            {
                                ModelState.AddModelError("", GetDictionaryText(DictionaryKeys.InvalidLoginCredentials));

                                return View(RenderingPath.Member + RenderingViews.RegisterFormFFNumber,
                                    registerViewModel);

                            }
                        }
                        catch (Exception exception)
                        {
                            message = exception.Message;
                            return (RedirectToLocal(repository.getErrorPath(promoSiteSettings) + "?message=" + message));
                        }
                    }
                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }


    #endregion

    #region Register With Email Address

        [HttpGet]
        // Based on "RegisterFormServer"
        public ActionResult RegisterFormEmailAddress(String ocode, String promo, string partner)
        {

            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {
                    var repository = new MemberRepository();
                    var registerFormEmailAddress = repository.getRegisterFormEmailAddress(promoSiteSettings);

                    return View(RenderingPath.Member +
                    RenderingViews.RegisterFormEmailAddress,
                    registerFormEmailAddress);

                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }

        [HttpPost]
        public ActionResult RegisterFormEmailAddress(RegisterFormEmailAddress registerViewModel, String selection = "",
            String gtir = "", String oCode = "", String brand = null)
        {
            String message = String.Empty;
            var repository = new MemberRepository();

            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {

                    if (SiteConfiguration.HasCaptchaSupport(promoSiteSettings))
                    {
                        CaptchaPrevalidate();
                    }

                    if (!ModelState.IsValid)
                    {

                        ModelState.AddModelError("", GetDictionaryText(DictionaryKeys.InvalidLoginCredentials));

                        return View(RenderingPath.Member + RenderingViews.RegisterFormEmailAddress,
                            registerViewModel);
                    }
                    else
                    {

                        try
                        {
                            // Step 1: Login.
                            var loginCommand = new WebLoginGetAllDataCommand(Request, registerViewModel.Username,
                                registerViewModel.Password);

                            var loginResponse = loginCommand.Execute();
                            if (loginResponse.Success)
                            {
                                //return (RedirectToLocal( repository.getConfirmationPath(promoSiteSettings) +  "?promo=HH42016&partner=American Airlines"));
                                return (RedirectToLocal(repository.getConfirmationPath(promoSiteSettings)));
                            }
                            else
                            {
                                ModelState.AddModelError("", GetDictionaryText(DictionaryKeys.InvalidLoginCredentials));

                                return View(RenderingPath.Member + RenderingViews.RegisterFormEmailAddress,
                                    registerViewModel);

                            }
                        }
                        catch (Exception exception)
                        {
                            message = exception.Message;
                            return (RedirectToLocal(repository.getErrorPath(promoSiteSettings) + "?message=" + message));
                        }
                    }
                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();

        }



    #endregion


        [HttpPost]
        public ActionResult Register(RegisterModel registerViewModel)
        {
            String message = String.Empty;

            BasicConfigurator.Configure();

            // Deal with form post here

            // Do what base.Index() eventually does
 
//            return base.index();


            if (!ModelState.IsValid)    {    
                // Save your new values    
                // Return view or redirect to another action    

//                return View(RenderingPath.Member + "_Register.cshtml", registerViewModel);
                return View( registerViewModel);
            }
            else
            {
                registerViewModel.PromoCode = "Promocode";
                //logger.Info("asdasd");


                try
                {
                    // Step 1: Login.
                    var loginCommand = new WebLoginGetAllDataCommand(Request, registerViewModel.Username,
                        registerViewModel.Password);

                    var loginResponse = loginCommand.Execute();
                    if (loginResponse.Success)
                    {
                        return View(RenderingPath.Member + "_RegisterConfirmation.cshtml");
                    }
                    else
                    {
                        // message = registerViewModel.Password;
                        message = loginResponse.DetailedError;
                        return (RedirectToAction("Index", "FriendlyError", new { message = message }));
                    }
                }
                catch (Exception exception)
                {
                    message = exception.Message;
                    return (RedirectToAction("Index", "FriendlyError",new { message = message }));
                }

            }


//            IView pageView =  Sitecore.Mvc.Presentation.PageContext.Current.PageView;
//            if (pageView == null)
//            {
//                return new HttpNotFoundResult();
//            }
//            else
//            {
////                return (ActionResult)this.View(pageView);
////                return View("confirmation");


//                return (RedirectToAction("Index", "FriendlyError",
//    new { message = "some message"}));


//            }
        }


        
        [HttpPost]
        public ActionResult RegisterViaAjax(
                string promo, 
                string parter, 
                string offercode,
                string settingsPath,
                string controlPath,
                string grecaptcharesponse
                )
        {
            
            String JSONResponseStatus = string.Empty;
            String JSONResponseMessage = string.Empty;


           // Sitecore.Data.Items.Item siteSettings = SiteConfiguration.GetSiteSettingsItem();




            return Json(new JSONResponseModel { Message = JSONResponseMessage, Status = JSONResponseStatus }, JsonRequestBehavior.AllowGet);


        }

        #endregion

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("/");
            }
        }

        /// <summary>
        /// perform captcha validation for new and existing memeber enrollment
        /// </summary>
        private void CaptchaPrevalidate()
        {
            var response = Request["g-recaptcha-response"];
            var secret = CaptchaUtil.GetPrivateKey();

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("{0}?secret={1}&response={2}", CaptchaUtil.GetCaptchaUrl(), secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            if (!captchaResponse.Success)
            {
                ModelState.AddModelError("", GetDictionaryText(DictionaryKeys.InvalidCaptcha));
            }
        }


        /// <summary>
        ///     populate validation message for all check boxes
        /// </summary>
        /// <param name="code"></param>   
        /// <param name="optInOutModel"></param>
        private void CheckboxesPreValidation(string code, OptInOutModel optInOutModel)
        {
            IEnumerable<Country> checkBoxes = new CountryCheckBox().LoadCountryCheckBoxes(code);

            if (!checkBoxes.Any())
            {
                checkBoxes = new CountryCheckBox().LoadCountryCheckBoxes("ALL");
            }
            ViewBag.CheckButtons = checkBoxes.ToList();

            ClearAllCheckValidation();


            foreach (Country checkBox in checkBoxes)
            {
                string key = checkBox.Id.Replace("_", ".");

                //set validation message from translation file in  CheckedConfirmAge field for uncheck box
                if (!String.IsNullOrEmpty(checkBox.ValidationNodeName.Trim()) && checkBox.Visible == "true" &&
                    checkBox.Id == "OptInOut_CheckedConfirmAge" && !optInOutModel.CheckedConfirmAge)
                {
                    ModelState[key].Errors.Add(
                        new CountryCheckBox().GetTranslation(checkBox.ValidationNodeName));
                }
                //set validation message from translation file in  CheckedTerms field for uncheck box
                if (!String.IsNullOrEmpty(checkBox.ValidationNodeName.Trim()) && checkBox.Visible == "true" &&
                    checkBox.Id == "OptInOut_CheckedTerms" && !optInOutModel.CheckedTerms)
                {
                    ModelState[key].Errors.Add(
                        new CountryCheckBox().GetTranslation(checkBox.ValidationNodeName));
                }
                //set validation message from translation file in  CheckedTerms2 field for uncheck box
                if (!String.IsNullOrEmpty(checkBox.ValidationNodeName.Trim()) && checkBox.Visible == "true" &&
                    checkBox.Id == "OptInOut_CheckedTerms2" && !optInOutModel.CheckedTerms2)
                {
                    ModelState[key].Errors.Add(
                        new CountryCheckBox().GetTranslation(checkBox.ValidationNodeName));
                }
                //set validation message from translation file in  CheckedThirdParties field for uncheck box
                if (!String.IsNullOrEmpty(checkBox.ValidationNodeName.Trim()) && checkBox.Visible == "true" &&
                    checkBox.Id == "OptInOut_CheckedThirdParties" && !optInOutModel.CheckedThirdParties)
                {
                    ModelState[key].Errors.Add(
                        new CountryCheckBox().GetTranslation(checkBox.ValidationNodeName));
                }
                //set validation message from translation file in  ContactByHHonors field for uncheck box
                if (!String.IsNullOrEmpty(checkBox.ValidationNodeName.Trim()) && checkBox.Visible == "true" &&
                    checkBox.Id == "OptInOut_ContactByHHonors" && !optInOutModel.ContactByHHonors)
                {
                    ModelState[key].Errors.Add(
                        new CountryCheckBox().GetTranslation(checkBox.ValidationNodeName));
                }
            }
        }


        private void DefaultOptInOutCheckboxesSelection(string code, OptInOutModel optInOutModel)
        {
            IEnumerable<Country> checkBoxes = new CountryCheckBox().LoadCountryCheckBoxes(code);
            if (!checkBoxes.Any())
            {
                checkBoxes = new CountryCheckBox().LoadCountryCheckBoxes("ALL");
            }
            ViewBag.CheckButtons = checkBoxes.ToList();
            foreach (Country checkBox in checkBoxes)
            {

                if (checkBox.Id == "OptInOut_CheckedConfirmAge")
                {
                    optInOutModel.CheckedConfirmAge = bool.Parse(checkBox.DefaultChecked);
                }

                if (checkBox.Id == "OptInOut_CheckedTerms")
                {
                    optInOutModel.CheckedTerms = bool.Parse(checkBox.DefaultChecked);
                }

                if (checkBox.Id == "OptInOut_CheckedTerms2")
                {
                    optInOutModel.CheckedTerms2 = bool.Parse(checkBox.DefaultChecked);
                }

                if (checkBox.Id == "OptInOut_CheckedThirdParties")
                {
                    optInOutModel.CheckedThirdParties = bool.Parse(checkBox.DefaultChecked);
                }

                if (checkBox.Id == "OptInOut_ContactByHHonors")
                {
                    optInOutModel.ContactByHHonors = bool.Parse(checkBox.DefaultChecked);
                }
            }
        }
        /// <summary>
        ///     Clear validation message from all checkboxes
        /// </summary>
        private void ClearAllCheckValidation()
        {
            if (ModelState.ContainsKey("OptInOut.CheckedConfirmAge"))
            {
                ModelState["OptInOut.CheckedConfirmAge"].Errors.Clear();
            }
            if (ModelState.ContainsKey("OptInOut.CheckedTerms"))
            {
                ModelState["OptInOut.CheckedTerms"].Errors.Clear();
            }
            if (ModelState.ContainsKey("OptInOut.CheckedTerms2"))
            {
                ModelState["OptInOut.CheckedTerms2"].Errors.Clear();
            }
            if (ModelState.ContainsKey("OptInOut.CheckedThirdParties"))
            {
                ModelState["OptInOut.CheckedThirdParties"].Errors.Clear();
            }
            if (ModelState.ContainsKey("OptInOut.ContactByHHonors"))
            {
                ModelState["OptInOut.ContactByHHonors"].Errors.Clear();
            }
        }



        [HttpPost]
        public ActionResult ChangeOptInOptOutCheckBoxes(string serializedFields, String countryCode
                )
        {
            var serializer = new ParamSerializer();
            var enrollForm = serializer.Deserialize<EnrollForm>(serializedFields);

            enrollForm.OptInOut = new OptInOutModel();


            IEnumerable<Country> checkBoxes = new CountryCheckBox().LoadCountryCheckBoxes(countryCode);
            if (!checkBoxes.Any())
            {
                checkBoxes = new CountryCheckBox().LoadCountryCheckBoxes("ALL");
            }
            ViewBag.CheckButtons = checkBoxes.ToList();
            foreach (Country checkBox in checkBoxes)
            {

                if (checkBox.Id == "OptInOut_CheckedConfirmAge")
                {
                    enrollForm.OptInOut.CheckedConfirmAge = bool.Parse(checkBox.DefaultChecked);
                }

                if (checkBox.Id == "OptInOut_CheckedTerms")
                {
                    enrollForm.OptInOut.CheckedTerms = bool.Parse(checkBox.DefaultChecked);
                }

                if (checkBox.Id == "OptInOut_CheckedTerms2")
                {
                    enrollForm.OptInOut.CheckedTerms2 = bool.Parse(checkBox.DefaultChecked);
                }

                if (checkBox.Id == "OptInOut_CheckedThirdParties")
                {
                    enrollForm.OptInOut.CheckedThirdParties = bool.Parse(checkBox.DefaultChecked);
                }

                if (checkBox.Id == "OptInOut_ContactByHHonors")
                {
                    enrollForm.OptInOut.ContactByHHonors = bool.Parse(checkBox.DefaultChecked);
                }
            }



            String JSONResponseStatus = string.Empty;
            String JSONResponseMessage = string.Empty;


            // Sitecore.Data.Items.Item siteSettings = SiteConfiguration.GetSiteSettingsItem();



            return View(RenderingPath.Shared +
                 RenderingViews.OptInOptOutCheckBoxes, enrollForm);

            //return Json(new JSONResponseModel { Message = JSONResponseMessage, Status = JSONResponseStatus }, JsonRequestBehavior.AllowGet);


        }




        #endregion


    }




    public class JSONResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }




}
