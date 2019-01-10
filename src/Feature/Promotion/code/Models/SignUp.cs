using System;
using System.ComponentModel.DataAnnotations;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using System.Web;


using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System.Collections.Generic;

namespace Acme.Feature.Promotion.Models
{
    public class SignUp : RenderingModel
    {

        public HtmlString SignUpHeader { get; set; }
        public HtmlString SignUpSubHeader { get; set; }
        public HtmlString SignUpLink { get; set; }

        public HtmlString SignUpHeader1 { get; set; }
        public HtmlString SignUpSubHeader1 { get; set; }
        public HtmlString SignUpSubHeader11 { get; set; }

        public HtmlString SignUpButtonText { get; set; }
        public HtmlString SignUpButtonLink { get; set; }

        public Item[] items;

        public List<Item> items2;

        public PageControlBase ControlBase { get; set; }


    }
}