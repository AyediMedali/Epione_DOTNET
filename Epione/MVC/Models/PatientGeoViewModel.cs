using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PatientGeoViewModel
    {
        public int id { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int phoneNumber { get; set; }

        // public string ville { get; set; }

        // public int codePostal { get; set;  }

        public AdresseViewModel adresse { get; set; }
    }
}