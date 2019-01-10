using Epsilon.Infrastructure.Implementations.UI.Models;
using Acme.Feature.Promotion.Models;

namespace Models.ViewModels
{
    public class LandingViewModel : BaseViewModel
    {
        #region Properties

        /*** THE FOLLOWING PROPERTIES ARE FOR THE LOGIN FORM ***/

        public Acme.Feature.Promotion.Models.RegisterModel Register { get; set; }


        /** THE FOLLOWING PROPERTIES ARE FOR THE ENROLL FORM ***/

        public EnrollForm Enroll { get; set; }

        /** THE FOLLOWING PROPERTIES ARE FOR THE OptInOut FORM ***/

//        public OptInOutModel OptInOut { get; set; }

        public string HHEncryptionMultiplier { get; set; }
        public string HHLanguage { get; set; }
        public string Var { get; set; }
        public string StatusType { get; set; }


        #endregion
    }
}