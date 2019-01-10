using System;
using System.ComponentModel.DataAnnotations;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Acme.Feature.Promotion.Models
{
    public class RegisterFormFFNumber : RegisterForm
    {
        #region Properties

        /// <summary>
        /// Represents the FrequentFlyernumber fiexld on the Register form.
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public String FFNumber { get; set; }

        #endregion


    }
}