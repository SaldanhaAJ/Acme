using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Acme.Feature.Promotion.Models;
using Acme.Feature.Promotion.Repositories;

using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;


using Epsilon.DataAccess.Implementations.Cache;
using Epsilon.DataAccess.Implementations.Commands;
using Epsilon.DataAccess.Implementations.DomainObjects.Request;
using Epsilon.DataAccess.Implementations.DomainObjects.Response;
using Epsilon.Infrastructure.Implementations.UI.Views;
using Acme.Foundation.Helper;





using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



using Sitecore.Analytics;

using Acme.Feature.Promotion.Models;
using Acme.Foundation.Helper;


using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Links;





namespace Acme.Feature.Promotion.Controllers
{
    public class MetaController : BaseController
    {

        public string Css()
        {

            String cssPath = String.Empty;
            if (!IsDataItemNull)
            {
                if (CurrentLanguage() == Languages.English)
                {
                    cssPath = DataItem.Fields[FieldNames.MainCss].Value.ToLower();
                    if (!(String.IsNullOrEmpty(cssPath) || cssPath.Length==0)) return String.Format("<link rel=\"stylesheet\" href=\"/Content/styles/{0}\" />", cssPath);
                    else  return String.Format("<link rel=\"stylesheet\" href=\"{0}\" />", Defaults.MainCss);
                }
                else
                {
                    cssPath = DataItem.Fields[FieldNames.MainOLCss].Value.ToLower();
                    if (!(String.IsNullOrEmpty(cssPath) || cssPath.Length == 0)) return String.Format("<link rel=\"stylesheet\" href=\"/Content/styles/{0}\" />", cssPath);
                    else  return String.Format("<link rel=\"stylesheet\" href=\"{0}\" />", Defaults.MainOLCss);
                }

            }
            else 
            return String.Format("<link rel=\"stylesheet\" href=\"{0}\" />", Defaults.MainCss);
        }



    }

}
