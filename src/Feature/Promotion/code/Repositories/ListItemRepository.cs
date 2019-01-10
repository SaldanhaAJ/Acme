using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Acme.Feature.Promotion.Models;
using Acme.Foundation.Helper;
using Acme.Feature.Promotion.Helpers;

namespace Acme.Feature.Promotion.Repositories
{
    public class ListItemRepository
    {

        public HeroImageAltSubTitleModel getPromos(Item datasource, string promo)
        {
            var viewModel = new HeroImageAltSubTitleModel();
            var rendering = RenderingContext.Current.Rendering;
           // var datasource = rendering.Item;
            string query = Query.PromoList;

            Sitecore.Data.Database master = Sitecore.Context.Database;

            List<Item> items = master.SelectItems(query).ToList();

            foreach (Item item in items)
            {
                String pageZone = item[FieldNames.PageZone];
                String content = item[FieldNames.Content];
                if (pageZone != null)
                {
                    pageZone = pageZone.ToLower();
                    if (pageZone == PageZones.HeroImageAltSubTitle) viewModel.HeroImageAltSubTitle = content;
                    if (pageZone == PageZones.HeroImage) viewModel.HeroImage = UIHelpers.GetImageURL(item, FieldNames.Image);
                    if (pageZone == PageZones.HeroImageMobile) viewModel.HeroImageMobile = UIHelpers.GetImageURL(item, FieldNames.Image);
                    else if (pageZone == PageZones.HeroImageAltTitle) viewModel.HeroImageAltTitle = content;
                }
            }

            return viewModel;
        }



    }
}