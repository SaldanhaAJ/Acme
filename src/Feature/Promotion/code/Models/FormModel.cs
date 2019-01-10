using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Epsilon.Infrastructure.Implementations.UI.DataAnnotationAttributes;


namespace Acme.Feature.Promotion.Models
{
    public class FormModel
    {
        [Required]
        public string Name { get; set; }
    }
}