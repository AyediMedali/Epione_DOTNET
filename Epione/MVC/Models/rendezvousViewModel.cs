using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class rendezvousViewModel
    {
        public int identifiant { get; set; }

        public double date { get; set; }

        [StringLength(255)]
        public string reason { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        //public int patient_id { get; set; }

        // [ForeignKey("patient")]
        public PatientViewModel patient { get; set; }

        //public int motif_id { get; set; }

        // [ForeignKey("motif")]
        public MotifViewModel motif { get; set; }

        // public int medecin_id { get; set; }

        // [ForeignKey("medecin")]
        public doctorViewModel medecin { get; set; }
    }
}