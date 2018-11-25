using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class rendezvousDELETEViewModel
    {
        public int identifiant { get; set; }

        public string reason { get; set; }

        public string state { get; set; }

        public PatientViewModel patient { get; set; }

        public MotifViewModel motif { get; set; }

        public doctorViewModel medecin { get; set; }
    }
}