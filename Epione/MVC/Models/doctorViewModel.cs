namespace MVC.Models
{
  
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class doctorViewModel
    {
  
        public doctorViewModel()
        {
            calendriers = new HashSet<calendrierViewModel>();
          
        }


        public int id { get; set; }

        public DateTime birthDay { get; set; }


        public bool? connected { get; set; }

        public DateTime dateCreation { get; set; }


        public string email { get; set; }


        public string firstName { get; set; }

   
        public bool isEnable { get; set; }

        public DateTime lastConnect { get; set; }

   
        public string lastName { get; set; }


        public string password { get; set; }

        public int phoneNumber { get; set; }


        public string token { get; set; }

        public string codePostal { get; set; }


        public string numAppart { get; set; }


        public string rue { get; set; }


        public string ville { get; set; }

        public DateTime dateOuverture { get; set; }

        public DateTime dateSansRDV { get; set; }


        public string presentation { get; set; }


        public string specialite { get; set; }


        public bool doctolib { get; set; }

        public virtual ICollection<calendrierViewModel> calendriers { get; set; }


    }
}
