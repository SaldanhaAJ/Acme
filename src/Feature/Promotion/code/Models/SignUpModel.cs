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
    public class SignUpModelOld : RenderingModel
    {

        public HtmlString SignUpHeader1 { get; set; }
        public HtmlString SignUpSubHeader1 { get; set; }
        public HtmlString SignUpSubHeader11 { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string Abstract { get; set; }

        public HtmlString SignUpButtonText { get; set; }
        public HtmlString SignUpButtonLink { get; set; }


        public Item[] items;

        public List<Item> items2;

    }
}