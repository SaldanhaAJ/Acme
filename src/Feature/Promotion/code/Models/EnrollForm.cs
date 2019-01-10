using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Epsilon.Infrastructure.Implementations.UI.DataAnnotationAttributes;
using System.ComponentModel.DataAnnotations;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;

namespace Acme.Feature.Promotion.Models
{
    /// <summary>
    /// This is a model of the Enroll form.
    /// </summary>
    public class EnrollForm : RenderingModel
    {
        #region Properties

        /// <summary>
        /// The First Name entered by the user on the Enroll form.
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [MustBeValidFirstNameAttribute]
        [Remote("IsValidFirstName", "Validation")]
        public String FirstName { get; set; }

        /// <summary>
        /// The Last Name entered by the user on the Enroll form.
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [MustBeValidLastNameAttribute]
        [RemoteAttribute("IsValidLastName", "Validation")]
        public String LastName { get; set; }

        /// <summary>
        /// The first email address field entered by the user on the Enroll form.
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [MustBeValidAddressAttribute]
        [RemoteAttribute("IsValidAddress1", "Validation")]
        public String Address1 { get; set; }

        /// <summary>
        /// The second email address field entered by the user on the Enroll form.
        /// </summary>
        [DataType(DataType.Text)]
        [MustBeValidAddressAttribute]
        [RemoteAttribute("IsValidAddress2", "Validation")]
        public String Address2 { get; set; }

        /// <summary>
        /// The currently selected Country VALUE from the Country drop down list.
        /// </summary>
        [Required]
        public String SelectedCountry { get; set; }

        /// <summary>
        /// The SelectList of Countries that will be used to populate the Country drop down list.
        /// </summary>
        public SelectList Countries { get; set; }

        /// <summary>
        /// The City field entered by the user on the Enroll form.
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [MustBeValidCityAttribute]
        [RemoteAttribute("IsValidCity", "Validation")]
        public String City { get; set; }

        /// <summary>
        /// The currently selected State VALUE from the State drop down List.
        /// </summary>

        public String SelectedState { get; set; }

        /// <summary>
        /// The SelectList of States that will be used to populate the State drop down list.
        /// </summary>
        public SelectList States { get; set; }

        /// <summary>
        /// The ZipCode entered by the user on the Enroll form.
        /// </summary>

        [Required]
        [DataType(DataType.Text)]
        [MustBeValidZip]
        [RemoteAttribute("IsValidZipCode", "Validation", AdditionalFields = "SelectedCountry")]
        public String ZipCode { get; set; }

        /// <summary>
        /// The SignUpEmailAddress field entered on the Enroll form.
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?")]
        public String SignUpEmailAddress { get; set; }

        public OptInOutModel OptInOut { get; set; }

        public String PromoCode { get; set; }

        public String Partner { get; set; }

        public String MilesOrPoints { get; set; }

        public String OfferCode { get; set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Standard parameterless constructor.
        /// </summary>
        public EnrollForm()
        {

        }

        /// <summary>
        /// Convenience constructor to allow us to populate the country and state SelectList properties.
        /// </summary>
        /// <param name="countries">A SelectList of countries.</param>
        /// <param name="states">A SelectList of states.</param>
        public EnrollForm(SelectList countries, SelectList states)
        {
            Countries = countries;
            States = states;
        }

        #endregion

    } // class
}