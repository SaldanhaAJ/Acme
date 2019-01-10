using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Acme.Feature.Promotion.Helpers
{
    public class RegisterRoutes
    {

        public virtual void Process(Sitecore.Pipelines.PipelineArgs args)
        {
            RouteTable.Routes.MapRoute("controller", "controller/{controller}/{action}", new
            {
                action = "Index"
            });
        }
    }
}