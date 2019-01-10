using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Acme.Feature.Promotion.Models;
using Acme.Feature.Promotion.Repositories;

using Acme.Feature.Promotion.Controllers;


using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;
using Sitecore.Analytics;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Acme.Foundation.Helper;

namespace Acme.Feature.Promotion.Controllers
{
    public class SingleItemController : BaseController
    {

        public ActionResult ButtonWithText()
        {
            if (!IsDataItemNull) return View(RenderingPath.SingleItem +
                RenderingViews.ButtonWithText, new SimpleItem(DataItem));
            else return ShowDataSourceIsNullMessage();


        }
        public ActionResult LandingBar()
        {

            if (!IsDataItemNull) return View(RenderingPath.SingleItem +
                RenderingViews.LandingBar, new SimpleItem(DataItem));
            else return ShowDataSourceIsNullMessage();
        }



        public ActionResult DesktopMobileImageWithScreenReaderText()
        {

            if (!IsDataItemNull) return View(RenderingPath.SingleItem +
                RenderingViews.DesktopMobileImageWithScreenReaderText, new ContentItem(DataItem));
            else return ShowDataSourceIsNullMessage();
        }



        public ActionResult ContentItemHTML()
        {

            if (!IsDataItemNull) return View(RenderingPath.SingleItem +
                RenderingViews.ContentItemHTML, new ContentItem(DataItem));
            else return ShowDataSourceIsNullMessage();
        }

        public ActionResult ContentItemHTMLByOcode(string ocode)
        {

            if (!IsDataSourceNull)
            {

                try
                {
                    if (string.IsNullOrEmpty(ocode)) ocode = Defaults.OCode;

                    Item item = Sitecore.Context.Database.SelectSingleItem(ContentPath + Query.ByOCode + ocode + "']");
                    return View(RenderingPath.SingleItem +
                        RenderingViews.ContentItemHTMLByOCode, new ContentByPartnerItem(item));
                }

                catch (Exception exception)
                {
                    return ShowDataSourceIsNullMessage(exception.Message);
                }

            }
            else return ShowDataSourceIsNullMessage();

        }


        public ActionResult PartnerLogoByOCode(string ocode)
        {

            if (!IsDataSourceNull)
            {

                try
                {
                    if (string.IsNullOrEmpty(ocode)) ocode = Defaults.OCode;

                    Item item = Sitecore.Context.Database.SelectSingleItem(ContentPath + Query.ByOCode + ocode + "']");
                    return View(RenderingPath.SingleItem +
                        RenderingViews.PartnerLogoImage, new ContentItem(DataItem));
                }

                catch (Exception exception)
                {
                    return ShowDataSourceIsNullMessage(exception.Message);
                }

            }
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






        public ActionResult LogoImage()
        {

            if (!IsDataItemNull) return View(RenderingPath.SingleItem +
                RenderingViews.LogoImage, new ImageLinkItem(DataItem));
            else return ShowDataSourceIsNullMessage();
        }



        public ActionResult HeroImageAltSubTitle(string promo)
        {
            var repository = new SingleItemRepository();

            var HeroImageAltSubTitleModel = repository.getHeroImageAltSubTitleModel(DataItem, promo);

            return View(RenderingPath.SingleItem + 
                "HeroImageAltSubTitle.cshtml", HeroImageAltSubTitleModel);

        }
    }
}
