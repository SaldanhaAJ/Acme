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
using Acme.Feature.Promotion.Helpers;

namespace Acme.Feature.Promotion.Models
{
    public class ImageLinkItem {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string AltText { get; set; }
        public string ToolTip { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }

        
        public ImageLinkItem()
        {

        }

        public ImageLinkItem(Item item)
        {
            if (item != null)
            {
                ID = item.ID.Guid;
                Title = item.Fields[FieldNames.Title].Value;
                AltText = item.Fields[FieldNames.AltText].Value; 
                //ToolTip = item.Fields["ToolTip"].Value;
                Image = UIHelpers.GetImageURL(item, FieldNames.Image);
                URL = item.Fields[FieldNames.URL].Value;

            }
        }

    }


}