using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MessageDELETEViewModel
    {
        public int id;

        public string content { get; set; }
        public bool seen { get; set; }

        public PatientViewModel patient { get; set; }

        public doctorViewModel doctor { get; set; }
    }
}