using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Acme.Feature.Promotion.Models;
using Acme.Feature.Promotion.Repositories;
using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;
//
//
using Epsilon.DataAccess.Implementations.Cache;
using Epsilon.DataAccess.Implementations.Commands;
using Epsilon.DataAccess.Implementations.DomainObjects.Request;
using Epsilon.DataAccess.Implementations.DomainObjects.Response;
using Epsilon.Infrastructure.Implementations.UI.Views;
using Acme.Foundation.Helper;




using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Sitecore.Analytics;
using log4net;
using log4net.Config;

namespace Acme.Feature.Promotion.Controllers
{
//    public class RegisterController : Controller
    //Sitecore.Mvc.Controllers.SitecoreController
    //Sitecore.Mvc.Controllers.SitecoreController
    public class RegisterController : BaseController
    {

        //
        // GET: /Register/

        private static readonly ILog logger =
           LogManager.GetLogger(typeof(RegisterController));
        [HttpGet]
        public ActionResult Index2(String promo, string partner)
        {

            var logger = log4net.LogManager.GetLogger("Sitecore.Diagnostics.Custom");
            logger.Info("Hello, world. And by world, I mean a text file.");

            var repository = new RegisterRepository();

            var registerModel = repository.getRegisterModel(promo, partner);

            //registerModel.PromoCode = "Promocode";

            //logger.Info("asdasd");

    //        return View(RenderingPath.Member +
    //"_Register.cshtml",
    //registerModel);


            return View(RenderingPath.Member +
            RenderingViews.Register,
            registerModel);






 
 //           return View(registerModel);
        }

        [HttpPost]
        public ActionResult Index2(RegisterModel registerViewModel)
        {
            String message = String.Empty;

            BasicConfigurator.Configure();

            // Deal with form post here

            // Do what base.Index() eventually does

            //            return base.index();


            if (!ModelState.IsValid)
            {
                // Save your new values    
                // Return view or redirect to another action    

                return View(RenderingPath.Member + RenderingViews.Register, registerViewModel);
                //return View(registerViewModel);
            }
            else
            {
                registerViewModel.PromoCode = "Promocode";
                logger.Info("asdasd");


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
                logger.Info("asdasd");


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


        [HttpGet]
        public ActionResult RegisterViaAjax2(
                )
        {


            String JSONResponseStatus = string.Empty;
            String JSONResponseMessage = string.Empty;


            return Json(new JSONResponseModel { Message = JSONResponseMessage, Status = JSONResponseStatus }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult serializeDeserialize(RegisterForm mydata)
        {

            String JSONResponseStatus = string.Empty;
            String JSONResponseMessage = string.Empty;


            // Sitecore.Data.Items.Item siteSettings = SiteConfiguration.GetSiteSettingsItem();




            return Json(new JSONResponseModel { Message = JSONResponseMessage, Status = JSONResponseStatus }, JsonRequestBehavior.AllowGet);

        }




        [HttpPost]
        public ActionResult RegisterViaAjax3(
                string promo, 
                string parter, 
                string offercode
                )
        {
            
            String JSONResponseStatus = string.Empty;
            String JSONResponseMessage = string.Empty;


           // Sitecore.Data.Items.Item siteSettings = SiteConfiguration.GetSiteSettingsItem();




            return Json(new JSONResponseModel { Message = JSONResponseMessage, Status = JSONResponseStatus }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult RegisterViaAjax1(
                string Username,
                string Password,
                string AffCode,
                string OfferCode,
                string PromoCodeList,
                string LandingPageName,
                bool IsValidGUIDLogin,
                string grecaptcharesponse)
        {


            String JSONResponseStatus = string.Empty;
            String JSONResponseMessage = string.Empty;




            return Json(new JSONResponseModel { Message = JSONResponseMessage, Status = JSONResponseStatus }, JsonRequestBehavior.AllowGet);


        }


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
        #endregion


    }




}
