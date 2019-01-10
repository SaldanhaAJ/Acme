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
    public class ContentByPartnerItem :  CustomItem
    {

    Item datasource;     

    public ContentByPartnerItem(Item item) : base(item)
    {
        
      Assert.IsNotNull(item, "item");
    }

    public string Title
    {
      get { return InnerItem[FieldId.Title]; }
    }

    public string MenuTitle
    {
      get { return InnerItem[FieldId.MenuTitle]; 
        }
    }

    public string Abstract
    {
      get { return InnerItem[FieldId.Abstract]; }
    }

    public string Body
    {
      get { return InnerItem[FieldId.Body]; }
    }

    public string ItemIcon
    {
      get { return InnerItem[FieldId.Icon]; }
    }

    public string Url
    {
      get { return LinkManager.GetItemUrl(InnerItem); }
    }
/*
    public string SearchDescription
    {
      get { return SiteConfiguration.GetPageDescripton(Item); }
    }
*/

   public string Content{
        
      get { return InnerItem[FieldId.Content]; }

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
      public static readonly ID Title = new ID("{234542DC-C610-4CA8-BAA6-2592A8BCB1D7}");
      public static readonly ID MenuTitle = new ID("{D7229DBA-B952-4D82-A5A0-459C69618D45}");
      public static readonly ID Abstract = new ID("{00E1D306-96BD-4B32-85B4-CD63C53CC6C1}");
      public static readonly ID Body = new ID("{5A5684BB-8B54-44F6-ABCC-2BADA05ADA5D}");
      public static readonly ID Icon = new ID("{2B60D8C1-81DB-45A7-B1CB-654CDDA96AE3}");

      public static readonly ID UseImageContent = new ID("{3B8630C3-D253-48C2-BB1E-A15BEFFA2977}");
      public static readonly ID Content = new ID("{9A9A4B3C-1580-48AC-BC25-D31064FF26A5}");
      public static readonly ID ContentTitle = new ID("{020B0BAA-D4F6-4875-811C-29A5B50BCB8D}");

      public static readonly ID Partner = new ID("{662CA47D-AA3F-4A16-9CE8-D02B4935A07B}");

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

