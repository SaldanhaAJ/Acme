using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Acme.Foundation.Helper;

using Acme.Feature.Promotion.Models;
using Acme.Feature.Promotion;


using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Acme.Feature.Promotion.Controllers
{
    public class BaseController : Controller
    {
        protected Item DataSourceItemOrCurrentItem
        {
            get
            {
                return RenderingContext.Current.Rendering.Item;
            }
        }


        public Item DataItem
        {
            get
            {
                try
                {
                    return RenderingContext.Current.Rendering.Item;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        protected bool IsDataItemNull
        {
            get
            {
                Boolean returnValue = true;
                try
                {
                    // return string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource) || RenderingContext.Current.Rendering.Item == null;
                    if (RenderingContext.Current.Rendering.Item != null) returnValue = false;
                    return returnValue;
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }



        /// <summary>
        /// Returns the DataSource Item specified by the user when Sublayout is added to the page.  If not specified, returns null
        /// </summary>
        public String DataSourceItem
        {
            get
            {
                try
                {
                    var str = RenderingContext.Current.Rendering.DataSource;
                    return str;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected bool IsDataSourceNull
        {

            get
            {
                Boolean returnValue = true;
                try
                {
                    if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))  returnValue = false;
                    return returnValue;
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }

        protected String DataSource
        {

            get
            {
                try
                {
                    return (RenderingContext.Current.Rendering.DataSource);
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        protected String ContextualMessage
        {

            get
            {
                try
                {
                    String str;
                    str = "Content Path: " + RenderingContext.Current.Rendering.Item.Paths.Path;
                    str = "<br/>";
                    str += "Rendering :" + RenderingContext.Current.Rendering.ToString();
                    str = "<br/>";
                    str += "Controller:";
                    str = "<br/>";
                    str += "Action:";

                    return str;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }



        protected String ContentPath
        {

            get
            {
                try
                {
                    return (RenderingContext.Current.Rendering.Item.Paths.Path);
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }


        protected String CurrentLanguage()
        {
            return Sitecore.Context.Language.ToString().ToUpper();
        }




        // Checks to see if the promo value passed in useable - maybe add a check against a XML file of promos 
        // too for additional security and avoiding random query of the CMS
        public static Boolean IsValidPromo (string promo){
            Boolean returnValue = false;
            if (promo != null)
            {
                if (promo.Length > 0) {
                    returnValue = true;
                }
                else
                {
                    returnValue= false;
                    //log promo blanl error
                }
            }
            else
            {
                returnValue= false;
                //log promo blanl error

            }
            return returnValue;


        }


        /// <summary>
        /// Wraps the standard sitecore dictionary call.  In order to have all site labels and standard text managed within the CMS, we use the dictionary.
        /// These items simply hold the value for each label.    
        /// </summary>
        /// <param name="key">The dictionary key you are requesting.</param>
        /// <returns>The phrase value for the requested key.</returns>
        protected string GetDictionaryText(string key)
        {
//            return Sitecore.Globalization.Translate.Text(key);
              return Sitecore.Globalization.Translate.Text(key);
        }       



        public ActionResult ShowListIsEmptyMessage()
        {
            return View(RenderingPath.ListItem + RenderingViews.PageMessage,
                new PageMessage(PageMessage.Messages.ListIsEmpty, ContextualMessage));
        }

        public ActionResult ShowProjectSettingsIssueMessage()
        {
            // Languages have not been set up in Project settings
            return View(RenderingPath.ListItem + RenderingViews.PageMessage,
                new PageMessage(PageMessage.Messages.ProjectSettingsIssue, ContextualMessage));
        }

        public ActionResult ShowMissingOrInvalidPromoCodeMessage()
        {
            // Invalid or missing promo code
            return View(RenderingPath.ListItem + RenderingViews.PageMessage,
                new PageMessage(PageMessage.Messages.PromoCodeMissingOrInvalid, ContextualMessage));

        }

        public ActionResult ShowDataSourceIsNullMessage()
        {
            string t1 = ContextualMessage;

            StackTrace stackTrace = new StackTrace();
            t1 = t1 + "<br/> <b> Calling Method: </b>";            
            t1 = t1 + stackTrace.GetFrame(1).GetMethod().Name.ToString();

            // Invalid or missing promo code
            return View(RenderingPath.ListItem + RenderingViews.PageMessage,
                new PageMessage(PageMessage.Messages.DataSourceIsNull, t1));

        }


        public ActionResult ShowListIsEmptyMessage(String additionalMessage)
        {
            return View(RenderingPath.ListItem + RenderingViews.PageMessage,
                new PageMessage(PageMessage.Messages.ListIsEmpty, ContextualMessage + additionalMessage));
        }

        public ActionResult ShowProjectSettingsIssueMessage(String additionalMessage)
        {
            // Languages have not been set up in Project settings
            return View(RenderingPath.ListItem + RenderingViews.PageMessage,
                new PageMessage(PageMessage.Messages.ProjectSettingsIssue, ContextualMessage + additionalMessage));
        }

        public ActionResult ShowMissingOrInvalidPromoCodeMessage(String additionalMessage)
        {
            // Invalid or missing promo code
            return View(RenderingPath.ListItem + RenderingViews.PageMessage,
                new PageMessage(PageMessage.Messages.PromoCodeMissingOrInvalid, ContextualMessage + additionalMessage));

        }

        public ActionResult ShowDataSourceIsNullMessage(String additionalMessage)
        {
            // Invalid or missing promo code
            return View(RenderingPath.ListItem + RenderingViews.PageMessage,
                new PageMessage(PageMessage.Messages.DataSourceIsNull, ContextualMessage + additionalMessage));

        }



    }
}
