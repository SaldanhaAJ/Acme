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
    public class RegisterRepository
    {

        public RegisterForm getRegisterForm(Item promoSiteSettings)
        {
            var viewModel = new RegisterForm();
            viewModel.ControlBase = new PageControlBase();

            var rendering = RenderingContext.Current.Rendering;
            var datasource = rendering.Item;

            viewModel.ControlBase.SiteSettingsPath = FieldRenderer.Render(datasource, FieldNames.SiteSettingsPath);
            viewModel.ControlBase.PromotionControlDataPath = FieldRenderer.Render(datasource, FieldNames.PromotionControlDataPath);

            return viewModel;

        }

        public String getConfirmationPath(Item promoSiteSettings)
        {
            return promoSiteSettings.Fields[FieldNames.ConfirmationPagePath].ToString();
            
        }

        public String getErrorPath(Item promoSiteSettings)
        {
            return promoSiteSettings.Fields[FieldNames.ErrorPagePath].ToString();

        }

        public String getAlreadyRegisteredPath(Item promoSiteSettings)
        {
            return promoSiteSettings.Fields[FieldNames.AlreadyRegisteredPagePath].ToString();

        }

        public RegisterForm getRegisterForm(string promo, string partner)
        {
            var viewModel = new RegisterForm();
            viewModel.ControlBase = new PageControlBase();

            var rendering = RenderingContext.Current.Rendering;
            var datasource = rendering.Item;

            var data = FieldRenderer.Render(datasource, "Data");
            // assign model value from SC
            var temp = FieldRenderer.Render(datasource, "usrplaceholder");
            /*
            Sitecore.Data.Items.Item parentItem = PageContext.Current.Item;
            var result = "";
            foreach (Item child in parentItem.Children)
            {
                // child.Template.Name
                result += child.Name + ",";
            }
            */

            viewModel.PromoCode = "some code";
            viewModel.Promo = promo;

            viewModel.Partner = partner;

            return viewModel;

        }


        public RegisterModel getRegisterModel(string promo, string partner)
        {
            var viewModel = new RegisterModel();

            var rendering = RenderingContext.Current.Rendering;
            var datasource = rendering.Item;

            var data = FieldRenderer.Render(datasource, "Data");
            // assign model value from SC
            var temp = FieldRenderer.Render(datasource, "usrplaceholder");

            Sitecore.Data.Items.Item parentItem = PageContext.Current.Item;
var result="";
 foreach(Item child in parentItem.Children) {
     // child.Template.Name
      result += child.Name + ",";
  }
            
            //viewModel.City = FieldRenderer.Render(datasource, "Name");
            // This retrieves the 'Background' parameter from the context rendering
            //viewModel.Background = rendering.Parameters["Background"];
            //viewModel.ContextItem = PageContext.Current.Item;
            //viewModel.Driver = driver;

            viewModel.PromoCode = "some code";
            viewModel.Promo = promo;

            viewModel.Partner = partner;

            return viewModel;

        }
    }
}