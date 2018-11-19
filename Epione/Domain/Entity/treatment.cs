namespace Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.treatment")]
    public partial class treatment
    {
        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int duration { get; set; }

        [StringLength(255)]
        public string result { get; set; }

        public int? parcours_id { get; set; }

        public virtual parcour parcour { get; set; }
    }
}
