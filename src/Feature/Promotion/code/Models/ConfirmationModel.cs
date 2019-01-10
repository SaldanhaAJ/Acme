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
    public class ConfirmationModel: RenderingModel
    {
        public string Header1{ get; set; }
        public string Header2 { get; set; }
        public string Header3 { get; set; }
        public string SubHeader1 { get; set; }
        public string SubHeader2 { get; set; }
        public string SubHeader3 { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string Abstract { get; set; }

        public string BodyContent1 { get; set; }
        public string BodyContent2 { get; set; }
        
        public string BookNowText { get; set; }
        public string BookNowLink { get; set; }

        public string BookNowMessage  { get; set; }
        public string ConfirmationMessage { get; set; }



        
        public Item[] items;

        public List<Item> items2;

    }
}