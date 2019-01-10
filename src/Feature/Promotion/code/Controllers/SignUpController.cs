using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Acme.Feature.Promotion.Models;
using Acme.Feature.Promotion.Repositories;
using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;
using Sitecore.Analytics;
using Sitecore.Data.Items;



//
//
using Epsilon.DataAccess.Implementations.Cache;
using Epsilon.DataAccess.Implementations.Commands;
using Epsilon.DataAccess.Implementations.DomainObjects.Request;
using Epsilon.DataAccess.Implementations.DomainObjects.Response;
using Epsilon.Infrastructure.Implementations.UI.Views;
using Acme.Foundation.Helper;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Acme.Feature.Promotion.Controllers
{
    public class SignUpControllerOld : Controller
    {
        //

        [HttpGet]
        public ActionResult SignUp(String promo, string partner)
        {

            var repository = new SignUpRepository();

            var signUpModel = repository.getSignUpModel();
            signUpModel = repository.updateSignUpModel(signUpModel, promo);

            //string query = "/sitecore/content/ShrinersHospital2/CareAndTreatment//*[@@templatename = 'CareAndTreatmentType' and @TreatmentType = '{ECDBE944-99DE-4347-8FA2-6613FA85402C}']";
            //var database = Sitecore.Configuration.Factory.GetDatabase("web");
            //items = database.SelectItems(query);

            return View(RenderingPath.Member + "SignUp.cshtml", signUpModel);

        }

    }
}
