using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Acme.Feature.Promotion.Models;
using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;
using Sitecore.Mvc.Controllers;

using Acme.Foundation.Helper;
using Acme.Feature.Promotion.Helpers;

namespace Acme.Feature.Promotion.Controllers
{
    public class FormController : Controller
    {
        //
        // GET: /Form/


        //[ActionName("StartBrowse")]
        public ActionResult Index()
        {
            return View( RenderingPath.Temp + RenderingViews.Form, new FormModel());
        }

        [HttpPost]
        [ValidRenderingToken]
        public ActionResult Index(FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return View("Success");

            }
        }
    }
}
