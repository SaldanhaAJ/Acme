using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Acme.Feature.Promotion
{
    public class CaptchaUtil
    {

        public static string GetPrivateKey()
        {
            var privateKey = "";

            privateKey = WebConfigurationManager.AppSettings["RecaptchaPrivateKey"];

            return privateKey;

        }

        public static string GetCaptchaLanguageCode(string languageCode)
        {
            var langUtil = new LanguageUtil();
            return langUtil.GetGoogleCaptchaCode(languageCode);

        }

        public static string GetPublicKey()
        {
            var publicKey = "";

            publicKey = WebConfigurationManager.AppSettings["RecaptchaPublicKey"];

            return publicKey;

        }

        public static string GetCaptchaUrl()
        {
            return WebConfigurationManager.AppSettings["CaptchaURL"];
        }

        public static string GetEnvironment()
        {

            var environment = "";
            var serverName = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            if (serverName != null)
            {
                if (serverName.IndexOf("hilt.uat", StringComparison.Ordinal) >= 0 || serverName.IndexOf("uat.hhonors", StringComparison.Ordinal) >= 0)
                {
                    //* *hilt.uat *@
                    environment = "UAT";
                }
                else if (serverName.IndexOf("hilt.dev", StringComparison.Ordinal) >= 0 || serverName.IndexOf("hilt.qa", StringComparison.Ordinal) >= 0)
                {
                    //* *hilt.dev, 
                    environment = "DEV";
                }
                else if (serverName.IndexOf("hilt.qa", StringComparison.Ordinal) >= 0 || serverName.IndexOf("hilt.qa", StringComparison.Ordinal) >= 0 || serverName.IndexOf("localhost", StringComparison.Ordinal) >= 0)
                {
                    //**hilt.qa
                    environment = "QA";
                }
                //                else if (serverName.IndexOf("hilt.dev", StringComparison.Ordinal) >= 0 || serverName.IndexOf("hilt.qa", StringComparison.Ordinal) >= 0 || serverName.IndexOf("localhost", StringComparison.Ordinal) >= 0)
                else if (serverName.IndexOf("localhost", StringComparison.Ordinal) >= 0)
                {
                    //**localhost
                    environment = "LOCAL";
                }
                else
                {
                    //*  use the PROD URL *@
                    environment = "PROD";
                }
            }
            else
            {
                //* cannot get sever info - use the PROD URL *@
                environment = "PROD";
            }
            return environment;
        }


    }
}