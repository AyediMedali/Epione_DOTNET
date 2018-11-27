using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class AdresseViewModel
    {
        public int id { get; set; }
        public string ville { get; set; }
        public string rue { get; set; }
        public int codePostal { get; set; }
    }
}