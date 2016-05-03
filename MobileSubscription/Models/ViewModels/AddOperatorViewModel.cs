using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileSubscription.Models.ViewModels
{
    public class AddOperatorViewModel
    {
        public List<SelectListItem> Countries { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please select a country")]
        public int CountryId { get; set; }

        [Display(Name = "Operator Name")]
        [Required(ErrorMessage = "Please provide new operator name")]
        public string NewOperatorName { get; set; }
    }
}