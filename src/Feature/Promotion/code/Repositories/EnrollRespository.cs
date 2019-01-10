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
    public class EnrollRespository
    {
        String contentPath;

        public EnrollRespository(string cp)
        {
            contentPath = cp;
        }


        public EnrollFormHeader getEnrollFormHeaderForPartner(string partner)
        {
            var viewModel = new EnrollFormHeader();
            //var rendering = RenderingContext.Current.Rendering;
            // var datasource = rendering.Item;

            if (partner == null) partner = "Default";
            string query = String.Format( contentPath +"/*[@Partner='{0}']", partner);

            Sitecore.Data.Database master = Sitecore.Context.Database;

            List<Item> items = master.SelectItems(query).ToList();

            foreach (Item item in items)
            {
                String pageZone = item[FieldNames.PageZone];
                String content = item[FieldNames.Content];
                if (pageZone != null)
                {
                    pageZone = pageZone.ToLower();
                    if (pageZone == PageZones.Header1.ToLower()) viewModel.HeaderText1 = new HtmlString(content);
                    if (pageZone == PageZones.Header2.ToLower()) viewModel.HeaderText2 = new HtmlString(content);
                    if (pageZone == PageZones.SubHeader1.ToLower()) viewModel.SubHeaderText1 = new HtmlString(content);
                    if (pageZone == PageZones.SubHeader2.ToLower()) viewModel.SubHeaderText2 = new HtmlString(content);
                    if (pageZone == PageZones.SubHeader3.ToLower()) viewModel.SubHeaderText3 = new HtmlString(content);
                }
            }

            return viewModel;
        }

        /*
        public EnrollFormHeader getEnrollItemForPromoAndPartner(string promo, string partner)
        {
            var viewModel = new EnrollFormHeader();
            //var rendering = RenderingContext.Current.Rendering;
            // var datasource = rendering.Item;

            if (partner == null) partner = "Default";
            string query = String.Format("/sitecore/content/{0}/Content/Enroll/*[@Partner='{1}']", promo, partner);

            Sitecore.Data.Database master = Sitecore.Context.Database;

            List<Item> items = master.SelectItems(query).ToList();

            foreach (Item item in items)
            {
                String pageZone = item[FieldNames.PageZone];
                String content = item[FieldNames.Content];
                if (pageZone != null)
                {
                    pageZone = pageZone.ToLower();
                    if (pageZone == PageZones.Header1.ToLower()) viewModel.HeaderText1 = new HtmlString(content);
                    if (pageZone == PageZones.Header2.ToLower()) viewModel.HeaderText2 = new HtmlString(content);
                    if (pageZone == PageZones.SubHeader1.ToLower()) viewModel.SubHeaderText1 = new HtmlString(content);
                    if (pageZone == PageZones.SubHeader2.ToLower()) viewModel.SubHeaderText2 = new HtmlString(content);
                    if (pageZone == PageZones.SubHeader3.ToLower()) viewModel.SubHeaderText3 = new HtmlString(content);
                }
            }

            return viewModel;
        }

        */

    }
}