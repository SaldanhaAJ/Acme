using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web;
using System.Linq;


using Acme.Foundation.Helper;

using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Links;
using Sitecore.Data.Fields;



namespace Acme.Feature.Promotion.Models
{
    public class EnrollFormHeader {
        public HtmlString HeaderText1 { get; set;}
        public HtmlString HeaderText2 { get; set;}
        public HtmlString HeaderText3 { get; set;}
        public HtmlString HeaderImage { get; set;}

        public HtmlString SubHeaderText1 { get; set;}
        public HtmlString SubHeaderText2 { get; set;}
        public HtmlString SubHeaderText3 { get; set; }

       
        public Guid ID { get; set; }

       
    }


}