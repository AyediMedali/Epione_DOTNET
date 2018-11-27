using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MessageViewModel
    {
        public int id { get; set; }
        public string content { get; set; }
        public bool seen { get; set; }
        public double date { get; set; }

        public PatientViewModel patient { get; set; }

        public doctorViewModel doctor { get; set; }
    }
}