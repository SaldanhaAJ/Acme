using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acme.Feature.Promotion.Helpers
{
    public class QueryPrep
    {

        public static string PrepFieldName(string fieldName)
        {
            if (fieldName.IndexOf("-") > 0)
            {
                fieldName = "#" + fieldName + "#";
            }
            if (fieldName.IndexOf("\"") > 0)
            {
                fieldName= fieldName.Replace("\"", "\\\""); 
            }

            return fieldName;
        } 
    }
}