using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;

using Sitecore.Mvc;
using Sitecore.Presentation;
using Sitecore.Layouts;
using Sitecore.Mvc.Controllers;


using Acme.Foundation.Helper;

//using Acme.Feature.Promotion;
using Acme.Feature.Promotion.Helpers;
using Acme.Feature.Promotion.Models;


namespace Acme.Feature.Promotion.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {

            var adminModel = new AdminModel();

            return View(RenderingPath.Admin + "_Process1.cshtml", adminModel);
        }

        [HttpPost]
        public ActionResult Process1(AdminModel adminModel)
        {
            string p1 = adminModel.Path;
            Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
//            Sitecore.Data.Items.Item myItem = master.GetItem("/sitecore/content/HH22016");
                        Sitecore.Data.Items.Item myItem = master.GetItem("/sitecore/content/" + p1);

            //string name = myItem.Fields["Header_HTML"].Value;

            string l = Sitecore.Data.Fields.LayoutField.GetFieldValue(myItem.Fields["__Renderings"]);
            LayoutDefinition layout = LayoutDefinition.Parse(l);

            foreach (DeviceDefinition dev in layout.Devices)
            {
                if (dev != null)
                {
                    var renderings = dev.Renderings;

                    if (renderings != null)
                    {
                        foreach (RenderingDefinition rend in renderings)
                        {
                            Dictionary<string, string> FieldsWithInSection = new Dictionary<string, string>();

                            
                            Response.Write("<b>Placeholder: </b><br/>" + rend.Placeholder.ToString());
                            Response.Write("</br>");
                         //   Response.Write(rend.ItemID);
                         //   Response.Write("</br>");


                            Response.Write("<b>Datasource: </b>" );
                            Response.Write("</br>");

                         //   Response.Write(rend.Datasource.ToString());
                         //   Response.Write("</br>");

                            Sitecore.Data.Items.Item item = master.GetItem(Sitecore.Data.ID.Parse(rend.Datasource));
                            if (item != null)
                            {
                                //Response.Write(item.Name.ToString());
                                Response.Write("/sitecore/content" + item.Paths.ContentPath.ToString());

                                Response.Write("</br>");

                                FieldsWithInSection = item.Fields.ToDictionary(field => field.Name, field => field.Value);
                                if (FieldsWithInSection.Count > 0)
                                {
                                    foreach (KeyValuePair<string, string> keyValue in FieldsWithInSection)
                                    {/*
                                        Response.Write(keyValue.Key);
                                        Response.Write(keyValue.Value);
                                        Response.Write("</br>");
                                    */
                                    }
                                    //int i = 0;
                                    //for (i = 0; i < FieldsWithInSection.Count; i++)
                                    //{

                                    //}
                                }

                            }

                            Response.Write("<b>Rendering: </b>");
                            Response.Write("</br>");

                            item = master.GetItem(Sitecore.Data.ID.Parse(rend.ItemID));
                            if (item != null)
                            {
                                Response.Write(item.Name.ToString());
                                Response.Write("</br>");

                                FieldsWithInSection = item.Fields.ToDictionary(field => field.Name, field => field.Value);
                                if (FieldsWithInSection.Count > 0)
                                {
                                    string s1;
                                    foreach (KeyValuePair<string, string> keyValue in FieldsWithInSection)
                                    {
                                        s1= keyValue.Key.ToString();
                                        if (s1.IndexOf("__") < 0)
                                        {
                                            Response.Write(keyValue.Key + " :");
                                            Response.Write(keyValue.Value);
                                            Response.Write("</br>");

                                        }

                                    }
                                    //int i = 0;
                                    //for (i = 0; i < FieldsWithInSection.Count; i++)
                                    //{

                                    //}
                                }
                            }

                            Response.Write("</br>");
                            Response.Write("</br>");
                        }
                    }
                }
            }



            //return View();
            return View(RenderingPath.Admin + "_Process1.cshtml");

        }



        [HttpPost]
        public ActionResult Process1Prev()

        {

            Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
            //Sitecore.Data.Items.Item myItem = master.GetItem("/sitecore/content/PromoSite1/lp1");

            //string name = myItem.Fields["Header_HTML"].Value;

            //string l = Sitecore.Data.Fields.LayoutField.GetFieldValue(myItem.Fields["__Renderings"]);
            //LayoutDefinition layout = LayoutDefinition.Parse(l);

            //foreach (DeviceDefinition dev in layout.Devices)
            //{
            //    if (dev != null)
            //    {
            //        var renderings = dev.Renderings;
            //        if (renderings != null)
            //        {
            //            foreach (RenderingDefinition rend in renderings)
            //            {
            //                Dictionary<string, string> FieldsWithInSection = new Dictionary<string, string>();

            //                Response.Write(rend.Placeholder.ToString());
            //                Response.Write(rend.ItemID);
            //                Sitecore.Data.Items.Item item = master.GetItem(Sitecore.Data.ID.Parse(rend.ItemID));
            //                if (item != null)
            //                {
            //                    FieldsWithInSection = item.Fields.ToDictionary(field => field.Name, field => field.Value);

            //                }

            //                Response.Write("</br>");
            //            }
            //        }
            //    }
            //}

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                CreateTemplate("/sitecore/templates/Hilton/Reference Data Templates", "PartnerTypes1");

                //AddFieldToTemplate("New Single Line Field", "/sitecore/templates/Sample/Sample Item");
                //AddFieldToTemplate("New Single Line Field", "/sitecore/templates/Hilton/ReferenceData/PartnerTypes");
                //AddFieldToTemplate("code", Common.Constants.FieldTypeSingleLineText,
                //    "Partner Type Code", Common.Constants.TemplateSectionData, 
                //    "/sitecore/templates/Hilton/ReferenceData/PartnerTypes");
                AddFieldToTemplate("description", TemplateFieldTypes.FieldTypeSingleLineText,
                    "Partner Type Description", TemplateFieldTypes.TemplateSectionData,
                    "/sitecore/templates/Hilton/Reference Data Templates/PartnerTypes1");

                
                //CreateContentItem("new data", "/sitecore/Content/GlobalContent", "/sitecore/templates/Hilton/ReferenceData/PartnerTypes");
            }


            return View();
        }


        private void CreateContentItem(string contentItemName, string contentPath, string templatePath)
        {


            var master = Sitecore.Configuration.Factory.GetDatabase("master");
            Sitecore.Data.Items.Item templateItem = master.GetItem(templatePath);

            if (templateItem != null)
            {

                var templateID = templateItem.ID;


                var rootItem = master.GetItem(contentPath);
                if (rootItem != null)
                {

                    if (rootItem != null)
                    {
                        //Create new item
                        var item = rootItem.Add(contentItemName, new TemplateID(new ID(templateID.ToString())));

                        if (item != null)
                        {
                            item.Fields.ReadAll();
                            item.Editing.BeginEdit();

                            try
                            {
                                //Add values for the fields
                                item.Fields["New Single Line Field"].Value = "test data";
                            }
                            catch (Exception)
                            {
                                item.Editing.EndEdit();
                            }
                        }
                    }

                }

            }

        }

        private void AddFieldToTemplate(string fieldName, string fieldType, string fieldTitle, string templateSec, string tempatePath)
        {
            const string templateOftemplateFieldId = "{455A3E98-A627-4B40-8035-E683A0331AC7}";

            // this will do on your "master" database, consider Sitecore.Context.Database if you need "web"
            var templateItem = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(tempatePath);
            if (templateItem != null)
            {
//                var templateSection = templateItem.Children.FirstOrDefault(i => i.Template.Name == templateSec);
                var templateSection = templateItem.Children.FirstOrDefault(i => i.Template.Name == "Template Section");
                if (templateSection != null)
                {
                    var newField = templateSection.Add(fieldName, new TemplateID(new ID(templateOftemplateFieldId)));
                    using (new EditContext(newField))
                    {
                        newField["Type"] = fieldType;
                        newField["Title"] = fieldTitle;
                    }
                }
                {
                    // ID value is the value for sitecore/templates/system/templates/template section{E269FBB5-3750-427A-9149-7AA950B49301}
//                    var templateSection1 = templateItem.Add(templateSec, new TemplateID(new ID("{E269FBB5-3750-427A-9149-7AA950B49301}")));
                    var templateSection1 = templateItem.Add("Template Section", new TemplateID(new ID("{E269FBB5-3750-427A-9149-7AA950B49301}")));

                    
                    // there are no template sections here, you may need to create one. template has only inherited fields if any
                    if (templateSection1 != null)
                    {
                        var newField = templateSection1.Add(fieldName, new TemplateID(new ID(templateOftemplateFieldId)));
                        using (new EditContext(newField))
                        {
                            newField["Type"] = fieldType; 
                            newField["Title"] = fieldTitle; 
                        }
                    }

                }
            }
        }

        private void CreateTemplate(string tempatePath, string template)
        {

            // this will do on your "master" database, consider Sitecore.Context.Database if you need "web"
            var master = Sitecore.Configuration.Factory.GetDatabase("master");
            var templateItem = master.GetItem(tempatePath + "/" + template);
            if (templateItem == null)
            {
                //Get the parent Item of the template (folder)
                Sitecore.Data.Items.Item parentItem  = master.Items.GetItem(tempatePath);

                //Create the template under the given parent Item
                //var temp1 = tempatePath + "/" + template;
                var temp1 = template;
                templateItem = master.Templates.CreateTemplate(temp1, parentItem);
            }
        }


    }
}
