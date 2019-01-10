using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web;
using System.Linq;


using Acme.Foundation.Helper;
using Acme.Feature.Navigation.Models;




using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Links;


namespace Acme.Feature.Navigation.Models
{
    public class ContentItem :  CustomItem
    {

    Item datasource;     

    public ContentItem(Item item) : base(item)
    {
        
      Assert.IsNotNull(item, "item");
    }

   public HtmlString Content{
        
      get { return new HtmlString((InnerItem[FieldId.Content])); }

   }

   public HtmlString ContentTitle
   {

       get { return new HtmlString((InnerItem[FieldId.ContentTitle])); }

   }

   public string ImageAltText
   {

       get { return InnerItem[FieldId.ImageAltText]; }

   }

   public string ImageTitle
   {

       get { return InnerItem[FieldId.ImageTitle]; }

   }

   public string ScreenReaderTitle
   {

       get { return InnerItem[FieldId.ScreenReaderTitle]; }

   }

   public string ScreenReaderSubTitle
   {

       get { return InnerItem[FieldId.ScreenReaderSubTitle]; }

   }



   public string Image
   {

       get { 
        
        return UIHelpers.GetImageURL(Item ,  FieldNames.Image); 
    }

   }


   public string ImageMobile
   {

       get {
           return UIHelpers.GetImageURL(Item, FieldNames.Image);
       }

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

      public static readonly ID UseImageContent = new ID("{5312ABEA-0D27-488D-B3AA-D3CCDDE4022F}");
      public static readonly ID Content = new ID("{71C897F5-B8D3-440F-9529-E23C509283BD}");
      public static readonly ID ContentTitle = new ID("{020B0BAA-D4F6-4875-811C-29A5B50BCB8D}");

      // Ref content Image Template IDs  
      public static readonly ID Image = new ID("{AC46A430-C05E-48B0-8C5C-CB22AC081279}");
      public static readonly ID ImageAltText = new ID("{164F9A73-750A-4AEC-A880-94DCAF64683B}");
      public static readonly ID ImageMobile = new ID("{FCB3D70E-D72F-4B42-BA5F-1E393EA94375}");
      public static readonly ID ImageTitle = new ID("{BE8FA9E9-678B-4403-B0AF-B2AE3BB07979}");
      public static readonly ID ScreenReaderTitle = new ID("{A1F43CF9-FACB-4239-923D-644704DF6F6C}");
      public static readonly ID ScreenReaderSubTitle = new ID("{23B0BB62-E80E-4FCC-A728-4D85F99F7DB9}");

    }


    }
}

