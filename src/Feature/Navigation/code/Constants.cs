using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Acme.Foundation.Helper;

namespace Acme.Feature.Navigation
{
    public class Constants
    {
    }

    #region "Paths"
    // Paths to the *.cshtml

    public class RenderingPath
    {
        public static String Navigation = Acme.Foundation.Helper.RenderingPath.RenderingsAcme_Path + "Navigation/";



    }
    #endregion

    #region "Rendering Views"

    public class RenderingViews
    {


        //Logo
        public static String LogoImage = "LogoImage.cshtml";
        //List of Language Drop Down Languages
        public static String LanguageDropDown = "LanguageDropDown.cshtml";
        //List of  Global Site Links
        public static String GlobalSiteLinks = "GlobalSites.cshtml";
        //List of Logo Bar Links
        public static String LogoBarLinks = "LogoBar.cshtml";
        public static String LogoBarLinks_2 = "LogoBar_2.cshtml";

        // List of Icon Images
        public static String IconBagImageLinkItems = "IconBagImageLinkItems.cshtml";
        //List of Customer Support Links
        public static String CustomerSupportLinks = "CustomerSupportLinks.cshtml";
        //List of Intant Benefits
        public static String InstantBenefitLinks = "InstantBenefitLinkItems.cshtml";

        // Content By Partner/Ocode Items
        public static String ContentItemHTMLByOCode = "ContentItemHTMLByOCode.cshtml";
        public static String DesktopMobileImagesWithScreenReaderText = "DesktopMobileImagesWithScreenReaderText.cshtml";
        public static String TermsAndConditionsContentItems = "TermsAndConditionsContentItems.cshtml";
        public static String PartnerLogoImage = "PartnerLogoImage.cshtml";



        //Content Item Type Views
        public static String DesktopMobileImageWithScreenReaderText = "DesktopMobileImageWithScreenReaderText.cshtml";
        public static String ContentItemHTML = "ContentItemHTML.cshtml";
        public static String TermsAndConditionsContentItem = "TermsAndConditionsContentItem.cshtml";
        //Promo List
        public static String PromoList = "PromoList.cshtml";



        //Messages 
        public static String PageMessage = "PageMessage.cshtml";

        //Error Page Message
        public static String ErrorMessage = "ErrorMessage.cshtml";


    }

    #endregion

}