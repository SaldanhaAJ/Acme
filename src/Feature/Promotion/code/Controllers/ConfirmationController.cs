using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Acme.Feature.Promotion.Models;
using Acme.Feature.Promotion.Repositories;
using Acme.Feature.Promotion;
using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;
using Sitecore.Analytics;
using Sitecore.Data.Items;

using Acme.Foundation.Helper;


//
//
using Epsilon.DataAccess.Implementations.Cache;
using Epsilon.DataAccess.Implementations.Commands;
using Epsilon.DataAccess.Implementations.DomainObjects.Request;
using Epsilon.DataAccess.Implementations.DomainObjects.Response;
using Epsilon.Infrastructure.Implementations.UI.Views;
using Acme.Feature.Promotion.Helpers;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Acme.Feature.Promotion.Controllers
{
    public class ConfirmationController : Controller
    {
        //
        // GET: /Confirmation/

        [HttpGet]
        public ActionResult Index(String promo, string partner)
        {

            // TBD: Check if the promo and partner are valid

            var repository = new ConfirmationRepository();

//            var confirmationModel = repository.getConfirmationModel("HH42016", "Default");
            var confirmationModel = repository.getConfirmationModel(promo, partner);

            foreach (Item item in confirmationModel.items2)
            {

                Sitecore.Collections.FieldCollection fields = item.Fields;
                if (Sitecore.Data.Fields.FieldTypeManager.GetField(fields["Content"]) is Sitecore.Data.Fields.TextField)
                {
                    var richtextfield = item["Content"];
//                    Response.Write(richtextfield);

                }
                else
                {
//                    Response.Write("NOT A TEXTFIELD");


                }


            }





            //string query = "/sitecore/content/ShrinersHospital2/CareAndTreatment//*[@@templatename = 'CareAndTreatmentType' and @TreatmentType = '{ECDBE944-99DE-4347-8FA2-6613FA85402C}']";
            //var database = Sitecore.Configuration.Factory.GetDatabase("web");
            //items = database.SelectItems(query);

            return View(RenderingPath.Confirmation + RenderingViews.Confirmation, confirmationModel);

        }

    }
}
