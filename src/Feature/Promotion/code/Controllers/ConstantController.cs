using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System;
using System.Web.Mvc;

using Sitecore.Mvc;


namespace Acme.Feature.Promotion.Controllers
{
    public class ConstantController : Controller
    {
        public string DefaultAction()
        {
            if (Sitecore.Mvc.Presentation.PageContext.Current == null)
            {
                return "SC.Mvc.Presentation.PageContext.Current null {0}";
            }

            if (Sitecore.Mvc.Presentation.PageContext.Current.Item == null)
            {
                return "SC.Mvc.Presentation.PageContext.Current.Item null";
            }

            return String.Format(
              "SC.Mvc.Presentation.PageContext.Current.Item: {0} ({1})",
              Sitecore.Mvc.Presentation.PageContext.Current.Item.Paths.FullPath,
              Sitecore.Mvc.Presentation.PageContext.Current.Item.Language);
        }
    }
}
