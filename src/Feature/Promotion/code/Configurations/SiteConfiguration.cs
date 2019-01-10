using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.Data.Fields;

using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

using Acme.Foundation.Helper;

namespace Project.Promotion.Configuration
{
    public class SiteConfiguration
    {

        public static Item GetPromSiteSettingItem(Item item)
        {
            String path = FieldRenderer.Render(item, FieldNames.SiteSettingsPath);
            path = item[FieldNames.SiteSettingsPath];

            if (path != null)
            {
                if (path.Length > 0)
                {
                    return Sitecore.Context.Database.GetItem(path);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static Item GetPromSiteSettingItemOld(string promo)
        {
            if (promo != null)
            {
                if (promo.Length > 0)
                {
                    string query = String.Format( Query.PromoSiteSettings_Query, promo);
                    return Sitecore.Context.Database.GetItem(query);
                }
                else
                {
                    return null;
                } 
            } else {
                return null;
            } 
        }
        public static bool DoesItemExistInCurrentLanguage(Item i)
        {
            // standard way of checking
            if (i.Versions.Count != 0) return true;

            return false;
        }

        public static bool HasCaptchaSupport(Item promoSiteSettings)
        {
            String temp= promoSiteSettings.Fields[FieldNames.CAPTCHASupport].ToString().ToUpper();
            if ((temp == "F") || (temp == "N")) return false;
            else  return true;
        }

        public static bool HasGUIDSupport(Item promoSiteSettings)
        {
            String temp = promoSiteSettings.Fields[FieldNames.GUIDSupport].ToString().ToUpper();
            if ((temp == "F") || (temp == "N")) return false;
            else return true;
        }

        public static bool HasGTIRSupport(Item promoSiteSettings)
        {
            String temp = promoSiteSettings.Fields[FieldNames.GTIRSupport].ToString().ToUpper();
            if ((temp == "F") || (temp == "N")) return false;
            else return true;
        }
        public static String getConfirmationPath(Item promoSiteSettings)
        {
            return promoSiteSettings.Fields[FieldNames.ConfirmationPagePath].ToString();

        }

        public static String getErrorPath(Item promoSiteSettings)
        {
            return promoSiteSettings.Fields[FieldNames.ErrorPagePath].ToString();

        }

        public static String getAlreadyRegisteredPath(Item promoSiteSettings)
        {
            return promoSiteSettings.Fields[FieldNames.AlreadyRegisteredPagePath].ToString();

        }



        /// <summary>
        /// Quick access to the home node for the site.        
        /// </summary>       
        /// <returns>The home item.</returns>
        public static Item GetHomeItem()
        {

            return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            // Since we want to support multi-site for evaluation purposes and do not create site nodes in the site section of 
            // the web.config, we will just go up the tree until we get to the content node.
            //Item temp = Sitecore.Context.Item;
            //Item contentNode = Sitecore.Context.Database.GetItem("/sitecore/content");
            //while (temp.Parent != null && temp.ParentID != contentNode.ID)
            //{
            //    temp = temp.Parent;
            //}
            //return temp;

            // This is the best way to get the home node, but it only works if there is a site definition in the web.config
            //return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            // These options are also ways to get tot he home node.
            //return Sitecore.Context.Item.Axes.SelectSingleItem("ancestor-or-self::*[@@templatekey='home']");
            //return Sitecore.Context.Database.GetItem("/sitecore/content/home");

            // There are multiple ways to retrieve the home node.  You can reference the path, but this is bad for multisite installs.  
            // You can also check by template if all items share the same template type, but my favorite way is to use the StartPath 
            // which is on the site definition node in the config file.
        }

    
    }
}