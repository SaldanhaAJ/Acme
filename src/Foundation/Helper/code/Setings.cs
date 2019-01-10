using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acme.Foundation.Helper
{
    public static class Settings
    {
        //public static string CustomLCBLog4Prefix
        //{
        //    get
        //    {
        //        return Sitecore.Configuration.Settings.GetSetting("LCBLog4Prefix", "EpsilonLCB:");
        //    }
        //}
        public static string GetLCBContentFolderPath
        {
            get
            {
                //return _settings.GetSetting("LCBRegionsSitecoreFolderPath");

                return Sitecore.Context.Site.RootPath + "/" + Sitecore.Configuration.Settings.GetSetting("LCBRootFolderPath", "");
            }
        }
        public static string GetLCBMediaFolderPath
        {
            get
            {
                //return _settings.GetSetting("LCBRegionsSitecoreFolderPath");

                return "/sitecore/media library" + "/" + Sitecore.Configuration.Settings.GetSetting("LCBRootFolderPath", "");
            }
        }
        public static string GetLCBRegionContentFolderPath(string LCBInstance)
        {

            //return _settings.GetSetting("LCBRegionsSitecoreFolderPath");

            return Sitecore.Context.Site.RootPath + "/" + Sitecore.Configuration.Settings.GetSetting("LCBRootFolderPath", "") + "/" + LCBInstance + "/Regions";

        }
        public static string GetLCBRegionMediaFolderPath(string LCBInstance)
        {
            return "/sitecore/media library" + "/" + Sitecore.Configuration.Settings.GetSetting("LCBRootFolderPath", "") + "/" + LCBInstance + "/Regions";
        }


        public static string GetSetting(string key, string defaultValue = "")
        {
            return Sitecore.Configuration.Settings.GetSetting(key, defaultValue);
        }
        public static string GetGenericRTMMessageContentSitecoreItemId
        {
            get
            {
                //return _settings.GetSetting("LCBRegionsSitecoreFolderPath");

                return Sitecore.Configuration.Settings.GetSetting("HarmonyRTMMessage-GenericRTMMessageContentSitecore-ItemId", "");
            }
        }


        //public static int HarmonyNameMaxLength
        //{
        //    get
        //    {
        //        //return _settings.GetSetting("LCBRegionsSitecoreFolderPath");
        //        return Convert.ToInt32(Sitecore.Configuration.Settings.GetSetting("HarmonyNameMaxlength", "40"));


        //    }
        //}





    }
}