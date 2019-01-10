using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acme.Feature.Promotion.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        public ActionResult Index()
        {

            var logger = log4net.LogManager.GetLogger("Sitecore.FXM.Diagnostics");
            logger.Info("Hello, world. And by world, I mean a text file.");

            return View("_index");
        }

    }
}
