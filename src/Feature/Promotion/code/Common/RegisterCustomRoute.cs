using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using Sitecore.Pipelines;


namespace Acme.Feature.Promotion
{
    public class RegisterCustomRoute
    {
        public virtual void Process(PipelineArgs args)
        {
            RouteTable.Routes.MapRoute("CustomRoute", "some/route/{controller}/{action}/{id}");
        }
    }
}