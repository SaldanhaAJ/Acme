using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;

namespace Acme.Feature.Promotion
{
    public class Language
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public bool Selected { get; set; }
    }

    public interface ILanguageUtil
    {
        /// <summary>
        ///     get language list from external xml
        /// </summary>
        /// <param name="culturalLang"></param>
        /// <param name="request"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        List<Language> GetLanguageList(string culturalLang, HttpRequestBase request, UrlHelper uri);

        /// <summary>
        ///     get chinese page url
        /// </summary>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        string GetChinesePageUrl(string action, string controller, string url);

        /// <summary>
        ///     get chinese page url from config xml
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        string GetUrl(string pageName);

        /// <summary>
        /// get language code for google captcha
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string GetGoogleCaptchaCode(string code);

        string GetCountryForLang(string code);
    }

    public class LanguageUtil : ILanguageUtil
    {
        /// <summary>
        ///     get language list from external xml
        /// </summary>
        /// <param name="culturalLang"></param>
        /// <param name="request"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public List<Language> GetLanguageList(string culturalLang, HttpRequestBase request, UrlHelper uri)
        {
            var currentAction = request.RequestContext.RouteData.Values["action"].ToString();
            var currentController = request.RequestContext.RouteData.Values["controller"].ToString();
            string url;
            string urlhttp = "http";

            string environment = CaptchaUtil.GetEnvironment();
            if (environment == "UAT" || environment == "PROD")
            {
                urlhttp = "https";
            }
            url = uri.Action(HttpContext.Current.Request.HttpMethod == "POST" && currentAction.Equals("register", StringComparison.InvariantCultureIgnoreCase) ? "" : currentAction, currentController, null, urlhttp);


            //put all current query string parameter in hashtable
            var ht = new Hashtable();
            foreach (
                string key in
                    request.QueryString.AllKeys.Where(
                        key => !key.Equals("lang", StringComparison.InvariantCultureIgnoreCase)))
            {
                ht.Add(key, request.QueryString[key]);
            }

            //restore query string parameter
            foreach (object key in ht.Keys)
            {
                if (url.IndexOf("?", StringComparison.Ordinal) > 0)
                {
                    url += "&" + key + "=" + ht[key];
                }
                else
                {
                    url += "?" + key + "=" + ht[key];
                }
            }
            string pageUrl = "";
            //commenting out for chinese page navigation

            //if (culturalLang == "CH")
            //{
            //    pageUrl = GetChinesePageUrl(currentAction, currentController, url);
            //    //redirect to chinese page
            //    HttpContext.Current.Response.RedirectPermanent(pageUrl);
            //}

            dynamic config = ConfigHelper.GetModuleConfig("Configuration");
            var supportedLanguages = GetPartnerWiseSupportedCultures(request.Params["ocode"]);
            //populate langauge drop down from config xml
            var languageList = new List<Language>();
            foreach (dynamic language in config.Languages.Language)
            {
                pageUrl = url.IndexOf("?", StringComparison.Ordinal) > 0
                    ? url + "&" + "lang=" + language.Code.Value
                    : url + "?" + "lang=" + language.Code.Value;

                if (supportedLanguages.Count != 0)
                {
                    if (supportedLanguages.Contains(language.Code.Value))
                    {
                        languageList.Add(new Language
                        {
                            Name = language.Name.Value,
                            Code = language.Code.Value,
                            Selected =
                                language.Code.Value.Equals(culturalLang,
                                    StringComparison.InvariantCultureIgnoreCase),
                            Url = pageUrl
                        });
                    }
                }
                else
                {
                    languageList.Add(new Language
                    {
                        Name = language.Name.Value,
                        Code = language.Code.Value,
                        Selected =
                            language.Code.Value.Equals(culturalLang,
                                StringComparison.InvariantCultureIgnoreCase),
                        Url = pageUrl
                    });
                }


            }
            return languageList;
        }
        /// <summary>
        /// get google recaptcha language code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetGoogleCaptchaCode(string code)
        {
            dynamic config = ConfigHelper.GetModuleConfig("Configuration");
            foreach (dynamic language in config.Languages.Language)
            {

                if (language.Code.Value == code)
                {
                    return language.CaptchaCode.Value;
                }
            }
            return "en";
        }

        /// <summary>
        /// get confirmation email common language code 
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns>string</returns>
        public static string GetPromotionConfirmationEmailCommonLang(string languageCode)
        {
            dynamic config = ConfigHelper.GetModuleConfig("Configuration");
            foreach (dynamic language in config.Languages.Language)
            {

                if (language.Code.Value == languageCode)
                {
                    return language.SendPromotionConfirmationEmailCommLang.Value.ToUpper();
                }
            }
            return "EN";
        }

        public string GetCountryForLang(string code)
        {
            dynamic config = ConfigHelper.GetModuleConfig("Configuration");
            foreach (dynamic language in config.Languages.Language)
            {

                if (language.Code.Value == code)
                {
                    return language.CountryCode.Value;
                }
            }
            return "US";
        }



        /// <summary>
        ///     get chinese page url
        /// </summary>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetChinesePageUrl(string action, string controller, string url)
        {
            if (action.Equals("index", StringComparison.InvariantCultureIgnoreCase) &&
                controller.Equals("landing", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetUrl("Landing");
            }
            if (action.Equals("enroll", StringComparison.InvariantCultureIgnoreCase) &&
                controller.Equals("landing", StringComparison.InvariantCultureIgnoreCase)
                && url.Contains("selection=D"))
            {
                return GetUrl("EnrollPoint");
            }
            if (action.Equals("enroll", StringComparison.InvariantCultureIgnoreCase) &&
                controller.Equals("landing", StringComparison.InvariantCultureIgnoreCase)
                && url.Contains("selection=M"))
            {
                return GetUrl("EnrollMile");
            }

            if (action.Equals("index", StringComparison.InvariantCultureIgnoreCase) &&
               controller.Equals("Confirmation", StringComparison.InvariantCultureIgnoreCase) &&
               url.Contains("statusType=new") && url.Contains("selection=D"))
            {
                return GetUrl("EnrollSuccessPoint");
            }
            if (action.Equals("index", StringComparison.InvariantCultureIgnoreCase) &&
               controller.Equals("Confirmation", StringComparison.InvariantCultureIgnoreCase) &&
               url.Contains("statusType=new") && url.Contains("selection=M"))
            {
                return GetUrl("EnrollSuccessMile");
            }

            if (action.Equals("index", StringComparison.InvariantCultureIgnoreCase) &&
               controller.Equals("Confirmation", StringComparison.InvariantCultureIgnoreCase) &&
               url.Contains("statusType=reg") && url.Contains("selection=D"))
            {
                return GetUrl("ConfirmationSuccessPoint");
            }
            if (action.Equals("index", StringComparison.InvariantCultureIgnoreCase) &&
               controller.Equals("Confirmation", StringComparison.InvariantCultureIgnoreCase) &&
               url.Contains("statusType=reg") && url.Contains("selection=M"))
            {
                return GetUrl("ConfirmationSuccessMile");
            }

            if (action.Equals("index", StringComparison.InvariantCultureIgnoreCase) &&
                controller.Equals("alreadyRegistered", StringComparison.InvariantCultureIgnoreCase)
                && url.Contains("selection=D"))
            {
                return GetUrl("AlreadyRegisteredPoint");
            }
            if (action.Equals("index", StringComparison.InvariantCultureIgnoreCase) &&
              controller.Equals("alreadyRegistered", StringComparison.InvariantCultureIgnoreCase)
              && url.Contains("selection=M"))
            {
                return GetUrl("AlreadyRegisteredMile");
            }
            if (action.Equals("index", StringComparison.InvariantCultureIgnoreCase) &&
                controller.Equals("friendlyError", StringComparison.InvariantCultureIgnoreCase) &&
                (url.Contains("PROMOTION CODE Expired") || url.Contains("The promotion is now over")))
            {
                return GetUrl("PromotionExpired");
            }
            return GetUrl("EnrollmentUnsuccess");
        }

        /// <summary>
        ///     get chinese page url from config xml
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public string GetUrl(string pageName)
        {
            dynamic config = ConfigHelper.GetModuleConfig("Configuration");
            foreach (dynamic page in config.ChinesePages.Page)
            {
                if (page.Name.Value.Equals(pageName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return page.Url.Value;
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// return language list based on oCode
        /// </summary>
        /// <param name="oCode"></param>
        /// <returns></returns>
        public List<String> GetPartnerWiseSupportedCultures(string oCode)
        {

            var languageList = new List<string>();

            dynamic config = ConfigHelper.GetModuleConfig("PartnerPromoCodes");

            foreach (dynamic offer in config.OfferCode)
            {
                if (offer.code.Value.Equals(oCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (offer.language.Value.Trim() != "")
                    {
                        return new List<string>(offer.language.Value.Split(','));
                    }

                }
            }

            return languageList;
        }

        /// <summary>
        /// return language list based on oCode
        /// </summary>
        /// <param name="oCode"></param>
        /// <returns></returns>
        public static string GetPartnerWiseDefaultCulture(string oCode)
        {
            dynamic config = ConfigHelper.GetModuleConfig("PartnerPromoCodes");

            foreach (dynamic offer in config.OfferCode)
            {
                if (offer.code.Value.Equals(oCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (offer.default_language.Value.Trim() != "")
                    {
                        return offer.default_language.Value;
                    }
                }
            }

            return "EN";
        }

        public List<String> GetAllSupportedCultures()
        {

            var languageList = new List<string>();

            dynamic config = ConfigHelper.GetModuleConfig("Configuration");

            foreach (dynamic language in config.Languages.Language)
            {
                languageList.Add(language.Code.Value);
            }

            return languageList;
        }

    }

}