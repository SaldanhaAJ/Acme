using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Acme.Feature.Promotion.Models;
using Acme.Foundation.Helper;

namespace Acme.Feature.Promotion.Repositories
{
    public class ConfirmationRepository
    {



        public ConfirmationModel getConfirmationModel(string promo, string partner)
        {

            var viewModel = new ConfirmationModel();
//            var rendering = RenderingContext.Current.Rendering;
//            var datasource = rendering.Item;
            if (partner == null) partner = "Default";
            string query =  String.Format("fast: /sitecore/content/{0}/Content/Confirmation/*[@Partner='{1}']", promo, partner);
            
            // does not work
//            string query = "select @@path, @@name as Name, @@templatekey as TemplateKey, @@id as ID, @Content, @@language from /sitecore/content/HH42016//*[@PageElement='Landing Page  Header 1' and @Partner='Default']";
            // works
//                        string query = "fast: /sitecore/content/HH42016//*[[@PageElement='header']";
//            string query = "fast: /sitecore/content/HH42016//*[@Partner='Default']";
//            string query = "fast: /sitecore/content/HH42016//*[@PageElement='header']";
//            string query = "fast: /sitecore/content/HH42016//*[@PageElement='header' and @Partner='Default']";
//              string query = "fast: /sitecore/content/HH42016//*[@PageElement='#Landing Page - Header 1#']";

            //                        string query = "fast:/sitecore/Content/Home";

           // Sitecore.Context.Language = Sitecore.Globalization.Language.Parse("en");
              Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");

//            viewModel.items = Sitecore.Context.Database.SelectItems(query);



//            List<Item> items = master.SelectItems(query).ToList();
//              viewModel.items2 = master.SelectItems(query).ToList();
              viewModel.items2 = master.SelectItems(query).ToList();

              List<Item> items = master.SelectItems(query).ToList();

              foreach (Item item in items)
              {
                  String pageZone = item[FieldNames.PageZone];
                  String content = item[FieldNames.Content];
                  if (pageZone != null)
                  {

                      pageZone = pageZone.ToLower();                      
                      if (pageZone == PageZones.Header1)viewModel.Header1 = content;
                      else if (pageZone == PageZones.Header2) viewModel.Header2 = content;
                      else if (pageZone == PageZones.Header3) viewModel.Header3 = content;
                      else if (pageZone == PageZones.SubHeader1) viewModel.SubHeader1= content;
                      else if (pageZone == PageZones.SubHeader2) viewModel.SubHeader2 = content;
                      else if (pageZone == PageZones.SubHeader3) viewModel.SubHeader3 = content;
                      else if (pageZone == PageZones.BodyContent1) viewModel.BodyContent1 = content;
                      else if (pageZone == PageZones.BodyContent2) viewModel.BodyContent2 = content;
                      else if (pageZone == PageZones.BookButton)
                      {
                          viewModel.BookNowText = content;
                          viewModel.BookNowLink = item["link"];
                      }
                      else if (pageZone == PageZones.BookNowMessage) viewModel.BookNowMessage = content;
                      else if (pageZone == PageZones.ConfirmationMessage) viewModel.ConfirmationMessage = content;
                  }



                  // Examine Field Type
                  /*
                  Sitecore.Collections.FieldCollection fields = item.Fields;
                  if (Sitecore.Data.Fields.FieldTypeManager.GetField(fields[FieldNames.Content]) is Sitecore.Data.Fields.TextField)
                  {
                      var richtextfield = item["Content"];

                  }
                   */
              }

            return viewModel;

        }


    }
}