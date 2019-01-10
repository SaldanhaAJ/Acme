using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Acme.Foundation.Helper
{
    public sealed class Templates
    {
        public string name { get; set; }
        public Guid value { get; set; }

        public Templates(Guid value, string name)
        {
            this.name = name;
            this.value = value;
        }

        public static readonly Templates InstanceBranchMediaTemplate = new Templates(new Guid("{91F0960C-E721-4F5E-9AC5-98477772BD7B}"), "InstanceBranchMediaTemplate");
        public static readonly Templates InstanceBranchContentTemplate = new Templates(new Guid("{AEB930C0-F554-4776-88A8-2E2462A6D1E6}"), "InstanceBranchContentTemplate");

        public static readonly Templates MarriottMediaFolderItemID = new Templates(new Guid("{AE8149D3-4E35-4C73-8FC7-A1F8ABE6DA2D}"), "MarriottMediaFolder");
        public static readonly Templates MediaFolderTemplateID = new Templates(new Guid("{985A3C8F-9103-46E8-9455-7E5AE58C7C71}"), "Media Folder");
        public static readonly Templates ContactListTemplateID = new Templates(new Guid("{3F557952-B2BB-45EB-B625-E29698B2A165}"), "ContactList");
        public static readonly Templates ContactListsFolder = new Templates(new Guid("{3C94F086-453B-48FC-9F1B-2B00BC0A55C7}"), "ContactListFolder");
        public static readonly Templates LCBInstance = new Templates(new Guid("{72A8DA29-9E74-4C87-A91A-9ABFFCF4CF00}"), "LCBInstance");
        public static readonly Templates LCBPropertyBranchTemplate = new Templates(new Guid("{9E53719A-EFF7-4E2E-B324-BADA77638545}"), "LCBPropertyBranchTemplate");
        public static readonly Templates RegionPropertiesFolder = new Templates(new Guid("{8C69E41F-4B4A-4C9B-8043-D27780A6AC50}"), "RegionPropertiesFolder");
        public static readonly Templates RegionContentTemplate = new Templates(new Guid("{2F5642C5-CEFA-4A22-8069-551A533912C1}"), "RegionContentTemplate");
        public static readonly Templates RegionMediaTemplate = new Templates(new Guid("{FE5DD826-48C6-436D-B87A-7C4210C7413B}"), "RegionMediaTemplate");
        public static readonly Templates PropertyMediaTemplate = new Templates(new Guid("{985A3C8F-9103-46E8-9455-7E5AE58C7C71}"), "PropertyMediaTemplate");
        public static readonly Templates PropertyTemplateID = new Templates(new Guid("{CFA485AD-A8F8-4CF1-BC9D-992DA4A32A41}"), "PropertyTemplate");
        public static readonly Templates MainSection = new Templates(new Guid("{E3E2D58C-DF95-4230-ADC9-279924CECE84}"), "MainSection"); //Sitecore Content Item Template id
        public override string ToString()
        {
            return value.ToString("B").ToUpper();
        }

        public Guid ToGuid()
        {
            return value;
        }
        public ID ToID()
        {
            return ID.Parse(value);
        }
    }
}