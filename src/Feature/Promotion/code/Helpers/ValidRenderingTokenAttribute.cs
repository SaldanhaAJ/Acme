using System;
using System.Web.Mvc;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Layouts;
using SC = Sitecore;


namespace Acme.Feature.Promotion.Helpers
{
    public class ValidRenderingTokenAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            var rendering = RenderingContext.CurrentOrNull;
            if (rendering == null) return false;

            Guid postedId;
            return Guid.TryParse(controllerContext.HttpContext.Request.Form["uid"], out postedId) && postedId.Equals(rendering.Rendering.UniqueId);
        }
    }
}