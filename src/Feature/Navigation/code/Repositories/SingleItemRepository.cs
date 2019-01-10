using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

using Acme.Feature.Navigation.Models;
using Acme.Foundation.Helper;
using Acme.Feature.Navigation.Models;

namespace Acme.Feature.Navigation.Repositories
{
    public class SingleItemRepository
    {

        public HeroImageAltSubTitleModel getHeroImageAltSubTitleModel(Item datasource, string promo)
        {
            var viewModel = new HeroImageAltSubTitleModel();
            var rendering = RenderingContext.Current.Rendering;
           // var datasource = rendering.Item;
            string query = String.Format("fast: /sitecore/content/{0}/Content/Landing/*", promo);

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

/*
        public SignUpModel getSignUpModel()
        {
            var viewModel = new HeroImageAltSubTitleModel();
            var rendering = RenderingContext.Current.Rendering;
            var datasource = rendering.Item;

            viewModel.SignUpHeader1= FieldRenderer.Render(datasource, FieldNames.SignUpHeader1);
            viewModel.SignUpButtonText = FieldRenderer.Render(datasource, FieldNames.SignUpButtonText);

            return viewModel;

        }
*/



    }
}