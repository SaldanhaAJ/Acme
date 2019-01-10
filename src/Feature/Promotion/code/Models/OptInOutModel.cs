using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web;
using System.Linq;



using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Links;

using Epsilon.Infrastructure.Implementations.UI.DataAnnotationAttributes;


namespace Acme.Feature.Promotion.Models
{
    public class OptInOutModel
    {
        #region Properties

        /// <summary>
        ///     The selection status of the  CheckedConfirmAge on the Enroll form.
        ///     <remarks>
        ///         We're using a custom attribute here to force it to be checked.
        ///     </remarks>
        /// </summary>
        [MustBeChecked]
        public Boolean CheckedConfirmAge { get; set; }

        /// <summary>
        ///     The selection status of the CheckedTerms on the Enroll form.
        ///     <remarks>
        ///         We're using a custom attribute here to force it to be checked.
        ///     </remarks>
        /// </summary>
        [MustBeChecked]
        public Boolean CheckedTerms { get; set; }

        /// <summary>
        ///     The selection status of the CheckBox CheckedTerms2 on the Enroll form.
        ///     <remarks>
        ///         We're using a custom attribute here to force it to be checked.
        ///     </remarks>
        /// </summary>
        [MustBeChecked]
        public Boolean CheckedTerms2 { get; set; }

        /// <summary>
        ///     The selection status of the ContactByHHonors on the Enroll form.
        ///     <remarks>
        ///         We're using a custom attribute here to force it to be checked.
        ///     </remarks>
        /// </summary>
        [MustBeChecked]
        public Boolean ContactByHHonors { get; set; }


        /// <summary>
        ///     The selection status of the CheckBox Button4 on the Enroll form.
        ///     <remarks>
        ///         We're using a custom attribute here to force it to be checked.
        ///     </remarks>
        /// </summary>
        [MustBeChecked]
        public Boolean CheckedThirdParties { get; set; }

        #endregion
    }
}