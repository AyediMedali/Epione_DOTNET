namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class horaireViewModel
    {
        public int id { get; set; }

      
        public bool disponible { get; set; }

        public TimeSpan time { get; set; }

        public int journee_id { get; set; }

        public journeeViewModel journee { get; set; }
    }
}
