using System;
using System.ComponentModel.DataAnnotations;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;

namespace Acme.Feature.Promotion.Models
{
    public class RegisterModel : RenderingModel
//    public class RegisterModel : IRenderingModel
    {
        #region Properties


        /// <summary>
        /// Represents the Username fiexld on the Register form.
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
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

        #endregion


    }
}