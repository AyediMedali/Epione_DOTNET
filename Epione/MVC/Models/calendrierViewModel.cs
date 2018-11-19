namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class calendrierViewModel
    {
 
        public calendrierViewModel()
        {
            journees = new HashSet<journeeViewModel>();
        }

        public int id { get; set; }

        public int? doctor_id { get; set; }

        public virtual doctorViewModel doctor { get; set; }

        
        public virtual ICollection<journeeViewModel> journees { get; set; }
    }
}
