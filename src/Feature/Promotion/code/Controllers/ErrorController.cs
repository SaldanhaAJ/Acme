using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Acme.Feature.Promotion.Models;

using Acme.Foundation.Helper;


using Acme.Feature.Promotion.Repositories;



using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;
using Sitecore.Analytics;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Acme.Foundation.Helper;
using Acme.Feature.Promotion.Helpers;

namespace Acme.Feature.Promotion.Controllers
{
    public class ErrorController : BaseController
    {

        public ActionResult ErrorMessage(String message)
        {

            String errorMessage = string.Empty;

            var errorMessages = new List<String>
                                {
                                    "PROMOTION CODE Expired",
                                    "This promotion is now over"
                                };

            if (!String.IsNullOrEmpty(message) && errorMessages.Contains(message))
            {
                errorMessage = UIHelpers.GetDictionaryText(DictionaryKeys.PromotionCodeExpired);
                ViewBag.IsPromoExpired = true;
            }

            else if (!String.IsNullOrEmpty(message) &&
                     (message.Contains("Duplicate Email Address") || message.Contains("DUPECHANNELADDR")))
            {
                errorMessage = UIHelpers.GetDictionaryText(DictionaryKeys.DuplicateEmailAddress);
            }

            else if (!String.IsNullOrEmpty(message) && (message.Contains("invalid product code")))
            {
                errorMessage = UIHelpers.GetDictionaryText(DictionaryKeys.InvalidProductCode);
                ViewBag.IsInvalidProductCode = true;
            }

            else if (!String.IsNullOrEmpty(message) &&
                     (message.Contains("Your request has timed out.") || message.Contains("REQUEST TIMED OUT")))
            {
                errorMessage = UIHelpers.GetDictionaryText(DictionaryKeys.RequestTimedOut);
            }

            if (String.IsNullOrEmpty(errorMessage)) errorMessage = message;


            ViewBag.Message = errorMessage;

            
            if (!IsDataItemNull) return View(RenderingPath.Error +
                RenderingViews.ErrorMessage, new SimpleItem(DataItem));
            else return ShowDataSourceIsNullMessage();
        }

        public ActionResult TermsAndConditionsContentItem(string partner)
        {

            if (!IsDataSourceNull)
            {
                try
                {
                    if (string.IsNullOrEmpty(partner)) partner = Defaults.Partner;

                    Item item = Sitecore.Context.Database.SelectSingleItem(ContentPath + Query.ByPartner + partner + "']");
                    return View(RenderingPath.SingleItem +
                        RenderingViews.TermsAndConditionsContentItem, new ContentItem(DataItem));
                }

                catch (Exception exception)
                {
                    return ShowDataSourceIsNullMessage(exception.Message);
                }

            }
            else return ShowDataSourceIsNullMessage();
        }


    }
}
