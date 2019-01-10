using System;
using System.ComponentModel.DataAnnotations;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Acme.Feature.Promotion.Models
{
    public class RegisterForm : RenderingModel
//    public class RegisterModel : IRenderingModel
    {
        #region Properties

//        public Sitecore.Mvc.Presentation.Rendering Rendering { get; set; }
//        // Item represents the rendering's datasource, and PageItem represents the context page
//        // These properties exist on Sitecore's own RenderingModel object
//        public Sitecore.Mvc.Presentation.Rendering.Item Item { get; set; }
//        public Sitecore.Mvc.Presentation.Rendering.Item PageItem { get; set; }

//        public void Initialize(Sitecore.Mvc.Presentation.Rendering rendering)
//        {
//            // Use the Rendering object passed in by Sitecore to set the datasource Item and context PageItem properties
//            Rendering = rendering;
//            Item = rendering.Item;
//            PageItem = PageContext.Current.Item;

//            // Set property values using FieldRenderer to ensure that the values are editable in the Page Editor
////            Make = new HtmlString(FieldRenderer.Render(Item, "Make"));
////            Model = new HtmlString(FieldRenderer.Render(Item, "Model"));
//        }


        /// <summary>
        /// Represents the Username fiexld on the Register form.
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [Remote("IsValidUserName", "Validation")]
        public String Username { get; set; }

        /// <summary>
        /// Represents the Password field on the Register form.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        /// <summary>
        /// This property represents the original OCode  value . 
        /// We preserve it in our model here until we need to access it later.
        /// </summary>
        public String OCode { get; set; }

        /// <summary>
        /// This property represents the original OCode  value . 
        /// We preserve it in our model here until we need to access it later.
        /// </summary>
        public String PromoCode { get; set; }
        
        public String Promo { get; set; }

        public String Partner { get; set; }

        public String MilesOrPoints { get; set; }

        public String OfferCode { get; set; }

        public PageControlBase ControlBase { get; set; }

        #endregion

        /*
        public Rendering Rendering { get; set; }
        public Sitecore.Mvc.Presentation.Rendering { get; set; }

        public void Initialize(Rendering rendering)
        {

        }
         * */

    }
}