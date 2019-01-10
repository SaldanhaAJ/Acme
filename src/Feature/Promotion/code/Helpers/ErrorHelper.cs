using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Web.Configuration;
using System.Web.UI;
using Sitecore.Web;

namespace Acme.Feature.Promotion.Helpers{
    public static class ErrorHelper
    {
    // represents the /configuration/system.web/customErrors section of web.config
    private static CustomErrorsSection _config = null;

    // URL to handle server errors
    private static string _error500Url = null;

    // lazy-loading representation of /configuration/system.web/customErrors
    public static CustomErrorsSection Config
    {
      get
      {
        if (_config == null)
        {
          System.Configuration.Configuration config =
            WebConfigurationManager.OpenWebConfiguration("/");
          _config =
            (CustomErrorsSection)config.GetSection("system.web/customErrors");
          Sitecore.Diagnostics.Assert.IsNotNull(_config, "customErrors");
        }

        return _config;
      }
    }

    // lazy-loading URL to handle server errors
    public static string Error500Url
    {
      get
      {
        // if this application has not attempted to determine the error page 
        // to handle the HTTP 500 condition, but the 
        // /configuration/system.web/customErrors/error element exists in web.config,
        // check for a contained <error> element with a statusCode attribute of 500
        if (_error500Url == null && Config != null)
        {
          // check for a /configuration/system.web/customErrors/error 500 element
          CustomError error500 = Config.Errors.Get(
            500.ToString(System.Globalization.CultureInfo.InvariantCulture));

          if (error500 != null && !String.IsNullOrEmpty(error500.Redirect))
          {
            _error500Url = error500.Redirect;
          }

          // if no such elemenent exists, use the defaultRedirect attribute
          // of the /configuration/system.web/customErrors/error element
          if (String.IsNullOrEmpty(_error500Url))
          {
            _error500Url = Config.DefaultRedirect;
          }

          // default to using an empty string if the defaultRedirect attribute is null
          if (_error500Url == null)
          {
            _error500Url = String.Empty;
          }
        }

        return _error500Url;
      }
    }

    // Determine whether to redirect after an error.
    public static bool ShouldRedirect()
    {
      // if the user is debugging, they have authenticated; do not redirect
      if (Sitecore.Context.PageMode.IsDebugging)
      {
        return false;
      }

      // if the /configuraiton/system.web/customErrors element is absent
      if (Config == null)
      {
        return true;
      }

      // if redirection to friendly error pages is completely disabled
      if (Config.Mode == System.Web.Configuration.CustomErrorsMode.Off)
      {
        return false;
      }

      // if configured to redirect only remote clients and this client is local
      if (Config.Mode == System.Web.Configuration.CustomErrorsMode.RemoteOnly
        && System.Web.HttpContext.Current.Request.IsLocal)
      {
        return false;
      }

      // otherwise, redirect by default
      return true;
    }

    // implementation of redirection logic
    public static void Redirect()
    {
      if (!String.IsNullOrEmpty(Error500Url))
      {
        string url = Error500Url 
          + "?aspxerrorpath=" 
          + WebUtil.GetLocalPath(Sitecore.Context.RawUrl);
                WebUtil.Redirect(url);
      }
      else
      {
        WebUtil.RedirectToErrorPage(
          "replace this text with your friendly error message");
      }
    }

    // log an exception
    public static void LogException(string message, Exception ex, object owner)
    {
      Sitecore.Diagnostics.Log.Error(message, ex, owner);
    }

    // render an error to the client browser
    public static void RenderError(
      string message,
      string details,
      HtmlTextWriter output)
    {
      Sitecore.Web.UI.WebControls.ErrorControl errorControl;
      errorControl = Sitecore.Web.UI.WebControl.GetErrorControl(
          message,
          details) as Sitecore.Web.UI.WebControls.ErrorControl;
      Sitecore.Diagnostics.Assert.IsNotNull(errorControl, "ErrorControl");
      errorControl.RenderControl(output);
      string error = String.Format(
        "A rendering error occurred: {0} (details: {1})",
        message,
        details);
      Sitecore.Diagnostics.Log.Error(error, errorControl);
    }
    }
}