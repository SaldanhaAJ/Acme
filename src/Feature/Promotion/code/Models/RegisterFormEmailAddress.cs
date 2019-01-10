using System;
using System.ComponentModel.DataAnnotations;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Acme.Feature.Promotion.Models
{
    public class RegisterFormEmailAddress : RegisterForm
    {
        #region Properties

        /// <summary>
        /// Represents the Password field on the Register form.
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?")]
        public String EmailAddress { get; set; }

        #endregion


    }
}