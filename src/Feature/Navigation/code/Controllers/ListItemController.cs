using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Acme.Foundation.Helper;

using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;
using Sitecore.Analytics;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Fields;
using Sitecore.Data;
using Acme.Feature.Navigation.Models;
using Acme.Feature.Navigation.Models;

namespace Acme.Feature.Navigation.Controllers
{
    public class ListItemController : Acme.Foundation.Helper.Controllers.BaseController
    {


        //[HttpGet]
        //public ActionResult MyPromos()
        //{

        //    List<Item> items = Sitecore.Context.Database.SelectItems(Query.PromoList).ToList();
        //    foreach (Item i in items)
        //    {
        //        if (SiteConfiguration.DoesItemExistInCurrentLanguage(i))
        //        {

        //        }
        //    }


        //   return View(
        //    RenderingPath.ListItem + RenderingViews.PromoList, items);
 

        //}




        public ActionResult LanguageDropDown()
        {
            List<SimpleItem> items = new List<SimpleItem>();


            if (!IsDataItemNull)
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItem(DataItem);
                if (promoSiteSettings != null)
                {
                    MultilistField languages = promoSiteSettings.Fields[FieldNames.Languages];
                    if (languages != null)
                    {
                        foreach (Item i in languages.GetItems()) { if (SiteConfiguration.DoesItemExistInCurrentLanguage(i)) items.Add(new SimpleItem(i)); }
                        if (items.Count > 0)
                        {
                            return View(RenderingPath.Navigation
                                + RenderingViews.LanguageDropDown, items);
                        }
                        else { return ShowListIsEmptyMessage(); }
                    }
                    else { return ShowListIsEmptyMessage(); }

                }
                else return ShowProjectSettingsIssueMessage();
            }
            else return ShowDataSourceIsNullMessage();


        }


        [HttpGet]
        public ActionResult LanguageDropDownOld(string promo)
        {
            List<SimpleItem> items = new List<SimpleItem>();

            if (IsValidPromo(promo))
            {
                Item promoSiteSettings = SiteConfiguration.GetPromSiteSettingItemOld(promo);
                if (promoSiteSettings != null)
                {

                    MultilistField languages = promoSiteSettings.Fields[FieldNames.Languages];
                    if (languages != null)
                    {
                        foreach (Item i in languages.GetItems()) { if (SiteConfiguration.DoesItemExistInCurrentLanguage(i)) items.Add(new SimpleItem(i)); }
                        if (items.Count > 0)
                        {
                            return View(RenderingPath.Navigation
                                + RenderingViews.LanguageDropDown, items);
                        }
                        else { return ShowListIsEmptyMessage(); }
                    }
                    else { return ShowListIsEmptyMessage(); }
                }
                else { return ShowProjectSettingsIssueMessage(); }
            }
            else { return  ShowMissingOrInvalidPromoCodeMessage(); }


//            return View(Constants.RenderingsHiltonComponentsListItem_Path + "LanguageDropDown.cshtml", items);

        }



        public ActionResult LogoBarLinks()
        {

            IEnumerable<LinkItem> items = Sitecore.Context.Database
            .GetItem(Query.GlobalLogoBarLinks)
            .Children
            .Select(x => new LinkItem(x));

            return View(
                Acme.Feature.Navigation.RenderingPath.Navigation + Acme.Feature.Navigation.RenderingViews.LogoBarLinks, items);
        }

        //public ActionResult LogoBarLinks2()
        //{

        //    IEnumerable<LinkItem> items = Sitecore.Context.Database
        //    .GetItem(Query.GlobalLogoBarLinks)
        //    .Children
        //    .Select(x => new LinkItem(x));

        //    return View(
        //        RenderingPath.ListItem + RenderingViews.LogoBarLinks_2, items);
        //}


        public ActionResult GlobalSiteLinks()
        {

            IEnumerable<LinkItem> items = Sitecore.Context.Database
            .GetItem(Query.GlobalGlobalSiteLinks)
            .Children
            .Select(x => new LinkItem(x));

            return View(RenderingPath.Navigation + 
                RenderingViews.GlobalSiteLinks, items);
        }

