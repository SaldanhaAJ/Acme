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
    public class LinkItem {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ToolTip { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }
        public string AltDesc { get; set; }
        public string StyleInfo { get; set; }

        public Boolean DisplayImage { get; set;}
        public Boolean DoNotLink { get; set; }
        public Boolean IsGTIRLink { get; set; }

        
        public LinkItem()
        {

        }

        public LinkItem(Item item)
        {
            if (item != null)
            {
                ID = item.ID.Guid;

                Title = item.Fields[FieldNames.Title].Value;
                //ToolTip = item.Fields["ToolTip"].Value;
                Image = UIHelpers.GetImageURL(item, FieldNames.Image);
                URL = item.Fields[FieldNames.URL].Value;

                Text = item.Fields[FieldNames.Text].Value; 
                ToolTip = item.Fields[FieldNames.ToolTip].Value;
                Image = UIHelpers.GetImageURL(item, FieldNames.Image);
                URL = item.Fields[FieldNames.URL].Value;
                AltDesc = item.Fields[FieldNames.AltDesc].Value;
                StyleInfo = item.Fields[FieldNames.StyleInfo].Value;
 
                CheckboxField field = (CheckboxField)item.Fields[FieldNames.DoNotLink];
                if (field != null)
                {
                    DoNotLink = field.Checked;
                }
                else { DoNotLink = false; }

                field = (CheckboxField)item.Fields[FieldNames.DisplayImage];
                if (field != null)
                {
                    DisplayImage = field.Checked;
                }
                else { DisplayImage = false; }

                field = (CheckboxField)item.Fields[FieldNames.IsGTIRLink];
                if (field != null)
                {
                    IsGTIRLink = field.Checked;
                }
                else { IsGTIRLink = false; }

            
            }
        }

    }

    /*
    public class LinkItem :  CustomItem
    {

    public LinkItem(Item item)
        : base(item)
    {
        
      Assert.IsNotNull(item, "item");      
         
    }

    public string Title
    {
      get { return InnerItem[FieldId.Title]; }
    }

    public string ToolTip
    {
      get { return InnerItem[FieldId.ToolTip]; 
        }
    }

    public string Text
    {
      get { return InnerItem[FieldId.Text]; }
    }


    public string Image
    {
      get { return InnerItem[FieldId.Image]; }
    }

    public string Url
    {
        get { return InnerItem[FieldId.URL]; ; }
    }

    public Item Item
    {
      get { return InnerItem; }
    }
    public IEnumerable<SimpleItem> ChildrenInCurrentLanguage
    {
      get
      {
        return InnerItem.Children.Select(x => new SimpleItem(x)).Where(x => SiteConfiguration.DoesItemExistInCurrentLanguage(x.Item));
      }
    }

    public IEnumerable<SimpleItem> Children
    {
      get
      {
        return InnerItem.Children.Select(x => new SimpleItem(x));
      }
    }
    public static class FieldId
    {


        public static readonly ID Title = new ID("{5B5395C1-11FF-4D17-A080-A43D504879CC}");
        public static readonly ID ToolTip = new ID("{7460C905-E609-493E-88EE-D413579A3D6A}");
        public static readonly ID URL = new ID("{BAAD398A-3EAF-43CC-8A1A-A308D2000BD3}");
      public static readonly ID Text = new ID("{8005378B-1505-4D45-AD6C-89D46F879AFB}");
      public static readonly ID Image = new ID("{2B60D8C1-81DB-45A7-B1CB-654CDDA96AE3}");
    }


    }
*/

}