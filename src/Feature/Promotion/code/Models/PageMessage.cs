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

using Acme.Foundation.Helper;




namespace Acme.Feature.Promotion.Models
{

    public class PageMessage
    {
        //Methods
        public PageMessage(ID id, String contextualMessage)
        {
            Assert.IsNotNull(id, "id");
            var item = Sitecore.Context.Database.GetItem(id);
            if (item == null)
            {
                Message =  ErrorMessages.MessageNoContent + id.ToString();
                return;
            } 
            Key = Key ?? item[FieldId.Key];
            Message = Message ?? item[FieldId.Message];
            if (Message == null) Message = ErrorMessages.MessageMissing;
            if (Message.Length == 0) Message = ErrorMessages.MessageMissing;
            Message += contextualMessage;
            DataSource = DataSource ?? item;
        }

        //Properties
        public string Key { get; protected set; }
        public string Message { get; protected set; }
        public Item DataSource { get; protected set; }

        //Nested Types
        public static class FieldId
        {
            public static readonly ID Key = ID.Parse("{C40AA279-0B4C-4422-867C-D73964B1ED21}");
            public static readonly ID Message = ID.Parse("{3430E449-695B-4059-AF41-CA7DDEC443B8}");
        }

        // Defined Alerts
        public static class Messages
        {
            public static readonly ID PromoCodeMissingOrInvalid = ID.Parse("{465B2838-A696-4F3D-BD0F-3CBA061682F4}");
            public static readonly ID ListIsEmpty = ID.Parse("{5CBEBA13-2A2C-455F-996B-B48D0FD994E2}");
            public static readonly ID ProjectSettingsIssue = ID.Parse("{F65E7667-2F38-4043-AC6C-DA254088DC84}");
            public static readonly ID NoVersionInCurrentLanguage = ID.Parse("{21FE905B-B783-46F1-9180-DC8FD3242F3A}");
            public static readonly ID VisitDetailsNotAllowedInPageEditor = ID.Parse("{324E820F-DF93-4E65-9E88-40C1D897FC4C}");
            public static readonly ID DataSourceIsNull = ID.Parse("{E0D24D76-D869-4A45-921D-C51AEDC37A1F}");
        
        }
    }

}