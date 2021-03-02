using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MvcProject_Moin.ViewModels
{
    public class StuffVM
    {
        public int StuffID { get; set; }

        [Required]
        [Display(Name = "Stuff Name")]
        public string StuffName { get; set; }

        [Required]
        [Display(Name = "Cell Phone No.")]
        public string CellPhone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Contact Address")]
        public string ContactAddress { get; set; }
    }
}