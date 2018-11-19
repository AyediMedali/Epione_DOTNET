using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class DemandeViewModel
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string specialite { get; set; }

        public string ville { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
    }
}