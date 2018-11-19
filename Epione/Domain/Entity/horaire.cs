namespace Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.horaires")]
    public partial class horaire
    {
        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool disponible { get; set; }

        public TimeSpan time { get; set; }

        public int journee_id { get; set; }

        public virtual journee journee { get; set; }
    }
}