        public ActionResult CustomerSupportLinks()
        {

            IEnumerable<LinkItem> items = Sitecore.Context.Database
            .GetItem(Query.GlobalCustomerSupportLinks)
            .Children
            .Select(x => new LinkItem(x));

            return View(RenderingPath.Navigation +
                RenderingViews.CustomerSupportLinks, items);
        }

        public ActionResult InstantBenefitLinks()
        {

            if (!IsDataSourceNull)
            {
                List<LinkItem> childItems = new List<LinkItem>();
                foreach (Item child in DataItem.Children)
                {
                    if (SiteConfiguration.DoesItemExistInCurrentLanguage(child))
                    {
                        childItems.Add(new LinkItem(child));
                    }

                }

                return View(RenderingPath.Navigation +
                    RenderingViews.InstantBenefitLinks, childItems);

            }
            else return ShowDataSourceIsNullMessage();

        }


        //public ActionResult AppStoreLinks()
        //{
        //    if (!IsDataSourceNull)
        //    {
        //        List<LinkItem> childItems = new List<LinkItem>();

        //        try
        //        {
        //            foreach (Item child in DataItem.Children)
        //            {
        //                if (SiteConfiguration.DoesItemExistInCurrentLanguage(child))
        //                {
        //                    childItems.Add(new LinkItem(child));
        //                }
        //            }
        //        }

        //        catch (Exception ex){
        //           ShowListIsEmptyMessage(ex.Message);
        //        }

        //        return View(RenderingPath.Navigation +
        //            RenderingViews.AppStoreLinks, childItems);
        //    }
        //    else return ShowDataSourceIsNullMessage();
        //}



        public ActionResult IconBagImageLinkItems()
        {

            if (!IsDataSourceNull)
            {


                List<LinkItem> childItems = new List<LinkItem>();
                foreach (Item child in DataItem.Children)
                {
                    if (SiteConfiguration.DoesItemExistInCurrentLanguage(child))
                    {
                        childItems.Add(new LinkItem(child));
                    }

                }

                return View(RenderingPath.Navigation +
                    RenderingViews.IconBagImageLinkItems, childItems);

            }
            else return ShowDataSourceIsNullMessage();

        }



        public ActionResult DesktopMobileImagesWithScreenReaderText(string partner)
        {
            if (!IsDataSourceNull)
            {

                if (string.IsNullOrEmpty(partner)) partner = Defaults.Partner;

                List<ContentByPartnerItem> items2 = new List<ContentByPartnerItem>();
                List<Item> items = Sitecore.Context.Database.SelectItems(ContentPath + Query.ByPartner + partner + "']").ToList();
                foreach (Item i in items)
                {
                    if (SiteConfiguration.DoesItemExistInCurrentLanguage(i))
                    {
                        items2.Add(new ContentByPartnerItem(i));
                    }
                }


                return View(RenderingPath.Navigation +
                    RenderingViews.DesktopMobileImagesWithScreenReaderText, items2);

            }
            else return ShowDataSourceIsNullMessage();

        }

        public ActionResult TermsAndConditionsContentItems(String partner)
        {
            if (!IsDataSourceNull){
            
                if (string.IsNullOrEmpty(partner)) partner= Defaults.Partner;

                List<ContentByPartnerItem> items2 = new List<ContentByPartnerItem>();

                string query = String.Format("fast: " + ContentPath + Query.ByPartner + "{0}" + "']",  partner);
 
//                List<Item> items = Sitecore.Context.Database.SelectItems(ContentPath + Query.ByPartner + partner + "']").ToList();
                List<Item> items = Sitecore.Context.Database.SelectItems(query).ToList();
                foreach (Item i in items)
                {
                    if (SiteConfiguration.DoesItemExistInCurrentLanguage(i))
                    {
                        items2.Add(new ContentByPartnerItem(i));
                    }
                }
                return View(RenderingPath.Navigation +
                    RenderingViews.TermsAndConditionsContentItems, items2);

            }else return ShowDataSourceIsNullMessage();
        }


        }

}
