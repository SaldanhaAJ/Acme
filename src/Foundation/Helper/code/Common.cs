using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acme.Foundation.Helper
{
    #region "Dictionary Keys"
    public static class DictionaryKeys
    {


        // Dictionary Domain
        public static String DictionaryDomain = "HiltonDictionaryDomain";


        //Error Messages
        public static String DuplicateEmailAddress = "DuplicateEmailAddress";
        public static String RequestTimedOut = "RequestTimedOut";
        public static String PromotionCodeExpired = "PromotionCodeExpired";
        public static String InvalidProductCode = "InvalidProductCode";

        public static String GeneralErrorMessageHeader = "GeneralErrorMessageHeader";
        public static String GeneralErrorMessageBody = "GeneralErrorMessageBody";


        //Validation Error Messages
        public static String InvalidLoginCredentials = "InvalidLoginCredentials";
        public static string InvalidCaptcha = "InvalidCaptcha";

        //Registration
        public static String Username = "Username";
        public static String Password = "Password";
        public static String SignIn = "Sign-In";
        public static String ForgotPassword = "ForgotPasswordText";
        public static String ForgotPasswordLink = "ForgotPasswordLink";
        public static String FFNumber = "FFNumber";
        //Sign-Up
        public static String SignUpHeader = "SignUpHeader";
        public static String SignUpButtonText = "SignUpButtonText";


        //Enroll
        public static String FirstName = "FirstName";
        public static String LastName = "LastName";
        public static String Address1 = "Address1";
        public static String Address2 = "Address2";
        public static String City = "City";
        public static String Country = "Country";
        public static String State = "State";

        public static String Zip = "Zip";
        public static String EmailAddress = "EmailAddress";
        public static String Register = "Register";
        public static String RequiredText = "RequiredText";
        public static String DisclaimerText = "DisclaimerText";


        // Dictionary Domain
        // Use the one above
        //public static String DictionaryDomain = "LCBDictionaryDomain";

        public static String Title = "Subscriber Title";
        //public static String FirstName = "Subscriber Firstname";
        //public static String LastName = "Subscriber Lastname";
        //public static String Address1 = "Subscriber Address1";
        //public static String Address2 = "Subscriber Address2";
        //public static String City = "Subscriber City";
        //public static String Country = "Subscriber Country";
        //public static String State = "Subscriber State";

        public static String PostalCode = "Subscriber Postalcode";
        //public static String EmailAddress = "Subscriber Email";
        public static String EmailAddressVerify = "Subscriber Email Verify";
        public static String BirthDay = "Subscriber Birthday";
        public static String BirthDayClear = "Subscriber Birthday Clear";
        public static String Subscribe = "Subscribe";

        //public static String RequiredText = "Required fields";
        public static String SubscriptionError = "Subscription Error";
        public static String PleaseSelect = "Please select";
        public static String SubscriberEmailCompareValidation = "Subscriber EmailCompare Validation";
        public static String SubscriberEmailValidation = "Subscriber Email Validation";




    }
    #endregion

    public static class Enums
    {


    }
    #region "Field Names"
    public class FieldNames
    {


        // Site confriguration
        public static String Languages = "Languages";
        public static String SiteSettingsPath = "SiteSettingsPath";
        public static String PromotionControlDataPath = "PromotionControlDataPath";
        public static String ConfirmationPagePath = "Confirmation";
        public static String AlreadyRegisteredPagePath = "AlreadyRegistered";
        public static String ErrorPagePath = "Error";
        public static String EnrollPagePath = "Enroll";


        public static String PromotionProjectType = "Promotion Project Type";
        public static String CountryDefault = "Country Default";
        public static String StateDefault = "State Default";
        public static String GTIRSupport = "Supports GTIR";
        public static String GUIDSupport = "Supports GUIDs";
        public static String CAPTCHASupport = "Supports CAPTCHA";

        /*
        SF more Sonar ProcessLanding Releated
        */
        public static String SupportsGTIR = "SupportsGTIR";
        public static String SupportsGUIDs = "SupportsGUIDs";
        public static String SupportsCAPTCHA = "SupportsCAPTCHA";
        public static String SuppressEnrollSection = "SuppressEnrollSection";
        public static String SendToLoginOnInvalidGUID = "SendToLoginOnInvalidGUID";
        public static String SendPromoRegistrationEmail = "SendPromoRegistrationEmail";

        public static String PromoCodeList = "PromoCodeList";
        public static String AffiliationCode = "AffiliationCode";

        public static String ConfirmationContent = "ConfirmationContent";
        public static String AlreadyRegisteredContent = "AlreadyRegisteredContent";
        public static String BodyContent = "BodyContent";
        public static String TermsAndConditionsBody = "TermsAndConditionsBody";





        public static String MainCss = "MainCss";
        public static String MainOLCss = "MainOLCss";
        public static String MainJPCss = "MainJPCss";
        public static String MainARCss = "MainARCss";

        //Field Names in SC templates
        public static String PageZone = "PageZone";
        public static String Content = "Content";


        public static String BookButton = "bookbutton";
        public static String Header1 = "header1";
        public static String Header2 = "header2";
        public static String Header3 = "header3";
        public static String SubHeader1 = "subheader1";
        public static String SubHeader2 = "subheader2";
        public static String SubHeader3 = "subheader3";
        public static String BodyContent1 = "body1";
        public static String BodyContent2 = "body2";
        public static String BookNowText = "booknowtext";
        public static String BookNowLink = "booknowlink";
        public static String BookNowMessage = "bookingmessage";
        public static String ConfirmationMessage = "confirmationmessage";


        public static String AltText = "AltText";
        public static String DisplayImage = "DisplayImage";
        public static String DoNotLink = "DoNotLink";
        public static String Image = "image";
        public static String ImageMobile = "imagemobile";
        public static String Text = "Text";
        public static String Title = "Title";
        public static String ToolTip = "ToolTip";
        public static String URL = "URL";
        public static String AltDesc = "AltDesc";
        public static String StyleInfo = "StyleInfo";
        public static String IsGTIRLink = "IsGTIRLink";


        //Sign Up Block 
        public static String SignUpHeader = "SignUpHeader";
        public static String SignUpSubHeader = "SignUpSubHeader";
        public static String SignUpHeader1 = "SignUpHeader1";
        public static String SignUpSubHeader1 = "signupsubheader1";
        public static String SignUpButtonText = "SignUpButtonText";
        public static String SignUpButtonLink = "signupbuttonlink";


        //Hero Image Block
        public static String HeroImage = "heroimage";
        public static String HeroImageMobile = "heroimagemobile";
        public static String HeroImageAltTitle = "heroimagealttitle";
        public static String HeroImageAltSubTitle = "heroimagealtsubtitle";



        //HARMONY FIELDS
        #region "HarmonyFields"
        public const string HarmonyMessageId = "HarmonyMessageId_HDS";
        public const string HarmonyListId = "HarmonyListId_HDS";
        public const string HarmonyListInternalName = "HarmonyList_InternalName_HDS";
        public const string HarmonyFolderId = "HarmonyFolderId_HDS";
        public const string HarmonyRealTimeEmailsMessageId = "RealTimeEmailsMessageId_HDS";
        public const string HarmonyEmailSettingsId = "HarmonyEmailSettingsId_HDS";
        public const string HarmonyPersistentMappingId = "HarmonyPersistentMappingId_HDS";
        public const string HarmonyBusinessUnitId = "XOUID_HDS";
        public const string HarmonyServerConnectionInfoId = "HarmonyServerConnectionInfoId_HDS";
        public const string HarmonyAuthorizedSendingDomainName = "HarmonyAuthorizedSendingDomainName";

        #endregion

        public const string GlobalOptoutSuffix = "Optout_Suffix";
        public const string GlobalOptoutURL = "globalout_url";

        #region GDPR 
        public const string GDPR_Profile_Freeze = "Freeze";
        public const string GDPR_Profile_FreezeDate = "FreezeDate";
        public const string GDPR_Profile_UnFreezeDate = "UnFreezeDate";
        #endregion

        #region Email
        public const string EmailFromName = "From Name";
        public const string EmailFromAddress = "From Address";
        public const string EmailReplyTo = "Reply To";
        public const string EmailIncludedRecipient = "Included Recipient Lists";
        #endregion
        //Header Fields
        public const string PropertyLogo = "PropertyLogo";
        public const string PropertyLobby = "PropertyLobby";
        public const string PropertyTitle = "PropertyTitle";

        //Footer Fields
        public const string FooterCopy = "FooterCopy";
        public const string FooterLinks = "FooterLinks";

        //Landing Page
        //public const string Title = "Title";
        public const string SubTitle = "SubTitle";
        public const string BodyText = "BodyText";

        public const string PropertyDescription = "PropertyDescription";
        public const string PropertyName = "PropertyName";
    }
    #endregion

    #region "Query Paths"
    public class Query
    {
        public const string Countries = "/sitecore/system/Settings/Analytics/Lookups/Countries/*";
        public const string Titles = "/sitecore/content/LCB/Shared/Global/Form Data Sources/Title/*";

        public static String GlobalLogoImage = "/sitecore/content/GlobalContent/Global Logo Image";
        public static String GlobalLogoBarLinks = "/sitecore/content/GlobalContent/Global Logo Bar Links";
        public static String GlobalGlobalSiteLinks = "/sitecore/content/GlobalContent/Global Site Links";
        public static String GlobalCustomerSupportLinks = "/sitecore/content/GlobalContent/Global Customer Support Links";
        public static String ByPartner = "/*[@Partner='";
        public static String ByOCode = "/*[@OCode='";
        public static String PromoList = "/sitecore/content/*/Configuration/*";
        public static String PromoSiteSettings_Query = "/sitecore/content/{0}/Configuration/SiteSettings";

    }
    #endregion

    #region "Paths"
    // Paths to the *.cshtml

    public class RenderingPath
    {
        public static String RenderingsBase_Path = "~/Views/";

        //        public static String RenderingsAcme_Path = RenderingsBase_Path + "Acme/";
                public static String RenderingsAcme_Path = RenderingsBase_Path + "";
        public static String RenderingsTemp_Path = RenderingsBase_Path + "temp/";

        //        public static String Register = RenderingsAcme_Path + "Register/";
        //        public static String Enroll = RenderingsAcme_Path + "Enroll/";
        public static String Member = RenderingsAcme_Path + "Member/";


        public static String Confirmation = RenderingsAcme_Path + "Confirmation/";
        public static String SingleItem = RenderingsAcme_Path + "SingleItem/";
        public static String ListItem = RenderingsAcme_Path + "ListItem/";
        public static String Admin = RenderingsAcme_Path + "Admin/";
        public static String Error = RenderingsAcme_Path + "Error/";

        public static String Shared = "~/Views/Shared/";

        public static String Temp = RenderingsAcme_Path + "temp/";


        //public const string RenderingsBase_Path = "~/Views/";
        //public const string RenderingsAccount_Path = RenderingsBase_Path + "Subscription/";
        //public const string Subscription = RenderingsAccount_Path;

    }
    #endregion

    #region "Rendering Views"

    public class RenderingViews
    {

        // Membership/Account Related
        public static String Register = "Register.cshtml";
        public static String RegisterForm = "RegisterForm.cshtml";
        public static String RegisterFormServer = "RegisterFormServer.cshtml";
        public static String RegisterFormFFNumber = "RegisterFormFFNumber.cshtml";
        public static String RegisterFormEmailAddress = "RegisterFormEmailAddress.cshtml";

        public static String EnrollForm = "EnrollForm.cshtml";
        public static String EnrollFormHeader = "EnrollFormHeader.cshtml";
        public static String EnrollFormFooter = "EnrollFormFooter.cshtml";
        public static String SignUp = "SignUp.cshtml";
        public static String OptInOptOutCheckBoxes = "_OptInOutCheckBoxes.cshtml";

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


        //Landing
        public static String LandingBar = "LandingBar.cshtml";

        // Confirmation
        public static String Confirmation = "Confirmation.cshtml";
        public static String AppStoreLinks = "AppStoreLinks.cshtml";


        //Messages 
        public static String PageMessage = "PageMessage.cshtml";

        //Error Page Message
        public static String ErrorMessage = "ErrorMessage.cshtml";


        //UI Elements - Button With Text
        public static String ButtonWithText = "ButtonWithText.cshtml";
        //Temp form
        public static String Form = "_form.cshtml";


        // From LCB //

        public const string SubscriptionForm = "Subscription.cshtml";
        public const string Header = "Header.cshtml";
        public const string Footer = "Footer.cshtml";
        public const string Landing = "Landing.cshtml";



    }

    #endregion


    public class TemplateFieldTypes
    {
        public static String TemplateSectionData = "Data";

        public static String FieldTypeDropList = "Droplist";
        public static String FieldTypeSingleLineText = "Single-Line Text";
        public static String FieldTypeImage = "Image";

    }


    public class ErrorMessages
    {
        public static String MessageMissing = "Message is missing for language";
        public static String MessageNoContent = "No content for :";


    }


    public class Defaults
    {
        public static String StyleSheet = "sf_mainol.css"; //default style shet if not is specified in the style widget
        public static String StyleSheetBasePath = "/docs/styles/";


        public static String MainCss = "/Content/styles/mainol.css";
        public static String MainOLCss = "/Content/styles/mainol.css";
        public static String MainARCss = "/Content/styles/mainar.css";
        public static String MainJPCss = "/Content/styles/mainjp.css";
        public static String Partner = "Default";
        public static String Country = "US";
        public static String State = "AL";
        public static String OCode = "Default";


        //Rgistration - Sign In
        public static String RegisterContentHeader = "MEMBER LOGIN";
        public static String RegisterSubContentHeader = "Just sign in to your account to register for the promotion.";
        public static String RegisterSignin = "SIGN IN>";
        public static String RegisterForgotPasswordLink = "https://secure3.hilton.com/en/hh/customer/login/forgotPassword.htm";
        public static String RegisterForgotPasswordText = "FORGOT PASSWORD>";

        //Sign-Up
        public static String SignUpHeader = "JOIN HHONORS";
        public static String SignUpSubHeader = "Join for free and get immediate benefits.";
        public static String SignUpMessage = "";
        public static String SignUpButtonText = "SIGN-UP>";


    }


    public class Languages
    {
        public static String English = "EN";


    }

    public class PageZones
    {
        public static String BookButton = "bookbutton";
        public static String Header1 = "header1";
        public static String Header2 = "header2";
        public static String Header3 = "header3";
        public static String SubHeader1 = "subheader1";
        public static String SubHeader2 = "subheader2";
        public static String SubHeader3 = "subheader3";
        public static String BodyContent1 = "body1";
        public static String BodyContent2 = "body2";
        public static String BookNowText = "booknowtext";
        public static String BookNowLink = "booknowlink";
        public static String BookNowMessage = "bookingmessage";
        public static String ConfirmationMessage = "confirmationmessage";

        //Sign Up Block 
        public static String SignUpHeader1 = "SignUpHeader1";
        public static String SignUpSubHeader1 = "signupsubheader1";
        public static String SignUpButtonText = "SignUpButtonText";
        public static String SignUpButtonLink = "signupbuttonlink";


        //Hero Image Block
        public static String HeroImage = "heroimage";
        public static String HeroImageMobile = "heroimagemobile";
        public static String HeroImageAltTitle = "heroimagealttitle";
        public static String HeroImageAltSubTitle = "heroimagealtsubtitle";



    }



    public class Constants
    {
        #region "Contacts"
        public const string ContactSource = "LCB";
        #endregion
        #region "Database"
        public const string WebDb = Epsilon.Digital.Sc.Constants.WebDb;
        public const string MasterDb = Epsilon.Digital.Sc.Constants.MasterDb;
        public const string SitecoreDomain = "sitecore";
        #endregion


        #region Property Creation
        public const string ContactListFolder = "/sitecore/system/Marketing Control Panel/Contact Lists";
        public const string ExmAdvancedUsersRole = "EXM Advanced Users";
        // public const string DomainName = "sitecore";
        #endregion

    }

}