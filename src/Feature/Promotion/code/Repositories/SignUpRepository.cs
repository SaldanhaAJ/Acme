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
    public class SignUpRepository
    {
        public SignUp getSignUp(Item promoSiteSettings)
        {
            var viewModel = new SignUp();
            viewModel.ControlBase = new PageControlBase();

            var rendering = RenderingContext.Current.Rendering;
            var datasource = rendering.Item;

            viewModel.ControlBase.SiteSettingsPath = FieldRenderer.Render(datasource, FieldNames.SiteSettingsPath);
            viewModel.ControlBase.PromotionControlDataPath = FieldRenderer.Render(datasource, FieldNames.PromotionControlDataPath);

            viewModel.SignUpHeader = new HtmlString(FieldRenderer.Render(datasource, FieldNames.SignUpHeader));
            viewModel.SignUpSubHeader = new HtmlString(FieldRenderer.Render(datasource, FieldNames.SignUpSubHeader));
            viewModel.SignUpLink = new HtmlString(getEnrollPath(promoSiteSettings));
            //viewModel.SignUpButtonText = new HtmlString(FieldRenderer.Render(datasource, FieldNames.SignUpButtonText));

            return viewModel;

        }

        public String getEnrollPath(Item promoSiteSettings)
        {
            return promoSiteSettings.Fields[FieldNames.EnrollPagePath].ToString();

        }


        public SignUp getSignUpModel()
        {
            var viewModel = new SignUp();
            var rendering = RenderingContext.Current.Rendering;
            var datasource = rendering.Item;

            viewModel.SignUpHeader = new HtmlString(FieldRenderer.Render(datasource, FieldNames.SignUpHeader));
            viewModel.SignUpSubHeader = new HtmlString(FieldRenderer.Render(datasource, FieldNames.SignUpSubHeader));

            return viewModel;

        }


        public SignUp getSignUp()
        {
            var viewModel = new SignUp();
            var rendering = RenderingContext.Current.Rendering;
            var datasource = rendering.Item;

            viewModel.SignUpHeader = new HtmlString(FieldRenderer.Render(datasource, FieldNames.SignUpHeader));
            viewModel.SignUpSubHeader = new HtmlString(FieldRenderer.Render(datasource, FieldNames.SignUpSubHeader));

            return viewModel;

        }



        // Update model instance with content that is partner based 
        public SignUp updateSignUpModel(SignUp signUpModel, string promo)
        {

            var viewModel = signUpModel;
            var rendering = RenderingContext.Current.Rendering;
            var datasource = rendering.Item;
            string query = String.Format("fast: /sitecore/content/{0}/Content/Landing/*", promo);

            // Sitecore.Context.Language = Sitecore.Globalization.Language.Parse("en");
            //   Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
            Sitecore.Data.Database master = Sitecore.Context.Database;

            List<Item> items = master.SelectItems(query).ToList();

            foreach (Item item in items)
            {
                String pageZone = item[FieldNames.PageZone];
                String content = item[FieldNames.Content];

                if (pageZone != null)
                {
                    pageZone = pageZone.ToLower();
                    if (pageZone == PageZones.SignUpSubHeader1)
                    {
                        viewModel.SignUpSubHeader = new HtmlString(content);
                    }
                    else if (pageZone == PageZones.SignUpButtonLink) viewModel.SignUpButtonLink = new HtmlString(content);
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