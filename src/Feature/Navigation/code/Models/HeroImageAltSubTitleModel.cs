using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web;

using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;




namespace Acme.Feature.Navigation.Models
{
    public class HeroImageAltSubTitleModel : RenderingModel
//    public class HeroImageAltSubTitleModel : CustomItem
    {
        /*
       Item datasource;     
       public HeroImageAltSubTitleModel(Item item)
        {
          Assert.IsNotNull(item, "item");      
          datasource = item;
       }
       public HeroImageAltSubTitleModel(Item item)
           : base(item)
       {
           Assert.IsNotNull(item, "item");
           datasource = item;
       }

                public Item Item
       {
           get { return InnerItem; }
       }    
 
        public string Title1
       {
           get { return FieldRenderer.Render(datasource, Constants.SignUpHeader1); }
       }
 
        */

        public string HeroImage { get; set; }
        public string HeroImageMobile { get; set; }
        public string HeroImageAltTitle { get; set; }
        public string HeroImageAltSubTitle { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string Abstract { get; set; }



    }
}