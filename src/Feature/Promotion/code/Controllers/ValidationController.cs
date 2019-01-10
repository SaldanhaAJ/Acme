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







namespace Acme.Feature.Promotion.Controllers
{
    public class ValidationController : BaseController
    {
        public ActionResult IsValidUserName()
        {
            var firstName = Request.Params["UserName"];
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
