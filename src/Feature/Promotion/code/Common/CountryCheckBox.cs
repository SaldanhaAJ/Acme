using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Xml.Linq;
using Epsilon.Infrastructure.Interfaces.Localization.Services;

using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

using Acme.Foundation.Helper;


namespace Acme.Feature.Promotion
{
    public class Country
    {
        public string Id { get; set; }
        public string Visible { get; set; }
        public string DefaultChecked { get; set; }
        public string Text { get; set; }
        public string ValidationNodeName { get; set; }
        public string NodeName { get; set; }

        public bool IsReverseChecked { get; set; }
    }

    public class CountryCheckBox
    {

        private readonly ITranslationService translationService;

        public CountryCheckBox()
        {
        }

        public CountryCheckBox(ITranslationService translationService)
        {
            this.translationService = translationService;
        }
        /// <summary>
        /// load all check boxes based on country
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public IEnumerable<Country> LoadCountryCheckBoxes(string countryCode)
        {
            XElement xElement = XElement.Load(HttpContext.Current.Server.MapPath("~/Config_Data/CountryCheckboxMap.xml"));

            var options = from o in xElement.Elements("country")
                          where (string)o.Attribute("code") == countryCode
                          select o;
            var rVal = (from c in options.Descendants()
                        select new Country
                        {
                            Id = (string)c.Attribute("Id"),
                            Visible = (string)c.Attribute("Visible"),
                            DefaultChecked = (string)c.Attribute("DefaultChecked"),
                            ValidationNodeName = (string)c.Attribute("ValidationNodeName"),
                            NodeName = (string)c.Attribute("NodeName"),
                            Text = GetDictionaryText((string)c.Attribute("NodeName")),
                            IsReverseChecked = c.Attribute("IsReverseChecked") != null && System.Convert.ToBoolean((string)c.Attribute("IsReverseChecked"))

                        });


            return rVal;
        }

        /// <summary>
        /// toggle check box status based on IsReverseChecked property
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="checkBoxId"></param>     
        /// <param name="checkBoxStatus"></param>
        /// <returns></returns>
        public bool GetCheckBoxStatus(string countryCode, string checkBoxId, bool checkBoxStatus)
        {
            var options = LoadCountryCheckBoxes(countryCode);

            if (!options.Any())
            {
                options = LoadCountryCheckBoxes("ALL");
            }

            if (options.Any(o => o.Id.Trim() == checkBoxId && o.IsReverseChecked))
            {
                checkBoxStatus = !checkBoxStatus;
            }
            return checkBoxStatus;

        }

        public string GetTranslation(string nodeName)
        {
            //return GetDictionaryText(nodeName);
            //            return translationService.GetSpecificTranslation(Thread.CurrentThread.CurrentCulture.Name == "en-GB" ? "OptInOutModel.GB" : "OptInOutModel", nodeName);
            return Sitecore.Globalization.Translate.TextByDomain(DictionaryKeys.DictionaryDomain, nodeName);
        }

        protected string GetDictionaryText(string key)
        {
//            return Sitecore.Globalization.Translate.Text(key);
            return Sitecore.Globalization.Translate.TextByDomain(DictionaryKeys.DictionaryDomain, key);
        }       

    }
}